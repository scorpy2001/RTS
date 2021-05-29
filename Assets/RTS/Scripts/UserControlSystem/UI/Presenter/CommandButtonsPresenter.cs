using System.Collections.Generic;
using RTS.Abstractions;
using RTS.UserControlSystem.Model;
using RTS.UserControlSystem.UiModel;
using RTS.UserControlSystem.UiView;
using UnityEngine;
using Zenject;

namespace RTS.UserControlSystem.UiPresenter
{
    public class CommandButtonsPresenter : MonoBehaviour
    {
        [SerializeField] private SelectableValueModel _selectable;
        [SerializeField] private CommandButtonsView _view;
        [Inject] private CommandButtonsModel _model;

        private ISelectable _currentSelectable;

        private void Start()
        {
            _selectable.OnSelected += onSelected;
            onSelected(_selectable.CurrentValue);
            _view.OnClick += _model.OnCommandButtonClicked;
            _model.OnCommandSent += _view.UnblockAllInteractions;
            _model.OnCommandCancel += _view.UnblockAllInteractions;
            _model.OnCommandAccepted += _view.BlockInteractions;
        }

        private void onSelected(ISelectable selectable)
        {
            if (_currentSelectable == selectable)
            {
                return;
            }
            if(_currentSelectable != null){
                _model.OnSelectionChanged();
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
    }
}
