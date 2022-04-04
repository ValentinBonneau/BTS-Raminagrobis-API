using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RaminagrobisBTS.DAL.Model;
using RaminagrobisBTS.DAL.Depot;
using RaminagrobisBTS.DTO;

namespace RaminagrobisBTS.Metier
{
    public class PanierA_Metier : IMetier
    {
        public int Id { get; set; }
        public IEnumerable<LignePanier_Metier> Lignes { get; set; }
        public int IdAdherent { get; set; }
        public int? IdPanierG { get; set; }

        #region Constructeur
        public PanierA_Metier(int idAdherent, IEnumerable<string> lignesCSV)
        {
            IdAdherent = idAdherent;
            var lignes = new List<LignePanier_Metier>();
            foreach (var item in lignesCSV)
            {
                var ligne = item.Split(";");
                lignes.Add(new LignePanier_Metier(new Reference_Metier(new Reference_DAL(ligne[0],"","")),Convert.ToInt32(ligne[1]),LignePanierType_Metier.Adherent));
            }
            Lignes = lignes;
        }

        #endregion

        public PanierA_Metier CreerEnBDD()
        {
            if (IsValid())
            {
                var depot = new PanierA_Depot();
                var ligne = new List<LignePanier_DAL>();
                foreach (var item in Lignes)
                {
                    ligne.Add(new LignePanier_DAL(item.Reference.Id,item.Quantite,LignePanierType.Adherent));
                }
                var trace = depot.Insert(new PanierA_DAL(IdAdherent,ligne ));
                Id = trace.Id;
                IdPanierG = trace.IdPanierG;
                foreach(var item in trace.Lignes)
                {
                    Lignes.First(x => x.Reference.Id == item.IdReference).Id =item.Id;
                }

                return this;
            }
            else
            {
                return null;
            }
        }


        public PanierA_DTO ToDTO()
        {
            var liste = new List<LignePanier_DTO>();
            foreach (var item in Lignes)
            {
                liste.Add(new LignePanier_DTO()
                {
                    Id = item.Id,
                    Quantite = item.Quantite,
                    Reference = new Reference_DTO()
                    {
                        Id = item.Reference.Id,
                        Libele = item.Reference.Libele,
                        Marque = item.Reference.Marque,
                        Ref = item.Reference.Ref
                    }
                });
            }
            return new PanierA_DTO()
            {
                Id = Id,
                IdAdherent = IdAdherent,
                IdPanierG = IdPanierG,
                Ligne = liste
            };
        }
        public bool IsValid()
        {
            //todo: mettre des condition valide
            return true;
        }
    }
}
