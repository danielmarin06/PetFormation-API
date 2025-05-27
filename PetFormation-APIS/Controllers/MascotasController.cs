using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PetFormation_APIS.Data;
using PetFormation_APIS.Models;

namespace PetFormation_APIS.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MascotasController : Controller
    {
        private readonly PetFormationDbContext _petFormationDbContext; 
    
        public MascotasController (PetFormationDbContext petFormationDbContext)
        {
            _petFormationDbContext = petFormationDbContext;
        }

        [HttpGet]
        public async Task<IActionResult> GetMascotas()
        {
            var mascotas = await _petFormationDbContext.Mascotas.ToListAsync();

            return Ok(mascotas);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetMascota(string id)
        {
            var idCliente = id;
            var mascotas = await _petFormationDbContext.Mascotas.Where(x => x.ID_CLIENTE == idCliente).ToListAsync();

            return Ok(mascotas);
        }

        [HttpGet]
        [Route("mascota/{id}")]
        public async Task<IActionResult> GetMascotaMascoTable(string id)
        {
            var idMascota = Convert.ToInt64(id);
            var mascotas = _petFormationDbContext.Mascotas.FirstOrDefault(x => x.ID_MASCOTA == idMascota);

            return Ok(mascotas);
        }

        [HttpPost]
        public async Task<IActionResult> AddMascotas([FromBody] mascotas mascotas)
        {
            mascotas.ID_MASCOTA = new int();

            await _petFormationDbContext.Mascotas.AddAsync(mascotas);
            await _petFormationDbContext.SaveChangesAsync();

            return Ok(mascotas);
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> UpdateMascota([FromRoute] string id, mascotas updateMascota)
        {
            var idMascota = Convert.ToInt32(id);

            var mascota = await _petFormationDbContext.Mascotas.FirstOrDefaultAsync(x => x.ID_MASCOTA == idMascota);

            if (mascota == null)
            {
                return NotFound();
            }
            //DateTime.TryParse(updateMascota.FECHA_NACIMIENTO_MASCOTA, out DateTime fechaNacimiento);

            mascota.NOMBRE_MASCOTA = updateMascota.NOMBRE_MASCOTA;
            mascota.FECHA_NACIMIENTO_MASCOTA = updateMascota.FECHA_NACIMIENTO_MASCOTA;
            mascota.TIPO_MASCOTA = updateMascota.TIPO_MASCOTA;
            mascota.RAZA_MASCOTA = updateMascota.RAZA_MASCOTA;
            mascota.TAMANO_MASCOTA = updateMascota.TAMANO_MASCOTA;
            mascota.GENERO_MASCOTA = updateMascota.GENERO_MASCOTA;
            mascota.ID_CLIENTE = updateMascota.ID_CLIENTE;

            await _petFormationDbContext.SaveChangesAsync();

            return Ok(mascota);
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeleteMascota([FromRoute] string id)
        {
            var idMascota = Convert.ToInt32(id);
            var mascota = await _petFormationDbContext.Mascotas.FirstOrDefaultAsync(x => x.ID_MASCOTA == idMascota);

            if (mascota == null)
            {
                return NotFound();
            }

            _petFormationDbContext.Mascotas.Remove(mascota);
            await _petFormationDbContext.SaveChangesAsync();

            return Ok(mascota);
        }

    }
}
