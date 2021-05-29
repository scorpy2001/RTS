using System;
using RTS.Abstractions;
using RTS.Utils;
using Zenject;

namespace RTS.UserControlSystem.UiModel
{
    public class MoveCommandCreator : CommandCreatorBase<IMoveCommand>
    {
        [Inject] private AssetsContext _context;

        protected override void SpecificCommandCreation(Action<IMoveCommand> creationCallback)
        {
            creationCallback?.Invoke(_context.Inject(new MoveUnitCommand()));
        }
    }
}
