namespace MineWalker
{
    internal class Game : IGame
    {
        private readonly IBoard board;
        private readonly IScreenWriter writer;
        private readonly IPlayer player;

        public IBoard Board => board;
        public IScreenWriter Writer => writer;
        public IPlayer Player => player;

        public Game()
        {
            writer = new ScreenWriter();
            board = new Board(this, 8, 8);
            player = new Player(this, 3);

            Board.Initialize();

            DrawScreen();
        }

        private void DrawScreen()
        {
            Writer.ClearScreen();
            Writer.WriteHeader();
            Writer.DrawBoard(Board);
            Writer.WriteFooter(Player.Lives);
        }
    }
}
