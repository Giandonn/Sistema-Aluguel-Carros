using Microsoft.EntityFrameworkCore;
using Prova.Repositories.Data;
using Prova.Repositories;
using Prova.Services;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<RentDbContext>(options =>
	options.UseSqlServer(connectionString));

//dependencias aqui
builder.Services.AddScoped<ClientRepository>();
builder.Services.AddScoped<CarRepository>();
builder.Services.AddScoped<RentRepository>();
builder.Services.AddScoped<RentService>();
builder.Services.AddScoped<EmailService>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

//verificar essa parte
using (var scope = app.Services.CreateScope()) {
	var services = scope.ServiceProvider;

	try {
		SeedData.Initialize(services);
	}
	catch (Exception ex) {
		var throwErro = services.GetRequiredService<ILogger<Program>>();
		throwErro.LogError(ex, "Erro.");
	}
}

app.UseSwagger();
app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Prova API v1"));

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();