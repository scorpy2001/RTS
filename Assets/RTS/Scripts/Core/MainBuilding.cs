using RTS.Abstractions;
using UnityEngine;

namespace RTS.Core
{
    public class MainBuilding : MonoBehaviour, IUnitProducer, ISelectable
    {
        [SerializeField] private GameObject _unitPrefab;
        [SerializeField] private Transform _unitsParent;
        [SerializeField] private float _maxHealth = 1000f;
        [SerializeField] private Sprite _icon;
        private float _health;

        public float Health => _health;

        public float MaxHealth => _maxHealth;

        public Sprite Icon => _icon;

        private void Awake()
        {
            _health = _maxHealth;
        }

        public void ProduceUnit()
        {
            Instantiate(_unitPrefab, new Vector3(Random.Range(-10, 10), 0, Random.Range(-10, 10)), Quaternion.identity, _unitsParent);
        }
    }
}