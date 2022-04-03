using WpfApp4.Models;

namespace WpfApp4.Commands
{
    public class AddCommnad : BaseCalcCommand
    {
        public AddCommnad(CounterViewModel viewModel) : base(viewModel) {}

        public override void Execute(object? parameter)
        {
            if (!IsValidFor2ArgCalc()) return;
            var newNum = NumberWithError.Add(ViewModel.Numbers[0], ViewModel.Numbers[1]);
            ViewModel.NumResult = newNum;
        }
    }
}
