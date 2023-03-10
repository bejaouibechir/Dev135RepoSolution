using Commercial.Model;
using Commercial.SqlServer;
using System;
using System.Windows.Input;
using WPFProjects.Calculator.MVVM.Helpers.Commands;

namespace Commercial.MVVM.ViewModels
{
    public class AddSociétéViewModel : ViewModelBase
    {
        private Société _sociétéInfo;
        CommercialContext _commercialContext;

        public AddSociétéViewModel()
        {
            SociétéInfo = new Société();
            CancelCommand = new DelegateCommand(cancelexecute, cancancelexecute);
            SaveCommand = new DelegateCommand(saveexecute, cansaveexecute);
            _commercialContext = new CommercialContext();
        }

        private bool cansaveexecute(object arg) => true;

        private void saveexecute(object obj)
        {
            _commercialContext.Sociétés.Add(SociétéInfo);
            _commercialContext.SaveChanges();
        }

        private bool cancancelexecute(object arg) => true;

        private void cancelexecute(object obj)
        {
           
        }

        public Société SociétéInfo 
        {
            get { return _sociétéInfo; }
            set { 
                _sociétéInfo= value;
                OnPropertyChanged(nameof(SociétéInfo));
            }
        }

        public ICommand CancelCommand { get; set; }
        public ICommand SaveCommand { get; set; }
    }
}
