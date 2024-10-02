using System;
using Prova.Models;

	namespace Prova.Models {
			public class Rent {
			public string Id { get; set; } = string.Empty;
			public Client? Cliente { get; set; } 
			public Car? Carro { get; set; } 
			public DateTime DataHora { get; set; } = DateTime.Now;

		public Rent() { }

			public Rent(Client cliente, Car carro, DateTime dataHora) {
					Cliente = cliente;
					Carro = carro;
					DataHora = dataHora;
					Id = Guid.NewGuid().ToString();
			}
		}
	}