using Commercial.Model;
using Commercial.MVVM.DAL;
using Commercial.MVVM.DAL.SqlServer;
using Commercial.MVVM.Helpers;
using Commercial.SqlServer;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Commercial.MVVM.ViewModels
{
    public class MainSociétéViewModel : ViewModelBase
    {
        AddSociétéWindow _addSociétéWindow;
        CommercialContext _context;
        public ObservableCollection<Société> _sociétés;
        

        public MainSociétéViewModel()
        {
            _context = new CommercialContext();
            Sociétés = new ObservableCollection<Société>(_context.Sociétés.AsEnumerable());
            ShowAddSociétéWinCommand = new DeletegateCommand(showaddsociétéwin, canshowsociétéwin);
            SearchSociétéByCodeCommand = new DeletegateCommand(searchsociétécode, cansearchsociétécode);
        }

        private void searchsociétécode(object obj)
        {
           //Implémenter la logique de recherche et de filtre des sociétés
        }

        private bool cansearchsociétécode(object arg) => true;
      

        private bool canshowsociétéwin(object arg) => true;
        private void showaddsociétéwin(object obj)
        {
            _addSociétéWindow = new AddSociétéWindow();
            _addSociétéWindow.ShowDialog();
        }

        public ICommand ShowAddSociétéWinCommand { get; set; }

        public ICommand SearchSociétéByCodeCommand { get; set; }




        public ObservableCollection<Société> Sociétés {
            get { 
                return _sociétés; 
            }
            set
            {
                _sociétés = value;
                OnPropertyChanged(nameof(Sociétés));
            }
        }




    }
}
