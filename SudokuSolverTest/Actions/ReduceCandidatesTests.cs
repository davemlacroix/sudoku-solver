
using NUnit.Framework;
using SudokuSolver.Actions;
using SudokuSolver.Iterators;
using SudokuSolver.SudokuPuzzle;

namespace SudokuSolverTest.Actions
{
    [TestFixture]
    [Category("Unit")]
    class ReduceCandidatesTests
    {
        [Test]
        public void Execute_PassedValues_ReducesCandidates()
        {
            var puzzle = new Puzzle(new int[9, 9]
                {
                    { 7, 6, 8, 0, 0, 0, 0, 4, 0 },
                    { 0, 2, 0, 0, 0, 0, 0, 0, 0 },
                    { 3, 9, 0, 0, 0, 0, 0, 0, 0 },
                    { 8, 0, 0, 0, 0, 0, 0, 0, 0 },
                    { 0, 0, 0, 0, 6, 0, 0, 0, 0 },
                    { 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                    { 0, 0, 0, 0, 0, 0, 0, 0, 9 },
                    { 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                    { 0, 0, 0, 0, 0, 0, 5, 0, 0 }
                });
            var iterator = new SubGridIterator(puzzle, 0);
            var reduce = new ReduceCandidates();

            var result = reduce.Execute(iterator);
            var cell = puzzle.GetCell(1, 0);

            Assert.AreEqual(3, cell.Candidates.Count);
        }
    }
}
