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

            var action = new ActOnAllSegments(_puzzle);
            while (!action.Execute(new ReduceCandidates()));

            return SolveCell(new PuzzleIterator(iterator));
        }

        private bool SolveCell(PuzzleIterator iterator)
        {
            var savePuzzle = new Puzzle(_puzzle);
            var action = new ActOnAllSegments(_puzzle);
            if (!FindNextEmptyCell(iterator))
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
                if(_puzzle.IsCompleted() && action.Execute(new ValidateSection()))
                {
                    return true;
                }

                _puzzle.SetMemento(memento);

                iterator.SetCurrent(new Cell(candidate.Value));
                action = new ActOnAllSegments(_puzzle);
                while (!action.Execute(new ReduceCandidates())) ;

                if (!action.Execute(new ValidateSection()))
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

        private bool FindNextEmptyCell(PuzzleIterator iterator)
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