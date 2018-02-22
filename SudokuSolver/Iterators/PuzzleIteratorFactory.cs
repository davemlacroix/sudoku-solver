using SudokuSolver.Contracts;
using SudokuSolver.SudokuPuzzle;
using System;

namespace SudokuSolver.Iterators
{
    public class PuzzleIteratorFactory
    {
        public ISegmentIterator GetIterator(IteratorType type, Puzzle puzzle, int index)
        {
            switch (type)
            {
                case IteratorType.Row:
                    return new RowIterator(puzzle, index);
                case IteratorType.Column:
                    return new ColumnIterator(puzzle, index);
                case IteratorType.SubGrid:
                    return new SubGridIterator(puzzle, index);
                default:
                    throw new ArgumentException("Invalid Iterator Type.");
            }
        }
    }
}
