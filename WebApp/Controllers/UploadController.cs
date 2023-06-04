using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ShareModel;
using WebApp.Data;
using WebApp.Models;
using WebApp.Services;

namespace WebApp.Controllers
{

    [Route("[controller]")]
    [DisableRequestSizeLimit]
    public class UploadController : Controller
    {
        private readonly IWebHostEnvironment environment;

        public UploadController(IWebHostEnvironment environment)
        {
            this.environment = environment;
        }

        [HttpPost("single")]
        public IActionResult Single(IFormFile file)
        {
            try
            {
                // Put your code here
                return Ok(new { Completed = true });
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost("image")]
        public IActionResult Image(IFormFile file)
        {
            try
            {
                // Used for demo purposes only
               // DeleteOldFiles();

                var fileName = $"upload-{DateTime.Today.ToString("yyyy-MM-dd")}-{Guid.NewGuid()}{Path.GetExtension(file.FileName)}";

                var path = Path.Combine(environment.WebRootPath, "upload", "images");

                using (var stream = new FileStream(Path.Combine(path, fileName), FileMode.Create))
                {
                    // Save the file
                    file.CopyTo(stream);

                    // Return the URL of the file
                    var url = Url.Content($"~/upload/images/{fileName}");

                    return Ok(new { Url = url });
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        void DeleteOldFiles()
        {
            foreach (var file in Directory.GetFiles(environment.WebRootPath))
            {
                var fileName = Path.GetFileName(file);

                if (fileName.StartsWith("upload-") && !fileName.StartsWith($"upload-{DateTime.Today.ToString("yyyy-MM-dd")}"))
                {
                    try
                    {
                        System.IO.File.Delete(file);
                    }
                    catch
                    {

                    }
                }
            }
        }

        [HttpPost("multiple")]
        public IActionResult Multiple(IFormFile[] files)
        {
            try
            {
                // Put your code here
                return StatusCode(200);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost("{id}")]
        public IActionResult Post(IFormFile[] files, int id)
        {
            try
            {
                // Put your code here
                return StatusCode(200);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost("specific")]
        public IActionResult Specific(IFormFile myName)
        {
            try
            {
                // Put your code here
                return Ok(new { Completed = true });
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

    }
}
