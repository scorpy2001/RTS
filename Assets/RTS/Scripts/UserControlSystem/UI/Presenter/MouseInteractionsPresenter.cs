using System.Linq;
using RTS.Abstractions;
using RTS.UserControlSystem.Model;
using RTS.UserControlSystem.UiModel;
using UnityEngine;
using UnityEngine.EventSystems;

namespace RTS.UserControlSystem.UiPresenter
{
    public class MouseInteractionsPresenter : MonoBehaviour
    {
        [SerializeField] private Camera _camera;
        [SerializeField] private SelectableValueModel _selectedObject;
        [SerializeField] private EventSystem _eventSystem;

        [SerializeField] private AttackTargetValue _attackTargetClicksRMB;
        [SerializeField] private Vector3Value _groundClicksRMB;
        [SerializeField] private Transform _groundTransform;
        private Plane _groundPlane;

        private void Start()
        {
            _groundPlane = new Plane(_groundTransform.up, 0);
        }

        private void Update()
        {
            if (_eventSystem.IsPointerOverGameObject())
            {
                return;
            }
            if (!Input.GetMouseButtonUp(0) && !Input.GetMouseButton(1))
            {
                return;
            }
            var ray = _camera.ScreenPointToRay(Input.mousePosition);
            var hits = Physics.RaycastAll(ray);
            if (Input.GetMouseButtonUp(0))
            {
                if (hits.Length == 0)
                {
                    return;
                }
                var selectable = hits.Select(hit => hit.collider.GetComponentInParent<ISelectable>()).FirstOrDefault(c => c != null);
                _selectedObject.SetValue(selectable);
            }
            else
            {
                var attackable = hits.Select(_ => _.collider.GetComponentInParent<IAttackable>()).FirstOrDefault(_ => _ != null);
                if (attackable != null)
                {
                    _attackTargetClicksRMB.SetValue(attackable);
                }
                else if (_groundPlane.Raycast(ray, out var enter))
                {
                    _groundClicksRMB.SetValue(ray.origin + ray.direction * enter);
                }
            }
        }
    }
}
