

using SudokuSolver.Iterators;
using SudokuSolver.SudokuPuzzle;

namespace SudokuSolver.Other
{
    public class PuzzleCompletedValidator
    {
        private Puzzle _puzzle;

        public PuzzleCompletedValidator(Puzzle puzzle)
        {
            _puzzle = puzzle;
        }

        public bool PuzzleIsCompleted()
        {
            var iterator = new PuzzleIterator(_puzzle);
            while(iterator.MoveNext())
            {
               if(iterator.Current.Value == 0)
                {
                    return false;
                }
            }
            return true;
        }

    }
}
