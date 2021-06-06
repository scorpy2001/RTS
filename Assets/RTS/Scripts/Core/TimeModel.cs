using System;
using RTS.Abstractions;
using UniRx;
using UnityEngine;
using Zenject;

namespace RTS.Core
{
    public class TimeModel : ITimeModel, ITickable
    {
        private ReactiveProperty<float> _gameTime = new ReactiveProperty<float>();
        private bool _isPaused;

        public IObservable<int> GameTime => _gameTime.Select(f => (int)f);

        public void Tick()
        {
            // if (!_isPaused)
            {
                _gameTime.Value += Time.deltaTime;
            }
        }

        public void Pause()
        {
            _isPaused = true;
            Time.timeScale = 0;
        }

        public void Unpause()
        {
            _isPaused = false;
            Time.timeScale = 1;
        }
    }
}
