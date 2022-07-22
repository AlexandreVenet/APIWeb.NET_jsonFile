// Code par défaut

/*var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}

app.UseHttpsRedirection();

var summaries = new[]
{
	"Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
};

app.MapGet("/weatherforecast", () =>
{
	var forecast = Enumerable.Range(1, 5).Select(index =>
		new WeatherForecast
		(
			DateTime.Now.AddDays(index),
			Random.Shared.Next(-20, 55),
			summaries[Random.Shared.Next(summaries.Length)]
		))
		.ToArray();
	return forecast;
})
.WithName("GetWeatherForecast");

app.Run();

internal record WeatherForecast(DateTime Date, int TemperatureC, string? Summary)
{
	public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}*/



// App de test minimale

/*
// Dans le fichier Properties/launchSettings.json, les deux lignes ""launchUrl": "swagger" peuvent être supprimées.

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

// Des routes Get 
app.MapGet("/", () => "Hello World!");
app.MapGet("/test", () => "Page de test");
app.MapGet("/test/{id}", (int id) => "Page de test avec la valeur : " + id);

// Lancement
app.Run();
*/



// App de test (minimale, pizza...)

using Microsoft.OpenApi.Models;
using APIWebNET_jsonFile.ClassesControllers;
using APIWebNET_jsonFile.ClassesData;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
	// Ajouter de la documentation Swagger (titre, infos, version...)
	c.SwaggerDoc("v1", new OpenApiInfo 
	{ 
		Title = "Test Swagger perso", 
		Description = "Faire des requêtes...", 
		Version = "version 999" 
	});
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
	app.UseDeveloperExceptionPage();
	app.UseSwagger();
	app.UseSwaggerUI(c =>
	{
		c.SwaggerEndpoint("/swagger/v1/swagger.json", "Une API perso");
	});
}

// Des routes

app.MapGet("/", () => "Hello World!");
app.MapGet("/test", () => "Page de test");
app.MapGet("/test/{id}", (int id) => "Page de test avec la valeur : " + id);

app.MapGet("/pizzas", () => PizzaController.GetPizzas());
app.MapGet("/pizzas/{id}", (int id) => PizzaController.GetPizza(id));
app.MapPost("/pizzas", (Pizza pizza) => PizzaController.CreatePizza(pizza));
app.MapPut("/pizzas", (Pizza pizza) => PizzaController.UpdatePizza(pizza));
app.MapDelete("/pizzas/{id}", (int id) => PizzaController.RemovePizza(id));

app.MapGet("/temps", () => TempsController.GetAll());
app.MapGet("/temps/{entier}", (int entier) => TempsController.GetOne(entier));
app.MapPost("/temps", (Temps temps) => TempsController.PostOne(temps));
app.MapPut("/temps",(Temps temps) => TempsController.PutOne(temps));
app.MapDelete("/temps/{entier}",(int entier)=> TempsController.DeleteOne(entier));

app.Run();