using SudokuSolver.Actions;
using SudokuSolver.Contracts;
using SudokuSolver.Iterators;
using SudokuSolver.SudokuPuzzle;
using System;

namespace SudokuSolver.Other
{
    public class PuzzleSolver
    {
        private Puzzle _puzzle;

        public PuzzleSolver(Puzzle puzzle)
        {
            _puzzle = puzzle;
        }

        public bool Solve()
        {
            var iterator = new PuzzleIterator(_puzzle);
            iterator.First();

            ReduceCandidates();

            return SolveCell(new PuzzleIterator(iterator));
        }

        private bool SolveCell(PuzzleIterator iterator)
        {
            if (!FindNextUndefinedCell(iterator))
            {
                return true; //may not be solved;
            }

            var memento = _puzzle.CreateMemento();

            var candidates = iterator.GetCurrent().Candidates;
            foreach (var candidate in candidates)
            {
                _puzzle.SetMemento(memento);

                var cell = new Cell(candidate.Value);
                iterator.SetCurrent(cell);
                ReduceCandidates();

                if(PuzzleIsSolved(iterator))
                {
                    return true;
                }  
            }
            return false;
        }

        private bool PuzzleIsSolved(PuzzleIterator puzzleIterator)
        {
            return PuzzleIsValid() && SolveCell(new PuzzleIterator(puzzleIterator));
        }

        private bool PuzzleIsValid()
        {
            var action = new ActOnAllSegments(_puzzle);
            var validateSection = new ValidateSection();
            return action.Execute(validateSection);
        }

        private void ReduceCandidates()
        {
            var action = new ActOnAllSegments(_puzzle);
            var reduceCandidates = new ReduceCandidates();
            while (!action.Execute(reduceCandidates));
        }

        private bool FindNextUndefinedCell(PuzzleIterator iterator)
        {
            while (!iterator.IsDone())
            {
                if (iterator.GetCurrent().Value == CellValue.Unknown.Value)
                {
                    return true;
                }
                iterator.Next();
            }
            return false;
        }
    }
}