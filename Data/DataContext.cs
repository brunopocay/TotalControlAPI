using Microsoft.EntityFrameworkCore;
using TotalControlAPI.Models;

namespace TotalControlAPI.Data
{
    public class DataContext : DbContext
    {
        static readonly string connectionString = "Server=localhost; User ID=root; Password=Pokas@201160137; Database=totalcontrol;";

        public DataContext(DbContextOptions<DataContext> options) : base(options){}

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
        }
        public DbSet<Users> Users => Set<Users>();
        public DbSet<Endereco> Endereco => Set<Endereco>();
        public DbSet<ControleMensal> ControleMensal => Set<ControleMensal>();
        public DbSet<Categorias> Categorias => Set<Categorias>();
        public DbSet<RefreshToken> RefreshToken => Set<RefreshToken>();
        public DbSet<MesControle> MesControle => Set<MesControle>();
       
    }
}
