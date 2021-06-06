using System.Threading;
using RTS.Abstractions;

namespace RTS.Core
{
    public class HoldPositionUnit : CommandExecutorBase<IStopCommand>
    {
        public CancellationTokenSource CancellationTokenSource { get; set; }

        protected override void ExecuteSpecificCommand(IStopCommand command)
        {
            CancellationTokenSource?.Cancel();
        }
    }
}
