﻿using CRUD.Domain.Entidades;
using CRUD.Persitense;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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

        [HttpGet]
        [Route("Buscar por ID")]
        public async Task<IActionResult> VerProducto(int id)
        {
            Producto producto = await _context.Productos.FindAsync(id);

            if (producto == null)
            {
                return NotFound();
            }
            return Ok(producto);
        }

        [HttpPut]
        [Route("editar")]
        public async Task<IActionResult> ActualizarProducto(int id, Producto producto)
        {
            var productoExistente = await _context.Productos.FindAsync(id);

            productoExistente!.Nombre = producto.Nombre;
            productoExistente.Descripcion = producto.Descripcion;
            productoExistente.Precio = producto.Precio;

            await _context.SaveChangesAsync();

            return Ok();
        }
        [HttpDelete]
        [Route("eliminar")]
        public async Task<IActionResult> EliminarProducto(int id)
        {
            var productoBorrado = await _context.Productos.FindAsync(id);
            _context.Productos.Remove(productoBorrado!);
            await _context.SaveChangesAsync();
            return Ok();
        }

    }
}
