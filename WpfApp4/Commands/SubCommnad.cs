using WpfApp4.Models;

namespace WpfApp4.Commands
{
    public class SubCommnad : BaseCalcCommand
    {
        public SubCommnad(CounterViewModel viewModel) : base(viewModel) {}

        public override void Execute(object? parameter)
        {
            if (!IsValidFor2ArgCalc()) return;
            var newNum = NumberWithError.Sub(ViewModel.Numbers[0], ViewModel.Numbers[1]);
            ViewModel.NumResult = newNum;
        }
    }
}
