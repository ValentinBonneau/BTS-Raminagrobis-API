using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RaminagrobisBTS.Metier
{
    public class LignePanier_Metier
    {
        public int Id { get; set; }
        public Reference_Metier Reference { get; set; }
        public int Quantite { get; set; }
        public int? Prix { get; set; }
        public LignePanierType_Metier Type { get; set; }
        #region Constructeur
        public LignePanier_Metier(Reference_Metier reference, int quantite, LignePanierType_Metier type)
        {
            Type = type;
            Quantite = quantite;
            Reference = reference;
        }
        #endregion

    }

    public enum LignePanierType_Metier
    {
        Adherent,
        Global
    }
}
