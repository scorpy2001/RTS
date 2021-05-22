using RTS.Abstractions;
using UnityEngine;

namespace RTS.Core
{
    public class Attaker : CommandExecutorBase<IAttackCommand>
    {
        protected override void ExecuteSpecificCommand(IAttackCommand command)
        {
            Debug.Log("Attacks");
        }
    }
}
