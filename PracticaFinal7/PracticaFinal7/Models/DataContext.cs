

namespace PracticaFinal7.Models
{
    using System.Data.Entity;
    public class DataContext:DbContext
    {
        public DataContext():base("DefaultConnection")
        {

        }

        public System.Data.Entity.DbSet<PracticaFinal7.Models.Cedula> Cedulas { get; set; }
    }
}