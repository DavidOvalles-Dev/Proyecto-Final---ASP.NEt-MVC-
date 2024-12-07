using System;
using System.Collections.Generic;

namespace proyecto.Domain.Entities
{
    public class Actividad
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public DateTime Fecha { get; set; }

        // Relación con Miembro (participantes)
        public ICollection<Miembro> Miembros { get; set; } = new List<Miembro>();

        // Relación con el Creador de la actividad
        public int CreadorId { get; set; }
        public Miembro Creador { get; set; }
    }
}
