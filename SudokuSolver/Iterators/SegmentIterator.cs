using SudokuSolver.Contracts;
using SudokuSolver.SudokuPuzzle;
using System;

namespace SudokuSolver.Iterators
{
    public class SegmentIterator
    {
        private int _row;
        private int _col;
        private int _subGrid;
        private bool _hasNext;

        private PuzzleIteratorFactory _iteratorFactory;
        private Puzzle _puzzle;

        public SegmentIterator(Puzzle puzzle)
        {
            _puzzle = puzzle;
            _iteratorFactory = new PuzzleIteratorFactory();

        }

        public void First()
        {
            _row = 0;
            _col = 0;
            _subGrid = 0;
            _hasNext = true;
        }

        public bool HasNext { get => _hasNext; }

        public ISegmentIterator GetNext()
        {
            int index;
            IteratorType type;

            if (_row < 9)
            {
                index = _row++;
                type = IteratorType.Row;
            }
            else if (_col < 9)
            {
                index = _col++;
                type = IteratorType.Column;
            }
            else if (_subGrid < 9)
            {
                index = _subGrid++;
                type = IteratorType.SubGrid;
                if (_subGrid == 9) { _hasNext = false; }
            }
            else
            {
                throw new Exception("End of iterator.");
            }

            return _iteratorFactory.GetIterator(type, _puzzle, index);
        }
    }
}
