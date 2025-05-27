using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PetFormation_APIS.Data;
using PetFormation_APIS.Models;

namespace PetFormation_APIS.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProveedoresController : Controller
    {
        private readonly PetFormationDbContext _petFormationDbContext;
        public ProveedoresController(PetFormationDbContext petFormationDbContext)
        {
            _petFormationDbContext = petFormationDbContext;
        }

        [HttpGet]
        public async Task<IActionResult> GetProveedores()
        {
            var proveedores = await _petFormationDbContext.Proveedores.ToListAsync();

            return Ok(proveedores);
        }

        [HttpPost]
        public async Task<IActionResult> AddProveedor([FromBody] proveedores proveedores)
        {
            proveedores.ID_PROVEEDOR = new int();

            await _petFormationDbContext.Proveedores.AddAsync(proveedores);
            await _petFormationDbContext.SaveChangesAsync();

            return Ok(proveedores);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetProveedor([FromRoute] string id)
        {
            var idProveedor = Convert.ToInt32(id);

            var proveedore = await _petFormationDbContext.Proveedores.FirstOrDefaultAsync(x => x.ID_PROVEEDOR == idProveedor);

            if (proveedore == null)
            {
                return NotFound();
            }

            return Ok(proveedore);
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> UpdateProveedor([FromRoute] string id, proveedores updateProveedorRequest)
        {
            var idProveedor = Convert.ToInt32(id);

            var proveedore = await _petFormationDbContext.Proveedores.FirstOrDefaultAsync(x => x.ID_PROVEEDOR == idProveedor);

            if (proveedore == null)
            {
                return NotFound();
            }

            proveedore.NOMBRE_PROVEEDOR = updateProveedorRequest.NOMBRE_PROVEEDOR;
            proveedore.CONTACTO_PROVEEDOR = updateProveedorRequest.CONTACTO_PROVEEDOR;
            proveedore.TELEFONO_PROVEEDOR = updateProveedorRequest.TELEFONO_PROVEEDOR;
            proveedore.CORREO_PROVEEDOR = updateProveedorRequest.CORREO_PROVEEDOR;
            proveedore.DIRECCION_PROVEEDOR = updateProveedorRequest.DIRECCION_PROVEEDOR;
            proveedore.ID_PRODUCTO = updateProveedorRequest.ID_PRODUCTO;

            await _petFormationDbContext.SaveChangesAsync();

            return Ok(proveedore);
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeleteProveedor([FromRoute] string id)
        {
            var idProveedor = Convert.ToInt32(id);
            var proveedore = await _petFormationDbContext.Proveedores.FirstOrDefaultAsync(x => x.ID_PROVEEDOR == idProveedor);

            if (proveedore == null)
            {
                return NotFound();
            }

            _petFormationDbContext.Proveedores.Remove(proveedore);
            await _petFormationDbContext.SaveChangesAsync();

            return Ok(proveedore);
        }
    }
}
