using System;

namespace proyecto.Domain.Entities
{
    public class MiembroActividad
    {
        public int MiembroId { get; set; }
        public Miembro Miembro { get; set; }

        public int ActividadId { get; set; }
        public Actividad Actividad { get; set; }

        public bool Asistio { get; set; } // Propiedad para registrar asistencia
    }

}
