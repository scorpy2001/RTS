using System;
using RTS.Abstractions;
using UnityEngine;

namespace RTS.UserControlSystem.Model
{
    [CreateAssetMenu(fileName = nameof(SelectableValueModel), menuName = "Strategy Game/" + nameof(SelectableValueModel), order = 0)]
    public class SelectableValueModel : ScriptableObject
    {
        public ISelectable CurrentValue { get; private set; }
        public event Action<ISelectable> OnSelected = delegate { };

        public void SetValue(ISelectable value)
        {
            if(value == null && CurrentValue != null){
                CurrentValue.Deselect();
            }
            CurrentValue = value;
            CurrentValue?.Select();
            OnSelected.Invoke(value);
        }
    }
}
