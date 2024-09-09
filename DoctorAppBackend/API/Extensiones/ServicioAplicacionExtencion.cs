using Data.Interfaces;
using Data.Servicios;
using Data;
using Microsoft.OpenApi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using API.Errores;

namespace API.Extensiones
{
    public static class ServicioAplicacionExtencion
    {
        public static IServiceCollection AgregarServicioAplicacion(this IServiceCollection service, IConfiguration config)
        {
            service.AddSwaggerGen(options =>
            {
                options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Description = "Ingresar Bearer [espacio] token \r\n\r\n" + "Ejemplo: Bearer xxxxxxxxxxxxxxxxxx",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Scheme = "Bearer"
                });
                options.AddSecurityRequirement(new OpenApiSecurityRequirement{
                {
                    new OpenApiSecurityScheme
                    {
                        Reference = new OpenApiReference
                        {
                            Type = ReferenceType.SecurityScheme,
                            Id = "Bearer"
                        },
                        Scheme = "oauth2",
                        Name = "Bearer",
                        In = ParameterLocation.Header
                    },
                    new List<String>()
                }});
            });

            var connectionString = config.GetConnectionString("DefaultConection");
            service.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(connectionString));
            service.AddCors();

            service.AddScoped<ITokenServicio, TokenServicio>();

            service.Configure<ApiBehaviorOptions>(options => 
            {
                options.InvalidModelStateResponseFactory = actionContext => 
                { 
                    var errores = actionContext.ModelState
                                    .Where(e => e.Value.Errors.Count() > 0 )
                                    .SelectMany(x => x.Value.Errors)
                                    .Select(x => x.ErrorMessage).ToArray();
                    var errorResponse = new ApiValidacionErrorResponse
                    {
                        Errores = errores
                    };
                    return new BadRequestObjectResult(errorResponse);
                };
            });  

            return service;
        }

    }
}
