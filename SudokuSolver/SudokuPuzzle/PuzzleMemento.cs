namespace SudokuSolver.SudokuPuzzle
{
    public class PuzzleMemento
    {
        private Puzzle _puzzle;
        private Cell [,] _savedState;

        public PuzzleMemento(Puzzle puzzle)
        {
            _puzzle = puzzle;
        }

        public void SaveState()
        {
            _savedState = _puzzle.GetState();
        }

        public void Undo()
        {
            _puzzle.SetState(_savedState);
        }
    }
}
