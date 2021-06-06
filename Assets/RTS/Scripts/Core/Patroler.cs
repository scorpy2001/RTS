using RTS.Abstractions;
using UnityEngine;

namespace RTS.Core
{
    public class Patroler : CommandExecutorBase<IPatrolCommand>
    {
        protected override void ExecuteSpecificCommand(IPatrolCommand command)
        {
            Debug.Log("Patrolls");
        }
    }
}
