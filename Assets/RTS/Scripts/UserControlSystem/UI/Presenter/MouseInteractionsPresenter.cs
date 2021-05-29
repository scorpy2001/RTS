using System.Linq;
using RTS.Abstractions;
using UnityEngine;

namespace RTS.UserControlSystem.UiPresenter
{
    public class MouseInteractionsPresenter : MonoBehaviour
    {
        [SerializeField] private Camera _camera;
        [SerializeField] private SelectableValueModel _selectedObject;

        private void Update()
        {
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
