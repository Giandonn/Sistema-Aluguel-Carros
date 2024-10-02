using System;

namespace Prova.Services {
	public class EmailService {
		public void SendEmail(string? email, string subject, string body) {
			Console.WriteLine($"Enviando e-mail para {email}: {subject} - {body}");
		}
	}
}
