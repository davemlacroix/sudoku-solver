using SudokuSolver.Contracts;
using SudokuSolver.SudokuPuzzle;
using System;

namespace SudokuSolver.Iterators
{
    public class RowIterator : ISegmentIterator
    {
        private Puzzle _puzzle;
        private int _row;
        private int _position;

        public RowIterator(Puzzle puzzle, int row)
        {
            ValidateIndex(row);

            _puzzle = puzzle;
            _row = row;
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
            return (_position < 9);
        }

        public Cell GetCurrent()
        {
            if (HasNext())
            {
                return _puzzle.GetCell(_row, _position);
            }
            throw new System.InvalidOperationException("Iterator has reached the end of section");
        }

        public void SetCurrent(Cell cell)
        {
            _puzzle.SetCell(cell, _row, _position);
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
