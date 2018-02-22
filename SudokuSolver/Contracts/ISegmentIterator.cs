using SudokuSolver.SudokuPuzzle;

namespace SudokuSolver.Contracts
{
    public interface ISegmentIterator
    {
        void First();
        void Next();
        bool HasNext();
        Cell GetCurrent();
        void SetCurrent(Cell cell);
    }
}