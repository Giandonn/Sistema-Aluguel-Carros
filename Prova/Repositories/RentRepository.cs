using Prova.Models;
using Prova.Repositories.Data;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

public class RentRepository {
	private readonly RentDbContext _context;

	public RentRepository(RentDbContext context) {
		_context = context;
	}

	public void Add(Rent rent) {
		_context.Rents.Add(rent);
		_context.SaveChanges();
	}

	public IEnumerable<Rent> GetRentsForCar(string carId) {
		return _context.Rents.Where(r => r.Carro.Id == carId).ToList();
	}

}