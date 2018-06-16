using System;
using SudokuSolver.Contracts;
using SudokuSolver.Other;
using SudokuSolver.SudokuPuzzle;

namespace SudokuSolver.Iterators
{
    public class SubGridIterator : ISegmentIterator
    {

        private Puzzle _puzzle;
        private int _col;
        private int _row;
        private int _position;

        public SubGridIterator(Puzzle puzzle, int section)
        {
            ValidateIndex(section);

            _puzzle = puzzle;
            _row = (section / 3) * 3;
            _col = (section % 3) * 3;
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
            return (_position >= Constants.NumberOfCellsInSegment);
        }

        public Cell GetCurrent()
        {
            return _puzzle.GetCell(GetRow(), GetCol());

        }

        public void SetCurrent(Cell cell)
        {
            _puzzle.SetCell(cell, GetRow(), GetCol());
        }

        private void ValidateIndex(int index)
        {
            if (index < 0 || index >= Constants.NumberOfCellsInSegment)
            {
                throw new ArgumentOutOfRangeException("Invalid index of " + index + ".");
            }
        }

        private int GetRow()
        {
            return _row + (_position / 3);
        }

        private int GetCol()
        {
            return _col + (_position % 3);
        }
    }
}


