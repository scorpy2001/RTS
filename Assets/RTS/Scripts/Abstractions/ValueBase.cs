using System;
using RTS.Utils;
using UnityEngine;

namespace RTS.Abstractions
{
    public abstract class ValueBase<T> : ScriptableObject, IAwaitable<T>
    {
        public T CurrentValue { get; private set; }
        public event Action<T> OnChange = delegate { };

        public class NewValueNotifier<TAwaited> : AwaiterBase<TAwaited>
        {
            private readonly ValueBase<TAwaited> _valueBase;

            public NewValueNotifier(ValueBase<TAwaited> valueBase)
            {
                _valueBase = valueBase; 
                _valueBase.OnChange += OnValueBaseChanged;
            }

            private void OnValueBaseChanged(TAwaited obj)
            {
                _valueBase.OnChange -= OnValueBaseChanged;
                OnChanged(obj);
            }
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
