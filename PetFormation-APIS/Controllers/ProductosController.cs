using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MySqlX.XDevAPI;
using PetFormation_APIS.Data;
using PetFormation_APIS.Models;

namespace PetFormation_APIS.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductosController : Controller
    {
        private readonly PetFormationDbContext _petFormationDbContext;
        public ProductosController(PetFormationDbContext petFormationDbContext)
        {
            _petFormationDbContext = petFormationDbContext;
        }

        [HttpGet]
        public async Task<IActionResult> GetProductos()
        {
            var producto = await _petFormationDbContext.Productos.ToListAsync();

            return Ok(producto);
        }

        [HttpPost]
        public async Task<IActionResult> AddProducto([FromBody] productos producto)
        {
            producto.ID_PRODUCTO = new int();

            await _petFormationDbContext.Productos.AddAsync(producto);
            await _petFormationDbContext.SaveChangesAsync();

            return Ok(producto);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetProducto([FromRoute] string id)
        {
            var idProducto = Convert.ToInt32(id);

            var producto = await _petFormationDbContext.Productos.FirstOrDefaultAsync(x => x.ID_PRODUCTO == idProducto);

            if (producto == null)
            {
                return NotFound();
            }

            return Ok(producto);
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> UpdateProducto([FromRoute] string id, productos updateProductoRequest)
        {
            var idProducto = Convert.ToInt32(id);

            var producto = await _petFormationDbContext.Productos.FirstOrDefaultAsync(x => x.ID_PRODUCTO == idProducto);

            if (producto == null)
            {
                return NotFound();
            }

            producto.NOMBRE_PRODUCTO = updateProductoRequest.NOMBRE_PRODUCTO;
            producto.TAMANO_PRODUCTO = updateProductoRequest.TAMANO_PRODUCTO;
            producto.COLOR_PRODUCTO = updateProductoRequest.COLOR_PRODUCTO;
            producto.CONTENIDO_PRODUCTO = updateProductoRequest.CONTENIDO_PRODUCTO;
            producto.CATEGORIA_PRODUCTO = updateProductoRequest.CATEGORIA_PRODUCTO;

            await _petFormationDbContext.SaveChangesAsync();

            return Ok(producto);
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeleteProducto([FromRoute] string id)
        {
            var idProducto = Convert.ToInt32(id);
            var producto = await _petFormationDbContext.Productos.FirstOrDefaultAsync(x => x.ID_PRODUCTO == idProducto);

            if (producto == null)
            {
                return NotFound();
            }

            _petFormationDbContext.Productos.Remove(producto);
            await _petFormationDbContext.SaveChangesAsync();

            return Ok(producto);
        }
    }
}
