using Microsoft.AspNetCore.Mvc;
using Prova.Models;
using Prova.DTOs;
using Prova.Services;
using System;

namespace Prova.Controllers {
	[ApiController]
	[Route("api/[controller]")]
	public class RentController : ControllerBase {
		private readonly RentService _rentService;
		private readonly EmailService _emailService;

		public RentController(RentService rentService, EmailService emailService) {
			_rentService = rentService;
			_emailService = emailService;
		}

		[HttpPost("carros/{idCarro}/alugueis")]
		public ActionResult<Rent> CreateRent(string idCarro, [FromBody] RentDTO request) {
			if (request == null) {
				return BadRequest("Dados de aluguel não fornecidos.");
			}

			if (request.DataHora.Date != DateTime.Now.Date) {
				return BadRequest("O aluguel só pode ser feito para a data atual.");
			}

			try {
				var rent = _rentService.CreateRent(idCarro, request.ClientId, request.DataHora);

				_emailService.SendEmail(rent.Cliente.Email, "Reserva confirmada",
					$"Seu aluguel foi realizado para o carro {rent.Carro.Modelo} na data {rent.DataHora.ToShortDateString()}.");

				return Created($"api/carros/{idCarro}/alugueis/{rent.Id}", rent);
			}
			catch (InvalidOperationException ex) {
				_emailService.SendEmail(request.ClientId, "Falha na reserva", ex.Message);
				return NotFound(ex.Message);
			}
			catch (Exception ex) {
				return StatusCode(500, "Erro: " + ex.Message);
			}
		}
	}
}
