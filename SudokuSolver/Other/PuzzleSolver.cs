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

        public PuzzleSolver(Puzzle puzzle)
        {
            _puzzle = puzzle;
        }



        public bool Solve()
        {

            var iterator = new PuzzleIterator(_puzzle);
            iterator.First();
            SolveCell();

            return true;
        }

        private void SolveCell()
        {
            var savePuzzle = new Puzzle(_puzzle);

            var acts = new ActOnAllSegments(savePuzzle);

            while (true) //for each candidate 
            {
                _puzzle = savePuzzle; //revert to saved

                //guess
                
                //reduce
                while (!acts.Execute(new ReduceCandidates()));

                //validate (needed? possibly)
                if (!acts.Execute(new ValidateSection()))
                {
                    continue;
                }

                //recursively solve
                SolveCell();
            }

        }


    }
}
