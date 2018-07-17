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
            var puzzleIterator = new PuzzleIterator(_puzzle);
            puzzleIterator.First();
            ReduceCandidates();

            return SolveCellsRecursively(new PuzzleIterator(puzzleIterator));
        }

        private bool SolveCellsRecursively(PuzzleIterator puzzleIterator)
        {
            if (FindNextUndefinedCell(puzzleIterator))
            {
                return TryEachCandidate(puzzleIterator);
            }
            return PuzzleIsValid();
        }

        private bool TryEachCandidate(PuzzleIterator puzzleIterator)
        {
            var memento = _puzzle.CreateMemento();

            var candidates = puzzleIterator.GetCurrent().Candidates;
            foreach (var candidate in candidates)
            {
                _puzzle.SetMemento(memento);
                GuessCandidate(puzzleIterator, candidate);
                if (PuzzleIsSolved(puzzleIterator))
                {
                    return true;
                }
            }
            return false;
        }

        private void GuessCandidate(PuzzleIterator puzzleIterator, CellValue candidate)
        {
            var cell = new Cell(candidate.Value);
            puzzleIterator.SetCurrent(cell);
            ReduceCandidates();
        }

        private bool PuzzleIsSolved(PuzzleIterator puzzleIterator)
        {
            return PuzzleIsValid() && SolveCellsRecursively(new PuzzleIterator(puzzleIterator));
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