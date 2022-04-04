using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RaminagrobisBTS.DAL.Depot;

namespace RaminagrobisBTS.DAL.Model
{
    public class PanierA_DAL
    {
        public int Id { get; set; }
        public int IdAdherent { get; set; }
        public int IdPanierG { get; set; }
        public IEnumerable<LignePanier_DAL> Lignes { get; set; }

        public PanierA_DAL(int id, int idA, int IdPG, IEnumerable<LignePanier_DAL> lignes) => (Id, IdAdherent, IdPanierG, Lignes) = (id, idA, IdPG, lignes);
        public PanierA_DAL(int idA, IEnumerable<LignePanier_DAL> lignes)
        {
            (IdAdherent, Lignes) = (idA, lignes);
            var depot = new PanierG_Depot();
            IdPanierG = depot.GetLast().Id;
        }
    }
}
