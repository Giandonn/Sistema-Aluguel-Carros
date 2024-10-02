using Prova.Models;
using Prova.Repositories;
using System;
using System.Collections.Generic;

namespace Prova.Services {
	public class RentService {
		private readonly RentRepository _rentRepository;
		private readonly ClientRepository _clientRepository;
		private readonly CarRepository _carRepository;
		private readonly EmailService _emailService;

		public RentService(RentRepository rentRepository, ClientRepository clientRepository, CarRepository carRepository, EmailService emailService) {
			_rentRepository = rentRepository;
			_clientRepository = clientRepository;
			_carRepository = carRepository;
			_emailService = emailService;
		}

		public Rent CreateRent(string carId, string clientId, DateTime rentalDate) {
			var client = _clientRepository.GetById(clientId);
			var car = _carRepository.GetById(carId);

			//tentar diminuir qtde de ifs aqui
			if (client == null || !client.Ativo.GetValueOrDefault()) {
				throw new InvalidOperationException("Cliente não encontrado ou inativo.");
			}

			if (car == null) {
				throw new InvalidOperationException("Carro não encontrado.");
			}

			if (IsCarRented(car, rentalDate)) {
				throw new InvalidOperationException("Carro não disponível.");
			}

			var rent = new Rent(client, car, rentalDate);
			_rentRepository.Add(rent);

			return rent;
		}

		//verifica disponibilidade do carro
		private bool IsCarRented(Car car, DateTime date) {
			var rentsForCar = _rentRepository.GetRentsForCar(car.Id);
			Console.WriteLine($"Verificando aluguéis para o carro {car.Id} na data {date.ToShortDateString()}");
			foreach (var rent in rentsForCar) {
				Console.WriteLine($"Aluguel: {rent.DataHora.ToShortDateString()}");
			}
			return rentsForCar.Any(r => r.DataHora.Date == date.Date);
		}

	}
}
