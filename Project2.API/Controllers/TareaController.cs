using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Project2.API.Data;
using Project2.Shared;

[Route("api/[controller]")]
[ApiController]
public class TareaController : ControllerBase
{
    private readonly ApplicationDbContext _context;

    public TareaController(ApplicationDbContext context)
    {
        _context = context;
    }

    // GET: api/Tarea
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Tarea>>> GetTareas()
    {
        return await _context.Tareas.ToListAsync();
    }

    // GET: api/Tarea/5
    [HttpGet("{id}")]
    public async Task<ActionResult<Tarea>> GetTarea(int id)
    {
        var tarea = await _context.Tareas.FindAsync(id);
        if (tarea == null) return NotFound();
        return tarea;
    }

    // POST: api/Tarea
    [HttpPost]
    public async Task<ActionResult<Tarea>> PostTarea(Tarea tarea)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);
        _context.Tareas.Add(tarea);
        await _context.SaveChangesAsync();
        return CreatedAtAction(nameof(GetTarea), new { id = tarea.Id }, tarea);
    }

    // PUT: api/Tarea/5
    [HttpPut("{id}")]
    public async Task<IActionResult> PutTarea(int id, Tarea tarea)
    {
        if (id != tarea.Id) return BadRequest();
        if (!ModelState.IsValid) return BadRequest(ModelState);
        _context.Entry(tarea).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!_context.Tareas.Any(e => e.Id == id)) return NotFound();
            else throw;
        }
        return NoContent();
    }

    // DELETE: api/Tarea/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteTarea(int id)
    {
        var tarea = await _context.Tareas.FindAsync(id);
        if (tarea == null) return NotFound();

        _context.Tareas.Remove(tarea);
        await _context.SaveChangesAsync();
        return NoContent();
    }
}
