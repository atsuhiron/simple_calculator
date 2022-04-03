using System;
using System.Linq;
using System.Windows.Input;

namespace WpfApp4.Commands
{
    public abstract class BaseCalcCommand : ICommand
    {
        public BaseCalcCommand(CounterViewModel viewModel)
        {
            ViewModel = viewModel;
        }

        public event EventHandler? CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public bool CanExecute(object? parameter)
        {
            return true;
        }

        public abstract void Execute(object? parameter);

        protected CounterViewModel ViewModel { get; set; }

        protected bool IsValidFor2ArgCalc()
        {
            if (ViewModel.Numbers.Count < 2) return false;
            return ViewModel.Numbers.All(num => num.IsValid());
        }
    }
}
