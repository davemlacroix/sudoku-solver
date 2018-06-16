using SudokuSolver.Contracts;
using SudokuSolver.Iterators;
using SudokuSolver.SudokuPuzzle;

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
            var iterator = new SegmentIterator(_puzzle);
            var success = true;

            iterator.First();
            while (!iterator.IsDone())
            {
                iterator.Next();
                if (!actionType.Execute(iterator.GetCurrent())) { success = false; }
            }

            return success;
        }
    }
}
