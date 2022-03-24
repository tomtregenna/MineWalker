namespace MineWalker
{
    internal class Player : IPlayer
    {
        private readonly IGame game;
        private readonly int lives;
        private readonly ITile position;

        public IGame Game => game;
        public int Lives => lives;

        public ITile Position {
            get { return position; }
            set { SetPosition(value); }
        }

        public Player(IGame game, int lives)
        {
            this.game = game;
            this.lives = lives;

            // Set initial position
            position = game.Board.GetTileAt(0, (int)Math.Round((decimal)(game.Board.Height - 1) / 2));
            position.TileType = TileType.TILE_PLAYER;
        }

        private void SetPosition(ITile newPosition)
        {
            Position.TileType = TileType.TILE_EMPTY;
            Position = newPosition;
            Position.TileType = TileType.TILE_PLAYER;
        }
    }
}
