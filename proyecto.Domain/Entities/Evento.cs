using System;
using System.ComponentModel.DataAnnotations;

namespace proyecto.Domain.Entities
{
    public class Evento
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Nombre { get; set; }

        public string Descripcion { get; set; }

        public DateTime Fecha { get; set; }

        [Range(0, double.MaxValue)]
        public decimal Costo { get; set; }
    }
}
