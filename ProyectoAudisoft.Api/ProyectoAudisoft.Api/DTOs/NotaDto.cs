namespace ProyectoAudisoft.Api.DTOs
{
    public class NotaDto
    {
        public int Id { get; set; }
        public decimal Valor { get; set; }

        public int EstudianteId { get; set; }
        public string Estudiante { get; set; }

        public int ProfesorId { get; set; }
        public string Profesor { get; set; }

        public string Materia { get; set; }
    }
}
