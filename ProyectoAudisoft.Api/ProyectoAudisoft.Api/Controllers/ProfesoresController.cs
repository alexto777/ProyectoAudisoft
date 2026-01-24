using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProyectoAudisoft.Api.Data;
using ProyectoAudisoft.Api.DTOs;
using ProyectoAudisoft.Api.Models;

namespace ProyectoAudisoft.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProfesoresController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ProfesoresController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Profesores
        [HttpGet("profesor/{profesorId}")]
        public async Task<IActionResult> GetByProfesor(int profesorId)
        {
            var notas = await _context.Notas
                .Where(n => n.ProfesorId == profesorId)
                .Include(n => n.Estudiante)
                .Select(n => new NotaDto
                {
                    Id = n.Id,
                    Valor = n.Valor,

                    EstudianteId = n.EstudianteId,
                    Estudiante = n.Estudiante.Nombre,

                    ProfesorId = n.ProfesorId,
                    Profesor = n.Profesor.Nombre,

                    Materia = n.Materia
                })
                .ToListAsync();

            return Ok(notas);
        }


        // GET: api/Profesores/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Profesor>> GetById(int id)
        {
            var profesor = await _context.Profesores.FindAsync(id);

            if (profesor == null)
                return NotFound();

            return profesor;
        }

        // POST: api/Profesores
        [HttpPost]
        public async Task<ActionResult<Profesor>> Post(Profesor profesor)
        {
            _context.Profesores.Add(profesor);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetById),
                new { id = profesor.Id }, profesor);
        }

        // PUT: api/Profesores/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, Profesor profesor)
        {
            if (id != profesor.Id)
                return BadRequest();

            _context.Entry(profesor).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProfesor(int id)
        {
            var tieneNotas = await _context.Notas.AnyAsync(n => n.ProfesorId == id);

            if (tieneNotas)
            {
                return BadRequest("El docente tiene estudiantes con notas asignadas");
            }

            var profesor = await _context.Profesores.FindAsync(id);
            if (profesor == null) return NotFound();

            _context.Profesores.Remove(profesor);
            await _context.SaveChangesAsync();

            return Ok("Profesor eliminado correctamente");
        }

    }
}
