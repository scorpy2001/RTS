using System;
using RTS.Abstractions;
using RTS.Utils;
using Zenject;

namespace RTS.UserControlSystem.UiModel
{
    public class PatrolCommandCreator : CommandCreatorBase<IPatrolCommand>
    {
        [Inject] private AssetsContext _context;

        protected override void SpecificCommandCreation(Action<IPatrolCommand> creationCallback)
        {
            creationCallback?.Invoke(_context.Inject(new PatrolCommand()));
        }
    }
}