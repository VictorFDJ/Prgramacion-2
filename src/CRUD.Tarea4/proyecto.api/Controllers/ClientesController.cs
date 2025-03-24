using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using proyecto.api.Models;

namespace proyecto.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientesController : ControllerBase
    {
        private readonly DataContext _context;

        public ClientesController(DataContext context)
        {

            _context = context;
        }

        [HttpPost]
        [Route("Crear")]
        public async Task<IActionResult>CrearCliente(Cliente cliente)
        {
            await _context.Clientes.AddAsync(cliente);
            await _context.SaveChangesAsync();
            return Ok();

        }
        [HttpGet]
        [Route("lista")]
        public async Task<ActionResult<IEnumerable<Producto>>> ListaClientes()
        {

            var clientes = await _context.Clientes.ToListAsync();
            return Ok(clientes);
        }
    }
}
