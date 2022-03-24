namespace MineWalker
{
    internal class Board : IBoard
    {
        private readonly IGame game;
        private readonly ITile[,] tiles;
        private readonly Random rnd;
        private readonly IList<ITile> waypoints;
        private readonly IList<ITile> path;
        private readonly int width;
        private readonly int height;
        private readonly int waypointCount;

        public int Width { get { return width; } }
        public int Height { get { return height; } }
        public IList<ITile> Path { get { return path; } }

        public Board(IGame game, int cols, int rows)
        {
            this.game = game;

            rnd = new();

            // Set the minimum board size to 3x3
            if (cols < 3 || cols > 26)
                throw new ArgumentOutOfRangeException(nameof(cols));

            // Set the maximum board size to 26x26 (e.g. A-Z)
            if (rows < 3 || rows > 26)
                throw new ArgumentOutOfRangeException(nameof(rows));

            // Dimension the 2D array
            tiles = new Tile[cols, rows];

            width = tiles.GetLength(0);
            height = tiles.GetLength(1);

            // Create new Tiles in the array
            for (int col = 0; col < width; col++)
            {
                for (int row = 0; row < height; row++)
                {
                    tiles[col, row] = new Tile(this, col, row, TileType.TILE_EMPTY);
                }
            }

            waypointCount = rnd.Next(2, (int)Math.Round((decimal)width / 2));
            waypoints = new List<ITile>();

            path = new List<ITile>();
        }

        public void Initialize()
        {
            // Set out waypoints for a known good path
            GenerateWaypoints();

            // Create a known good path via waypoints
            FindPath();
        }

        public ITile GetTileAt(int col, int row)
        {
            if ((col >= width) || (col < 0))
                throw new ArgumentOutOfRangeException(nameof(col));

            if ((row >= height) || (row < 0))
                throw new ArgumentOutOfRangeException(nameof(row));

            return tiles[col, row];
        }

        public void SetTile(ITile newTile)
        {
            if ((newTile.Column >= width) || (newTile.Column < 0))
                throw new ArgumentOutOfRangeException(nameof(newTile.Column));

            if ((newTile.Row >= height) || (newTile.Row < 0))
                throw new ArgumentOutOfRangeException(nameof(newTile.Row));

            tiles[newTile.Column, newTile.Row].TileType = newTile.TileType;
        }

        private void GenerateWaypoints()
        {
            var lastCol = 0;            

            for (int i = 0; i < waypointCount; i++)
            {
                var col = rnd.Next(lastCol + 1, width - (waypointCount - waypoints.Count));
                var row = rnd.Next(0, height);

                lastCol = col;

                var newTile = new Tile(this, col, row, TileType.TILE_WAYPOINT);

                waypoints.Add(newTile);
                SetTile(newTile);
            }
        }

        private void FindPath()
        {
            ITile currentTile = game.Player.Position;

            path.Add(new Tile(this, currentTile, TileType.TILE_PATH));

            foreach (var waypoint in waypoints)
            {
                // Trace path to the right until in the same column as the waypoint
                while (currentTile.Column < waypoint.Column)
                {
                    currentTile = GetTileAt(currentTile.Column + 1, currentTile.Row);

                    var newTile = new Tile(this, currentTile, TileType.TILE_PATH);

                    path.Add(newTile);
                    SetTile(newTile);
                }

                // Trace path up or down until in the same row as the waypoint
                while (currentTile.Row != waypoint.Row)
                {
                    currentTile = (currentTile.Row < waypoint.Row)
                       ? GetTileAt(currentTile.Column, currentTile.Row + 1)
                       : GetTileAt(currentTile.Column, currentTile.Row - 1);

                    var newTile = new Tile(this, currentTile, TileType.TILE_PATH);

                    path.Add(newTile);
                    SetTile(newTile);
                }

                SetTile(waypoint);
            }

            // Trace path to the right until at the far right of the board
            while (currentTile.Column < (width - 1))
            {
                currentTile = GetTileAt(currentTile.Column + 1, currentTile.Row);

                var newTile = new Tile(this, currentTile, TileType.TILE_PATH);

                path.Add(newTile);
                SetTile(newTile);
            }
        }
    }
}
