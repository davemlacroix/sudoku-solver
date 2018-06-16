using SudokuSolver.SudokuPuzzle;

namespace SudokuSolver.Contracts
{
    public interface ISegmentIterator : IIterator
    {
        Cell GetCurrent();
        void SetCurrent(Cell cell);
    }
}