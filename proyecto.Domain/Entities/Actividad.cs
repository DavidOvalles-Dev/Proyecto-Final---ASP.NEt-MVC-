using proyecto.Domain.Entities;

namespace proyecto.Domain.Entities
{
    public class Actividad
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public DateTime Fecha { get; set; }

        // Relación con el creador
        public int CreadorId { get; set; }
        public Miembro Creador { get; set; }
    }
}