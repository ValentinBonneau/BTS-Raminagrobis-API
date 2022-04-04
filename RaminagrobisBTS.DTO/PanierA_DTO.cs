using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RaminagrobisBTS.DTO
{
    public class PanierA_DTO
    {
        public int? Id { get; set; }
        public IEnumerable<LignePanier_DTO> Ligne { get; set; }
        public int IdAdherent { get; set; }
        public int? IdPanierG { get; set; }
    }
    
}
