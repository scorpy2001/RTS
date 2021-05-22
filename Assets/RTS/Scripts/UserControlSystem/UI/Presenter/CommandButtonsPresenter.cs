using System;
using System.Collections.Generic;
using RTS.Abstractions;
using RTS.UserControlSystem.Model;
using RTS.UserControlSystem.UiView;
using RTS.Utils;
using UnityEngine;

namespace RTS.UserControlSystem.UiPresenter
{
    public class CommandButtonsPresenter : MonoBehaviour
    {
        [SerializeField] private SelectableValueModel _selectable;
        [SerializeField] private CommandButtonsView _view;
        [SerializeField] private AssetsContext _context;
        
        private ISelectable _currentSelectable;

        private void Start()
        {
            _selectable.OnSelected += onSelected;
            onSelected(_selectable.CurrentValue);
            _view.OnClick += onButtonClick;
        }

        private void onSelected(ISelectable selectable)
        {
            if (_currentSelectable == selectable)
            {
                return;
            }

            _currentSelectable = selectable;
            _view.Clear();

            if (selectable != null)
            {
                var commandExecutors = new List<ICommandExecutor>();
                commandExecutors.AddRange((selectable as Component).GetComponentsInParent<ICommandExecutor>());
                _view.MakeLayout(commandExecutors);
            }
        }

        private void onButtonClick(ICommandExecutor commandExecutor)
        {
            switch (commandExecutor)
            {
                case CommandExecutorBase<IProduceUnitCommand> unitProducer:
                    unitProducer.ExecuteCommand(_context.Inject(new ProduceUnitCommand()));
                    break;
                case CommandExecutorBase<IAttackCommand> attaker:
                    attaker.ExecuteCommand(new AttackCommand()); // TODO: возможо будет необходимо внедрение зависимоти.
                    break;
                case CommandExecutorBase<IMoveCommand> attaker:
                    attaker.ExecuteCommand(new MoveUnitCommand()); // TODO: возможо будет необходимо внедрение зависимоти.
                    break;
                case CommandExecutorBase<IPatrolCommand> attaker:
                    attaker.ExecuteCommand(new PatrolCommand()); // TODO: возможо будет необходимо внедрение зависимоти.
                    break;
                case CommandExecutorBase<IStopCommand> attaker:
                    attaker.ExecuteCommand(new HoldPositionCommand()); // TODO: возможо будет необходимо внедрение зависимоти.
                    break;
                default:
                    throw new ApplicationException($"{nameof(CommandButtonsPresenter)}.{nameof(onButtonClick)}: Unknown type of commands executor: {commandExecutor.GetType().FullName}!");
            }
        }
    }
}
