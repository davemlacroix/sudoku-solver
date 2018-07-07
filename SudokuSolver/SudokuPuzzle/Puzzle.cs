using SudokuSolver.Contracts;
using System;
using SudokuSolver.Other;

namespace SudokuSolver.SudokuPuzzle
{
    public class Puzzle
    {
        private Cell[,] _puzzle;

        public Puzzle()
        {
            _puzzle = new Cell[9, 9];
            for (int row = 0; row < 9; row++)
            {
                for (int col = 0; col < 9; col++)
                {
                    _puzzle[row, col] = new Cell();
                }
            }
        }

        public Puzzle(int[,] puzzle)
        {
            ValidateSize(puzzle.GetLength(0));
            ValidateSize(puzzle.GetLength(1));

            _puzzle = new Cell[9, 9];
            for (int row = 0; row < 9; row++)
            {
                for (int col = 0; col < 9; col++)
                {
                    _puzzle[row, col] = new Cell(puzzle[row, col]);
                }
            }
        }

        public Puzzle(Puzzle puzzle)
        {
            _puzzle = CopyPuzzle(puzzle._puzzle);
        }

        public void SetCell(Cell cell, int row, int col)
        {
            ValidateIndex(row);
            ValidateIndex(col);

            _puzzle[row, col] = cell;
        }

        public Cell GetCell(int row, int col)
        {
            ValidateIndex(row);
            ValidateIndex(col);

            return new Cell(_puzzle[row, col]);
        }

        public IMemento CreateMemento()
        {
            return new PuzzleMemento() { State = CopyPuzzle(_puzzle)};
        }

        public void SetMemento(IMemento memento)
        {
            _puzzle = CopyPuzzle((Cell[,]) memento.State);
        }

        private class PuzzleMemento : IMemento
        {
            public object State { get; set; }
        }

        public bool IsCompleted()
        {
            //this needs to be replaced
            for (int row = 0; row < 9; row++)
            {
                for (int col = 0; col < 9; col++)
                {
                    if(_puzzle[row, col].Value == CellValue.Unknown.Value)
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        private void ValidateIndex(int index)
        {
            if (index < 0 || index > 8)
            {
                throw new ArgumentOutOfRangeException("Invalid index of " + index + ".");
            }
        }

        private void ValidateSize(int size)
        {
            if (size != 9)
            {
                throw new ArgumentOutOfRangeException("Invalid array size of " + size + ".");
            }
        }

        private Cell[,] CopyPuzzle(Cell[,] puzzle)
        {
            var copy = new Cell[9, 9];
            for (int row = 0; row < Constants.NumberOfCellsInSegment; row++)
            {
                for (int col = 0; col < Constants.NumberOfCellsInSegment; col++)
                {
                    copy[row, col] = new Cell(puzzle[row, col]);
                }
            }
            return copy;
        }
    }
}
