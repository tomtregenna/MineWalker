namespace MineWalker
{
    internal class ScreenWriter : IScreenWriter
    {
        public ScreenWriter()
        {

        }

        public void ClearScreen()
        {
            Console.Clear();
        }

        public void WriteHeader()
        {
            Console.WriteLine("Welcome to MineWalker");
            Console.WriteLine("=====================");
            Console.WriteLine(String.Empty);
            Console.WriteLine("Using the arrow keys, navigate from one side of the board to the other whilst avoiding the mines.");
            Console.WriteLine("Each mine hit will result in a lost life. When all lives are lost, the game is over.");
            Console.WriteLine(String.Empty);
        }

        public void DrawBoard(IBoard board)
        {
            for (var row = (board.Height - 1); row >= 0; row--)
            {
                for (var col = 0; col < board.Width; col++)
                {
                    Console.Write(board.GetTileAt(col, row).GetText());
                }
                    //if (path.Any(x => x.colNo.Equals(col) && x.rowNo.Equals(row)))
                    //    if (waypoints.Any(x => x.colNo.Equals(col) && x.rowNo.Equals(row)))

                    //    else
                    //        Console.Write("[x]");
                    //else
                    //    Console.Write("[ ]");

                Console.WriteLine();
            }
        }

        public void WriteFooter(int lives)
        {
            Console.WriteLine($"Lives remaining: {lives}");
        }


    }
}
