using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RaminagrobisBTS.DAL.Model
{
    public class Fournisseur_DAL
    {
        public int Id { get; set; }
        public string NomSociete { get; set; }
        public string NomCivile { get; set; }
        public string PrenomCivile { get; set; }
        public string Email { get; set; }
        public string Adresse { get; set; }
        public Fournisseur_DAL(string nomSociete, string nomCivile, string prenomCivile, string email, string adresse) => (NomSociete, NomCivile, PrenomCivile, Email, Adresse) = (nomSociete, nomCivile, prenomCivile, email, adresse);
        public Fournisseur_DAL(int id, string nomSociete, string nomCivile, string prenomCivile, string email, string adresse) => (Id, NomSociete, NomCivile, PrenomCivile, Email, Adresse) = (id, nomSociete, nomCivile, prenomCivile, email, adresse);

    }
}
