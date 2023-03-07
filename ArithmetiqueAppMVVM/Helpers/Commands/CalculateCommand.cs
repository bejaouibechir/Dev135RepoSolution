using ArithmetiqueAppMVVM.ViewModels;
using System;
using System.Windows.Input;

namespace ArithmetiqueAppMVVM.Helpers.Commands
{
    public class CalculateCommand : ICommand
    {
        private readonly ViewModel _vmodel;

        public event EventHandler CanExecuteChanged;


        public CalculateCommand(ViewModel vmodel)
        {
            _vmodel = vmodel;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
           int operation = (int)parameter;
            _vmodel.Calculate(operation);
        }
    }
}
