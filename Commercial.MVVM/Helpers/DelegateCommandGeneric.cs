using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Commercial.MVVM.Helpers
{
    public class DeletegateCommand<T> : ICommand //Commande routée
    {
        private readonly Action<T> _execute;
        private readonly Func<T, bool> _canexecute;

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public DeletegateCommand()
        {

        }

        public DeletegateCommand(Action<T> execute, Func<T, bool> canexecute)
        {
            _execute = execute;
            _canexecute = canexecute;
        }

        public bool CanExecute(object parameter)
        {
            return _canexecute((T)parameter);
        }

        public void Execute(object parameter)
        {
            _execute((T)parameter);
        }
    }
}
