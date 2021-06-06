using System.Linq;
using RTS.Abstractions;
using RTS.UserControlSystem.Model.ScriptableObjects;
using UniRx;
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

            var leftClickStream = Observable.EveryUpdate().Where(_ => Input.GetMouseButtonDown(0) && !_eventSystem.IsPointerOverGameObject());
            leftClickStream.Subscribe(LeftMouseButtonClick);
            var rightClickStream = Observable.EveryUpdate().Where(_ => Input.GetMouseButtonDown(1) && !_eventSystem.IsPointerOverGameObject());
            rightClickStream.Subscribe(RightMouseButtonClick);
        }

        private void LeftMouseButtonClick(long _)
        {
            var ray = _camera.ScreenPointToRay(Input.mousePosition);
            var hits = Physics.RaycastAll(ray);

            if (hits.Length == 0)
            {
                return;
            }
            var selectable = hits.Select(hit => hit.collider.GetComponentInParent<ISelectable>()).FirstOrDefault(c => c != null);
            _selectedObject.SetValue(selectable);

        }

        private void RightMouseButtonClick(long _)
        {
            var ray = _camera.ScreenPointToRay(Input.mousePosition);
            var hits = Physics.RaycastAll(ray);

            var attackable = hits.Select(hit => hit.collider.GetComponentInParent<IAttackable>()).FirstOrDefault(attackable => attackable != null);
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
