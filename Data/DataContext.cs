using Microsoft.EntityFrameworkCore;
using TotalControlAPI.Models;

namespace TotalControlAPI.Data
{
    public class DataContext : DbContext
    {
        static readonly string connectionString = "Server=localhost; User ID=root; Password=Pokas@131293; Database=TotalControl;";

        public DataContext(DbContextOptions<DataContext> options) : base(options){}

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
        }
        public DbSet<Pessoas> Pessoas => Set<Pessoas>();
        public DbSet<Endereco> Endereco => Set<Endereco>();
        public DbSet<ControleMensal> ControleMensal => Set<ControleMensal>();
        public DbSet<Categorias> Categorias => Set<Categorias>();
       
    }
}
