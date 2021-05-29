using UnityEngine;

namespace RTS.Abstractions
{
    public interface IMoveCommand : ICommand
    {
        Vector3 Target { get; }
    }
}
