﻿namespace RaminagrobisBTS.DTO
{
    public class Adherent_DTO
    {
        public int? Id { get; set; }
        public string NomSociete { get; set; }
        public string NomCivile { get; set; }
        public string PrenomCivile { get; set; }
        public string Email { get; set; }
        public string Adresse { get; set; }
        public DateTime DateAdhesion { get; set; }
    }
}