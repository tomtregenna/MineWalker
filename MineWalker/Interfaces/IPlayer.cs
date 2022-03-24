namespace MineWalker.Interfaces
{
    internal interface IPlayer
    {
        public IGame Game { get; }
        public int Lives { get; }
        public ITile Position { get; }
    }
}
