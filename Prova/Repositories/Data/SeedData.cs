using Microsoft.EntityFrameworkCore;
using Prova.Models;
using Prova.Repositories.Data;
using System.Linq;

namespace Prova.Repositories.Data {
	public class SeedData {
		public static void Initialize(IServiceProvider serviceProvider) {
			using (var context = new RentDbContext(
				serviceProvider.GetRequiredService<DbContextOptions<RentDbContext>>())) {

				if (!context.Cars.Any()) {
					context.Cars.AddRange(
						new Car(id: "1", modelo: "Toyota Corolla", categoria: "CategoriaTesteCorolla"),
						new Car(id: "2", modelo: "Honda Civic", categoria: "CategoriaTesteCivic"),
						new Car(id: "3", modelo: "Chevrolet Onix", categoria: "CategoriaTesteOnix")
					);
				}

				if (!context.Clients.Any()) {
					context.Clients.AddRange(
						new Client(id: "1", name: "Cliente Teste", email: "email.teste@example.com", ativo: true),
						new Client(id: "2", name: "Lucas", email: "lucas.teste@example.com", ativo: true),
						new Client(id: "3", name: "Lucas 2", email: "lucas2.teste@example.com", ativo: false)
					);
				}

				context.SaveChanges();
			}
		}
	}
}
