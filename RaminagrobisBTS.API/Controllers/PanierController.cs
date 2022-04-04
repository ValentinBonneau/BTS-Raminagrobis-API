using Microsoft.AspNetCore.Mvc;
using RaminagrobisBTS.DTO;
using RaminagrobisBTS.Metier;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RaminagrobisBTS.API.Controllers
{
    [Route("panier")]
    [ApiController]
    public class PanierController : Controller
    {
        [HttpPost("adherent/{id}")]
        public ActionResult<PanierA_DTO> Post(IFormFile file, int id)
        {
            try
            {
                var liste = new List<string>();
                using (StreamReader reader = new StreamReader(file.OpenReadStream()))
                {      
                    reader.ReadLine(); // c'est pour le haut des colones
                    while(!reader.EndOfStream)
                    {
                        liste.Add(reader.ReadLine());
                    }
                }
                var panier = new PanierA_Metier(id, liste);
                
                return Ok(panier.CreerEnBDD().ToDTO());
            }
            catch (Exception ex)
            {
                return Conflict(ex);
            }
        }
    }
    
}
