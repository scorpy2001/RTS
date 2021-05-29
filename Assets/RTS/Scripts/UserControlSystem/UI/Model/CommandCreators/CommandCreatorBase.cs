using System;
using RTS.Abstractions;

namespace RTS.UserControlSystem.UiModel
{
    public abstract class CommandCreatorBase<T> where T : ICommand
    {
        public ICommandExecutor ProcessCommandExecutor(ICommandExecutor commandExecutor, Action<T> callback)
        {
            if (commandExecutor is CommandExecutorBase<T>)
            {
                SpecificCommandCreation(callback);
            }
            return commandExecutor;
        }

        protected abstract void SpecificCommandCreation(Action<T> creationCallback);

        public virtual void ProcessCancel() { }
    }
}
