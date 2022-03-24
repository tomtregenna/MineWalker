namespace MineWalker.Interfaces
{
    internal interface ITile
    {
        public IBoard Board { get; }
        public int Column { get; }
        public int Row { get; }
        public char Letter { get; }
        public TileType TileType { get; set; }

        public string GetText();
    }
}
