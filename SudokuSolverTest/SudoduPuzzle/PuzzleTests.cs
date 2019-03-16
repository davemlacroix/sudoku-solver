using NUnit.Framework;
using SudokuSolver.SudokuPuzzle;
using System;

namespace SudokuSolverTest.SudoduPuzzle
{
    [TestFixture]
    [Category("Unit")]
    class PuzzleTests
    {
        [Test]
        public void Constructor_WhenCalled_HasEmptyCells()
        {
            Puzzle puzzle = new Puzzle();

            var cell = puzzle.GetCell(2, 3);

            Assert.AreEqual(CellValue.Unknown.Value, cell.Value);
        }

        [TestCase(0, 0, 7)]
        [TestCase(0, 7, 4)]
        [TestCase(3, 0, 8)]
        [TestCase(8, 6, 5)]
        [TestCase(6, 8, 9)]
        [TestCase(4, 4, 6)]
        public void ArrayConstructor_ForGivenIndex_SetsExpectedValue(int row, int col, int expected)
        {
            Puzzle puzzle = new Puzzle(new int[9, 9]
                {
                    { 7, 0, 0, 0, 0, 0, 0, 4, 0 },
                    { 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                    { 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                    { 8, 0, 0, 0, 0, 0, 0, 0, 0 },
                    { 0, 0, 0, 0, 6, 0, 0, 0, 0 },
                    { 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                    { 0, 0, 0, 0, 0, 0, 0, 0, 9 },
                    { 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                    { 0, 0, 0, 0, 0, 0, 5, 0, 0 }
                });

            var cell = puzzle.GetCell(row, col);

            Assert.AreEqual(expected, cell.Value);
        }

        [TestCase(0, 0, 7)]
        [TestCase(0, 7, 4)]
        [TestCase(3, 0, 8)]
        [TestCase(8, 6, 5)]
        [TestCase(6, 8, 9)]
        [TestCase(4, 4, 6)]
        public void CopyConstructor_ForGivenIndex_SetsExpectedValue(int row, int col, int expected)
        {
            Puzzle puzzle = new Puzzle(new int[9, 9]
                {
                    { 7, 0, 0, 0, 0, 0, 0, 4, 0 },
                    { 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                    { 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                    { 8, 0, 0, 0, 0, 0, 0, 0, 0 },
                    { 0, 0, 0, 0, 6, 0, 0, 0, 0 },
                    { 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                    { 0, 0, 0, 0, 0, 0, 0, 0, 9 },
                    { 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                    { 0, 0, 0, 0, 0, 0, 5, 0, 0 }
                });

            Puzzle copyPuzzle = new Puzzle(puzzle);

            var cell = copyPuzzle.GetCell(row, col);

            Assert.AreEqual(expected, cell.Value);
        }

        [Test]
        public void SetCell_WhenCalled_SetsToExpected()
        {
            Puzzle puzzle = new Puzzle();

            puzzle.SetCell(new Cell(5), 2, 3);
            var cell = puzzle.GetCell(2, 3);

            Assert.AreEqual(5, cell.Value);
        }

        [Test]
        public void GetCell_WhenCalled_ReturnsCopy()
        {
            Puzzle puzzle = new Puzzle();

            var cell1 = puzzle.GetCell(2, 2);
            var cell2 = puzzle.GetCell(2, 2);

            cell1.Value = 2;
            cell2.Value = 3;

            Assert.AreEqual(2, cell1.Value);
        }

        [TestCase(-1, 5)]
        [TestCase(9, 5)]
        [TestCase(5, -1)]
        [TestCase(5, 9)]

        public void SetCell_GivenInvalidRange_ThrowsError(int row, int col)
        {
            var puzzle = new Puzzle();

            Assert.Throws<ArgumentOutOfRangeException>(
                 () => puzzle.SetCell(new Cell(), row, col));
        }

        [TestCase(-1, 5)]
        [TestCase(9, 5)]
        [TestCase(5, -1)]
        [TestCase(5, 9)]

        public void GetCell_GivenInvalidRange_ThrowsError(int row, int col)
        {
            var puzzle = new Puzzle();

            Assert.Throws<ArgumentOutOfRangeException>(
                 () => puzzle.GetCell(row, col));
        }
    }
}
