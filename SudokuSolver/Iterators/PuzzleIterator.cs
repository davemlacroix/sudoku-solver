using SudokuSolver.Contracts;
using SudokuSolver.SudokuPuzzle;
using System;
using System.Collections;
using System.Collections.Generic;

namespace SudokuSolver.Iterators
{
    public class PuzzleIterator : IEnumerator<Cell>
    {
        private Puzzle _puzzle;
        private int _position;

        public PuzzleIterator(PuzzleIterator iterator)
        {
            _puzzle = iterator._puzzle;
            _position = iterator._position;
        }

        public PuzzleIterator(Puzzle puzzle)
        {
            _puzzle = puzzle;
            Reset();
        }

        public Cell Current
        {
            get
            {
                if (_position == -1)
                {
                    throw new InvalidOperationException();
                }
                return _puzzle.GetCell(GetRow(), GetCol());
            }
        }

        object IEnumerator.Current
        {
            get { return _puzzle.GetCell(GetRow(), GetCol()); }
        }

        public void Reset()
        {
            _position = -1;
        }

        public bool MoveNext()
        {

            if (_position < Constants.NumberOfCellsInPuzzle-1)
            {
                _position++;
                return true;
            }

            return false;    
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

        public void Dispose() { }
    }
}