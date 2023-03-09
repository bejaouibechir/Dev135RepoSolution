using System;
using System.Windows.Input;

namespace Commercial.MVVM.Helpers
{
    public class DeletegateCommand : ICommand
    {
        private readonly Action<object> _execute;
        private readonly Func<object, bool> _canexecute;

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public DeletegateCommand(Action<object> execute,Func<object,bool> canexecute )
        {
            _execute = execute;
            _canexecute = canexecute;
        }  

        public bool CanExecute(object parameter)
        {
            return _canexecute(parameter);
        }

        public void Execute(object parameter)
        {
            _execute(parameter);
        }
    }
}
