using RTS.Abstractions;
using UnityEngine;

namespace RTS.UserControlSystem
{
    public class MoveUnitCommand : IMoveCommand
    {
        public Vector3 Target { get; }

        public MoveUnitCommand(Vector3 target)
        {
            Target = target;
        }
    }
}
