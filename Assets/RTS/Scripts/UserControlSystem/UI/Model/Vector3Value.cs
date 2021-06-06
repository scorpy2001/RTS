using RTS.Abstractions;
using UnityEngine;

namespace RTS.UserControlSystem.UiModel
{
    [CreateAssetMenu(fileName = nameof(Vector3Value), menuName = "Strategy Game/" + nameof(Vector3Value), order = 0)]
    public class Vector3Value : ValueBase<Vector3>
    {
    }
}
