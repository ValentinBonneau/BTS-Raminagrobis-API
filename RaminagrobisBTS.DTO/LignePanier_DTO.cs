using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RaminagrobisBTS.DTO
{
    public class LignePanier_DTO
    {
        public int Id { get; set; }
        public Reference_DTO Reference { get; set; }
        public int Quantite { get; set; }
        public int? Prix { get; set; }

    }
}
