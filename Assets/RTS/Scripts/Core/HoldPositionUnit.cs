using RTS.Abstractions;
using UnityEngine;

namespace RTS.Core
{
    public class HoldPositionUnit : CommandExecutorBase<IStopCommand>
    {
        protected override void ExecuteSpecificCommand(IStopCommand command)
        {
            Debug.Log("Holds Position");
        }
    }
}
