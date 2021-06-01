using RTS.Abstractions;
using UnityEngine;
using UnityEngine.AI;

namespace RTS.Core
{
    public class MovableUnit : CommandExecutorBase<IMoveCommand>
    {
        [SerializeField] private NavMeshAgent _navMeshAgent;

        protected override void ExecuteSpecificCommand(IMoveCommand command)
        {
            _navMeshAgent.destination = command.Target;
        }
    }
}
