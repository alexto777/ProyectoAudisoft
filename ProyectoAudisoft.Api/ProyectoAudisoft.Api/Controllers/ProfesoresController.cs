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
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var profesores = await _context.Profesores.ToListAsync();
            return Ok(profesores);
        }

        // GET: api/Profesores/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var profesor = await _context.Profesores.FindAsync(id);
            if (profesor == null) return NotFound();
            return Ok(profesor);
        }

        // POST: api/Profesores
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] ProfesorCreateDto dto)
        {
            var profesor = new Profesor
            {
                Nombre = dto.Nombre,
                Especialidad = dto.Especialidad
            };


            _context.Profesores.Add(profesor);
            await _context.SaveChangesAsync();

            return Ok(profesor);
        }

        // PUT: api/Profesores/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] ProfesorUpdateDto dto)
        {
            var profesor = await _context.Profesores.FindAsync(id);
            if (profesor == null) return NotFound();

            profesor.Nombre = dto.Nombre;

            await _context.SaveChangesAsync();
            return NoContent();
        }

        // DELETE: api/Profesores/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var profesor = await _context.Profesores.FindAsync(id);
            if (profesor == null) return NotFound();

            var tieneNotas = await _context.Notas.AnyAsync(n => n.ProfesorId == id);
            if (tieneNotas)
                return BadRequest("El profesor tiene notas asociadas");

            _context.Profesores.Remove(profesor);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
