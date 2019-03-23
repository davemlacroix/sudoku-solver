using SudokuSolver.Contracts;
using SudokuSolver.SudokuPuzzle;
using System;

namespace SudokuSolver.Other
{
    public class PrintPuzzle
    {
        private Puzzle _puzzle;

        public PrintPuzzle(Puzzle puzzle)
        {
            _puzzle = puzzle;
        }

        public void Print()
        {

            //this assumes the PuzzleIterator iterates through row by row
            //which means this is coupled with PuzzleIterator
            var col = 0;
            foreach (var cell in _puzzle.Cells)
            {
                Console.Write(cell.Value);
                Console.Write(" ");
                if (++col >= Constants.NumberOfCellsInSegment)
                {
                    Console.Write("\n");
                    col = 0;
                }
            }
        }
    }
}
