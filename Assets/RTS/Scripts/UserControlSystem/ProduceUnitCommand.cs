using RTS.Abstractions;
using RTS.Utils;
using UnityEngine;

namespace RTS.UserControlSystem
{
    public class ProduceUnitCommand : IProduceUnitCommand
    {
        [InjectAsset("unit_Tank_Combat_B")]private GameObject _unitPrefab;
        public GameObject UnitPrefab => _unitPrefab;
    }
}
