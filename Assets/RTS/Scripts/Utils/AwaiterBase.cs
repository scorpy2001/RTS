using System;

namespace RTS.Utils
{
    public abstract class AwaiterBase<TAwaited> : IAwaiter<TAwaited>
    {
        private TAwaited _result;
        private Action _continuation;
        private bool _isCompleted;

        public bool IsCompleted => _isCompleted;

        public TAwaited GetResult() => _result;

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

        protected void OnChanged(TAwaited obj)
        {
            _result = obj;
            _isCompleted = true;
            _continuation?.Invoke();
        }

    }
}
