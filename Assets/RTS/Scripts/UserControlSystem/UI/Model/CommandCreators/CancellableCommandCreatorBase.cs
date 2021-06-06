using System;
using System.Threading;
using RTS.Abstractions;
using RTS.Utils;
using Zenject;

namespace RTS.UserControlSystem.UiModel
{
    public abstract class CancellableCommandCreatorBase<TCommand, TArgument> : CommandCreatorBase<TCommand> where TCommand : ICommand
    {
        [Inject] private AssetsContext _context;
        [Inject] private IAwaitable<TArgument> _awaitableArgument;

        private CancellationTokenSource _cancellationTokenSource;

        protected override sealed async void SpecificCommandCreation(Action<TCommand> creationCallback)
        {
            _cancellationTokenSource = new CancellationTokenSource();

            try
            {
                var argument = await _awaitableArgument.WithCancellation(_cancellationTokenSource.Token);
                creationCallback?.Invoke(_context.Inject(CreateCommand(argument)));
            }
            catch { }
        }

        protected abstract TCommand CreateCommand(TArgument argument);

        public override void ProcessCancel()
        {
            base.ProcessCancel();

            if (_cancellationTokenSource != null)
            {
                _cancellationTokenSource.Cancel();
                _cancellationTokenSource.Dispose();
                _cancellationTokenSource = null;
            }
        }
    }
}
