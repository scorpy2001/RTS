namespace RTS.Abstractions
{
    public interface IAttackCommand : ICommand
    {
        IAttackable Target { get; }
    }
}
