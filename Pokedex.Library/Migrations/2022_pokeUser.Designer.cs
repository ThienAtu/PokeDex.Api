﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Pokedex.Library.Data;

#nullable disable

namespace Pokedex.Library.Migrations;

[DbContext(typeof(PokedexDbContext))]
[Migration("pokeUser")]
partial class UserMigrate
{
  /// <inheritdoc />
  protected override void BuildTargetModel(ModelBuilder modelBuilder)
  {
#pragma warning disable 612, 618
    modelBuilder
      .HasAnnotation("ProductVersion", "7.0.1")
      .HasAnnotation("Relational:MaxIdentifierLength", 128);

    SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);
#pragma warning restore 612, 618
  }
}
