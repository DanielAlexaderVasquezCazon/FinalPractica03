namespace admPracticaFinal7.Models
{
    using System.Data.Entity;
    public class DataContext : DbContext
    {
        public DataContext() : base("DefaultConnection")
        {

        }

        public System.Data.Entity.DbSet<admPracticaFinal7.Models.Cedula> Cedulas { get; set; }
    }
}