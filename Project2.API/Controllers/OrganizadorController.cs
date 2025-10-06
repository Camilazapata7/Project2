using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Project2.API.Data;
using Project2.Shared;


[Route("api/[controller]")]
[ApiController]
public class OrganizadorController : ControllerBase
{
    private readonly ApplicationDbContext _context;

    public OrganizadorController(ApplicationDbContext context)
    {
        _context = context;
    }

    // GET: api/Organizador (Read All)
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Organizador>>> GetOrganizadores()
    {
        return await _context.Organizadores.ToListAsync();
    }

    // GET: api/Organizador/5 (Read By ID)
    [HttpGet("{id}")]
    public async Task<ActionResult<Organizador>> GetOrganizador(int id)
    {
        var organizador = await _context.Organizadores.FindAsync(id);
        if (organizador == null) return NotFound();
        return organizador;
    }

    // POST: api/Organizador (Create)
    [HttpPost]
    public async Task<ActionResult<Organizador>> PostOrganizador(Organizador organizador){
        if (!ModelState.IsValid) return BadRequest(ModelState);
        _context.Organizadores.Add(organizador);
        await _context.SaveChangesAsync();
        return CreatedAtAction(nameof(GetOrganizador), new { id = organizador.Id }, organizador);
    }

    // PUT: api/Organizador/5 (Update)
    [HttpPut("{id}")]
    public async Task<IActionResult> PutOrganizador(int id, Organizador organizador)
    {
        if (id != organizador.Id) return BadRequest();
        if (!ModelState.IsValid) return BadRequest(ModelState);

        // Marca la entidad como modificada para que EF Core sepa que debe actualizarla.
        _context.Entry(organizador).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!_context.Organizadores.Any(e => e.Id == id))
            {
                return NotFound();
            }
            else
            {
                throw;
            }
        }
        return NoContent(); // 204 No Content: Éxito en la actualización
    }

    // DELETE: api/Organizador/5 (Delete)
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteOrganizador(int id)
    {
        var organizador = await _context.Organizadores.FindAsync(id);
        if (organizador == null) return NotFound();

        _context.Organizadores.Remove(organizador);
        await _context.SaveChangesAsync();
        return NoContent(); // 204 No Content: Éxito en la eliminación
    }
}