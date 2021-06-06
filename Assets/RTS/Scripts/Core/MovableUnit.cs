using System.Threading;
using RTS.Abstractions;
using UnityEngine;
using UnityEngine.AI;
using RTS.Utils;

namespace RTS.Core
{
    [RequireComponent(typeof(HoldPositionUnit))]
    public class MovableUnit : CommandExecutorBase<IMoveCommand>
    {
        [SerializeField] private UnitMovementStop _stop;
        [SerializeField] private NavMeshAgent _navMeshAgent;
        [SerializeField] private HoldPositionUnit _holdPositionUnit;

        protected override async void ExecuteSpecificCommand(IMoveCommand command)
        {
            _holdPositionUnit.CancellationTokenSource = new CancellationTokenSource();

            _navMeshAgent.SetDestination(command.Target);
            try
            {
                await _stop.WithCancellation(_holdPositionUnit.CancellationTokenSource.Token);
            }
            catch
            {
                _navMeshAgent.isStopped = true;
                _navMeshAgent.ResetPath();
            }
            
            _holdPositionUnit.CancellationTokenSource = null;
        }
    }
}
