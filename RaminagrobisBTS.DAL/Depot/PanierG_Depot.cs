using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RaminagrobisBTS.DAL.Model;
using System.Data.SqlClient;


namespace RaminagrobisBTS.DAL.Depot
{
    public class PanierG_Depot : Depot<PanierG_DAL>
    {


        public override IEnumerable<PanierG_DAL> GetAll()
        {
            throw new NotImplementedException();
        }

        public PanierG_DAL GetLast()
        {
            CreerConnexionEtCommande();

            commande.CommandText = "SELECT TOP (1) [Id],[semaine],[cloture] FROM [RaminagrobisBTS].[dbo].[PanierGlobal] Order by semaine desc";

            var reader = commande.ExecuteReader();
            PanierG_DAL reponse;

            if (reader.Read())
            {
                reponse = new PanierG_DAL(reader.GetInt32(0),reader.GetDateTime(1),reader.GetBoolean(2),new List<LignePanier_DAL>());
            }
            else // si il n'y a aucun pannier Global 
            {
                reponse = Insert(new PanierG_DAL()); // on en creer un et on renvoie celui ci
            }

            DetruireConnexionEtCommande();

            return reponse;

        }

        public override PanierG_DAL Insert(PanierG_DAL item)
        {
            CreerConnexionEtCommande();

            commande.CommandText = "INSERT INTO [dbo].[PanierGlobal] ([semaine], [cloture]) VALUES (@semaine , @cloture );select scope_identity()";
            commande.Parameters.Add(new SqlParameter("@semaine",item.Semaine));
            int cloture;
            if (item.Cloture) // conversion chiante bool / bit (HAHA IL A DIT BITE)
            {
                cloture = 1;
            }
            else
            {
                cloture = 2;
            }
            commande.Parameters.Add(new SqlParameter("@cloture", cloture));
            item.Id = Convert.ToInt32(commande.ExecuteScalar());

            DetruireConnexionEtCommande();
            
            return item;
        }

        public override PanierG_DAL Update(PanierG_DAL item)
        {
            throw new NotImplementedException();
        }

        public override void Delete(PanierG_DAL item)
        {
            throw new NotImplementedException();
        }
    }
}
