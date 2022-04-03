using System;
using System.Windows.Input;

namespace WpfApp4.Commands
{
    public class PasteResultCommand : ICommand
    {
        private CounterViewModel ViewModel { get; set; }

        public PasteResultCommand(CounterViewModel viewModel)
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

        public void Execute(object? parameter)
        {
            if (parameter is string targetName)
            {
                var numbers = ViewModel.Numbers;
                var result = ViewModel.NumResult;

                switch (targetName)
                {
                    case "A":
                        if (numbers.Count < 1) break;
                        numbers[0] = result;
                        ViewModel.NumAVal = result.Value ?? 0;
                        ViewModel.NumAErr = result.Error;
                        break;
                    case "B":
                        if (numbers.Count < 2) break;
                        numbers[1] = result;
                        ViewModel.NumBVal = result.Value ?? 0;
                        ViewModel.NumBErr = result.Error;
                        break;
                    default:
                        break;
                }
            }
        }
    }
}
