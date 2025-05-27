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
    public class VentasController : Controller
    {
        private readonly PetFormationDbContext _petFormationDbContext;
        public VentasController(PetFormationDbContext petFormationDbContext)
        {
            _petFormationDbContext = petFormationDbContext;
        }

        [HttpGet]
        public async Task<IActionResult> GetVentas()
        {
            var venta = await _petFormationDbContext.Ventas.ToListAsync();

            return Ok(venta);
        }

        [HttpPost]
        public async Task<IActionResult> AddVentas([FromBody] ventas venta)
        {
            if (venta.ID_VENTA != null && venta.ID_CLIENTE != null)
            {
                //cliente.ID_CLIENTE = new string();

                await _petFormationDbContext.Ventas.AddAsync(venta);
                await _petFormationDbContext.SaveChangesAsync();

                return Ok(venta);
            }
            else
            {
                return BadRequest();
            }

        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetVenta([FromRoute] string id)
        {
            var idVenta = Convert.ToInt32(id);

            var venta = await _petFormationDbContext.Ventas.FirstOrDefaultAsync(x => x.ID_VENTA == idVenta);

            if (venta == null)
            {
                return NotFound();
            }

            return Ok(venta);
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> UpdateVenta([FromRoute] string id, ventas updateVentaRequest)
        {
            var idVenta = Convert.ToInt32(id);

            var venta = await _petFormationDbContext.Ventas.FirstOrDefaultAsync(x => x.ID_VENTA == idVenta);

            if (venta == null)
            {
                return NotFound();
            }

            venta.TIMESTAMP_VENTA = updateVentaRequest.TIMESTAMP_VENTA;
            venta.ID_CLIENTE = updateVentaRequest.ID_CLIENTE;
            venta.GRAN_TOTAL = updateVentaRequest.GRAN_TOTAL;

            await _petFormationDbContext.SaveChangesAsync();

            return Ok(venta);
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeleteVenta([FromRoute] string id)
        {
            var idVenta = Convert.ToInt32(id);
            var venta = await _petFormationDbContext.Ventas.FirstOrDefaultAsync(x => x.ID_VENTA == idVenta);

            if (venta == null)
            {
                return NotFound();
            }

            _petFormationDbContext.Ventas.Remove(venta);
            await _petFormationDbContext.SaveChangesAsync();

            return Ok(venta);
        }
    }
}
