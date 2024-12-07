using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace proyecto.Domain.Entities
{
    public class Miembro
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Nombre { get; set; }

        [Required]
        [MaxLength(50)]
        public string Apellido { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public DateTime FechaNacimiento { get; set; }

        // Relación muchos a muchos con Actividad
        public ICollection<MiembroActividad> MiembroActividades { get; set; } = new List<MiembroActividad>();
    }
}
