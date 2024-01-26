using ConvertisseurWS.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ConvertisseurWS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DevisesController : ControllerBase
    {
        public List<Devise> ListDevises;
        public DevisesController()
        {
            ListDevises = new List<Devise>();
            ListDevises.Add(new Devise(1, "Dollar", 1.08));
            ListDevises.Add(new Devise(2, "FrancSuisse", 1.07));
            ListDevises.Add(new Devise(3, "Yen", 120));
            /*
            Devise deviseDollar = new Devise(1, "Dollar", 1.08);
            Devise deviseFrancSuisse = new Devise(2, "FrancSuisse", 1.07);
            Devise deviseYen = new Devise(3, "Yen", 120);
            */
        }

        // GET: api/<DevisesController>
        [HttpGet]
        public IEnumerable<Devise> GetAll()
        {
            return ListDevises;
        }

        // GET api/<DevisesController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<DevisesController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<DevisesController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<DevisesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
