﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Raminagrobis.DAL
{
    public class Panier_DAL
    {
        public int ID { get; set; }
        public int IDAdherent { get; private set; }
        public int IDPanierG { get; set; }
        public List<LignePanier_DAL> Lignes { get; private set; }

        public Panier_DAL(IEnumerable<LignePanier_DAL> desLignes) => (Lignes) = (desLignes.ToList());

        public Panier_DAL(int id, int idAdherent, int idPanierG, IEnumerable<LignePanier_DAL> desLignes)
            => (ID, IDAdherent, IDPanierG, Lignes) = (id, idAdherent, idPanierG, desLignes.ToList());
        public Panier_DAL(int idAdherent, int idPanierG, IEnumerable<LignePanier_DAL> desLignes)
            => (IDAdherent, IDPanierG, Lignes) = (idAdherent, idPanierG, desLignes.ToList());
        public Panier_DAL(int id, int idAdherent) => (ID, IDAdherent) = (id, idAdherent);
    }
}
