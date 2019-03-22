using SudokuSolver.Contracts;
using SudokuSolver.Iterators;
using SudokuSolver.Other;
using SudokuSolver.SudokuPuzzle;
using System;

namespace SudokuSolver.Actions
{
    public class ActOnAllSegments
    {
        private Puzzle _puzzle;

        public ActOnAllSegments(Puzzle puzzle)
        {
            _puzzle = puzzle;
        }

        public bool Execute(IAction actionType)
        {
            var success = true;

            foreach(var segment in _puzzle.Segments)
            {
                if (!actionType.Execute(segment))
                {
                    success = false;
                }
            }

            return success;
        }
    }
}
