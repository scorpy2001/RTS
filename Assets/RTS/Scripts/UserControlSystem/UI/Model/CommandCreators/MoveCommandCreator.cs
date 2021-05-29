using System;
using RTS.Abstractions;
using RTS.Utils;
using UnityEngine;
using Zenject;

namespace RTS.UserControlSystem.UiModel
{
    public class MoveCommandCreator : CommandCreatorBase<IMoveCommand>
    {
        [Inject] private AssetsContext _context;
        private Action<IMoveCommand> _creationCallback;
        
        [Inject]
        private void Init(Vector3Value groundClicks)
        {
            groundClicks.OnNewValue += OnNewValue;
        }

        private void OnNewValue(Vector3 groundClick)
        {
            _creationCallback?.Invoke(_context.Inject(new MoveUnitCommand(groundClick)));
            _creationCallback = null;
        }

        protected override void SpecificCommandCreation(Action<IMoveCommand> creationCallback)
        {
            _creationCallback = creationCallback;
        }

        public override void ProcessCancel()
        {
            base.ProcessCancel(); _creationCallback = null;
        }
    }
}
