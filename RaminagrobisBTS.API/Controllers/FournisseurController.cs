using Microsoft.AspNetCore.Mvc;
using RaminagrobisBTS.DTO;
using RaminagrobisBTS.Metier;

namespace RaminagrobisBTS.API.Controllers
{
    [Route("Fournisseur")]
    [ApiController]
    public class FournisseurController : Controller
    {
        // GET: api/<FournisseurController>
        [HttpGet]
        public ActionResult<IEnumerable<Fournisseur_DTO>> Get()
        {
            var reponse = new List<Fournisseur_DTO>();
            foreach (var item in Fournisseur_Metier.GetAll())
            {
                reponse.Add(item.ToDTO());
            }
            return Ok(reponse);

        }

        // GET api/<FournisseurController>/5
        [HttpGet("{id}")]
        public ActionResult<Fournisseur_DTO> Get(int id)
        {
            try
            {
                return Ok(Fournisseur_Metier.GetById(id).ToDTO());
            }
            catch
            {
                return NotFound();
            }
        }

        // POST api/<FournisseurController>
        [HttpPost]
        public ActionResult<Fournisseur_DTO> Post([FromForm] Fournisseur_DTO fournisseur)
        {
            try
            {
                var fournMetier = new Fournisseur_Metier(fournisseur);
                fournMetier.CreerEnBDD();
                return Ok(fournMetier.ToDTO());
            }
            catch(Exception ex)
            {
                return Conflict(ex);
            }
        }

        // PUT api/<FournisseurController>/5
        [HttpPatch("{id}")]
        public ActionResult<Fournisseur_DTO> Patch(int id, [FromForm] Fournisseur_DTO fournisseur)
        {
            try
            {
                var fourn = new Fournisseur_Metier(fournisseur);
                fourn.Id = id;
                return Ok(fourn.Modifier().ToDTO());
            }
            catch
            {
                return Conflict();
            }
        }
    }
}
