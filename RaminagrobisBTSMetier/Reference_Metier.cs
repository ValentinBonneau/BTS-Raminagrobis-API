﻿using RaminagrobisBTS.DAL.Depot;
using RaminagrobisBTS.DAL.Model;
using RaminagrobisBTS.DTO;

namespace RaminagrobisBTS.Metier
{
    public class Reference_Metier
    {
        public int Id { get; set; }
        public string Ref { get; set; }
        public string Libele { get; set; }
        public string Marque { get; set; }

        #region Constructeur

        public Reference_Metier(int id,string reference,string libelle,string marque)
        {
            Id = id;
            Ref = reference;
            Libele = libelle;
            Marque = marque;
        }
        public Reference_Metier(string reference, string libelle, string marque) : this(new Reference_DAL(reference, libelle, marque))
        {
            //RINE
        }
        public Reference_Metier(Reference_DAL dal)
        {
            Ref = dal.Ref;
            Libele= dal.Libele;
            Marque = dal.Marque;
            Id = dal.Id;
        }
        #endregion

        public void AssoToFournisseur(int idFournisseur)
        {
            var depot = new Reference_Depot();
            depot.AssoToFournisseur(new Reference_DAL(Id, Ref, Libele, Marque),idFournisseur);
        }

        public static void UnAssoFournisseur(int idFournisseur)
        {
            var depot = new Reference_Depot();
            depot.UnAssoToFournisseur(idFournisseur);
        }

        public static IEnumerable<Reference_Metier> GetAll()
        {
            var depot = new Reference_Depot();
            var reponse = new List<Reference_Metier>();
            foreach (var item in depot.GetAll())
            {
                reponse.Add(new Reference_Metier(item));
            }
            return reponse;
        }

        public Reference_DTO toDTO()
        {
            return new Reference_DTO()
            {
                Id = Id,
                Ref = Ref,
                Libele = Libele,
                Marque = Marque
            };
        }
    }
}