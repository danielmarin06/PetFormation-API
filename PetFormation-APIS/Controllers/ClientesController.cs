using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MySqlX.XDevAPI;
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
            var cliente = await _petFormationDbContext.Clientes.ToListAsync();

            return Ok(cliente);
        }

        [HttpPost]
        public async Task<IActionResult> AddClientes([FromBody] clientes cliente)
        {
            if (cliente.ID_CLIENTE != null && cliente.TELEFONO_CLIENTE != null)
            {
                //cliente.ID_CLIENTE = new string();

                await _petFormationDbContext.Clientes.AddAsync(cliente);
                await _petFormationDbContext.SaveChangesAsync();

                return Ok(cliente);
            }
            else
            {
                return BadRequest();
            }

        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetCliente([FromRoute] string id)
        {
            //var idCliente = Convert.ToInt32(id);

            var cliente = await _petFormationDbContext.Clientes.FirstOrDefaultAsync(x => x.ID_CLIENTE == id);

            if (cliente == null)
            {
                return NotFound();
            }

            return Ok(cliente);
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> UpdateCliente([FromRoute] string id, clientes updateClienteRequest)
        {
            //var idCliente = Convert.ToInt32(id);

            var cliente = await _petFormationDbContext.Clientes.FirstOrDefaultAsync(x => x.ID_CLIENTE == id);

            if (cliente == null)
            {
                return NotFound();
            }

            cliente.ID_CLIENTE = updateClienteRequest.ID_CLIENTE;
            cliente.NOMBRE_CLIENTE = updateClienteRequest.NOMBRE_CLIENTE;
            cliente.TELEFONO_CLIENTE = updateClienteRequest.TELEFONO_CLIENTE;
            cliente.DIRECCION_CLIENTE = updateClienteRequest.DIRECCION_CLIENTE;
            cliente.CORREO_CLIENTE = updateClienteRequest.CORREO_CLIENTE;
            

            await _petFormationDbContext.SaveChangesAsync();

            return Ok(cliente);
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeleteCliente([FromRoute] string id)
        {
            //var idCliente = Convert.ToInt32(id);
            var cliente = await _petFormationDbContext.Clientes.FirstOrDefaultAsync(x => x.ID_CLIENTE == id);

            if (cliente == null)
            {
                return NotFound();
            }

            _petFormationDbContext.Clientes.Remove(cliente);
            await _petFormationDbContext.SaveChangesAsync();

            return Ok(cliente);
        }
    }
}
