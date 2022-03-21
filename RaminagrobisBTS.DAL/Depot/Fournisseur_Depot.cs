using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RaminagrobisBTS.DAL.Model;
using System.Data.SqlClient;

namespace RaminagrobisBTS.DAL.Depot
{
    public class Fournisseur_Depot : Depot<Fournisseur_DAL>
    {
        public Fournisseur_Depot():base(){}

        public override void Delete(Fournisseur_DAL item)
        {
            throw new NotImplementedException();
        }

        public Fournisseur_DAL GetByID(int id)
        {
            CreerConnexionEtCommande();

            commande.CommandText = "SELECT * FROM [dbo].[Fournisseurs] where id=@id";
            commande.Parameters.Add(new SqlParameter("@id", id));

            var reader = commande.ExecuteReader();
            Fournisseur_DAL reponse;


            if (reader.Read())
            {
                reponse = new Fournisseur_DAL(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetString(3), reader.GetString(4), reader.GetString(5));
            }
            else
            {
                reponse = null;
            }

            
            DetruireConnexionEtCommande();
            return reponse;
        }

        public override IEnumerable<Fournisseur_DAL> GetAll()
        {
            CreerConnexionEtCommande();

            commande.CommandText = "SELECT * FROM [dbo].[Fournisseurs]";
            var reader = commande.ExecuteReader();

            var reponse = new List<Fournisseur_DAL>();

            while (reader.Read())
            {
                reponse.Add(new Fournisseur_DAL(reader.GetInt32(0),reader.GetString(1), reader.GetString(2), reader.GetString(3), reader.GetString(4), reader.GetString(5)));
            }
            DetruireConnexionEtCommande();
            return reponse;
        }

        public override Fournisseur_DAL Insert(Fournisseur_DAL item)
        {
            CreerConnexionEtCommande();

            commande.CommandText = "INSERT INTO [dbo].[Fournisseurs] ([NomSociete],[NomCivile],[PrenomCivile],[Email],[Adresse]) VALUES" +
                " (@NomSociete,@NomCivile,@PrenomCivile,@Email,@Adresse);" +
                " select scope_identity()";
            commande.Parameters.Add(new SqlParameter("@NomSociete", item.NomSociete));
            commande.Parameters.Add(new SqlParameter("@NomCivile", item.NomCivile));
            commande.Parameters.Add(new SqlParameter("@PrenomCivile", item.PrenomCivile));
            commande.Parameters.Add(new SqlParameter("@Email", item.Email));
            commande.Parameters.Add(new SqlParameter("@Adresse", item.Adresse));
            item.Id = Convert.ToInt32((decimal)commande.ExecuteScalar());

            DetruireConnexionEtCommande();

            return item;
        }

        public override Fournisseur_DAL Update(Fournisseur_DAL item)
        {
            CreerConnexionEtCommande();

            commande.CommandText = "UPDATE [dbo].[Fournisseurs] SET [NomSociete] = @NomSociete, [NomCivile] = @NomCivile, [PrenomCivile] = @PrenomCivile, [Email] = @Email, [Adresse] = @Adresse WHERE [Id] = @Id";
            commande.Parameters.Add(new SqlParameter("@Id", item.Id));
            commande.Parameters.Add(new SqlParameter("@NomSociete", item.NomSociete));
            commande.Parameters.Add(new SqlParameter("@NomCivile", item.NomCivile));
            commande.Parameters.Add(new SqlParameter("@PrenomCivile", item.PrenomCivile));
            commande.Parameters.Add(new SqlParameter("@Email", item.Email));
            commande.Parameters.Add(new SqlParameter("@Adresse", item.Adresse));
            commande.ExecuteNonQuery();

            DetruireConnexionEtCommande();

            return item;
        }
    }
}
