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
    internal class PuzzleIteratorTests
    {
        private PuzzleIterator _iterator;
        private int[,] _testPuzzle = new int[9, 9]
        {
            { 1, 2, 0, 0, 0, 4, 0, 8, 5 },
            { 7, 0, 0, 0, 0, 0, 0, 0, 0 },
            { 0, 0, 0, 0, 0, 0, 0, 0, 0 },
            { 0, 0, 0, 0, 0, 0, 0, 0, 0 },
            { 0, 0, 0, 0, 0, 0, 0, 0, 0 },
            { 0, 0, 0, 0, 0, 0, 0, 0, 0 },
            { 0, 0, 0, 0, 0, 0, 0, 0, 0 },
            { 0, 0, 0, 0, 0, 0, 0, 0, 0 },
            { 0, 0, 0, 0, 0, 0, 0, 0, 3 }
        };

        [SetUp]
        public void SetUp()
        {
            var puzzle = new Puzzle(_testPuzzle);
            _iterator = new PuzzleIterator(puzzle);
        }

        [Test]
        public void MoveNext_NotLastElement_ReturnsTrue()
        {
            Assert.IsTrue(_iterator.MoveNext());
        }

        [Test]
        public void MoveNext_LastElement_ReturnsFalse()
        {
            bool success = true;
            for (int i = 0; i <= Constants.NumberOfCellsInPuzzle; i++)
            {
                success = _iterator.MoveNext();
            }

            Assert.IsFalse(success);
        }

        [Test]
        public void SetCurrent_WhenUsed_ChangesValue()
        {

            _iterator.MoveNext();
            _iterator.SetCurrent(new Cell(4));

            Assert.AreEqual(4, _iterator.Current.Value);
        }

        [Test]
        public void MoveNext_WhenUsed_IteratesThroughPuzzle()
        {
            _iterator.MoveNext();
            foreach (int value in _testPuzzle)
            {
                Assert.AreEqual(value, _iterator.Current.Value);
                _iterator.MoveNext();
            }

        }

        [Test]
        public void Current_AfterReset_ThrowsInvalidOperationException()
        {
            _iterator.Reset();
            Assert.Throws<InvalidOperationException>(
                 () => { var result = _iterator.Current; });
        }

    }
}