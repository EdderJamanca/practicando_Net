﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using apifluent;

#nullable disable

namespace apifluent.Migrations
{
    [DbContext(typeof(TareasCantext))]
    partial class TareasCantextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("apifluent.Models.Categoria", b =>
                {
                    b.Property<Guid>("CategoriaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<int>("Peso")
                        .HasColumnType("int");

                    b.HasKey("CategoriaId");

                    b.ToTable("Categoria", (string)null);

                    b.HasData(
                        new
                        {
                            CategoriaId = new Guid("f86031eb-72b9-4d84-83ff-4bb9f6fc93ee"),
                            Nombre = "Actividades pendientes",
                            Peso = 20
                        },
                        new
                        {
                            CategoriaId = new Guid("f86031eb-72b9-4d84-83ff-4bb9f6fc9312"),
                            Nombre = "Actividades personales",
                            Peso = 50
                        });
                });

            modelBuilder.Entity("apifluent.Models.Tareas", b =>
                {
                    b.Property<Guid>("TareaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CategoriaId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("FechaCreacion")
                        .HasColumnType("datetime2");

                    b.Property<int>("PrioridadTarea")
                        .HasColumnType("int");

                    b.Property<string>("Titulo")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.HasKey("TareaId");

                    b.HasIndex("CategoriaId");

                    b.ToTable("Tarea", (string)null);

                    b.HasData(
                        new
                        {
                            TareaId = new Guid("f86031eb-72b9-4d84-83ff-4bb9f6fc9310"),
                            CategoriaId = new Guid("f86031eb-72b9-4d84-83ff-4bb9f6fc93ee"),
                            FechaCreacion = new DateTime(2024, 4, 28, 0, 31, 42, 339, DateTimeKind.Local).AddTicks(97),
                            PrioridadTarea = 1,
                            Titulo = "Pago de servicios"
                        },
                        new
                        {
                            TareaId = new Guid("f86031eb-72b9-4d84-83ff-4bb9f6fc9410"),
                            CategoriaId = new Guid("f86031eb-72b9-4d84-83ff-4bb9f6fc9312"),
                            FechaCreacion = new DateTime(2024, 4, 28, 0, 31, 42, 339, DateTimeKind.Local).AddTicks(112),
                            PrioridadTarea = 1,
                            Titulo = "Pago de servicios"
                        });
                });

            modelBuilder.Entity("apifluent.Models.Tareas", b =>
                {
                    b.HasOne("apifluent.Models.Categoria", "Categoria")
                        .WithMany("Tareas")
                        .HasForeignKey("CategoriaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Categoria");
                });

            modelBuilder.Entity("apifluent.Models.Categoria", b =>
                {
                    b.Navigation("Tareas");
                });
#pragma warning restore 612, 618
        }
    }
}
