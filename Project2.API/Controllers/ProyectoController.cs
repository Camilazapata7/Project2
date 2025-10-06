using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Project2.API.Data;
using Project2.Shared;

[Route("api/[controller]")]
[ApiController]
public class ProyectoController : ControllerBase
{
    private readonly ApplicationDbContext _context;

    public ProyectoController(ApplicationDbContext context)
    {
        _context = context;
    }

    // GET: api/Proyecto
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Proyecto>>> GetProyectos()
    {
        return await _context.Proyectos.ToListAsync();
    }

    // GET: api/Proyecto/5
    [HttpGet("{id}")]
    public async Task<ActionResult<Proyecto>> GetProyecto(int id)
    {
        var proyecto = await _context.Proyectos.FindAsync(id);
        if (proyecto == null) return NotFound();
        return proyecto;
    }

    // POST: api/Proyecto
    [HttpPost]
    public async Task<ActionResult<Proyecto>> PostProyecto(Proyecto proyecto)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);
        _context.Proyectos.Add(proyecto);
        await _context.SaveChangesAsync();
        return CreatedAtAction(nameof(GetProyecto), new { id = proyecto.Id }, proyecto);
    }

    // PUT: api/Proyecto/5
    [HttpPut("{id}")]
    public async Task<IActionResult> PutProyecto(int id, Proyecto proyecto)
    {
        if (id != proyecto.Id) return BadRequest();
        if (!ModelState.IsValid) return BadRequest(ModelState);
        _context.Entry(proyecto).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!_context.Proyectos.Any(e => e.Id == id)) return NotFound();
            else throw;
        }
        return NoContent();
    }

    // DELETE: api/Proyecto/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteProyecto(int id)
    {
        var proyecto = await _context.Proyectos.FindAsync(id);
        if (proyecto == null) return NotFound();

        _context.Proyectos.Remove(proyecto);
        await _context.SaveChangesAsync();
        return NoContent();
    }
}
