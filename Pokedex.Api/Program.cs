using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Net.Http.Headers;
using Pokedex.Library.Data;
using Pokedex.Library.Data.Pokedex;
using Pokedex.Library.Data.PokeUser;
using System.Text;

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
builder.Services.AddTransient<IPokeUserRepository, PokeUserRepository>();
builder.Services.AddMediatR(typeof(PokedexResponsitory).Assembly);
builder.Services.AddAutoMapper(typeof(Program).Assembly);
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
  .AddJwtBearer(_ => 
  {
    _.TokenValidationParameters = new TokenValidationParameters
    {
      ValidateIssuerSigningKey = true,
      IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration.GetSection("JwtOption:SecretKey").Value!)),
      ValidateIssuer = false,
      ValidateAudience = false,
    };
  });

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

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
