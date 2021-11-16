using MySql.Data.MySqlClient;
using Phonebook.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phonebook.Providers
{
    public class CompanyProvider : BaseProvider
    {
        protected override string GetTable()
        {
            return "company";
        }
        protected override Entity CreateItem(MySqlDataReader reader)
        {
            return new Company(Convert.ToInt32(reader["id"]),reader["name"].ToString());
        }

        // CODE DE RECUPERATION DES DONNEE AVANT LA MISE EN PLACE DE LA BASE DE DONNEE
        //DEBUT DE CE CODE
        //protected override IEnumerable<Entity> GetData()
        //  {
        //Entity c1 = new Company(1, "Google");
        //Entity c2 = new Company(2, "Apple");
        //Entity c3 = new Company(3, "Microsoft");
        //return new List<Entity>() { c1,c2,c3 };
        //   }
        //FIN DU FIN

        //LE CODE (ado.net) AVANT LA MISE EN PLACE DES CODES COMMUN DANS BaseProvider
        // protected override IEnumerable<Entity> GetData()
        // {
        //  string connectionString = "server=localhost;port=3308;user=root;password=;database=adodotnet";
        //  MySqlConnection connection=new MySqlConnection(connectionString);
        // connection.Open();

        //MySqlCommand command= new MySqlCommand("SELECT* FROM company",connection);
        //MySqlDataReader reader=command.ExecuteReader();
        //List<Entity> entities = new List<Entity>();
        // while(reader.Read())
        //{
        //    Company comp = new Company(
        //      Convert.ToInt32(reader["id"]),
        //    reader["name"].ToString()
        //  );
        // entities.Add(comp);
        //  }
        // return  entities;
        // }

    }
}
