using Phonebook.Models;
using Phonebook.Providers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Phonebook.Services
{
    public class RepositoryService
    {
        private readonly IEnumerable<IDataProvider> _providers; //readonly veut dire que la _provider ne changera pas
        public RepositoryService(IEnumerable<IDataProvider> providers)
        {
            _providers= providers;
        }
        public IEnumerable<Entity> List()
        {
            IEnumerable<Entity> entities = new List<Entity>();
            foreach(IDataProvider element in _providers)
            {
                entities=entities.Concat(element.List());
            }
            return entities;
        }
        public IEnumerable<Entity> Search(string text)
        {
            //string texte = text.ToLower();
            //return List().Where(x => JsonSerializer.Serialize<object>(x).ToLower().Contains(texte));//.Select(x => x).Where(x => x.ToString().ToLower().Contains(texte));

            IEnumerable<Entity> entities = new List<Entity>();
            foreach(IDataProvider element in _providers)
            {
                entities= entities.Concat(element.Search(text));
            }
            return entities;
        }

    }
}
