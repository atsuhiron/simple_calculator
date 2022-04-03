using WpfApp4.Models;

namespace WpfApp4.Commands
{
    public class DivCommnad : BaseCalcCommand
    {
        public DivCommnad(CounterViewModel viewModel) : base(viewModel) {}

        public override void Execute(object? parameter)
        {
            if (!IsValidFor2ArgCalc()) return;
            var newNum = NumberWithError.Div(ViewModel.Numbers[0], ViewModel.Numbers[1]);
            ViewModel.NumResult = newNum;
        }
    }
}
