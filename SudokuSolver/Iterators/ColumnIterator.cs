using SudokuSolver.Contracts;
using SudokuSolver.SudokuPuzzle;
using System;

namespace SudokuSolver.Iterators
{
    public class ColumnIterator : ISegmentIterator
    {
        private Puzzle _puzzle;
        private int _col;
        private int _position;

        public ColumnIterator(Puzzle puzzle, int col)
        {
            ValidateIndex(col);

            _puzzle = puzzle;
            _col = col;
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

        public bool IsDone()
        {
            return (_position >= 9);
        }

        public Cell GetCurrent()
        {
            if (!IsDone())
            {
                return _puzzle.GetCell(_position, _col);
            }
            throw new System.InvalidOperationException("Iterator has reached the end of section");
        }

        public void SetCurrent(Cell cell)
        {
            _puzzle.SetCell(cell, _position, _col);
        }

        private void ValidateIndex(int index)
        {
            if (index < 0 || index > 8)
            {
                throw new ArgumentOutOfRangeException("Invalid index of " + index + ".");
            }
        }
    }
}

