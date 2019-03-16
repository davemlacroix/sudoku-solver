using NUnit.Framework;
using SudokuSolver.Contracts;
using SudokuSolver.Iterators;
using SudokuSolver.Other;
using SudokuSolver.SudokuPuzzle;
using System;

namespace SudokuSolverTest.Iterators
{
    [TestFixture]
    [Category("Unit")]
    internal class SubGridIteratorTests
    {
        private Puzzle _puzzle;
        private SubGridIterator _iterator;
        private readonly int[,] _testPuzzle = new int[9, 9]
        {
            { 1, 2, 3, 0, 0, 4, 3, 4, 2 },
            { 4, 5, 6, 0, 0, 0, 0, 0, 0 },
            { 7, 8, 9, 0, 0, 0, 8, 7, 9 },
            { 0, 0, 3, 0, 0, 0, 0, 0, 0 },
            { 0, 0, 0, 0, 0, 0, 0, 0, 0 },
            { 4, 0, 0, 0, 0, 0, 0, 0, 0 },
            { 0, 0, 0, 0, 0, 0, 9, 8, 7 },
            { 0, 0, 8, 0, 0, 0, 6, 5, 4 },
            { 2, 0, 0, 0, 0, 0, 3, 2, 1 }
        };


        [SetUp]
        public void SetUp()
        {
            _puzzle = new Puzzle(_testPuzzle);
            _iterator = new SubGridIterator(_puzzle, 0);
        }


        [Test]
        public void Constructor_WhenCalled_IsOnFirstCell()
        {
            Assert.AreEqual(1, _iterator.GetCurrent().Value);
        }

        [Test]
        public void Constructor_IndexTooLarge_ThrowsError()
        {

            Assert.Throws<ArgumentOutOfRangeException>(
                 () => new SubGridIterator(_puzzle, Constants.NumberOfCellsInSegment));
        }

        [Test]
        public void Constructor_IndexTooSmall_ThrowsError()
        {

            Assert.Throws<ArgumentOutOfRangeException>(
                 () => new SubGridIterator(_puzzle, -1));
        }

        [Test]
        public void First_WhenCalled_MovesToFirstCell()
        {

            _iterator.Next();
            _iterator.Next();
            _iterator.First();

            Assert.AreEqual(1, _iterator.GetCurrent().Value);
        }

        [Test]
        public void IsDone_LastElement_ReturnsTrue()
        {

            for (int i = 0; i < Constants.NumberOfCellsInSegment; i++)
            {
                _iterator.Next();
            }
            Assert.IsTrue(_iterator.IsDone());
        }

        [Test]
        public void IsDone_NotLastElement_ReturnsFalse()
        {

            for (int i = 0; i < Constants.NumberOfCellsInSegment; i++)
            {
                Assert.IsFalse(_iterator.IsDone());
                _iterator.Next();
            }
        }

        [Test]
        public void Next_LastElement_ThrowsError()
        {

            for (int i = 0; i < Constants.NumberOfCellsInSegment; i++)
            {
                _iterator.Next();
            }

            Assert.Throws<InvalidOperationException>(
                 () => _iterator.Next());
        }

        [Test]
        public void SetCurrent_WhenUsed_ChangesValue()
        {

            _iterator.SetCurrent(new Cell(4));

            Assert.AreEqual(4, _iterator.GetCurrent().Value);
        }

        [TestCase(0, new int[9] { 1, 2, 3, 4, 5, 6, 7, 8, 9 })]
        [TestCase(2, new int[9] { 3, 4, 2, 0, 0, 0, 8, 7, 9 })]
        [TestCase(8, new int[9] { 9, 8, 7, 6, 5, 4, 3, 2, 1 })]
        public void Next_IteratesThroughFirstColumn_IteratesThroughPuzzle(int grid, int[] gridValues)
        {

            _iterator = new SubGridIterator(_puzzle, grid);
            foreach (int value in gridValues)
            {
                Assert.AreEqual(value, _iterator.GetCurrent().Value);
                if (!_iterator.IsDone()) { _iterator.Next(); }
            }

        }
    }
}