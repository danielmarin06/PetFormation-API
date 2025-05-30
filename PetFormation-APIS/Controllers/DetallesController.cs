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
    public class DetallesController : Controller
    {

        private readonly PetFormationDbContext _petFormationDbContext;
        public DetallesController(PetFormationDbContext petFormationDbContext)
        {
            _petFormationDbContext = petFormationDbContext;
        }

        [HttpGet]
        public async Task<IActionResult> GetDetalles()
        {
            var detalle = await _petFormationDbContext.Detalles.ToListAsync();

            return Ok(detalle);
        }

        [HttpPost]
        public async Task<IActionResult> AddDetalles([FromBody] List<detalles> detallesList)
        {

            if (detallesList == null || !detallesList.Any())
            {
                return BadRequest("Lista de detalles vacía.");
            }

            await _petFormationDbContext.Detalles.AddRangeAsync(detallesList);
            await _petFormationDbContext.SaveChangesAsync();

            return Ok(detallesList);
            //if (detalle.ID_DETALLE != null && detalle.ID_VENTA != null)
            //{
            //    //cliente.ID_CLIENTE = new string();

            //    await _petFormationDbContext.Detalles.AddRangeAsync(detallesList);
            //    await _petFormationDbContext.SaveChangesAsync();

            //    return Ok(detallesList);
            //}
            //else
            //{
            //    return BadRequest();
            //}

        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetDetalle([FromRoute] string id)
        {
            var idDetalle = Convert.ToInt32(id);

            var detalle = await _petFormationDbContext.Detalles.FirstOrDefaultAsync(x => x.ID_DETALLE == idDetalle);

            if (detalle == null)
            {
                return NotFound();
            }

            return Ok(detalle);
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> UpdateDetalle([FromRoute] string id, detalles updateDetalleRequest)
        {
            var idDetalle = Convert.ToInt32(id);

            var detalle = await _petFormationDbContext.Detalles.FirstOrDefaultAsync(x => x.ID_DETALLE == idDetalle);

            if (detalle == null)
            {
                return NotFound();
            }

            detalle.ID_VENTA = updateDetalleRequest.ID_VENTA;
            detalle.ID_CALUPRODUCT = updateDetalleRequest.ID_CALUPRODUCT;
            detalle.CANTIDAD_DETALLE = updateDetalleRequest.CANTIDAD_DETALLE;
            detalle.TIMESTAMP_DETALLE = updateDetalleRequest.TIMESTAMP_DETALLE;
            detalle.TOTAL_DETALLE = updateDetalleRequest.TOTAL_DETALLE;

            await _petFormationDbContext.SaveChangesAsync();

            return Ok(detalle);
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeleteDetalle([FromRoute] string id)
        {
            var idDetalle = Convert.ToInt32(id);
            var detalle = await _petFormationDbContext.Detalles.FirstOrDefaultAsync(x => x.ID_DETALLE == idDetalle);

            if (detalle == null)
            {
                return NotFound();
            }

            _petFormationDbContext.Detalles.Remove(detalle);
            await _petFormationDbContext.SaveChangesAsync();

            return Ok(detalle);
        }
    }
}
