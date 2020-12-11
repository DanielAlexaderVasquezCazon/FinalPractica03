using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PracticaFinal4.Models
{
    public class Horario
    {
        [Key]
        public int Hora { get; set; }
        public string  Materia { get; set; }   
    }
    public class Documento
    {
        [Key]
        [Required]
        public string Nombre { get; set; }
        [Required]
        public int Edad { get; set; }
        [Required]
        public string Apellido { get; set; }
        [Required]
        public List<Horario> horarios { get; set; }

    }
}