using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.DtOs
{

    public class RegistroDto
    {
        [Required(ErrorMessage = "El username es requerido")]
        public string Username { get; set; }

        [Required(ErrorMessage = "El password es requerido")]
        [StringLength(10,MinimumLength = 4, ErrorMessage = "El password debe tener un minimo de 4 caracteres y un maximo de 10")]
        public string Password { get; set; }
    }
}
