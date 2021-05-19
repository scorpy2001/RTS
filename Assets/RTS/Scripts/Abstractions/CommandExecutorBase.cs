using UnityEngine;

namespace RTS.Abstractions
{
    public abstract class CommandExecutorBase<T> : MonoBehaviour, ICommandExecutor where T: ICommand
    {
        public void ExecuteCommand(object command) => ExecuteSpecificCommand((T)command);

        protected abstract void ExecuteSpecificCommand(T command);
    }
}
