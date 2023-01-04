using Pokedex.Library.Data.Pokedex;
using Microsoft.EntityFrameworkCore.Design;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Pokedex.Library.Data;
using Microsoft.Net.Http.Headers;

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
builder.Services.AddAutoMapper(typeof(Program).Assembly);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}

app.UseCors(_ =>
	_.WithOrigins("https://localhost:7000", "http://localhost:7001")
	.AllowAnyMethod()
	.WithHeaders(HeaderNames.ContentType));

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
