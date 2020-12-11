

namespace PracticaFinal7.Models
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