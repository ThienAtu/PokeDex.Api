﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Pokedex.Library.Data.Pokedex;

#nullable disable

namespace Pokedex.Library.Migrations
{
    [DbContext(typeof(PokedexDbContext))]
    [Migration("20221218122142_pokedex.009")]
    partial class pokedex009
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Pokedex.Library.Model.PokedexModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(3)
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<decimal>("Height")
                        .HasColumnType("decimal(18,1)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("NameJapanese")
                        .IsRequired()
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("NameRomanji")
                        .IsRequired()
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("Number")
                        .IsRequired()
                        .HasColumnType("nvarchar(3)");

                    b.Property<string>("Type1")
                        .IsRequired()
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("Type2")
                        .IsRequired()
                        .HasColumnType("nvarchar(200)");

                    b.Property<decimal>("Weight")
                        .HasColumnType("decimal(18,1)");

                    b.HasKey("Id");

                    b.ToTable("PokedexModels");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Height = 0.7m,
                            Name = "Bulbasaur",
                            NameJapanese = "フシギダネ",
                            NameRomanji = "Fushigidane",
                            Number = "001",
                            Type1 = "Grass",
                            Type2 = "Poison",
                            Weight = 6.9m
                        },
                        new
                        {
                            Id = 2,
                            Height = 1.0m,
                            Name = "Ivysaur",
                            NameJapanese = "フシギソウ",
                            NameRomanji = "Fushigisou",
                            Number = "002",
                            Type1 = "Grass",
                            Type2 = "Poison",
                            Weight = 13.0m
                        },
                        new
                        {
                            Id = 3,
                            Height = 2.0m,
                            Name = "Venusaur",
                            NameJapanese = "フシギバナ",
                            NameRomanji = "Fushigibana",
                            Number = "003",
                            Type1 = "Grass",
                            Type2 = "Poison",
                            Weight = 100.0m
                        },
                        new
                        {
                            Id = 4,
                            Height = 0.6m,
                            Name = "Charmander",
                            NameJapanese = "ヒトカゲ",
                            NameRomanji = "Hitokage",
                            Number = "004",
                            Type1 = "Fire",
                            Type2 = "",
                            Weight = 8.5m
                        },
                        new
                        {
                            Id = 5,
                            Height = 1.1m,
                            Name = "Charmeleon",
                            NameJapanese = "リザード",
                            NameRomanji = "Lizardo",
                            Number = "005",
                            Type1 = "Fire",
                            Type2 = "",
                            Weight = 19.0m
                        },
                        new
                        {
                            Id = 6,
                            Height = 1.7m,
                            Name = "Charizard",
                            NameJapanese = "リザードン",
                            NameRomanji = "Lizardon",
                            Number = "006",
                            Type1 = "Fire",
                            Type2 = "Flying",
                            Weight = 90.5m
                        },
                        new
                        {
                            Id = 7,
                            Height = 0.5m,
                            Name = "Squirtle",
                            NameJapanese = "ゼニガメ",
                            NameRomanji = "Zenigame",
                            Number = "007",
                            Type1 = "Water",
                            Type2 = "",
                            Weight = 9.0m
                        },
                        new
                        {
                            Id = 8,
                            Height = 1.0m,
                            Name = "Wartortle",
                            NameJapanese = "カメール",
                            NameRomanji = "Kameil",
                            Number = "008",
                            Type1 = "Water",
                            Type2 = "",
                            Weight = 22.5m
                        },
                        new
                        {
                            Id = 9,
                            Height = 1.6m,
                            Name = "Blastoise",
                            NameJapanese = "カメックス",
                            NameRomanji = "Kamex",
                            Number = "009",
                            Type1 = "Water",
                            Type2 = "",
                            Weight = 85.5m
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
