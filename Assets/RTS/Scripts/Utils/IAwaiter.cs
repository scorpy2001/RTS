using System.Runtime.CompilerServices;

namespace RTS.Utils
{
    public interface IAwaiter<TAwaited> : INotifyCompletion
    {
        bool IsCompleted { get; }
        TAwaited GetResult();
    }
}
