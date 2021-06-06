using RTS.Abstractions;
using UnityEngine;

namespace RTS.UserControlSystem.UiModel
{
    public class MoveCommandCreator : CancellableCommandCreatorBase<IMoveCommand, Vector3>
    {
        protected override IMoveCommand CreateCommand(Vector3 argument) => new MoveUnitCommand(argument);
    }
}
