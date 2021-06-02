using System;
using RTS.Utils;
using UnityEngine;

namespace RTS.Abstractions
{
    public abstract class ValueBase<T> : ScriptableObject, IAwaitable<T>
    {
        public T CurrentValue { get; private set; }
        public event Action<T> OnChange = delegate { };

        public class NewValueNotifier<TAwaited> : IAwaiter<TAwaited>
        {
            private readonly ValueBase<TAwaited> _valueBase;
            private TAwaited _result;
            private Action _continuation;
            private bool _isCompleted;

            public NewValueNotifier(ValueBase<TAwaited> valueBase)
            {
                _valueBase = valueBase; 
                _valueBase.OnChange += OnValueBaseChanged;
            }

            private void OnValueBaseChanged(TAwaited obj)
            {
                _valueBase.OnChange -= OnValueBaseChanged;
                _result = obj; 
                _isCompleted = true; 
                _continuation?.Invoke();
            }

            public void OnCompleted(Action continuation)
            {
                if (_isCompleted)
                {
                    continuation?.Invoke();
                }
                else
                {
                    _continuation = continuation;
                }
            }

            public bool IsCompleted => _isCompleted; 
            public TAwaited GetResult() => _result;
        }

        public virtual void SetValue(T value)
        {
            CurrentValue = value;
            OnChange.Invoke(value);
        }

        public IAwaiter<T> GetAwaiter()
        {
            return new NewValueNotifier<T>(this);
        }
    }

}
