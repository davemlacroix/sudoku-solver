using SudokuSolver.Contracts;
using SudokuSolver.Iterators;
using System;
using System.Linq;

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
            _puzzle = new Cell[9, 9];
            for (int row = 0; row < 9; row++)
            {
                for (int col = 0; col < 9; col++)
                {
                    _puzzle[row, col] = new Cell(puzzle.GetCell(row, col));
                }
            }
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

        public Cell[,] GetState()
        {

            var copy = new Cell[9, 9];
            for (int row = 0; row < 9; row++)
            {
                for (int col = 0; col < 9; col++)
                {
                    copy[row, col] = new Cell(_puzzle[row, col]);
                }
            }
            return copy;
        }

        public void SetState(Cell [,] puzzle)
        {
            for (int row = 0; row < 9; row++)
            {
                for (int col = 0; col < 9; col++)
                {
                    _puzzle[row, col] = new Cell(puzzle[row, col]);
                }
            }
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
    }
}
