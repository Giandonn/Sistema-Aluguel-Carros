using System;

namespace Prova.Models 
{
	public class Car {
		public string Id { get; set; } = string.Empty;
		public string Modelo { get; set; } = string.Empty;
		public string? Categoria { get; set; }

		public Car() { }

		public Car(string id, string modelo, string? categoria) {
			Id = id;
			Modelo = modelo;
			Categoria = categoria;
		}

		public Car(string modelo, string? categoria) {
			Modelo = modelo;
			Categoria = categoria;
		}
	}
}
