using System.Linq;
using RTS.Abstractions;
using RTS.UserControlSystem.Model;
using UnityEngine;
using UnityEngine.EventSystems;

namespace RTS.UserControlSystem.UiPresenter
{
    public class MouseInteractionsPresenter : MonoBehaviour
    {
        [SerializeField] private Camera _camera;
        [SerializeField] private SelectableValueModel _selectedObject;
        [SerializeField] private EventSystem _eventSystem;

        private void Update()
        {
            if (_eventSystem.IsPointerOverGameObject())
            {
                return;
            }

            if (!Input.GetMouseButtonUp(0))
            {
                return;
            }

            var hits = Physics.RaycastAll(_camera.ScreenPointToRay(Input.mousePosition));
            if (hits.Length == 0)
            {
                return;
            }
            var selectable = hits.Select(hit => hit.collider.GetComponentInParent<ISelectable>()).FirstOrDefault(c => c != null);
            _selectedObject.SetValue(selectable);
        }
    }
}
