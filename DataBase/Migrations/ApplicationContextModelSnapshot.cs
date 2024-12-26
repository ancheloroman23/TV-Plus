﻿// <auto-generated />
using System;
using DataBase;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DataBase.Migrations
{
    [DbContext(typeof(ApplicationContext))]
    partial class ApplicationContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("DataBase.Models.Genero", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Generos", (string)null);
                });

            modelBuilder.Entity("DataBase.Models.Productora", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Productoras", (string)null);
                });

            modelBuilder.Entity("DataBase.Models.Serie", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Descripcion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("IdGeneroPrimario")
                        .HasColumnType("int");

                    b.Property<int?>("IdGeneroSecundario")
                        .HasColumnType("int");

                    b.Property<int>("IdProductora")
                        .HasColumnType("int");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("UrlPortada")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UrlVideo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("IdGeneroPrimario");

                    b.HasIndex("IdGeneroSecundario");

                    b.HasIndex("IdProductora");

                    b.ToTable("Series", (string)null);
                });

            modelBuilder.Entity("DataBase.Models.Serie", b =>
                {
                    b.HasOne("DataBase.Models.Genero", "Genero")
                        .WithMany("Series")
                        .HasForeignKey("IdGeneroPrimario")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("DataBase.Models.Genero", "GeneroSecundario")
                        .WithMany()
                        .HasForeignKey("IdGeneroSecundario")
                        .OnDelete(DeleteBehavior.NoAction);

                    b.HasOne("DataBase.Models.Productora", "Productora")
                        .WithMany("Series")
                        .HasForeignKey("IdProductora")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Genero");

                    b.Navigation("GeneroSecundario");

                    b.Navigation("Productora");
                });

            modelBuilder.Entity("DataBase.Models.Genero", b =>
                {
                    b.Navigation("Series");
                });

            modelBuilder.Entity("DataBase.Models.Productora", b =>
                {
                    b.Navigation("Series");
                });
#pragma warning restore 612, 618
        }
    }
}