using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace admPracticaFinal7.Models
{
    using System.ComponentModel.DataAnnotations;
    public class Cedula
    {
        [Key]
        [Required]
        public string nombre { get; set; }
        [Required]
        public string apellido { get; set; }

    }
}