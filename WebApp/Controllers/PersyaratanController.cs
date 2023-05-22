using Microsoft.AspNetCore.Mvc;
using ShareModel;
using WebApp.Models;
using WebApp.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersyaratanController : ControllerBase
    {
        private readonly IPersyaratanService persyaratanService;

        public PersyaratanController(IPersyaratanService _persyaratanService)
        {
            persyaratanService = _persyaratanService;
        }

        // GET: api/<PersyaratanController>
        [HttpGet]
        public Task<IEnumerable<Persyaratan>> Get()
        {
           return persyaratanService.Get();
        }

        // GET api/<PersyaratanController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<PersyaratanController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<PersyaratanController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<PersyaratanController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
