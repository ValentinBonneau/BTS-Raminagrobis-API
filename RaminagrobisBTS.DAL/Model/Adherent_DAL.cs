using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RaminagrobisBTS.DAL.Model
{
    public class Adherent_DAL
    {
        public int Id { get; set; }
        public string NomSociete { get; set; }
        public string NomCivile { get; set; }
        public string PrenomCivile { get; set; }
        public string Email { get; set; }
        public string Adresse { get; set; }
        public DateOnly DateAdhesion { get; private set; }

        public Adherent_DAL(string nomSociete,string nomCivile, string prenomCivile, string email, string adresse, DateOnly dateAdhesion) => (NomSociete,NomCivile,PrenomCivile,Email,Adresse,DateAdhesion) = (nomSociete,nomCivile,prenomCivile,email,adresse,dateAdhesion);
        public Adherent_DAL(int id,string nomSociete,string nomCivile, string prenomCivile, string email, string adresse, DateOnly dateAdhesion) => (Id,NomSociete,NomCivile,PrenomCivile,Email,Adresse,DateAdhesion) = (id,nomSociete,nomCivile,prenomCivile,email,adresse,dateAdhesion);
    }
}
