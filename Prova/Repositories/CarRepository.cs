using Prova.Models;
using Prova.Repositories.Data;
using System.Collections.Generic;
using System.Linq;

namespace Prova.Repositories {
	public class CarRepository {
		private readonly RentDbContext _context;

		public CarRepository(RentDbContext context) {
			_context = context;
		}

		public Car GetById(string id) {
			return _context.Cars.FirstOrDefault(c => c.Id == id);
		}

		public void Add(Car car) {
			_context.Cars.Add(car);
			_context.SaveChanges();
		}

		public IEnumerable<Car> GetAll() {
			return _context.Cars.ToList();
		}
	}
}
