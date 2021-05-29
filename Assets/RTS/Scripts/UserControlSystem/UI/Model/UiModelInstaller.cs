using RTS.Abstractions;
using RTS.UserControlSystem.Model;
using RTS.Utils;
using UnityEngine;
using Zenject;

namespace RTS.UserControlSystem.UiModel
{
    public class UiModelInstaller : MonoInstaller
    {
        [SerializeField] private AssetsContext _legacyContext;
        [SerializeField] private Vector3Value _goundClicksRMB;
        [SerializeField] private AttackTargetValue _attackTargetClicksRMB;
        [SerializeField] private SelectableValueModel _selectedObject;
        
        public override void InstallBindings()
        {
            Container.Bind<AssetsContext>().FromInstance(_legacyContext);
            Container.Bind<Vector3Value>().FromInstance(_goundClicksRMB);
            Container.Bind<AttackTargetValue>().FromInstance(_attackTargetClicksRMB);
            Container.Bind<SelectableValueModel>().FromInstance(_selectedObject);
            Container.Bind<CommandCreatorBase<IProduceUnitCommand>>().To<ProduceUnitCommandCreator>().AsTransient();
            Container.Bind<CommandCreatorBase<IAttackCommand>>().To<AttackCommandCreator>().AsTransient();
            Container.Bind<CommandCreatorBase<IMoveCommand>>().To<MoveCommandCreator>().AsTransient();
            Container.Bind<CommandCreatorBase<IPatrolCommand>>().To<PatrolCommandCreator>().AsTransient();
            Container.Bind<CommandCreatorBase<IStopCommand>>().To<HoldPositionCommandCreator>().AsTransient();
            Container.Bind<CommandButtonsModel>().AsTransient();
        }
    }
}
