﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RaminagrobisBTS.Metier;
using RaminagrobisBTS.DTO;

namespace RaminagrobisBTS.API.Controllers
{
    [Route("Reference")]
    [ApiController]
    public class ReferenceController : Controller
    {
        [HttpPost("{idFournisseur}")]
        public IActionResult AddRef(int idFournisseur, IFormFile file)
        {
            try
            {
           

                Reference_Metier.UnAssoFournisseur(idFournisseur);

                using (StreamReader reader = new StreamReader(file.OpenReadStream()))
                {
                    var topline = reader.ReadLine();
                    var columnName = topline.Split(";");
                    while (!reader.EndOfStream)
                    {
                        var line = reader.ReadLine();
                        var values = line.Split(';');

                        string refs = values[0];
                        string noms = values[1];
                        string marque = values[2];

                        var reference = new Reference_Metier(refs, noms, marque);
                        reference.AssoToFournisseur(idFournisseur);
                    }
                }

                return Ok();
            }
            catch (Exception ex)
            {
                return Conflict(ex);
            }
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                var reponse = new List<Reference_DTO>();
                foreach (var item in Reference_Metier.GetAll())
                {
                    reponse.Add(item.toDTO());
                }
                return Ok(reponse);
            }
            catch (Exception ex)
            {
                return Conflict(ex);
            }
        }
    }
}