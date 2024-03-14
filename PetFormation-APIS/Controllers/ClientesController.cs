using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PetFormation_APIS.Data;
using PetFormation_APIS.Models;

namespace PetFormation_APIS.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClientesController : Controller
    {
        private readonly PetFormationDbContext _petFormationDbContext;
        public ClientesController(PetFormationDbContext petFormationDbContext)
        {
            _petFormationDbContext = petFormationDbContext;
        }

        [HttpGet]
        public async Task<IActionResult> GetClientes()
        {
            var clientes = await _petFormationDbContext.Clientes.ToListAsync();

            return Ok(clientes);
        }

        [HttpPost]
        public async Task<IActionResult> AddClientes([FromBody] cliente clientes)
        {
            clientes.ID_CLIENTE = new int();

            await _petFormationDbContext.Clientes.AddAsync(clientes);
            await _petFormationDbContext.SaveChangesAsync();

            return Ok(clientes);
        }
    }
}
