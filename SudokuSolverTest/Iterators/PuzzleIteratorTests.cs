using NUnit.Framework;
using SudokuSolver.Iterators;
using SudokuSolver.Other;
using SudokuSolver.SudokuPuzzle;
using System;

namespace SudokuSolverTest.Iterators
{
    [TestFixture]
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
        public void Constructor_WhenCalled_IsOnFirstCell()
        {
            Assert.AreEqual(1, _iterator.GetCurrent().Value);
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

            for (int i = 0; i < Constants.NumberOfCellsInPuzzle; i++)
            {
                _iterator.Next();
            }
            Assert.IsTrue(_iterator.IsDone());
        }

        [Test]
        public void IsDone_NotLastElement_ReturnsFalse()
        {

            for (int i = 0; i < Constants.NumberOfCellsInPuzzle; i++)
            {
                Assert.IsFalse(_iterator.IsDone());
                _iterator.Next();
            }
        }

        [Test]
        public void Next_LastElement_ThrowsError()
        {

            for (int i = 0; i < Constants.NumberOfCellsInPuzzle; i++)
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

        [Test]
        public void Next_WhenUsed_IteratesThroughPuzzle()
        {

            foreach (int value in _testPuzzle)
            {
                Assert.AreEqual(value, _iterator.GetCurrent().Value);
                if (!_iterator.IsDone()) { _iterator.Next(); }
            }

        }
    }
}