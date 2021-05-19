using System;
using System.Collections.Generic;
using RTS.Abstractions;
using RTS.UserControlSystem.Model;
using RTS.UserControlSystem.UiView;
using UnityEngine;

namespace RTS.UserControlSystem.UiPresenter
{
    public class CommandButtonsPresenter : MonoBehaviour
    {
        [SerializeField] private SelectableValueModel _selectable;
        [SerializeField] private CommandButtonsView _view;
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
                    unitProducer.ExecuteCommand(new ProduceUnitCommand());
                    break;
                default:
                    throw new ApplicationException($"{nameof(CommandButtonsPresenter)}.{nameof(onButtonClick)}: Unknown type of commands executor: {commandExecutor.GetType().FullName}!");
            }
        }
    }
}
