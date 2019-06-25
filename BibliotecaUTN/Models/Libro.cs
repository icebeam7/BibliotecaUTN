using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BibliotecaUTN.Models
{
    [Table("tbl_Libro")]
    public class Libro
    {
        [Key]
        public Guid IdLibro { get; set; }

        public string ISBN { get; set; }

        public string Titulo { get; set; }

        [ForeignKey("FK_EditorialLibro"), Display(Name = "Editorial")]
        public Guid IdEditorial { get; set; }
        [Display(Name = "Editorial")]
        public Editorial FK_EditorialLibro { get; set; }

        [ForeignKey("FK_GeneroLibro"), Display(Name = "Genero")]
        public Guid IdGenero { get; set; }
        [Display(Name = "Genero")]
        public Genero FK_GeneroLibro { get; set; }

        [ForeignKey("FK_PaisLibro"), Display(Name = "Pais")]
        public Guid IdPais { get; set; }
        [Display(Name = "Pais")]
        public Pais FK_PaisLibro { get; set; }

        public int Año { get; set; }

        public string Imagen { get; set; }

        public List<AutorLibro> AutoresLibros { get; set; }
    }
}
