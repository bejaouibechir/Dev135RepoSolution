using System;
using System.Windows.Input;

namespace ArithmetiqueAppMVVM.Helpers.Commands
{
    //Commande routée
    public class CancelCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        //public bool CanExecute(object parameter) => true; <= bodied expression

        public bool CanExecute(object parameter)
        { 
            return true; 
        }

        public void Execute(object parameter)
        {
            App.Current.Shutdown();
        }
    }
}
