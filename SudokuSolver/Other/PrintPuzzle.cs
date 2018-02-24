using SudokuSolver.SudokuPuzzle;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            for (int row = 0; row< 9; row++)
            {
                for (int col = 0; col < 9; col++)
                {
                    Console.Write(_puzzle.GetCell(row, col).Value);
                    Console.Write(" ");
                }
                Console.Write("\n");
            }
        }
    }
}
