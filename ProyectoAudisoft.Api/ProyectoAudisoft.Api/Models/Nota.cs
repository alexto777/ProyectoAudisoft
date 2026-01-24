namespace ProyectoAudisoft.Api.Models
{
    public class Nota
    {
        public int Id { get; set; }
        public required string Materia { get; set; }

        public decimal Valor { get; set; }

        // FK Estudiante
        public int EstudianteId { get; set; }
        public Estudiante? Estudiante { get; set; }

        // FK Profesor
        public int ProfesorId { get; set; }
        public Profesor? Profesor { get; set; }
    }
}
