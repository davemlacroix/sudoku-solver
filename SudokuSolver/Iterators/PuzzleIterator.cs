using SudokuSolver.SudokuPuzzle;
using System;

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
            _position++;
        }

        public bool HasNext()
        {
            return (_position < 81);
        }

        public Cell GetCurrent()
        {
            if (HasNext())
            {
                return _puzzle.GetCell(GetRow(), GetCol());
            }
            throw new System.InvalidOperationException("Iterator has reached the end of section");
        }

        public void SetCurrent(Cell cell)
        {
            _puzzle.SetCell(cell, GetRow(), GetCol());
        }

        private int GetRow()
        {
            return _position / 9;
        }

        private int GetCol()
        {
            return _position % 9;
        }
    }
}
