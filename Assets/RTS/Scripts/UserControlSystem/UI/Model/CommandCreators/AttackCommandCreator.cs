using System;
using RTS.Abstractions;
using RTS.Utils;
using Zenject;

namespace RTS.UserControlSystem.UiModel
{
    public class AttackCommandCreator : CommandCreatorBase<IAttackCommand>
    {
        [Inject] private AssetsContext _context;

        protected override void SpecificCommandCreation(Action<IAttackCommand> creationCallback)
        {
            creationCallback?.Invoke(_context.Inject(new AttackCommand()));
        }
    }
}
