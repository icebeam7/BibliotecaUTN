﻿// <auto-generated />
using System;
using BibliotecaUTN.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace BibliotecaUTN.Migrations
{
    [DbContext(typeof(BibliotecaContext))]
    [Migration("20190625122810_03_AddAlumnoIdentity4")]
    partial class _03_AddAlumnoIdentity4
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.4-servicing-10062")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("BibliotecaUTN.Models.Alumno", b =>
                {
                    b.Property<Guid>("IdAlumno")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("Activo");

                    b.Property<string>("Email");

                    b.Property<string>("IdIdentity");

                    b.Property<string>("Matricula");

                    b.Property<string>("Nombre");

                    b.Property<string>("Password");

                    b.HasKey("IdAlumno");

                    b.ToTable("tbl_Alumno");
                });

            modelBuilder.Entity("BibliotecaUTN.Models.Autor", b =>
                {
                    b.Property<Guid>("IdAutor")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Nombre");

                    b.HasKey("IdAutor");

                    b.ToTable("tbl_Autor");
                });

            modelBuilder.Entity("BibliotecaUTN.Models.AutorLibro", b =>
                {
                    b.Property<Guid>("IdLibro");

                    b.Property<Guid>("IdAutor");

                    b.HasKey("IdLibro", "IdAutor");

                    b.HasIndex("IdAutor");

                    b.ToTable("tbl_AutorLibro");
                });

            modelBuilder.Entity("BibliotecaUTN.Models.Editorial", b =>
                {
                    b.Property<Guid>("IdEditorial")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Nombre");

                    b.HasKey("IdEditorial");

                    b.ToTable("tbl_Editorial");
                });

            modelBuilder.Entity("BibliotecaUTN.Models.Genero", b =>
                {
                    b.Property<Guid>("IdGenero")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Nombre");

                    b.HasKey("IdGenero");

                    b.ToTable("tbl_Genero");
                });

            modelBuilder.Entity("BibliotecaUTN.Models.Libro", b =>
                {
                    b.Property<Guid>("IdLibro")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Año");

                    b.Property<string>("ISBN");

                    b.Property<Guid>("IdEditorial");

                    b.Property<Guid>("IdGenero");

                    b.Property<Guid>("IdPais");

                    b.Property<string>("Imagen");

                    b.Property<string>("Titulo");

                    b.HasKey("IdLibro");

                    b.HasIndex("IdEditorial");

                    b.HasIndex("IdGenero");

                    b.HasIndex("IdPais");

                    b.ToTable("tbl_Libro");
                });

            modelBuilder.Entity("BibliotecaUTN.Models.Pais", b =>
                {
                    b.Property<Guid>("IdPais")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Nombre");

                    b.HasKey("IdPais");

                    b.ToTable("tbl_Pais");
                });

            modelBuilder.Entity("BibliotecaUTN.Models.Prestamo", b =>
                {
                    b.Property<Guid>("IdPrestamo")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid>("Codigo");

                    b.Property<DateTime>("FechaDevolucion");

                    b.Property<DateTime>("FechaLimite");

                    b.Property<DateTime>("FechaPrestamo");

                    b.Property<Guid>("IdAlumno");

                    b.Property<Guid>("IdLibro");

                    b.Property<Guid>("IdStatusPrestamo");

                    b.Property<double>("MontoMulta");

                    b.HasKey("IdPrestamo");

                    b.HasIndex("IdAlumno");

                    b.HasIndex("IdLibro");

                    b.HasIndex("IdStatusPrestamo");

                    b.ToTable("tbl_Prestamo");
                });

            modelBuilder.Entity("BibliotecaUTN.Models.StatusPrestamo", b =>
                {
                    b.Property<Guid>("IdStatusPrestamo")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Nombre");

                    b.HasKey("IdStatusPrestamo");

                    b.ToTable("tbl_StatusPrestamo");
                });

            modelBuilder.Entity("BibliotecaUTN.Models.AutorLibro", b =>
                {
                    b.HasOne("BibliotecaUTN.Models.Autor", "FK_Autor")
                        .WithMany("AutoresLibros")
                        .HasForeignKey("IdAutor")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("BibliotecaUTN.Models.Libro", "FK_Libro")
                        .WithMany("AutoresLibros")
                        .HasForeignKey("IdLibro")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("BibliotecaUTN.Models.Libro", b =>
                {
                    b.HasOne("BibliotecaUTN.Models.Editorial", "FK_EditorialLibro")
                        .WithMany("Libros")
                        .HasForeignKey("IdEditorial")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("BibliotecaUTN.Models.Genero", "FK_GeneroLibro")
                        .WithMany("Libros")
                        .HasForeignKey("IdGenero")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("BibliotecaUTN.Models.Pais", "FK_PaisLibro")
                        .WithMany("Libros")
                        .HasForeignKey("IdPais")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("BibliotecaUTN.Models.Prestamo", b =>
                {
                    b.HasOne("BibliotecaUTN.Models.Alumno", "FK_AlumnoPrestamo")
                        .WithMany("Prestamos")
                        .HasForeignKey("IdAlumno")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("BibliotecaUTN.Models.Libro", "FK_LibroPrestamo")
                        .WithMany()
                        .HasForeignKey("IdLibro")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("BibliotecaUTN.Models.StatusPrestamo", "FK_StatusPrestamo")
                        .WithMany("Prestamos")
                        .HasForeignKey("IdStatusPrestamo")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
