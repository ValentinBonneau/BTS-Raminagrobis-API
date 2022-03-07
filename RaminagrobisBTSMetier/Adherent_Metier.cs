using RaminagrobisBTS.DAL.Depot;
using RaminagrobisBTS.DAL.Model;
using RaminagrobisBTS.DTO;

namespace RaminagrobisBTS.Metier
{
    public class Adherent_Metier : IMetier
    {
        public int Id { get; set; }
        public string NomSociete { get; set; }
        public string NomCivile { get; set; }
        public string PrenomCivile { get; set; }
        public string Email { get; set; }
        public string Adresse { get; set; }
        public DateOnly DateAdhesion { get; set; }


        #region Constructeur
        public Adherent_Metier(int id, string nomSociete, string nomCivile, string prenomCivile, string email, string adresse, DateOnly dateAdhesion)
            => (Id, NomSociete, NomCivile, PrenomCivile, Email, Adresse, DateAdhesion)
            = (id, nomSociete, nomCivile, prenomCivile, email, adresse, dateAdhesion);
        public Adherent_Metier(string nomSociete, string nomCivile, string prenomCivile, string email, string adresse, DateOnly dateAdhesion)
            => (NomSociete, NomCivile, PrenomCivile, Email, Adresse, DateAdhesion)
            = (nomSociete, nomCivile, prenomCivile, email, adresse, dateAdhesion);
        public Adherent_Metier(Adherent_DAL adherent)
        {
            Id = adherent.Id;
            NomSociete = adherent.NomSociete;
            NomCivile = adherent.NomCivile;
            PrenomCivile = adherent.PrenomCivile;
            Email = adherent.Email;
            Adresse = adherent.Adresse;
            DateAdhesion = adherent.DateAdhesion;
        }

        public Adherent_Metier(Adherent_DTO adherent)
        {
            if(adherent.Id != null) {
                Id = (int)adherent.Id;

            }
            NomSociete = adherent.NomSociete;
            NomCivile = adherent.NomCivile;
            PrenomCivile = adherent.PrenomCivile;
            Email = adherent.Email;
            Adresse = adherent.Adresse;
            DateAdhesion = new DateOnly(adherent.DateAdhesion.Year, adherent.DateAdhesion.Month, adherent.DateAdhesion.Day);
        }



        #endregion

        public bool IsValid()
        {
            return (Email.Contains('@'));
        }

        public static IEnumerable<Adherent_Metier> GetAll()
        {
            var depot = new Adherent_Depot();
            var reponse = new List<Adherent_Metier>();
            foreach (var item in depot.GetAll())
            {
                reponse.Add(new Adherent_Metier(item));
            }
            return reponse;
        }



        public Adherent_Metier CreerEnBDD()
        {
            
            if (IsValid())
            {
                var depot = new Adherent_Depot();
                Id = depot.Insert(new Adherent_DAL(NomSociete,NomCivile,PrenomCivile,Email,Adresse,DateAdhesion)).Id;
                return this;
            }
            else
            {
                return null;
            }
        }

        public static Adherent_Metier GetById(int id)
        {
            var depot = new Adherent_Depot();
            return new Adherent_Metier(depot.GetById(id));
        }

        public Adherent_Metier Modifier()
        {

            var depot = new Adherent_Depot();
            return new Adherent_Metier(depot.Update(new Adherent_DAL(Id, NomSociete, NomCivile, PrenomCivile, Email, Adresse, DateAdhesion)));
        }

        public static void Supprimer(int id)
        {
            var depot = new Adherent_Depot();
            depot.Delete(depot.GetById(id));

        }


        public Adherent_DTO ToDTO()
        {
            return new Adherent_DTO()
            {
                Id = Id,
                NomCivile = NomCivile,
                NomSociete = NomSociete,
                PrenomCivile = PrenomCivile,
                Email = Email,
                Adresse = Adresse,
                DateAdhesion = new DateTime(DateAdhesion.Year, DateAdhesion.Month, DateAdhesion.Day)
            };
        }
    }
}