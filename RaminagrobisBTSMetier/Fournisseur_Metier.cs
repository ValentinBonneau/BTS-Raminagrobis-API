using RaminagrobisBTS.DAL.Depot;
using RaminagrobisBTS.DAL.Model;
using RaminagrobisBTS.DTO;

namespace RaminagrobisBTS.Metier
{
    public class Fournisseur_Metier : IMetier
    {

        public int Id { get; set; }
        public string NomSociete { get; set; }
        public string NomCivile { get; set; }
        public string PrenomCivile { get; set; }
        public string Email { get; set; }
        public string Adresse { get; set; }

        #region Constructeur
        public Fournisseur_Metier(int id, string nomSociete, string nomCivile, string prenomCivile, string email, string adresse)
            => (Id, NomSociete, NomCivile, PrenomCivile, Email, Adresse)
            = (id, nomSociete, nomCivile, prenomCivile, email, adresse);
        public Fournisseur_Metier(string nomSociete, string nomCivile, string prenomCivile, string email, string adresse)
            => (NomSociete, NomCivile, PrenomCivile, Email, Adresse)
            = (nomSociete, nomCivile, prenomCivile, email, adresse);
        public Fournisseur_Metier(Fournisseur_DAL adherent)
        {
            Id = adherent.Id;
            NomSociete = adherent.NomSociete;
            NomCivile = adherent.NomCivile;
            PrenomCivile = adherent.PrenomCivile;
            Email = adherent.Email;
            Adresse = adherent.Adresse;
        }

        public Fournisseur_Metier(Fournisseur_DTO adherent)
        {
            if (adherent.Id != null)
            {
                Id = (int)adherent.Id;

            }
            NomSociete = adherent.NomSociete;
            NomCivile = adherent.NomCivile;
            PrenomCivile = adherent.PrenomCivile;
            Email = adherent.Email;
            Adresse = adherent.Adresse;
        }

        #endregion

        public bool IsValid()
        {
            return (Email.Contains('@'));
        }

        public static IEnumerable<Fournisseur_Metier> GetAll()
        {
            var depot = new Fournisseur_Depot();
            var reponse = new List<Fournisseur_Metier>();
            foreach (var item in depot.GetAll())
            {
                reponse.Add(new Fournisseur_Metier(item));
            }
            return reponse;
        }

        public static Fournisseur_Metier GetById(int id)
        {
            var depot = new Fournisseur_Depot();
            return new Fournisseur_Metier(depot.GetByID(id));
        }

        public Fournisseur_Metier CreerEnBDD()
        {
            if (IsValid())
            {
                var depot = new Fournisseur_Depot();
                var newFourn = depot.Insert(new Fournisseur_DAL(NomSociete,NomCivile,PrenomCivile,Email,Adresse));
                Id = newFourn.Id;
                return this;
            }
            else
            {
                return null;
            }
        }

        public Fournisseur_Metier Modifier()
        {
            var depot = new Fournisseur_Depot();
            return new Fournisseur_Metier(depot.Update(new Fournisseur_DAL(Id,NomSociete,NomCivile,PrenomCivile,Email,Adresse)));
        }

        public Fournisseur_DTO ToDTO()
        {
            return new Fournisseur_DTO()
            {
                Id = Id,
                NomCivile = NomCivile,
                NomSociete = NomSociete,
                PrenomCivile = PrenomCivile,
                Email = Email,
                Adresse = Adresse,
            };
        }



    }
}
