using RTS.Abstractions;
using UnityEngine;

namespace RTS.Core
{
    public class SelectableUnit : MonoBehaviour, ISelectable
    {
        [SerializeField] private float _maxHealth = 1000f;
        [SerializeField] private Sprite _icon;
        [SerializeField] private Outline _outline;
        private float _health;

        public float Health => _health;

        public float MaxHealth => _maxHealth;

        public Sprite Icon => _icon;

        public Transform Transform => gameObject.transform;

        private void Awake()
        {
            _health = _maxHealth;
        }

        public void Deselect()
        {
            _outline.OutlineMode = Outline.Mode.None;
        }

        public void Select()
        {
            _outline.OutlineMode = Outline.Mode.OutlineAll;
        }
    }
}
