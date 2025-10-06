using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Project2.API.Data;
using Project2.Shared;

[Route("api/[controller]")]
[ApiController]
public class VoluntarioController : ControllerBase
{
    private readonly ApplicationDbContext _context;

    public VoluntarioController(ApplicationDbContext context)
    {
        _context = context;
    }

    // GET: api/Voluntario
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Voluntario>>> GetVoluntarios()
    {
        return await _context.Voluntarios.ToListAsync();
    }

    // GET: api/Voluntario/5
    [HttpGet("{id}")]
    public async Task<ActionResult<Voluntario>> GetVoluntario(int id)
    {
        var voluntario = await _context.Voluntarios.FindAsync(id);
        if (voluntario == null) return NotFound();
        return voluntario;
    }

    // POST: api/Voluntario
    [HttpPost]
    public async Task<ActionResult<Voluntario>> PostVoluntario(Voluntario voluntario)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);
        _context.Voluntarios.Add(voluntario);
        await _context.SaveChangesAsync();
        return CreatedAtAction(nameof(GetVoluntario), new { id = voluntario.Id }, voluntario);
    }

    // PUT: api/Voluntario/5
    [HttpPut("{id}")]
    public async Task<IActionResult> PutVoluntario(int id, Voluntario voluntario)
    {
        if (id != voluntario.Id) return BadRequest();
        if (!ModelState.IsValid) return BadRequest(ModelState);
        _context.Entry(voluntario).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!_context.Voluntarios.Any(e => e.Id == id)) return NotFound();
            else throw;
        }
        return NoContent();
    }

    // DELETE: api/Voluntario/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteVoluntario(int id)
    {
        var voluntario = await _context.Voluntarios.FindAsync(id);
        if (voluntario == null) return NotFound();

        _context.Voluntarios.Remove(voluntario);
        await _context.SaveChangesAsync();
        return NoContent();
    }
}