using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MySqlX.XDevAPI;
using PetFormation_APIS.Data;
using PetFormation_APIS.Models;

namespace PetFormation_APIS.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CaluproductController : Controller
    {
        private readonly PetFormationDbContext _petFormationDbContext;
        public CaluproductController(PetFormationDbContext petFormationDbContext)
        {
            _petFormationDbContext = petFormationDbContext;
        }

        [HttpGet]
        public async Task<IActionResult> GetCaluproducts()
        {
            var caluproduct = await _petFormationDbContext.Caluproduct.ToListAsync();

            return Ok(caluproduct);
        }

        [HttpPost]
        public async Task<IActionResult> AddProducto([FromBody] caluproduct calu)
        {
            calu.ID_CALUPRODUCT = new int();

            await _petFormationDbContext.Caluproduct.AddAsync(calu);
            await _petFormationDbContext.SaveChangesAsync();

            return Ok(calu);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetCaluproduct([FromRoute] string id)
        {
            var idCaluProducto = Convert.ToInt32(id);

            var calu = await _petFormationDbContext.Caluproduct.FirstOrDefaultAsync(x => x.ID_CALUPRODUCT == idCaluProducto);

            if (calu == null)
            {
                return NotFound();
            }

            return Ok(calu);
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> UpdateCaluproduct([FromRoute] string id, caluproduct updateCaluproductsRequest)
        {
            var idCaluProducto = Convert.ToInt32(id);

            var calu = await _petFormationDbContext.Caluproduct.FirstOrDefaultAsync(x => x.ID_CALUPRODUCT == idCaluProducto);

            if (calu == null)
            {
                return NotFound();
            }

            calu.NOMBRE_CALUPRODUCT = updateCaluproductsRequest.NOMBRE_CALUPRODUCT;
            calu.TAMANO_CALUPRODUCT = updateCaluproductsRequest.TAMANO_CALUPRODUCT;
            calu.CARACTERISTICA_CALUPRODUCT = updateCaluproductsRequest.CARACTERISTICA_CALUPRODUCT;
            calu.TIMESTAMP = updateCaluproductsRequest.TIMESTAMP;
            calu.PRECIO_CALUPRODUCT = updateCaluproductsRequest.PRECIO_CALUPRODUCT;

            await _petFormationDbContext.SaveChangesAsync();

            return Ok(calu);
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeleteCaluproduct([FromRoute] string id)
        {
            var idCaluProducto = Convert.ToInt32(id);
            var calu = await _petFormationDbContext.Caluproduct.FirstOrDefaultAsync(x => x.ID_CALUPRODUCT == idCaluProducto);

            if (calu == null)
            {
                return NotFound();
            }

            _petFormationDbContext.Caluproduct.Remove(calu);
            await _petFormationDbContext.SaveChangesAsync();

            return Ok(calu);
        }
    }
}
