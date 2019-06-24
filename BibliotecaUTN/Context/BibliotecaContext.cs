﻿using Microsoft.EntityFrameworkCore;
using BibliotecaUTN.Models;

namespace BibliotecaUTN.Context
{
    public class BibliotecaContext : DbContext
    {
        public BibliotecaContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Alumno> Alumnos { get; set; }
        public DbSet<Autor> Autores { get; set; }
        public DbSet<Editorial> Editoriales { get; set; }
        public DbSet<Genero> Generos { get; set; }
        public DbSet<Libro> Libros { get; set; }
        public DbSet<Pais> Paises { get; set; }
        public DbSet<Prestamo> Prestamos { get; set; }
        public DbSet<StatusPrestamo> StatusPrestamos { get; set; }
        public DbSet<AutorLibro> AutoresLibros { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AutorLibro>()
                .HasKey(x => new { x.IdLibro, x.IdAutor });
        }
    }
}
