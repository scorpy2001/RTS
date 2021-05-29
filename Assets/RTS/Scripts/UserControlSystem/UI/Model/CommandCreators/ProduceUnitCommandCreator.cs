using System;
using RTS.Abstractions;
using RTS.Utils;
using Zenject;

namespace RTS.UserControlSystem.UiModel
{
    public class ProduceUnitCommandCreator : CommandCreatorBase<IProduceUnitCommand>
    {
        [Inject] private AssetsContext _context;

        protected override void SpecificCommandCreation(Action<IProduceUnitCommand> creationCallback)
        {
            creationCallback?.Invoke(_context.Inject(new ProduceUnitCommandHeir()));
        }
    }
}
