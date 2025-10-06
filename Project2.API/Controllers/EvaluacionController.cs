using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Project2.API.Data;
using Project2.Shared;

[Route("api/[controller]")]
[ApiController]
public class EvaluacionController : ControllerBase
{
    private readonly ApplicationDbContext _context;

    public EvaluacionController(ApplicationDbContext context)
    {
        _context = context;
    }

    // GET: api/Evaluacion
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Evaluacion>>> GetEvaluaciones()
    {
        return await _context.Evaluaciones.ToListAsync();
    }

    // GET: api/Evaluacion/5
    [HttpGet("{id}")]
    public async Task<ActionResult<Evaluacion>> GetEvaluacion(int id)
    {
        var evaluacion = await _context.Evaluaciones.FindAsync(id);
        if (evaluacion == null) return NotFound();
        return evaluacion;
    }

    // POST: api/Evaluacion
    [HttpPost]
    public async Task<ActionResult<Evaluacion>> PostEvaluacion(Evaluacion evaluacion)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);
        _context.Evaluaciones.Add(evaluacion);
        await _context.SaveChangesAsync();
        return CreatedAtAction(nameof(GetEvaluacion), new { id = evaluacion.Id }, evaluacion);
    }

    // PUT: api/Evaluacion/5
    [HttpPut("{id}")]
    public async Task<IActionResult> PutEvaluacion(int id, Evaluacion evaluacion)
    {
        if (id != evaluacion.Id) return BadRequest();
        if (!ModelState.IsValid) return BadRequest(ModelState);
        _context.Entry(evaluacion).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!_context.Evaluaciones.Any(e => e.Id == id)) return NotFound();
            else throw;
        }
        return NoContent();
    }

    // DELETE: api/Evaluacion/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteEvaluacion(int id)
    {
        var evaluacion = await _context.Evaluaciones.FindAsync(id);
        if (evaluacion == null) return NotFound();

        _context.Evaluaciones.Remove(evaluacion);
        await _context.SaveChangesAsync();
        return NoContent();
    }
}
