using NSubstitute;
using NUnit.Framework;
using SudokuSolver.SudokuPuzzle;
using System.Collections.Generic;

namespace SudokuSolver.Test.SudoduPuzzle
{
    [TestFixture]
    [Category("Unit")]
    class CellTests
    {
        [Test]
        public void EmptyConstructor_WhenCalled_HasValueUnknown()
        {
            var cell = new Cell();

            Assert.AreEqual(CellValue.Unknown.Value, cell.Value);
        }

        [Test]
        public void EmptyConstructor_WhenCalled_Has9Candidates()
        {
            var cell = new Cell();

            Assert.AreEqual(9, cell.Candidates.Count);
        }

        [Test]
        public void SetConstructor_WhenCalled_SetsValueToExpected()
        {
            var cell = new Cell(2);

            Assert.AreEqual(2, cell.Value);
        }

        [Test]
        public void SetConstructor_WhenCalled_HasNoCandidates()
        {
            var cell = new Cell(2);

            Assert.AreEqual(0, cell.Candidates.Count);
        }

        [Test]
        public void SetConstructor_WhenCalled_HasExpectedValue()
        {
            var cell = new Cell(new List<CellValue> { CellValue.Eight, CellValue.Five });

            Assert.AreEqual(CellValue.Unknown.Value, cell.Value);
        }

        [Test]
        public void SetConstructor_WhenCalledWith0_HasCandidates()
        {
            var cell = new Cell(0);

            Assert.AreEqual(9, cell.Candidates.Count);
        }

        [Test]
        public void CandidatesConstructor_WhenCalled_HasCandidatesList()
        {
            var cell = new Cell(new List<CellValue> { CellValue.Eight, CellValue.Five });


            Assert.AreEqual(2, cell.Candidates.Count);
        }

        [Test]
        public void Candidates_WhenCalled_ReturnsCopy()
        {
            var cell = new Cell();
            var candidates = cell.Candidates;

            cell.RemoveCandidate(7);

            Assert.AreEqual(9, candidates.Count);
        }

        [Test]
        public void CopyConstructor_WhenCalled_CreatesCopy()
        {
            var cell = new Cell(new List<CellValue> { CellValue.Eight, CellValue.Five });

            var cellCopy = new Cell(cell);

            Assert.AreEqual(cell.Candidates.Count, cellCopy.Candidates.Count);
        }

        [Test]
        public void RemoveCandidate_WhenCalledWithCandidate_ReducesCandidateCount()
        {
            var cell = new Cell();

            cell.RemoveCandidate(8);

            Assert.AreEqual(8, cell.Candidates.Count);
        }

        [Test]
        public void RemoveCandidate_WhenNotCandidate_ReturnsFalse()
        {
            var cell = new Cell(new List<CellValue> { CellValue.Eight, CellValue.Five });

            Assert.IsFalse(cell.RemoveCandidate(7));
        }

        [Test]
        public void RemoveCandidate_WhenCandidate_ReturnsTrue()
        {
            var cell = new Cell(new List<CellValue> { CellValue.Eight, CellValue.Five });

            Assert.IsTrue(cell.RemoveCandidate(8));
        }

        [Test]
        public void RemoveCandidate_ReduceToOneCandidate_SetsValue()
        {
            var cell = new Cell(new List<CellValue> { CellValue.Eight, CellValue.Five });

            cell.RemoveCandidate(8);

            Assert.AreEqual(5, cell.Value);
        }

        [Test]
        public void RemoveCandidate_ReduceToOneCandidate_RemovesLastCandidate()
        {
            var cell = new Cell(new List<CellValue> { CellValue.Eight, CellValue.Five });

            cell.RemoveCandidate(8);

            Assert.AreEqual(0, cell.Candidates.Count);
        }

    }


}
