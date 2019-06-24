using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BibliotecaUTN.Models
{
    [Table("tbl_Prestamo")]
    public class Prestamo
    {
        [Key]
        public Guid IdPrestamo { get; set; }

        [ForeignKey("FK_LibroPrestamo")]
        public Guid IdLibro { get; set; }
        public Libro FK_LibroPrestamo { get; set; }

        [ForeignKey("FK_AlumnoPrestamo")]
        public Guid IdAlumno { get; set; }
        public Alumno FK_AlumnoPrestamo { get; set; }

        public Guid Codigo { get; set; }

        public DateTime FechaPrestamo { get; set; }

        public DateTime FechaLimite { get; set; }

        public DateTime FechaDevolucion { get; set; }

        [ForeignKey("FK_StatusPrestamo")]
        public Guid IdStatusPrestamo { get; set; }
        public StatusPrestamo FK_StatusPrestamo { get; set; }

        public double MontoMulta { get; set; }
    }
}
