using System;
using RTS.Abstractions;
using UnityEngine;

namespace RTS.UserControlSystem.UiModel
{
    [CreateAssetMenu(fileName = nameof(AttackTargetValue), menuName = "Strategy Game/" + nameof(AttackTargetValue), order = 0)]

    public class AttackTargetValue : ScriptableObject
    {
        public IAttackable CurrentValue { get; private set; }
        public Action<IAttackable> OnNewValue;

        public void SetValue(IAttackable value)
        {
            CurrentValue = value;
            OnNewValue?.Invoke(value);
        }
    }
}
