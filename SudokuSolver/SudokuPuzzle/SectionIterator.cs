
using System;

namespace SudokuSolver.SudokuPuzzle
{
    public class SectionIterator
    {
        private Cell[] _cells;
        private int _position;

        public SectionIterator(Cell [] cells)
        {
            if(cells.GetLength(0) != 9)
            {
                throw new ArgumentOutOfRangeException("Section must have exactly 9 cells.");
            }

            _cells = cells;
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
            return (_position != 9);
        }

        public Cell GetCurrent()
        {
            return new Cell(_cells[_position]);
        }

        public void SetCell(Cell cell)
        {
            _cells[_position] = cell;
        }

    }
}
