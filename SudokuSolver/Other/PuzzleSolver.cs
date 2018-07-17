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
            var savePuzzle = new Puzzle(_puzzle);
            var action = new ActOnAllSegments(_puzzle);
            if (!GetNextUndefinedCell(iterator))
            {
                return true; //may not be solved;
            }

            var candidates = iterator.GetCurrent().Candidates;
            if (candidates.Count == 0)
            {
                return false;
            }
            var memento = _puzzle.CreateMemento();

            var solved = false;
            foreach (var candidate in candidates)
            {
                if (_puzzle.IsCompleted() && PuzzleIsValid())
                {
                    return true;
                }

                _puzzle.SetMemento(memento);

                iterator.SetCurrent(new Cell(candidate.Value));
                ReduceCandidates();

                if (!PuzzleIsValid())
                {
                    continue;
                }
                if (!SolveCell(new PuzzleIterator(iterator)))
                {
                    continue;
                }
                solved = true;
            }
            return solved;
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

        private bool GetNextUndefinedCell(PuzzleIterator iterator)
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