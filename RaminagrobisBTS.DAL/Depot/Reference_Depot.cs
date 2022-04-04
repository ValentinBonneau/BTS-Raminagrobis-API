using RaminagrobisBTS.DAL.Model;
using System.Data.SqlClient;

namespace RaminagrobisBTS.DAL.Depot
{
    public class Reference_Depot : Depot<Reference_DAL>
    {


        public override IEnumerable<Reference_DAL> GetAll()
        {
            CreerConnexionEtCommande();

            commande.CommandText = "SELECT * FROM [dbo].[Reference]";
            var reader = commande.ExecuteReader();

            var reponse = new List<Reference_DAL>();

            while (reader.Read())
            {
                reponse.Add(new Reference_DAL(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetString(3)));
            }
            DetruireConnexionEtCommande();
            return reponse;
        }

        public Reference_DAL GetById(int Id)
        {
            CreerConnexionEtCommande();

            commande.CommandText = "SELECT * FROM [dbo].[Reference] where id = @id";
            commande.Parameters.Add(new SqlParameter("@id",Id));

            var reader = commande.ExecuteReader();

            if (reader.Read())
            {
                var reponse = new Reference_DAL(Id, reader.GetString(1), reader.GetString(2),reader.GetString(3));
                DetruireConnexionEtCommande();
                return reponse;
            }
            else
            {
                DetruireConnexionEtCommande();
                return null;
            }

            DetruireConnexionEtCommande();
        }
        public int? GetIdByRef(string Ref)
        {
            CreerConnexionEtCommande();

            commande.CommandText = "SELECT id FROM [dbo].[Reference] where Ref=@ref";
            commande.Parameters.Add(new SqlParameter("@ref", Ref));
            
            var reponse = (int?)commande.ExecuteScalar();

            DetruireConnexionEtCommande();
            return reponse;
        }
        public string? GetRefById(int id)
        {
            CreerConnexionEtCommande();

            commande.CommandText = "SELECT Ref FROM [dbo].[Reference] where Id=@id";
            commande.Parameters.Add(new SqlParameter("@id", id));

            var reponse = (string?)commande.ExecuteScalar();

            DetruireConnexionEtCommande();
            return reponse;
        }

        public override Reference_DAL Insert(Reference_DAL item)
        {
            CreerConnexionEtCommande();

            commande.CommandText = "INSERT INTO [dbo].[Reference] ([Ref],[Libelle],[Marque]) VALUES (@ref,@libelle,@marque);select scope_identity()";
            commande.Parameters.Add(new SqlParameter("@ref", item.Ref));
            commande.Parameters.Add(new SqlParameter("@libelle",item.Libele));
            commande.Parameters.Add(new SqlParameter("@marque",item.Marque));
            item.Id = Convert.ToInt32((decimal)commande.ExecuteScalar());

            DetruireConnexionEtCommande();

            return item;
        }

        public Reference_DAL AssoToFournisseur(Reference_DAL item, int idFournisseur)
        {
            CreerConnexionEtCommande();

            commande.CommandText = "INSERT INTO [dbo].[FournisseurToReference] ([IdFournisseur],[idReference]) VALUES (@idfour,@idref)";
            commande.Parameters.Add(new SqlParameter("@idfour", idFournisseur));
            commande.Parameters.Add(new SqlParameter("@idref", item.Id));

            commande.ExecuteNonQuery();

            DetruireConnexionEtCommande();

            return item;
        }

        public void UnAssoToFournisseur(int idFournisseur)
        {
            CreerConnexionEtCommande();

            commande.CommandText = "DELETE [dbo].[FournisseurToReference] WHERE [IdFournisseur]=@idfour";
            commande.Parameters.Add(new SqlParameter("@idfour", idFournisseur));

            commande.ExecuteNonQuery();

            DetruireConnexionEtCommande();
        }



        public override Reference_DAL Update(Reference_DAL item)
        {
            throw new NotImplementedException();
        }

        public override void Delete(Reference_DAL item)
        {
            throw new NotImplementedException();
        }

    }
}
