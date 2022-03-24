namespace MineWalker.Interfaces
{
    internal interface IScreenWriter
    {
        public void ClearScreen();
        public void WriteHeader();
        public void DrawBoard(IBoard board);
        public void WriteFooter(int lives);
    }
}
