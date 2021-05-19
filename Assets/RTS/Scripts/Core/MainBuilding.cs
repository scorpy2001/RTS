using RTS.Abstractions;
using UnityEngine;

namespace RTS.Core
{
    public class MainBuilding : CommandExecutorBase<IProduceUnitCommand>, ISelectable
    {
        [SerializeField] private Transform _unitsParent;
        [SerializeField] private float _maxHealth = 1000f;
        [SerializeField] private Sprite _icon;
        [SerializeField] private Outline _outline;
        private float _health;

        public float Health => _health;

        public float MaxHealth => _maxHealth;

        public Sprite Icon => _icon;

        private void Awake()
        {
            _health = _maxHealth;
        }

        public void Select()
        {
            _outline.OutlineMode = Outline.Mode.OutlineAll;
        }

        public void Deselect()
        {
            _outline.OutlineMode = Outline.Mode.None;
        }

        protected override void ExecuteSpecificCommand(IProduceUnitCommand command)
        {
            Instantiate(command.UnitPrefab, new Vector3(Random.Range(-10, 10), 0, Random.Range(-10, 10)), Quaternion.identity, _unitsParent);
        }
    }
}