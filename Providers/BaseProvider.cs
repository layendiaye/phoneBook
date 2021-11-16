using MySql.Data.MySqlClient;
using Phonebook.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Phonebook.Providers
{
    public abstract class BaseProvider : IDataProvider
    {
        protected abstract Entity CreateItem(MySqlDataReader reader);
        protected abstract string GetTable();
        private IEnumerable<Entity> GetData()// on a mis en private car cette methode est appelé uniquement dans cette classe, on ne le trouve null part ailleur pas à l'exterieur
        {

            string connectionString = "server=localhost;port=3308;user=root;password=;database=adodotnet";
            MySqlConnection connection = new MySqlConnection(connectionString);
            connection.Open();


            MySqlCommand command = new MySqlCommand("SELECT* FROM " + GetTable(), connection);//on a remplacer la table person ou company par GetTable()
                                                                                              // pour  rendre la ligne generique (commun)
            MySqlDataReader reader = command.ExecuteReader();
            List<Entity> resultats = new List<Entity>();
            while (reader.Read())
            {

                Entity pers = CreateItem(reader);
              
                resultats.Add(pers);
            }
           
            connection.Close();
            
            return resultats;
        }


        public IEnumerable<Entity> List()
        {
            return GetData();//on peut mettre this.getData() mais unitile car il n'ya pas d'ambigûité
        }

        public IEnumerable<Entity> Search(string text)
        {
            string search = text.ToLower();
            List<Entity> results = new List<Entity>();
            foreach (Entity item in GetData())
            {
                if (item.ToString().ToLower().Contains(search))
                {
                    results.Add(item);
                }
            }

            return results;

            //return getData().Select(x=>x).Where(x =>x.ToString().ToLower().Contains(texte));
            //return getData().Where(x => JsonSerializer.Serialize<object>(x).ToLower().Contains(texte));
        }
    }
   
}
