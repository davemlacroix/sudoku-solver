using SudokuSolver.Contracts;
using SudokuSolver.Other;
using SudokuSolver.SudokuPuzzle;
using System;
using System.Collections;
using System.Collections.Generic;

namespace SudokuSolver.Iterators
{
    public class SegmentIterator : IEnumerator<ISegmentIterator>
    {
        private int _row;
        private int _col;
        private int _subGrid;
        private int _index;

        private SegmentIteratorFactory _iteratorFactory;
        private Puzzle _puzzle;
        private IteratorType _type;

        public SegmentIterator(Puzzle puzzle)
        {
            _puzzle = puzzle;
            _iteratorFactory = new SegmentIteratorFactory();
            Reset();
        }

        public bool MoveNext()
        {
            if (_row < Constants.NumberOfSegmentsByType)
            {
                _index = _row++;
                _type = IteratorType.Row;
                return true;
            }

            if (_col < Constants.NumberOfSegmentsByType)
            {
                _index = _col++;
                _type = IteratorType.Column;
                return true;
            }

            if (_subGrid < Constants.NumberOfSegmentsByType)
            {
                _index = _subGrid++;
                _type = IteratorType.SubGrid;
                return true;
            }

            return false;
        }

        public ISegmentIterator Current
        {
            get
            {
                if (_index == -1)
                {
                    throw new InvalidOperationException();
                }
                return _iteratorFactory.GetIterator(_type, _puzzle, _index);
            }
        }

        object IEnumerator.Current
        {
            get { return Current; }
        }

        public void Dispose() { }

        public void Reset()
        {
            _index = -1;
            _row = 0;
            _col = 0;
            _subGrid = 0;
        }
    }
}
