using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Project2.API.Data;
using Project2.Shared;

[Route("api/[controller]")]
[ApiController]
public class ParticipacionController : ControllerBase
{
    private readonly ApplicationDbContext _context;

    public ParticipacionController(ApplicationDbContext context)
    {
        _context = context;
    }

    // GET: api/Participacion
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Participacion>>> GetParticipaciones()
    {
        return await _context.Participaciones.ToListAsync();
    }

    // GET: api/Participacion/5
    [HttpGet("{id}")]
    public async Task<ActionResult<Participacion>> GetParticipacion(int id)
    {
        var participacion = await _context.Participaciones.FindAsync(id);
        if (participacion == null) return NotFound();
        return participacion;
    }

    // POST: api/Participacion
    [HttpPost]
    public async Task<ActionResult<Participacion>> PostParticipacion(Participacion participacion)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);
        _context.Participaciones.Add(participacion);
        await _context.SaveChangesAsync();
        return CreatedAtAction(nameof(GetParticipacion), new { id = participacion.Id }, participacion);
    }

    // PUT: api/Participacion/5
    [HttpPut("{id}")]
    public async Task<IActionResult> PutParticipacion(int id, Participacion participacion)
    {
        if (id != participacion.Id) return BadRequest();
        if (!ModelState.IsValid) return BadRequest(ModelState);
        _context.Entry(participacion).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!_context.Participaciones.Any(e => e.Id == id)) return NotFound();
            else throw;
        }
        return NoContent();
    }

    // DELETE: api/Participacion/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteParticipacion(int id)
    {
        var participacion = await _context.Participaciones.FindAsync(id);
        if (participacion == null) return NotFound();

        _context.Participaciones.Remove(participacion);
        await _context.SaveChangesAsync();
        return NoContent();
    }
}
