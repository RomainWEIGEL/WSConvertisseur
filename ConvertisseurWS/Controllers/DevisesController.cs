using ConvertisseurWS.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ConvertisseurWS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DevisesController : ControllerBase
    {
        ///<summary></summary> : Constructeur du controller qui gère les devises
        ///<returns><returns> : pas de valeur retour
        ///<response code="404"></response> : rien
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

        ///<summary></summary> : récupère les devises pour les affiché
        ///<remarks></remarks> : faut qu'il soit gérer avant
        ///<returns><returns> : Liste des devises
        ///<response code="404"></response> : rien
        // GET: api/<DevisesController>
        [HttpGet]
        public IEnumerable<Devise> GetAll()
        {
            return ListDevises;
        }

        ///<summary></summary> : affiche une devise depuis son id
        ///<returns><returns> : Description de la valeur de retour
        ///<param name="id"></param> : récupère l'id de devise
        ///<response code="404"></response> : affiche qu'il ne le trouve pas
        // GET api/<DevisesController>/5
        [HttpGet("{id}", Name = "GetDevise")]
        public ActionResult<Devise> GetById(int id)
        {
            Devise? devise = ListDevises.FirstOrDefault((d) => d.Id == id);
            if (devise == null)
            {
                return NotFound();
            }
            return devise;
        }

        ///<summary></summary> : ajoute une devise dans une liste passer en parametre
        ///<returns><returns> : montre le résultat
        ///<param name="devise"></param> : rentre une devise pour l'ajouter
        ///<response code="404"></response> : affiche que c'est une mauvaise requet
        // POST api/<DevisesController>
        [HttpPost]
        public ActionResult<Devise> Post([FromBody] Devise devise)
        {
            if (!ModelState.IsValid || devise.NomDevise == null)
            {
                return BadRequest(ModelState);
            }
            ListDevises.Add(devise);
            return CreatedAtAction("GetById", new { id = devise.Id }, devise);

        }

        ///<summary></summary> : modifie une devise dans la liste passer en parametre
        ///<returns><returns> : renvoie si c'est une bonne request ou non
        ///<param name="devise"></param> : rentre une devise existante pour la modifier
        ///<response code="404"></response> : mauvaise request
        // PUT api/<DevisesController>/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Devise devise)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (id != devise.Id)
            {
                return BadRequest();
            }
            int index = ListDevises.FindIndex((d) => d.Id == id);
            if (index < 0)
            {
                return NotFound();
            }
            ListDevises[index] = devise;
            return NoContent();
        }

        ///<summary></summary> : supprime une valeur dans le tableau
        ///<returns><returns> : rien
        ///<param name="id"></param> : rentre un id existant pour supprimer la devise
        ///<response code="404"></response> : mauvaise request
        // DELETE api/<DevisesController>/5
        [HttpDelete("{id}", Name = "GetDevise")]
        public void Delete(int id)
        {
            Devise? devise = ListDevises.FirstOrDefault((d) => d.Id == id);
            
            ListDevises.Remove( devise);
        }
    }
}
