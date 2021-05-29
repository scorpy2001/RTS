using RTS.Abstractions;
using RTS.UserControlSystem.Model;
using RTS.Utils;
using UnityEngine;
using Zenject;

namespace RTS.UserControlSystem.UiModel
{
    public class UiModelInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<CommandCreatorBase<IProduceUnitCommand>>().To<ProduceUnitCommandCreator>().AsTransient();
            Container.Bind<CommandCreatorBase<IAttackCommand>>().To<AttackCommandCreator>().AsTransient();
            Container.Bind<CommandCreatorBase<IMoveCommand>>().To<MoveCommandCreator>().AsTransient();
            Container.Bind<CommandCreatorBase<IPatrolCommand>>().To<PatrolCommandCreator>().AsTransient();
            Container.Bind<CommandCreatorBase<IStopCommand>>().To<HoldPositionCommandCreator>().AsTransient();
            Container.Bind<CommandButtonsModel>().AsTransient();
        }
    }
}
