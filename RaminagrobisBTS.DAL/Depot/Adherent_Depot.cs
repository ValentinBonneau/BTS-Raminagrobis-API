using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RaminagrobisBTS.DAL.Model;

namespace RaminagrobisBTS.DAL.Depot
{
    public class Adherent_Depot : Depot<Adherent_DAL>
    {
        public Adherent_Depot() : base()
        {

        }
        public override void Delete(Adherent_DAL item)
        {
            CreerConnexionEtCommande();

            commande.CommandText = "DELETE FROM [dbo].[Adherent] WHERE [Id] = @Id";
            commande.Parameters.Add(new SqlParameter("@id", item.Id));

            commande.ExecuteNonQuery();

            DetruireConnexionEtCommande();
        }

        public override IEnumerable<Adherent_DAL> GetAll()
        {
            CreerConnexionEtCommande();

            commande.CommandText = "SELECT * FROM [dbo].[Adherent]";
            var reader = commande.ExecuteReader();

            var reponse = new List<Adherent_DAL>();

            while (reader.Read())
            {
                var datetime = reader.GetDateTime(6);
                reponse.Add(new Adherent_DAL(reader.GetInt32(0),reader.GetString(1), reader.GetString(2), reader.GetString(3), reader.GetString(4), reader.GetString(5),new DateOnly(datetime.Year,datetime.Month,datetime.Day)));
            }
            return reponse;

            DetruireConnexionEtCommande();

        }

        public override Adherent_DAL Insert(Adherent_DAL item)
        {
            CreerConnexionEtCommande();

            commande.CommandText = "INSERT INTO [dbo].[Adherent] ([NomSociete],[NomCivile],[PrenomCivile],[Email],[Adresse],[DateAdhesion]) VALUES" +
                " (@NomSociete,@NomCivile,@PrenomCivile,@Email,@Adresse,@DateAdhesion);" +
                " select scope_identity()";
            commande.Parameters.Add(new SqlParameter("@NomSociete", item.NomSociete));
            commande.Parameters.Add(new SqlParameter("@NomCivile", item.NomCivile));
            commande.Parameters.Add(new SqlParameter("@PrenomCivile", item.PrenomCivile));
            commande.Parameters.Add(new SqlParameter("@Email", item.Email));
            commande.Parameters.Add(new SqlParameter("@Adresse", item.Adresse));
            commande.Parameters.Add(new SqlParameter("@DateAdhesion", new DateTime(item.DateAdhesion.Year, item.DateAdhesion.Month,item.DateAdhesion.Day)));
            item.Id = Convert.ToInt32((decimal)commande.ExecuteScalar());

            DetruireConnexionEtCommande();

            return item;
        }

        public override Adherent_DAL Update(Adherent_DAL item)
        {
            CreerConnexionEtCommande();

            commande.CommandText = "UPDATE [dbo].[Adherent] SET [NomSociete] = @NomSociete, [NomCivile] = @NomCivile, [PrenomCivile] = @PrenomCivile, [Email] = @Email, [Adresse] = @Adresse, [DateAdhesion] = @DateAdhesion WHERE [Id] = @Id";
            commande.Parameters.Add(new SqlParameter("@Id", item.Id));
            commande.Parameters.Add(new SqlParameter("@NomSociete", item.NomSociete));
            commande.Parameters.Add(new SqlParameter("@NomCivile", item.NomCivile));
            commande.Parameters.Add(new SqlParameter("@PrenomCivile", item.PrenomCivile));
            commande.Parameters.Add(new SqlParameter("@Email", item.Email));
            commande.Parameters.Add(new SqlParameter("@Adresse", item.Adresse));
            commande.Parameters.Add(new SqlParameter("@DateAdhesion", new DateTime(item.DateAdhesion.Year, item.DateAdhesion.Month, item.DateAdhesion.Day)));
            commande.ExecuteNonQuery();

            DetruireConnexionEtCommande();

            return item;
        }

        public Adherent_DAL GetById(int id)
        {
            CreerConnexionEtCommande();

            commande.CommandText = "SELECT [Id],[NomSociete],[NomCivile],[PrenomCivile],[Email],[Adresse],[DateAdhesion] FROM [dbo].[Adherent] Where [Id] = @Id";
            commande.Parameters.Add(new SqlParameter("@Id", id));
            var reader = commande.ExecuteReader();

            Adherent_DAL reponse;

            if (reader.Read())
            {
                var datetime = reader.GetDateTime(6);
                reponse = new Adherent_DAL(reader.GetInt32(0),reader.GetString(1), reader.GetString(2), reader.GetString(3), reader.GetString(4), reader.GetString(5), new DateOnly(datetime.Year, datetime.Month, datetime.Day));
            }
            else
            {
                throw new Exception($"pas d'Adherent à l'id {id}");
            }


            DetruireConnexionEtCommande();

            return reponse;
        }
    }
}
