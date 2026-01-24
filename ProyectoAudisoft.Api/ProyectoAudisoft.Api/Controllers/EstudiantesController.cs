using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProyectoAudisoft.Api.Data;
using ProyectoAudisoft.Api.Models;

namespace ProyectoAudisoft.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EstudiantesController : ControllerBase
    {
        private readonly AppDbContext _context;

        public EstudiantesController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var estudiantes = await _context.Estudiantes.ToListAsync();
            return Ok(estudiantes);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var estudiante = await _context.Estudiantes.FindAsync(id);
            if (estudiante == null)
                return NotFound();

            var tieneNotas = await _context.Notas.AnyAsync(n => n.EstudianteId == id);
            if (tieneNotas)
                return BadRequest("El estudiante tiene notas asignadas");

            _context.Estudiantes.Remove(estudiante);
            await _context.SaveChangesAsync();

            return Ok("Estudiante eliminado exitosamente");
        }


    }
}
