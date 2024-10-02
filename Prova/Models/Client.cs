using System;

namespace Prova.Models 
{
	public class Client {
		public string Id { get; set; } = string.Empty;
		public string Name { get; set; } = string.Empty;
		public string? Email { get; set; }
		public bool? Ativo { get; set; }

		public Client() { }

		public Client(string id, string name, string? email, bool? ativo) {
			Id = id;
			Name = name;
			Email = email;
			Ativo = ativo;
		}

		public Client(string name, string? email, bool? ativo) {
			Name = name;
			Email = email;
			Ativo = ativo;
		}
	}
}