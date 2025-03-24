using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using proyecto.api.Models;

namespace proyecto.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductosController : ControllerBase
    {

        private readonly DataContext _context;

        public ProductosController(DataContext context)
        {

            _context = context;
        }

        [HttpPost]
        [Route("Crear")]
        public async Task<IActionResult> CrearProducto(Producto producto)
        {
            await _context.Productos.AddAsync(producto);
            await _context.SaveChangesAsync();
            return Ok();
        }
        [HttpGet]
        [Route("lista")]
        public async Task<ActionResult<IEnumerable<Producto>>>ListaProductos()
        {

            var productos = await _context.Productos.ToListAsync();
            return Ok(productos);
        }

    }
}
