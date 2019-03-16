using NUnit.Framework;
using SudokuSolver.SudokuPuzzle;
using System;

namespace SudokuSolverTest.SudoduPuzzle
{
    [TestFixture]
    [Category("Unit")]
    class CellValueTests
    {
        [Test]
        public void CellValue_Unknown_HasValue0()
        {
            Assert.AreEqual(0, CellValue.Unknown.Value);
        }

        [Test]
        public void CellValue_One_HasValue1()
        {
            Assert.AreEqual(1, CellValue.One.Value);
        }

        [Test]
        public void CellValue_Two_HasValue2()
        {
            Assert.AreEqual(2, CellValue.Two.Value);
        }

        [Test]
        public void CellValue_Three_HasValue3()
        {
            Assert.AreEqual(3, CellValue.Three.Value);
        }

        [Test]
        public void CellValue_Four_HasValue4()
        {
            Assert.AreEqual(4, CellValue.Four.Value);
        }

        [Test]
        public void CellValue_Five_HasValue5()
        {
            Assert.AreEqual(5, CellValue.Five.Value);
        }

        [Test]
        public void CellValue_Six_HasValue6()
        {
            Assert.AreEqual(6, CellValue.Six.Value);
        }

        [Test]
        public void CellValue_Seven_HasValue7()
        {
            Assert.AreEqual(7, CellValue.Seven.Value);
        }

        [Test]
        public void CellValue_Eight_HasValue8()
        {
            Assert.AreEqual(8, CellValue.Eight.Value);
        }

        [Test]
        public void CellValue_Nine_HasValue9()
        {
            Assert.AreEqual(9, CellValue.Nine.Value);
        }

        [Test]
        public void Constructor_WhenCalled_SetsToUnknown()
        {
            var value = new CellValue();

            Assert.AreEqual(CellValue.Unknown.Value, value.Value);
        }

        [Test]
        public void Constructor_WhenCalled_SetsToExpected()
        {
            var value = new CellValue(2);

            Assert.AreEqual(2, value.Value);
        }

        [Test]
        public void Value_UseValidValue_SetsToExpected()
        {
            var value = new CellValue();

            value.Value = 3;
            Assert.AreEqual(3, value.Value);
        }

        [Test]
        public void Value_LessThan0_ThrowsError()
        {
            var value = new CellValue();

            Assert.Throws<ArgumentOutOfRangeException>(
                 () => value.Value = -1 );
        }

        [Test]
        public void Value_GreaterThan9_ThrowsError()
        {
            var value = new CellValue();

            Assert.Throws<ArgumentOutOfRangeException>(
                 () => value.Value = 10);
        }

    }
}
