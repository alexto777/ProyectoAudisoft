using System.Collections.Generic;

namespace ProyectoAudisoft.Api.Models
{
    public class Profesor
    {
        public int Id { get; set; }
        public required string Nombre { get; set; }
        public required string Especialidad { get; set; }

        public ICollection<Nota>? Notas { get; set; }
    }
}
