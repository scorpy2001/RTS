using UnityEngine;

namespace RTS.Abstractions
{
    public interface ISelectable
    {
        float Health { get; }
        float MaxHealth { get; }
        Sprite Icon { get; }
        Transform Transform { get; }

        void Select();
        void Deselect();
    }
}
