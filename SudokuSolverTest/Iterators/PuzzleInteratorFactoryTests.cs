using NUnit.Framework;
using NSubstitute;
using SudokuSolver.SudokuPuzzle;
using SudokuSolver.Iterators;
using SudokuSolver.Contracts;

namespace SudokuSolverTest.Iterators
{
    [TestFixture]
    class PuzzleIteratorFactoryTests
    {
        [Test]
        public void GetIterator_RequestRow_ReturnsRow()
        {
            var puzzle = Substitute.For<Puzzle>();
 
            var iterator = new SegmentIteratorFactory().GetIterator(IteratorType.Row, puzzle, 1);

            Assert.IsInstanceOf<RowIterator>(iterator);
        }

        [Test]
        public void GetIterator_RequestColumn_ReturnsColumn()
        {
            var puzzle = Substitute.For<Puzzle>();

            var iterator = new SegmentIteratorFactory().GetIterator(IteratorType.Column, puzzle, 1);

            Assert.IsInstanceOf<ColumnIterator>(iterator);
        }

        [Test]
        public void GetIterator_RequestSubGrid_ReturnsSubGrid()
        {
            var puzzle = Substitute.For<Puzzle>();

            var iterator = new SegmentIteratorFactory().GetIterator(IteratorType.SubGrid, puzzle, 1);

            Assert.IsInstanceOf<SubGridIterator>(iterator);
        }
    }
}
