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
            if (Input.GetMouseButtonUp(0))
            {
                var hits = Physics.RaycastAll(ray);
                if (hits.Length == 0)
                {
                    return;
                }
                var selectable = hits.Select(hit => hit.collider.GetComponentInParent<ISelectable>()).FirstOrDefault(c => c != null);
                _selectedObject.SetValue(selectable);
            }
            else
            {
                if (_groundPlane.Raycast(ray, out var enter))
                {
                    _groundClicksRMB.SetValue(ray.origin + ray.direction * enter);
                }
            }
        }
    }
}
