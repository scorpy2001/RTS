using System;
using RTS.Abstractions;
using UnityEngine;

namespace RTS.UserControlSystem.Model
{
    [CreateAssetMenu(fileName = nameof(SelectableValueModel), menuName = "Strategy Game/" + nameof(SelectableValueModel), order = 0)]
    public class SelectableValueModel : ValueBase<ISelectable>
    {
        public override void SetValue(ISelectable value)
        {
            if ((value == null || CurrentValue != value) && CurrentValue != null)
            {
                CurrentValue.Deselect();
            }

            base.SetValue(value);

            CurrentValue?.Select();
        }
    }
}
