using SudokuSolver.Contracts;
using SudokuSolver.Other;
using SudokuSolver.SudokuPuzzle;
using System;

namespace SudokuSolver.Iterators
{
    public class SegmentIterator : IIterator
    {
        private int _row;
        private int _col;
        private int _subGrid;
        private int _index;
        private bool _isDone;

        private SegmentIteratorFactory _iteratorFactory;
        private Puzzle _puzzle;
        private IteratorType _type;

        public SegmentIterator(Puzzle puzzle)
        {
            _puzzle = puzzle;
            _iteratorFactory = new SegmentIteratorFactory();
            First();
        }

        public void First()
        {
            _row = 0;
            _col = 0;
            _subGrid = 0;
            _isDone = false;
        }

        public bool IsDone() => _isDone;


        public void Next()
        {
            if (_row < Constants.NumberOfSegmentsByType)
            {
                _index = _row++;
                _type = IteratorType.Row;
            }
            else if (_col < Constants.NumberOfSegmentsByType)
            {
                _index = _col++;
                _type = IteratorType.Column;
            }
            else if (_subGrid < Constants.NumberOfSegmentsByType)
            {
                _index = _subGrid++;
                _type = IteratorType.SubGrid;
                if (_subGrid == Constants.NumberOfSegmentsByType) { _isDone = true; }
            }
            else
            {
                throw new InvalidOperationException("End of iterator.");
            }
        }

        public ISegmentIterator GetCurrent()
        {
            return _iteratorFactory.GetIterator(_type, _puzzle, _index);
        }
    }
}
