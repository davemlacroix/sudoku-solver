using NUnit.Framework;
using SudokuSolver.Actions;
using SudokuSolver.Other;
using SudokuSolver.SudokuPuzzle;

namespace SudokuSolverTest.Other
{
    [TestFixture]
    [Category("Integration")]
    class PuzzleSolverTests
    {
        [Test]
        public void Solve_Puzzle1_SolvesPuzzle()
        {
            var puzzle = new Puzzle(new int[9, 9]
                {
                    { 0, 0, 3, 0, 2, 0, 6, 0, 0},
                    { 9, 0, 0, 3, 0, 5, 0, 0, 1},
                    { 0, 0, 1, 8, 0, 6, 4, 0, 0},
                    { 0, 0, 8, 1, 0, 2, 9, 0, 0},
                    { 7, 0, 0, 0, 0, 0, 0, 0, 8},
                    { 0, 0, 6, 7, 0, 8, 2, 0, 0},
                    { 0, 0, 2, 6, 0, 9, 5, 0, 0},
                    { 8, 0, 0, 2, 0, 3, 0, 0, 9},
                    { 0, 0, 5, 0, 1, 0, 3, 0, 0}
                });

            Solve_WithGivenPuzzle_SolvesPuzzle(puzzle);
        }

        [Test]
        public void Solve_Puzzle2_SolvesPuzzle()
        {
            var puzzle = new Puzzle(new int[9, 9]
                {
                    { 0, 7, 1, 0, 9, 0, 8, 0, 0},
                    { 0, 0, 0, 3, 0, 6, 0, 0, 0},
                    { 4, 9, 0, 0, 0, 0, 7, 0, 5},
                    { 0, 1, 0, 9, 0, 0, 0, 0, 0},
                    { 9, 0, 2, 0, 0, 0, 6, 0, 3},
                    { 0, 0, 0, 0, 0, 8, 0, 2, 0},
                    { 8, 0, 5, 0, 0, 0, 0, 7, 6},
                    { 0, 0, 0, 6, 0, 7, 0, 0, 0},
                    { 0, 0, 7, 0, 4, 0, 3, 5, 0},
                });

            Solve_WithGivenPuzzle_SolvesPuzzle(puzzle);
        }

        [Test]
        public void Solve_Puzzle3_SolvesPuzzle()
        {
            var puzzle = new Puzzle(new int[9, 9]
                {
                    { 7, 1, 0, 0, 0, 0, 0, 9, 0},
                    { 0, 4, 0, 0, 1, 0, 0, 3, 0},
                    { 0, 0, 0, 0, 7, 2, 0, 6, 0},
                    { 9, 0, 0, 0, 0, 4, 0, 0, 5},
                    { 0, 3, 5, 1, 0, 0, 9, 0, 0},
                    { 0, 0, 0, 5, 0, 0, 6, 0, 8},
                    { 1, 0, 0, 2, 0, 9, 7, 0, 0},
                    { 6, 0, 9, 0, 0, 0, 0, 8, 0},
                    { 0, 0, 7, 6, 4, 0, 0, 0, 9},
                });

            Solve_WithGivenPuzzle_SolvesPuzzle(puzzle);
        }

        [Test]
        public void Solve_Puzzle4_SolvesPuzzle()
        {
            var puzzle = new Puzzle(new int[9, 9]
                {
                    { 0, 0, 0, 0, 0, 0, 0, 0, 0},
                    { 4, 0, 0, 6, 0, 9, 0, 0, 1},
                    { 3, 1, 0, 0, 0, 0, 0, 4, 8},
                    { 6, 0, 0, 4, 0, 7, 0, 0, 3},
                    { 0, 0, 7, 0, 1, 0, 5, 0, 0},
                    { 9, 0, 0, 8, 0, 6, 0, 0, 4},
                    { 1, 3, 0, 0, 0, 0, 0, 8, 2},
                    { 7, 0, 0, 2, 0, 3, 0, 0, 6},
                    { 0, 0, 0, 0, 0, 0, 0, 0, 0},
                });

            Solve_WithGivenPuzzle_SolvesPuzzle(puzzle);
        }

        private void Solve_WithGivenPuzzle_SolvesPuzzle(Puzzle puzzle)
        {
            var solver = new PuzzleSolver(puzzle);
            var acts = new ActOnAllSegments(puzzle);
            var printPuzzle = new PrintPuzzle(puzzle);

            solver.Solve();
            printPuzzle.Print();

            Assert.IsTrue(acts.Execute(new ValidateSection()));
        }
    }
}

