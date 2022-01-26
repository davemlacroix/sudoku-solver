
using System;
using System.Runtime.Serialization;

namespace SudokuSolver.Api.Models
{

    public class SudokuPuzzleModel
    {

        public SudokuCellModel[][] Puzzle { get; set; }

    }
}
