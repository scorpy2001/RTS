using RTS.Abstractions;
using RTS.UserControlSystem.Model.ScriptableObjects;
using UnityEngine;
using Zenject;

namespace RTS.UserControlSystem.UiModel
{
    public class PatrolCommandCreator : CancellableCommandCreatorBase<IPatrolCommand, Vector3>
    {
        [Inject] private SelectableValueModel _selectable;

        protected override IPatrolCommand CreateCommand(Vector3 argument) => new PatrolCommand(_selectable.CurrentValue.Transform.position, argument);
    }
}