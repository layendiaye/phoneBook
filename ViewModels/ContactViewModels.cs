using Phonebook.Models;
using Phonebook.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phonebook.ViewModels
{
    public class ContactViewModels : INotifyPropertyChanged //notification de changement de valeur (observable), c'est comme le fireTableDataChanged de java
    {
        public string search { get; set; }  
        private readonly RepositoryService _repositoryService;

        public event PropertyChangedEventHandler? PropertyChanged;

        public IEnumerable<string> Resultes { get; set; }
        public ContactViewModels(RepositoryService repositoryService)
        {
            _repositoryService = repositoryService;
            //Resultes = new List<string>() { "bonjour","comment", "vas", "tu ?"};

            search = ""; //string vide au depart pour eviter les buggs string non referenced
        }
        public void ExecuteList()
        {
            IEnumerable<Entity> results = _repositoryService.List();
            Resultes=results.Select(x=>x.ToString());
            PropertyChanged(this, new PropertyChangedEventArgs("Resultes"));
            //this= l'auteur de l'événement=viewmodel)
        }
        public void ExecuteSearch()
        {
            IEnumerable<Entity> results = _repositoryService.Search(this.search);//on peut ne pas mettre le this car il n'ya pas d'ambiguté sur la methode(elle n'est pas appelé ailleur)
            Resultes = results.Select(x => x.ToString());
            
            PropertyChanged(this, new PropertyChangedEventArgs("Resultes"));

            //pour vider le textbox
           search = "";
            PropertyChanged(this, new PropertyChangedEventArgs("search"));

        }

    }
}
