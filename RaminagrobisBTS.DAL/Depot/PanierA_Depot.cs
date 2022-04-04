using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RaminagrobisBTS.DAL.Model;
using System.Data.SqlClient;

namespace RaminagrobisBTS.DAL.Depot
{
    public class PanierA_Depot : Depot<PanierA_DAL>
    {


        public override IEnumerable<PanierA_DAL> GetAll()
        {
            throw new NotImplementedException();
        }

        public override PanierA_DAL Insert(PanierA_DAL item)
        {
            CreerConnexionEtCommande();

            commande.CommandText = "INSERT INTO [dbo].[Panier] ([IdAdherent] ,[IdPanierGlobal]) VALUES (@idA,@idPG); select scope_identity()";
            commande.Parameters.Add(new SqlParameter("@idA", item.IdAdherent));
            commande.Parameters.Add(new SqlParameter("@idPG", item.IdPanierG));

            item.Id = Convert.ToInt32(commande.ExecuteScalar());

            foreach (var ligne in item.Lignes)
            {
                ligne.IdPanier = item.Id;
                var depot = new LignePA_Depot();
                depot.Insert(ligne);
            }

            DetruireConnexionEtCommande();
            return item;
        }

        public override PanierA_DAL Update(PanierA_DAL item)
        {
            throw new NotImplementedException();
        }

        public override void Delete(PanierA_DAL item)
        {
            throw new NotImplementedException();
        }
    }
}
