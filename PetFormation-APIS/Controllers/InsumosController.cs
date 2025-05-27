using Google.Protobuf.WellKnownTypes;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MySqlX.XDevAPI;
using PetFormation_APIS.Data;
using PetFormation_APIS.Models;

namespace PetFormation_APIS.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class InsumosController : Controller
    {
        private readonly PetFormationDbContext _petFormationDbContext;
        public InsumosController(PetFormationDbContext petFormationDbContext)
        {
            _petFormationDbContext = petFormationDbContext;
        }

        [HttpGet]
        public async Task<IActionResult> GetInsumos()
        {
            var insumo = await _petFormationDbContext.Insumos.ToListAsync();

            return Ok(insumo);
        }

        [HttpPost]
        public async Task<IActionResult> AddInsumos([FromBody] insumos insumo)
        {
            if (insumo.ID_INSUMO != null && insumo.NOMBRE_INSUMO != null)
            {
                //cliente.ID_CLIENTE = new string();

                await _petFormationDbContext.Insumos.AddAsync(insumo);
                await _petFormationDbContext.SaveChangesAsync();

                return Ok(insumo);
            }
            else
            {
                return BadRequest();
            }

        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetInsumo([FromRoute] string id)
        {
            var idInsumo = Convert.ToInt32(id);

            var insumo = await _petFormationDbContext.Insumos.FirstOrDefaultAsync(x => x.ID_INSUMO == idInsumo);

            if (insumo == null)
            {
                return NotFound();
            }

            return Ok(insumo);
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> UpdateDetalle([FromRoute] string id, insumos updateInsumoRequest)
        {
            var idInsumo = Convert.ToInt32(id);

            var insumo = await _petFormationDbContext.Insumos.FirstOrDefaultAsync(x => x.ID_INSUMO == idInsumo);

            if (insumo == null)
            {
                return NotFound();
            }

            insumo.NOMBRE_INSUMO = updateInsumoRequest.NOMBRE_INSUMO;
            insumo.PRECIO_INSUMO = updateInsumoRequest.PRECIO_INSUMO;
            insumo.ID_PROVEEDOR = updateInsumoRequest.ID_PROVEEDOR;

            await _petFormationDbContext.SaveChangesAsync();

            return Ok(insumo);
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeleteCliente([FromRoute] string id)
        {
            var idInsumo = Convert.ToInt32(id);
            var insumo = await _petFormationDbContext.Insumos.FirstOrDefaultAsync(x => x.ID_INSUMO == idInsumo);

            if (insumo == null)
            {
                return NotFound();
            }

            _petFormationDbContext.Insumos.Remove(insumo);
            await _petFormationDbContext.SaveChangesAsync();

            return Ok(insumo);
        }
    }
}
