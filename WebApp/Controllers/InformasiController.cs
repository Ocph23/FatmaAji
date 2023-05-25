using Microsoft.AspNetCore.Mvc;
using ShareModel;
using WebApp.Models;
using WebApp.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InformasiController : ControllerBase
    {
        private readonly IInformasiService informasiService;

        public InformasiController(IInformasiService _informasiService)
        {
            informasiService = _informasiService;
        }

        // GET: api/<InformasiController>
        [HttpGet]
        public async Task<IEnumerable<Informasi>> Get()
        {
           var result  = await informasiService.Get();
            return result.Where(x=>x.Publish);
        }
    }
}
