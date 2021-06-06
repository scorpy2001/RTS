using RTS.Abstractions;
using UnityEngine;

namespace RTS.Core
{
    public class MainBuilding : CommandExecutorBase<IProduceUnitCommand>
    {
        [SerializeField] private Transform _unitsParent;

        protected override void ExecuteSpecificCommand(IProduceUnitCommand command)
        {
            Instantiate(command.UnitPrefab, new Vector3(Random.Range(-10, 10), 0, Random.Range(-10, 10)), Quaternion.identity);
        }
    }
}