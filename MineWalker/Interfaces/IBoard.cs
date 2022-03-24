namespace MineWalker.Interfaces
{
    internal interface IBoard
    {
        public int Height { get; }
        public int Width { get; }

        public ITile GetTileAt(int col, int row);

        public void Initialize();
    }
}
