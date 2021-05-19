using RTS.Abstractions;
using UnityEngine;

namespace RTS.UserControlSystem
{
    public class ProduceUnitCommand : IProduceUnitCommand
    {
        [SerializeField] private GameObject _unitPrefab;
        public GameObject UnitPrefab => _unitPrefab;
    }
}
