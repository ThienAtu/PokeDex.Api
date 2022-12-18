using Pokedex.Library.Data.Pokedex;
using Microsoft.EntityFrameworkCore.Design;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Pokedex.Library.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<PokedexDbContext>(_ =>
{
	_.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});
builder.Services.AddTransient<IPokedexResponsitory, PokedexResponsitory>();
builder.Services.AddMediatR(typeof(PokedexResponsitory).Assembly);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
