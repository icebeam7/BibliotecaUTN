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

        [ForeignKey("FK_EditorialLibro")]
        public Guid IdEditorial { get; set; }
        public Editorial FK_EditorialLibro { get; set; }

        [ForeignKey("FK_GeneroLibro")]
        public Guid IdGenero { get; set; }
        public Genero FK_GeneroLibro { get; set; }

        [ForeignKey("FK_PaisLibro")]
        public Guid IdPais { get; set; }
        public Pais FK_PaisLibro { get; set; }

        public int Año { get; set; }

        public string Imagen { get; set; }

        public List<AutorLibro> AutoresLibros { get; set; }
    }
}
