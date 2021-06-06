using RTS.Abstractions;
using TMPro;
using Zenject;
using System;
using UnityEngine;
using UniRx;
using UnityEngine.UI;

namespace RTS.UserControlSystem.UiPresenter
{
    public class TopPanelPresenter : MonoBehaviour
    {
        [SerializeField] private TMP_Text _time;
        [SerializeField] private Button _menuButton;
        [SerializeField] private GameObject _menuGo;

        [Inject]
        private void Init(ITimeModel timeModel)
        {
            timeModel.GameTime.Subscribe(seconds =>
            {
                var t = TimeSpan.FromSeconds(seconds);
                _time.text = string.Format($"{t.Hours:D2}:{t.Minutes:D2}:{t.Seconds:D2}");
            });

            _menuButton.OnClickAsObservable().Subscribe(_ =>
            {
                _menuGo.SetActive(true);
                timeModel.Pause();
            });
        }
    }
}
