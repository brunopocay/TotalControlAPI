using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using TotalControlAPI.Models;

namespace TotalControlAPI.Data
{
    public class DataContext : DbContext
    {
        static readonly string connectionString = "Server=localhost; User ID=root; Password=Pokas@201160137; Database=totalcontrol;";

        public DataContext(DbContextOptions<DataContext> options) : base(options) 
        {
                    
        }
      
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
        }

		public DbSet<Users> Users => Set<Users>();
        public DbSet<Endereco> Endereco => Set<Endereco>();
        public DbSet<RegistroFinanceiroMensal> RegistroFinanceiroMensal => Set<RegistroFinanceiroMensal>();
        public DbSet<Categorias> Categorias => Set<Categorias>();
        public DbSet<RefreshToken> RefreshToken => Set<RefreshToken>();
        public DbSet<MesReferencia> MesReferencia => Set<MesReferencia>();

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
            modelBuilder.Entity<Users>().HasOne(endereco => endereco.Endereco).WithOne(user => user.Users).HasForeignKey<Endereco>(end => end.UserId);
		}

	}
}
