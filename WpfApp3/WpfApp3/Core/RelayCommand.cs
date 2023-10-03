using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace WpfApp3.Core
{
    class RelayCommand : ICommand
    {
        private Action<object> _execute;
        private Func<object, bool> _canExecute;

        public RelayCommand(Func<object, bool> canExecute) => _canExecute = canExecute ?? throw new ArgumentNullException(nameof(canExecute));

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }


        }

        public RelayCommand(Action<object> execute, Func<object, bool> canExecute = null)
        {
            _execute = execute;
            _canExecute = canExecute;
        }

        bool ICommand.CanExecute(object parameter)
        {
            return _canExecute == null || _canExecute(parameter);
        }

        void ICommand.Execute(object parameter)
        {
            _execute(parameter);
        }

    }
}
