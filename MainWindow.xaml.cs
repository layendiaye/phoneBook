using Phonebook.Models;
using Phonebook.Providers;
using Phonebook.Services;
using Phonebook.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;//using = import

namespace Phonebook //package
{
    
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 
    public partial class MainWindow : Window ///(: =extends
    {

        private readonly AboutViewModels _aboutViewModels;
        private readonly ContactViewModels _contactViewModels;
        public MainWindow()
        {
            IDataProvider pers = new PersonProvider();
            IDataProvider comp = new CompanyProvider();
            IEnumerable<IDataProvider> provider = new List<IDataProvider>() { pers, comp };
            RepositoryService serv = new RepositoryService(provider);
            //les DataContexts sont initialisés une seule fois (constructeur)
            _aboutViewModels = new AboutViewModels();
            _contactViewModels = new ContactViewModels(serv);

            InitializeComponent();
        }
        public void About_click(object sender, RoutedEventArgs e)
        {
            DataContext = _aboutViewModels;//new AboutViewModels() les DataContexts sont maintenant initialisés ds le constructrus;
        }
        public void Contact_click(object sender, RoutedEventArgs e)
        {
            DataContext = _contactViewModels; //new ContactViewModels();idem que About_click 
        }
    }
}
