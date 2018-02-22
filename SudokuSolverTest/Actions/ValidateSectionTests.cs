using NUnit.Framework;
using SudokuSolver.Actions;
using SudokuSolver.Iterators;
using SudokuSolver.SudokuPuzzle;

namespace SudokuSolverTest.Actions
{
    [TestFixture]
    class ValidateSectionTests
    {
        [Test]
        public void Validate_ValidRow_ReturnsTrue()
        {
            var puzzle = new Puzzle(new int[9, 9]
                {
                    { 1, 2, 0, 0, 0, 4, 0, 8, 0 },
                    { 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                    { 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                    { 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                    { 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                    { 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                    { 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                    { 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                    { 0, 0, 0, 0, 0, 0, 0, 0, 0 }
                });

            var iterator = new RowIterator(puzzle, 0);
            var validator = new ValidateSection();
            Assert.IsTrue(validator.Execute(iterator));
        }

        [Test]
        public void Validate_RowWithDuplicateValue_ReturnsFalse()
        {
            var puzzle = new Puzzle(new int[9, 9]
                {
                    { 1, 2, 0, 0, 0, 4, 0, 8, 2 },
                    { 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                    { 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                    { 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                    { 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                    { 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                    { 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                    { 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                    { 0, 0, 0, 0, 0, 0, 0, 0, 0 }
                });

            var iterator = new RowIterator(puzzle, 0);
            var validator = new ValidateSection();
            Assert.IsFalse(validator.Execute(iterator));
        }

        [Test]
        public void GetValues_Validated_ReturnsList()
        {
            var puzzle = new Puzzle(new int[9, 9]
                {
                    { 1, 2, 0, 0, 0, 4, 0, 8, 0 },
                    { 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                    { 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                    { 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                    { 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                    { 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                    { 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                    { 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                    { 0, 0, 0, 0, 0, 0, 0, 0, 0 }
                });

            var iterator = new RowIterator(puzzle, 0);
            var validator = new ValidateSection();
            validator.Execute(iterator);
            Assert.AreEqual(4, validator.GetValues().Count);
        }

        [Test]
        public void GetValues_Invalid_ReturnsEmptyList()
        {
            var puzzle = new Puzzle(new int[9, 9]
                {
                    { 1, 2, 0, 0, 0, 4, 0, 8, 2 },
                    { 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                    { 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                    { 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                    { 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                    { 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                    { 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                    { 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                    { 0, 0, 0, 0, 0, 0, 0, 0, 0 }
                });

            var iterator = new RowIterator(puzzle, 0);
            var validator = new ValidateSection();
            validator.Execute(iterator);
            Assert.AreEqual(0, validator.GetValues().Count);
        }
    }
}
