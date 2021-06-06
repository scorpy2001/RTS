using System.Threading;
using System.Threading.Tasks;
using RTS.Abstractions;
using RTS.Utils;
using UnityEngine;
using UnityEngine.AI;

namespace RTS.Core
{
    public class Patroler : CommandExecutorBase<IPatrolCommand>
    {
        [SerializeField] private NavMeshAgent _navMeshAgent;
        [SerializeField] private HoldPositionUnit _holdPositionUnit;

        protected override async void ExecuteSpecificCommand(IPatrolCommand command)
        {
            _holdPositionUnit.CancellationTokenSource = new CancellationTokenSource();
            try
            {
                await Patrol(command.From, command.To).WithCancellation(_holdPositionUnit.CancellationTokenSource.Token);
            }
            catch
            {
                _navMeshAgent.isStopped = true;
                _navMeshAgent.ResetPath();
            }

            _holdPositionUnit.CancellationTokenSource = null;
        }

        private async Task<AsyncExtensions.Void> Patrol(Vector3 from, Vector3 to)
        {
            while (true)
            {
                await MoveTo(to);
                await MoveTo(from);
            }
        }

        private async Task MoveTo(Vector3 destination)
        {
            _navMeshAgent.SetDestination(destination);

            while ((transform.position - destination).sqrMagnitude >= 0.1f)
            {
                await Task.Yield();
            }
        }
    }
}
