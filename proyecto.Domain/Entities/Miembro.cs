using System.ComponentModel.DataAnnotations;

namespace proyecto.Domain.Entities
{
    public class Miembro
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Email { get; set; }
        public DateTime FechaNacimiento { get; set; }
    }
}
