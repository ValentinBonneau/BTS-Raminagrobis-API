using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RaminagrobisBTS.DAL.Model
{
    public class PanierG_DAL
    {
        public int Id { get; set; }
        public DateTime Semaine { get; set; }
        public bool Cloture { get; set; }
        public IEnumerable<LignePanier_DAL> Lignes { get; set; }

        public PanierG_DAL(int id, DateTime semaine, bool cloture, IEnumerable<LignePanier_DAL> lignes) => (Id,Semaine,Cloture,Lignes) = (id,semaine,cloture,lignes);
        public PanierG_DAL(DateTime semaine, bool cloture, IEnumerable<LignePanier_DAL> lignes) => (Semaine,Cloture,Lignes) = (semaine,cloture,lignes);
        public PanierG_DAL()
        {
            Semaine = DateTime.Now;
            Cloture = false;
            Lignes = new List<LignePanier_DAL>();
        }
        
    }
}
