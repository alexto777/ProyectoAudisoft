using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProyectoAudisoft.Api.Data;
using ProyectoAudisoft.Api.DTOs;
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
            var estudiantes = await _context.Estudiantes
            .Select(e => new
            {
                e.Id,
                e.Nombre,
                CantidadNotas = _context.Notas.Count(n => n.EstudianteId == e.Id)
            })
            .ToListAsync();

                    return Ok(estudiantes);

        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var estudiante = await _context.Estudiantes
                .AsNoTracking()
                .FirstOrDefaultAsync(e => e.Id == id);

            if (estudiante == null)
                return NotFound();

            var tieneNotas = await _context.Notas
                .AsNoTracking()
                .AnyAsync(n => n.EstudianteId == id);

            if (tieneNotas)
                return BadRequest("El estudiante tiene notas asignadas");

            _context.Estudiantes.Remove(estudiante);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpPost]
        public async Task<IActionResult> Post(Estudiante estudiante)
        {
            _context.Estudiantes.Add(estudiante);
            await _context.SaveChangesAsync();
            return Ok(estudiante);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, Estudiante dto)
        {
            var estudiante = await _context.Estudiantes.FindAsync(id);
            if (estudiante == null)
                return NotFound();

            estudiante.Nombre = dto.Nombre;

            await _context.SaveChangesAsync();

            return Ok(estudiante);
        }

    }
}
