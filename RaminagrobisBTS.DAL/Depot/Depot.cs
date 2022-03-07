
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;

namespace RaminagrobisBTS.DAL.Depot
{
    abstract public class Depot<Type_DAL> : IDepot<Type_DAL>
    {
        public string ChaineDeConnexion { get; set; }

        protected SqlConnection connexion;
        protected SqlCommand commande;

        public Depot()
        {
            var builder = new ConfigurationBuilder();
            var config = builder.AddJsonFile("appsettings.json", false, true).Build();
            ChaineDeConnexion = config.GetSection("ConnectionStrings:default").Value;
            if (ChaineDeConnexion == null)
            {
                throw new Exception($"la chaine de connexion n'est pas definie {config.GetSection("ConnectionStrings").GetChildren().ToString()}");
            }
            //TODO la chaine de connexion fonctione pas
        }

        protected void CreerConnexionEtCommande()
        {
            connexion = new SqlConnection(ChaineDeConnexion);
            connexion.Open();
            commande = new SqlCommand();
            commande.Connection = connexion;
        }

        protected void DetruireConnexionEtCommande()
        {
            commande.Dispose();
            connexion.Close();
            connexion.Dispose();

        }
        #region Méthodes Abstraite
        public abstract IEnumerable<Type_DAL> GetAll();

        public abstract Type_DAL Insert(Type_DAL item);

        public abstract Type_DAL Update(Type_DAL item);

        public abstract void Delete(Type_DAL item);
        #endregion
    }
}
