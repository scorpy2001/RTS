using RTS.Abstractions;
using UniRx;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace RTS.UserControlSystem.UiPresenter
{
    public class MenuPresenter : MonoBehaviour
    {
        [SerializeField] private Button _backButton;
        [SerializeField] private Button _exitButton;

        private void Start()
        {
            _backButton.OnClickAsObservable().Subscribe(_ => gameObject.SetActive(false));

            _exitButton.OnClickAsObservable().Subscribe(_ =>
            {
#if UNITY_EDITOR
                EditorApplication.isPlaying = false;
#else
                Application.Quit();
#endif
            });
        }

        [Inject]
        private void Init(ITimeModel timeModel)
        {
            _backButton.OnClickAsObservable().Subscribe(_ =>
            {
                gameObject.SetActive(false);
                timeModel.Unpause();
            });
        }

    }
}
