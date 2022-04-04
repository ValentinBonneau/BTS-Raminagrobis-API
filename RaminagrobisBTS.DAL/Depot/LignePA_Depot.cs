using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RaminagrobisBTS.DAL.Model;
using System.Data.SqlClient;

namespace RaminagrobisBTS.DAL.Depot
{
    public class LignePA_Depot : Depot<LignePanier_DAL>
    {
        
        public override IEnumerable<LignePanier_DAL> GetAll()
        {
            throw new NotImplementedException();
        }

        public override LignePanier_DAL Insert(LignePanier_DAL item)
        {
            if (item.LignePanierType == LignePanierType.Adherent)
            {
                CreerConnexionEtCommande();
                commande.CommandText = "INSERT INTO [dbo].[LignePanier] ([IdReference],[quantite],[IdPanier]) VALUES (@idR,@quantite,@idP);select scope_identity()";
                commande.Parameters.Add(new SqlParameter("@idR", item.IdReference));
                commande.Parameters.Add(new SqlParameter("@quantite",item.Quantite));
                commande.Parameters.Add(new SqlParameter("@idP",item.IdPanier));
                
                item.Id = Convert.ToInt32(commande.ExecuteScalar());
                
                DetruireConnexionEtCommande();
            }

            return item;
        }

        public override LignePanier_DAL Update(LignePanier_DAL item)
        {
            throw new NotImplementedException();
        }
        
        public override void Delete(LignePanier_DAL item)
        {
            throw new NotImplementedException();
        }

    }
}
