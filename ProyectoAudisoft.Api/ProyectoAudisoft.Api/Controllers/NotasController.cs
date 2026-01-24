using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProyectoAudisoft.Api.Data;
using ProyectoAudisoft.Api.DTOs;
using ProyectoAudisoft.Api.Models;

namespace ProyectoAudisoft.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class NotasController : ControllerBase
    {
        private readonly AppDbContext _context;

        public NotasController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Notas
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var notas = await _context.Notas
                .Include(n => n.Estudiante)
                .Include(n => n.Profesor)
                .Select(n => new NotaDto
                {
                    Id = n.Id,
                    Valor = n.Valor,
                    Materia = n.Materia,

                    EstudianteId = n.EstudianteId,
                    Estudiante = n.Estudiante.Nombre,

                    ProfesorId = n.ProfesorId,
                    Profesor = n.Profesor.Nombre
                })
                .ToListAsync();

            return Ok(notas);
        }

        // GET: api/Notas/estudiante/1
        [HttpGet("estudiante/{estudianteId}")]
        public async Task<IActionResult> GetByEstudiante(int estudianteId)
        {
            var notas = await _context.Notas
                .Where(n => n.EstudianteId == estudianteId)
                .Include(n => n.Profesor)
                .Include(n => n.Estudiante)
                .Select(n => new NotaDto
                {
                    Id = n.Id,
                    Valor = n.Valor,
                    Materia = n.Materia,

                    EstudianteId = n.EstudianteId,
                    Estudiante = n.Estudiante.Nombre,

                    ProfesorId = n.ProfesorId,
                    Profesor = n.Profesor.Nombre
                })
                .ToListAsync();

            return Ok(notas);
        }

        // GET: api/Notas/profesor/1
        [HttpGet("profesor/{profesorId}")]
        public async Task<IActionResult> GetByProfesor(int profesorId)
        {
            var notas = await _context.Notas
                .Where(n => n.ProfesorId == profesorId)
                .Include(n => n.Estudiante)
                .Include(n => n.Profesor)
                .Select(n => new NotaDto
                {
                    Id = n.Id,
                    Valor = n.Valor,
                    Materia = n.Materia,

                    EstudianteId = n.EstudianteId,
                    Estudiante = n.Estudiante.Nombre,

                    ProfesorId = n.ProfesorId,
                    Profesor = n.Profesor.Nombre
                })
                .ToListAsync();

            return Ok(notas);
        }

        // POST: api/Notas
        [HttpPost]
        public async Task<IActionResult> Post(Nota nota)
        {
            if (nota == null)
                return BadRequest("La nota es obligatoria");

            if (nota.Valor < 0 || nota.Valor > 5)
                return BadRequest("La nota debe estar entre 0 y 5");

            _context.Notas.Add(nota);
            await _context.SaveChangesAsync();

            var dto = await _context.Notas
                .Include(n => n.Estudiante)
                .Include(n => n.Profesor)
                .Where(n => n.Id == nota.Id)
                .Select(n => new NotaDto
                {
                    Id = n.Id,
                    Valor = n.Valor,
                    Materia = n.Materia,

                    EstudianteId = n.EstudianteId,
                    Estudiante = n.Estudiante.Nombre,

                    ProfesorId = n.ProfesorId,
                    Profesor = n.Profesor.Nombre
                })
                .FirstAsync();

            return Ok(dto);
        }

        // PUT: api/Notas/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, Nota nota)
        {
            if (id != nota.Id)
                return BadRequest("Id incorrecto");

            if (nota.Valor < 0 || nota.Valor > 5)
                return BadRequest("La nota debe estar entre 0 y 5");

            var existente = await _context.Notas.FindAsync(id);
            if (existente == null)
                return NotFound();

            existente.Valor = nota.Valor;
            existente.Materia = nota.Materia;
            existente.ProfesorId = nota.ProfesorId;
            existente.EstudianteId = nota.EstudianteId;

            await _context.SaveChangesAsync();

            return NoContent();
        }

        // DELETE: api/Notas/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var nota = await _context.Notas.FindAsync(id);
            if (nota == null)
                return NotFound();

            _context.Notas.Remove(nota);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
