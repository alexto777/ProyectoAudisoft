namespace ProyectoAudisoft.Api.DTOs
{
    public class NotaCreateDto
    {
        public decimal Valor { get; set; }
        public int EstudianteId { get; set; }
        public int ProfesorId { get; set; }
        public string? Materia { get; set; }
    }

}
