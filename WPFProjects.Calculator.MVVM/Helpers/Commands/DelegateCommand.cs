using System;
using System.Windows.Input;

namespace WPFProjects.Calculator.MVVM.Helpers.Commands
{
    public class DelegateCommand : ICommand
    {
        private readonly Action<object> _execute;
        private readonly Func<object, bool> _canexecute;

        /* Evenement qui se déclenche à chaque fois que
         * la commande change d'état actif->inactif ou l'inverse*/
        
        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

      
        /*
          On passe des références vers les méthodes qu'on va appeler au constructeur
         */
        public DelegateCommand(Action<object> execute,Func<object,bool> canexecute)
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

    public class DelegateCommand<T> : ICommand
    {
        private readonly Action<T> _execute;
        private readonly Func<T, bool> _canexecute;

        /* Evenement qui se déclenche à chaque fois que
         * la commande change d'état actif->inactif ou l'inverse*/

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }


        /*
          On passe des références vers les méthodes qu'on va appeler au constructeur
         */
        public DelegateCommand(Action<T> execute, Func<T, bool> canexecute)
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
