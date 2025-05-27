using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PetFormation_APIS.Data;
using PetFormation_APIS.Models;
using System.Linq;

namespace PetFormation_APIS.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LoginController : ControllerBase
    {
        private readonly PetFormationDbContext _petFormationDbContext;
        public LoginController(PetFormationDbContext petFormationDbContext)
        {
            _petFormationDbContext = petFormationDbContext;
        }
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] login login)
        {
            var user = await _petFormationDbContext.Login.FirstOrDefaultAsync(u => u.username == login.username);
            if (user.password == login.password)
            {
                //// Genera un token de autenticación (JWT o similar)
                //var token = "tu_token_de_autenticacion"; // Cambia esto por una generación real de token
                //return Ok(new { token });
                return Ok("ACCESO CORRECTO");    
            }
            return Unauthorized();
        }
    }
}

