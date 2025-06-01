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
        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromBody] Login login)
        {
            var user = await _petFormationDbContext.Login.FirstOrDefaultAsync(u => u.username == login.username);
            if (user.password == login.password)
            {
                user.logged = true;
                await _petFormationDbContext.SaveChangesAsync();
                return Ok(new { logged = true });
            }
            login.logged = false;
            return Unauthorized(new { logged = false });
        }

        //[HttpGet("logged-status")]
        //public async Task<bool> GetLoggedStatus()
        //{
        //    var logged = _petFormationDbContext.Login.FirstOrDefaultAsync(u => u.logged == true);

        //    return await _petFormationDbContext.Login.AnyAsync(u => u.logged == true);
        //}

        [HttpGet("logged-status")]
        public async Task<ActionResult<bool>> GetLoggedStatus()
        {
            try
            {
                bool isLogged = await _petFormationDbContext.Login.AnyAsync(u => u.logged == true);
                return Ok(isLogged);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error en el servidor: {ex.Message}");
            }
        }

    }
}

