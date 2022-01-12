using NUnit.Framework;
using SudokuSolver.Contracts;
using SudokuSolver.Iterators;
using SudokuSolver.Other;
using SudokuSolver.SudokuPuzzle;
using System;

namespace SudokuSolver.Test.Iterators
{
    [TestFixture]
    [Category("Unit")]
    internal class SegmentIteratorTests
    {
        private Puzzle _puzzle;
        private SegmentIterator _iterator;
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
            _iterator = new SegmentIterator(_puzzle);
        }


        [Test]
        public void Constructor_WhenCalled_HasFirstIndex()
        {

            _iterator.MoveNext();
            ISegmentIterator segmentIterator = _iterator.Current;
            Assert.IsTrue(IteratorHasValues(segmentIterator, new int[] { 1, 2, 3, 0, 0, 4, 3, 4, 2 }));

        }

        [Test]
        public void Current_AfterReset_ThrowsInvalidOperationException()
        {
            _iterator.Reset();
            Assert.Throws<InvalidOperationException>(
                 () => { var result = _iterator.Current; });
        }


        [Test]
        public void MoveNext_NotLastElement_ReturnsTrue()
        {
            var success = _iterator.MoveNext();
            Assert.IsTrue(success);
        }

        [Test]
        public void MoveNext_LastElement_ReturnsFalse()
        {
            bool success = true;
            for (int i = 0; i <= Constants.NumberOfSegments; i++)
            {
                success = _iterator.MoveNext();
            }

            Assert.IsFalse(success);
        }

        [Test]
        public void MoveNext_IteratesThroughSegments_ReturnsExpectedTypes()
        {
            IteratorSegmentType<RowIterator>();
            IteratorSegmentType<ColumnIterator>();
            IteratorSegmentType<SubGridIterator>();
        }

        private void IteratorSegmentType<SegmentType>()
        {
            for (int i = 0; i < Constants.NumberOfSegmentsByType; i++)
            {
                _iterator.MoveNext();
                Assert.IsInstanceOf<SegmentType>(_iterator.Current);
            }
        }

        public bool IteratorHasValues(ISegmentIterator iterator, int[] values)
        {

            foreach (int value in values)
            {
                if (value != iterator.GetCurrent().Value)
                {
                    return false;
                }
                iterator.Next();
            }
            return true;
        }
    }
}