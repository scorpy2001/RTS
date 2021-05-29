using System;
using RTS.Abstractions;
using RTS.Utils;
using Zenject;

namespace RTS.UserControlSystem.UiModel
{
    public class AttackCommandCreator : CommandCreatorBase<IAttackCommand>
    {
        [Inject] private AssetsContext _context;
        private Action<IAttackCommand> _creationCallback;
        
        [Inject]
        private void Init(AttackTargetValue attackTargetClicks)
        {
            attackTargetClicks.OnNewValue += OnNewValue;
        }

        private void OnNewValue(IAttackable attackTargetClicks)
        {
            _creationCallback?.Invoke(_context.Inject(new AttackCommand(attackTargetClicks)));
            _creationCallback = null;
        }

        protected override void SpecificCommandCreation(Action<IAttackCommand> creationCallback)
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
