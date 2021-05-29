using System;
using RTS.Abstractions;
using RTS.UserControlSystem.Model;
using RTS.Utils;
using UnityEngine;
using Zenject;

namespace RTS.UserControlSystem.UiModel
{
    public class PatrolCommandCreator : CommandCreatorBase<IPatrolCommand>
    {
        [Inject] private AssetsContext _context;
        [Inject] private SelectableValueModel _selectable;

        private Action<IPatrolCommand> _creationCallback;
        
        [Inject]
        private void Init(Vector3Value groundClick)
        {
            groundClick.OnChange += OnChangeValue;
        }

        private void OnChangeValue(Vector3 groundClick)
        {
            _creationCallback?.Invoke(_context.Inject(new PatrolCommand(_selectable.CurrentValue.Transform.position, groundClick)));
            _creationCallback = null;
        }

        protected override void SpecificCommandCreation(Action<IPatrolCommand> creationCallback)
        {
            _creationCallback = creationCallback;
        }

        public override void ProcessCancel()
        {
            base.ProcessCancel(); 
            _creationCallback = null;
        }
    }
}