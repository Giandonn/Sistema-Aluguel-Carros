using Microsoft.EntityFrameworkCore;
using Prova.Models;

namespace Prova.Repositories.Data {
	public class RentDbContext : DbContext {
		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
			optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=RentsDB;ConnectRetryCount=0");
		}

		public RentDbContext(DbContextOptions<RentDbContext> options) : base(options) {
		}

		public DbSet<Rent> Rents { get; set; }
		public DbSet<Car> Cars { get; set; }
		public DbSet<Client> Clients { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder) {
			modelBuilder.Entity<Rent>()
				.HasOne(r => r.Cliente)
				.WithMany() 
				.HasForeignKey("ClienteId"); 

			modelBuilder.Entity<Rent>()
				.HasOne(r => r.Carro)
				.WithMany()
				.HasForeignKey("CarroId"); 
		}

	}
}