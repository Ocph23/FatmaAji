using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ShareModel;
using WebApp.Data;
using WebApp.Models;
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
        private readonly Microsoft.AspNetCore.Hosting.IHostingEnvironment _env;
        public PendaftaranController(UserManager<ApplicationUser> _userManager, IPendaftaranService _pendaftaranService, Microsoft.AspNetCore.Hosting.IHostingEnvironment env)
        {
            userManager = _userManager;
            pendaftaranService = _pendaftaranService;
            _env = env;
        }

        [HttpGet]
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

        [HttpPut]
        public async Task<IActionResult> Put([FromBody]CalonPesertaDidik value)
        {
            try
            {
                var updated = await pendaftaranService.UpdateProfile(value!);
                return Ok(updated);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpPost("persyaratan/{id}")]
        public async Task<IActionResult> PostPersyaratan(int id, [FromBody] ItemPersyaratan model)
        {
            try
            {
                ItemPersyaratan result = await pendaftaranService.AddPersyaratan(id,model);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpPut("persyaratan/{id}")]
        public async Task<IActionResult> PutPersyaratan(int id, [FromBody] ItemPersyaratan model)
        {
            try
            {
                ItemPersyaratan result = await pendaftaranService.UpdatePersyaratan(id, model);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("upload/{id}")]
        public async Task<IActionResult> Upload(int id, IList<IFormFile> files)
        {

            var httprequest = HttpContext.Request.Form.Files;
            string filex = string.Empty;
            foreach (var file in httprequest)
            {
                var fileType = Path.GetExtension(file.FileName);
                //var ext = file.;
                if (fileType.ToLower() == ".pdf" || fileType.ToLower() == ".jpg" || fileType.ToLower() == ".png" || fileType.ToLower() == ".jpeg")
                {
                    var filePath = Path.Combine(_env.ContentRootPath, "wwwroot/files");
                    if (!Directory.Exists(filePath))
                        Directory.CreateDirectory(filePath);
                    var docName = Path.GetFileName(file.FileName);
                    if (file != null && file.Length > 0)
                    {
                        var Id = Guid.NewGuid();
                        var DocType = fileType;
                        filex = Id.ToString() + DocType;
                        var DocUrl = Path.Combine(filePath, filex);
                        using (var stream = new FileStream(DocUrl, FileMode.Create))
                        {
                            await file.CopyToAsync(stream);
                        }

                        //ItemPersyaratan result = await pendaftaranService.UpdatePersyaratan(id, model);
                    }
                    else
                    {
                        return BadRequest();
                    }
                }
            }
            return Ok(filex);
        }
    }
}
