using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ShareModel;
using WebApp.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IUserService userService;
        private readonly IAntrianZonasiService zonasiService;

        public AccountController(IUserService _userService, IAntrianZonasiService _zonasiService)
        {
            userService = _userService;
            zonasiService = _zonasiService;
        }


        [ApiAuthorize(Roles = "Pendaftar, Admin")]
        [HttpGet]
        public async Task<IActionResult> Get()
        {

            return Ok(new List<string>());
        }


        // POST api/<AccountController>
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterRequest value)
        {
            try
            {
                return Ok(await userService.Register(value));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }


        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequest value)
        {

            try
            {
                return Ok(await userService.Authenticate(value));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }



        [HttpGet("zonasi")]
        public async Task<IActionResult> GetZonasi()
        {
              return Ok(await zonasiService.Get());   
           

        }



    }
}
