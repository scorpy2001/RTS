using RTS.Abstractions;
using UnityEngine;

namespace RTS.UserControlSystem.UiModel
{
    [CreateAssetMenu(fileName = nameof(AttackTargetValue), menuName = "Strategy Game/" + nameof(AttackTargetValue), order = 0)]

    public class AttackTargetValue : ValueBase<IAttackable>
    {
    }
}
