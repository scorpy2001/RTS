using UnityEngine;

namespace RTS.Abstractions
{
    public interface IPatrolCommand : ICommand
    {
        Vector3 From { get; }
        Vector3 To { get; }
    }
}
