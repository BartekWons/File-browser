using System.Windows.Input;

namespace File_browser.ViewModel
{
    public class RelayCommand : ICommand
    {
        private Action<object> _execute;
        private Func<object, bool> _canExecute;

        public event EventHandler? CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public RelayCommand(Action<object> execute, Func<object, bool> canExectue = null)
        {
            _execute = execute;
            _canExecute = canExectue;
        }

        // Questionable implementation: certain arguments make the stack overflow
        // public bool CanExecute(object? parameter)
        // {
        //     return _canExecute == null || CanExecute(parameter);
        // }

        public void Execute(object? parameter)
        {
            _execute(parameter);
        }

    }
}
