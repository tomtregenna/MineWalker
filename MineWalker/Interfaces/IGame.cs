namespace MineWalker.Interfaces
{
    internal interface IGame
    {
        public IBoard Board { get; }
        public IScreenWriter Writer { get; }
        public IPlayer Player { get; }
    }
}
