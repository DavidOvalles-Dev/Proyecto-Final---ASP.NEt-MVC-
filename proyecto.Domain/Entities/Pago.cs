using System;
using System.ComponentModel.DataAnnotations;

namespace proyecto.Domain.Entities
{
    public class Pago
    {
        public int Id { get; set; }

        [Required]
        public int MiembroId { get; set; }
        public Miembro Miembro { get; set; }

        [Range(0, double.MaxValue)]
        public decimal Monto { get; set; }

        [Required]
        public DateTime FechaPago { get; set; }
    }
}
