﻿using NUnit.Framework;
using SudokuSolver.Contracts;
using SudokuSolver.Iterators;
using SudokuSolver.Other;
using SudokuSolver.SudokuPuzzle;
using System;

namespace SudokuSolverTest.Iterators
{
    [TestFixture]
    [Category("Unit")]
    internal class ColumnIteratorTests
    {
        private Puzzle _puzzle;
        private ColumnIterator _iterator;
        private readonly int[,] _testPuzzle = new int[9, 9]
        {
            { 1, 2, 0, 0, 0, 4, 0, 8, 5 },
            { 7, 0, 0, 0, 0, 0, 0, 0, 0 },
            { 0, 0, 2, 0, 0, 0, 0, 0, 0 },
            { 0, 0, 3, 0, 0, 0, 0, 0, 0 },
            { 0, 0, 0, 0, 0, 0, 0, 0, 0 },
            { 4, 0, 0, 0, 0, 0, 0, 0, 0 },
            { 0, 0, 0, 0, 0, 0, 0, 0, 0 },
            { 0, 0, 8, 0, 0, 0, 0, 0, 0 },
            { 2, 0, 0, 0, 0, 0, 0, 0, 3 }
        };


        [SetUp]
        public void SetUp()
        {
            _puzzle = new Puzzle(_testPuzzle);
            _iterator = new ColumnIterator(_puzzle, 0);
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
                 () => new ColumnIterator(_puzzle, Constants.NumberOfCellsInSegment));
        }

        [Test]
        public void Constructor_IndexTooSmall_ThrowsError()
        {

            Assert.Throws<ArgumentOutOfRangeException>(
                 () => new ColumnIterator(_puzzle, -1));
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

        [TestCase(0, new int[9] { 1, 7, 0, 0, 0, 4, 0, 0, 2 })]
        [TestCase(2, new int[9] { 0, 0, 2, 3, 0, 0, 0, 8, 0 })]
        [TestCase(8, new int[9] { 5, 0, 0, 0, 0, 0, 0, 0, 3 })]
        public void Next_IteratesThroughColumn_HasExpected(int column, int [] columnValues)
        {

            _iterator = new ColumnIterator(_puzzle, column);
            foreach (int value in columnValues)
            {
                Assert.AreEqual(value, _iterator.GetCurrent().Value);
                if (!_iterator.IsDone()) { _iterator.Next(); }
            }

        }
    }
}