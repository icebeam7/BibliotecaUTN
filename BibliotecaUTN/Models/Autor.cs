using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BibliotecaUTN.Models
{
    [Table("tbl_Autor")]
    public class Autor
    {
        [Key]
        public Guid IdAutor { get; set; }

        public string Nombre { get; set; }

        public List<AutorLibro> AutoresLibros { get; set; }
    }
}
