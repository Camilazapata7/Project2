using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Project2.API.Data;
using Project2.Shared;

// Define la ruta de la API: /api/Organizador
[Route("api/[controller]")]
[ApiController]
public class OrganizadorController : ControllerBase
{
    private readonly ApplicationDbContext _context;

    public OrganizadorController(ApplicationDbContext context)
    {
        _context = context;
    }

    // GET: api/Organizador (Leer todos)
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Organizador>>> GetOrganizadores()
    {
        return await _context.Organizadores.ToListAsync();
    }

    // GET: api/Organizador/5 (Leer por ID)
    [HttpGet("{id}")]
    public async Task<ActionResult<Organizador>> GetOrganizador(int id)
    {
        var organizador = await _context.Organizadores.FindAsync(id);
        if (organizador == null) return NotFound();
        return organizador;
    }

    // POST: api/Organizador (Crear nuevo)
    [HttpPost]
    public async Task<ActionResult<Organizador>> PostOrganizador(Organizador organizador)
    {
        // Las validaciones de Shared se ejecutan automáticamente aquí.
        if (!ModelState.IsValid) return BadRequest(ModelState);

        _context.Organizadores.Add(organizador);
        await _context.SaveChangesAsync();
        return CreatedAtAction(nameof(GetOrganizador), new { id = organizador.Id }, organizador);
    }

    // ... Debes agregar los métodos PUT (Update) y DELETE (Delete) aquí para completar el CRUD ...
}