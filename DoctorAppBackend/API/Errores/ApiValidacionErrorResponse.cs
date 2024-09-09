namespace API.Errores
{
    public class ApiValidacionErrorResponse : ApiErrorResponse
    {
        public ApiValidacionErrorResponse() : base(400)
        {
            
        }

        public IEnumerable<String> Errores { get; set; }
    }
}
