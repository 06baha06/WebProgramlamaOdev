using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebProgramlamaOdev.Models;

namespace EFCoreExample1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BolumApiController : ControllerBase
    {
        private BolumlerContext _context = new BolumlerContext();
        // GET: api/<Ogrenci Controller>
        [HttpGet]
        public IEnumerable<Bolum> Get()
        {
            var bolumler = _context.Bolumler.ToList();
            return bolumler;
        }
        // GET api/<OgrenciController>/5
        [HttpGet("{id}")]
        public Bolum Get(int id)
        {
            var y = _context.Bolumler.FirstOrDefault(x => x.BolumID == id);
            return y;
        }
        // POST api/<ApiDeneme>
        [HttpPost]
        public ActionResult<Bolum> Post([FromBody] Bolum bolum)
        {

            _context.Bolumler.Add(bolum);
            _context.SaveChanges();

            return CreatedAtAction(nameof(Get), new { id = bolum.BolumID }, bolum);
        }

        // PUT api/<ApiDeneme>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ApiDeneme>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
   
//// POST api/<OgrenciController>
//[HttpPost]
//    public void Post([FromBody] Yazar y)
//    {
//    }
//    k.Yazarlar.Add(y);
//k.SaveChanges();