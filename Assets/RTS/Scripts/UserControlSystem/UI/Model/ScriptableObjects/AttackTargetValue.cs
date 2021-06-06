using RTS.Abstractions;
using UnityEngine;

namespace RTS.UserControlSystem.Model.ScriptableObjects
{
    [CreateAssetMenu(fileName = nameof(AttackTargetValue), menuName = "Strategy Game/" + nameof(AttackTargetValue), order = 0)]

    public class AttackTargetValue : ValueBase<IAttackable>
    {
    }
}
