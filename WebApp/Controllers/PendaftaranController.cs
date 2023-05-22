using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;
using ShareModel;
using System.Security.Claims;
using WebApp.Data;
using WebApp.Services;

namespace WebApp.Controllers
{

    [ApiAuthorize(Roles = "Pendaftar")]
    [Route("api/[controller]")]
    [ApiController]
    public class PendaftaranController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly IPendaftaranService pendaftaranService;

        public PendaftaranController(UserManager<ApplicationUser> _userManager, IPendaftaranService _pendaftaranService)
        {
            userManager = _userManager;
            pendaftaranService = _pendaftaranService;
        }

        [HttpPost("profile")]
        public async Task<IActionResult> CreateProfile()
        {
            try
            {
                var userid = userManager.GetUserId(User);
                var profile = await pendaftaranService.CreateProfile(userid!);
                return Ok(profile);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("profile")]
        public async Task<IActionResult> GetProfile()
        {
            try
            {
                var userid = userManager.GetUserId(User);
                var profile = await pendaftaranService.GetByUserId(userid!);
                return Ok(profile);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
