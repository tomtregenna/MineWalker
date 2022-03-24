namespace MineWalker
{
    internal class Tile : ITile
    {
        private readonly IBoard board;
        private readonly int col;
        private readonly int row;
        private TileType tileType;

        public IBoard Board => board;
        public int Column => col;
        public int Row => row;

        public char Letter => (char)col;

        public TileType TileType
        {
            get { return tileType; }
            set { tileType = value; }
        }

        public Tile(IBoard board, ITile tile, TileType type) : this(board, tile.Column, tile.Row, type) { }

        public Tile(IBoard board, int col, int row, TileType type)
        {
            this.board = board;
            this.col = col;
            this.row = row;

            tileType = type;
        }

        public string GetText()
        {
            return tileType switch
            {
                TileType.TILE_EMPTY => "[ ]",
                TileType.TILE_MINE => "[M]",
                TileType.TILE_PATH => "[P]",
                TileType.TILE_PLAYER => "[X]",
                TileType.TILE_WAYPOINT => "[W]",
                _ => "[?]",
            };
        }

        //public Tile(Tile tile)
        //{
        //    col = tile.col;
        //    row = tile.row;
        //}

        //public static int GetColNumber(char val)
        //{
        //    if (!char.IsLetter(val))
        //    {
        //        var capVal = char.ToUpper(val);

        //        if (capVal >= 'A' && capVal <= 'H')
        //            return capVal - 'A';
        //    }

        //    throw new ArgumentOutOfRangeException("Column letter is outside the allowed bounds (A - H).");
        //}
    }
}