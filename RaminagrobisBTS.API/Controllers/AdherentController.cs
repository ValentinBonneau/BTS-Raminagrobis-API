using Microsoft.AspNetCore.Mvc;
using RaminagrobisBTS.DTO;
using RaminagrobisBTS.Metier;

namespace RaminagrobisBTS.API.Controllers
{
    [Route("Adherent")]
    [ApiController]
    public class AdherentController : Controller
    {
        // GET: AdherentController
        [HttpGet]
        public ActionResult<IEnumerable<Adherent_DTO>> Index()
        {
            var reponse = new List<Adherent_DTO>();
            foreach (var item in Adherent_Metier.GetAll())
            {
                reponse.Add(item.ToDTO());
            }
            return Ok(reponse);
        }

        // GET: AdherentController/Details/5
        [HttpGet("{id}")]
        public ActionResult<Adherent_DTO> Details(int id)
        {
            try
            {
                return Ok(Adherent_Metier.GetById(id).ToDTO());
            }
            catch
            {
                return NotFound();
            }
            
        }

        // POST: AdherentController/Create
        [HttpPost]
        public ActionResult<Adherent_DTO> Create([FromForm] Adherent_DTO adherent)
        {
            var metier = new Adherent_Metier(adherent.NomSociete, adherent.NomCivile, adherent.PrenomCivile, adherent.Email, adherent.Adresse, new DateOnly(adherent.DateAdhesion.Year,adherent.DateAdhesion.Month,adherent.DateAdhesion.Day));

            try
            {
                metier.CreerEnBDD();
                return Ok(metier.ToDTO());
            }
            catch
            {
                return Conflict();
            }
        }

        // Patch: AdherentController/Edit/5
        [HttpPatch("{id}")]
        public ActionResult<Adherent_DTO> Edit(int id, [FromForm] Adherent_DTO adherent)
        {
            try
            {
                var adh = new Adherent_Metier(adherent);
                adh.Id = id;
                return Ok(adh.Modifier().ToDTO());
            }
            catch
            {
                return Conflict();
            }
        }

        // GET: AdherentController/Delete/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            try
            {
                Adherent_Metier.Supprimer(id);
                return Ok();
            }
            catch 
            { 
                return Conflict(); 
            }
        }
    }
}
