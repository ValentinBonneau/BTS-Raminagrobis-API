using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RaminagrobisBTS.DAL.Model
{
    public class LignePanier_DAL
    {
        public int Id { get; set; }
        public int IdReference { get; set; }
        public LignePanierType LignePanierType { get; set; }
        public int Quantite { get; set; }
        public int IdPanier { get; set; }
        public LignePanier_DAL(int id, int idRef, int quantite, LignePanierType type, int idPanier) => (Id, IdReference, Quantite, LignePanierType, IdPanier) = (id, idRef, quantite, type, idPanier);
        public LignePanier_DAL(int idRef, int quantite, LignePanierType type) => (IdReference, Quantite, LignePanierType) = (idRef, quantite, type);

    
    }
    public enum LignePanierType
    {
        Adherent,
        Global
    }
}
