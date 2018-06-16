using SudokuSolver.Other;
using SudokuSolver.SudokuPuzzle;

namespace SudokuSolver.Iterators
{
    public class PuzzleIterator
    {
        private Puzzle _puzzle;
        private int _position;

        public PuzzleIterator(Puzzle puzzle)
        {
            _puzzle = puzzle;
            _position = 0;
        }

        public void First()
        {
            _position = 0;
        }

        public void Next()
        {
            if (IsDone())
            {
                throw new System.InvalidOperationException("Iterator has reached the end of section");
            }

            _position++;
        }

        public bool IsDone()
        {
            return (_position >= Constants.NumberOfCellsInPuzzle);
        }

        public Cell GetCurrent()
        {
            return _puzzle.GetCell(GetRow(), GetCol());
        }

        public void SetCurrent(Cell cell)
        {
            _puzzle.SetCell(cell, GetRow(), GetCol());
        }

        private int GetRow()
        {
            return _position / Constants.NumberOfCellsInSegment;
        }

        private int GetCol()
        {
            return _position % Constants.NumberOfCellsInSegment;
        }
    }
}