using RTS.Abstractions;
using UnityEngine;

namespace RTS.Core
{
    public class MovableUnit : CommandExecutorBase<IMoveCommand>
    {
        protected override void ExecuteSpecificCommand(IMoveCommand command)
        {
            Debug.Log($"{name} is moving to {command.Target}!");
        }
    }
}
