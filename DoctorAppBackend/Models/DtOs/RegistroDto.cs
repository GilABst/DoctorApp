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
        public string Password { get; set; }
    }
}
