using Prova.Models;
using System.Linq;
using Prova.Repositories.Data; 

namespace Prova.Repositories {
	public class ClientRepository {
		private readonly RentDbContext _context;

		public ClientRepository(RentDbContext context) {
			_context = context;
		}

		public Client GetById(string id) {
			return _context.Clients.FirstOrDefault(c => c.Id == id);
		}

		public void Add(Client client) {
			_context.Clients.Add(client);
			_context.SaveChanges();
		}
	}
}
