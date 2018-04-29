using SudokuSolver.Actions;
using SudokuSolver.Iterators;
using SudokuSolver.SudokuPuzzle;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SudokuSolver.Other
{
    public class PuzzleSolver
    {
        private Puzzle _puzzle;
        private PuzzleIterator _iterator;

        public PuzzleSolver(Puzzle puzzle)
        {
            _puzzle = puzzle;
            _iterator = new PuzzleIterator(_puzzle);
        }

        public bool Solve()
        {
            _iterator.First();
            return SolveCell();
        }

        private bool SolveCell()
        {
            var savePuzzle = new Puzzle(_puzzle);
            var acts = new ActOnAllSegments(_puzzle);

            while (!acts.Execute(new ReduceCandidates()));

            while (FindNextEmptyCell())
            {
                var candidates = _iterator.GetCurrent().Candidates;

                if(candidates.Count == 0)
                {
                    return false;
                }

                foreach (CellValue c in candidates) //for each candidate 
                {
                    _puzzle = savePuzzle; 
                    _iterator.SetCurrent(new Cell(c.Value));

                    while (!acts.Execute(new ReduceCandidates())) ;

                    if (SolveCell())
                    {
                        return true;
                    }
                } 
            }
            return true;

        }

        private bool FindNextEmptyCell()
        {
            while (_iterator.HasNext())
            {
                if (_iterator.GetCurrent().Value == CellValue.Unknown.Value)
                {
                    return true;
                }
                _iterator.Next();
            }

            return false;
        }
    }
}
