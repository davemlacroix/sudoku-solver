
using SudokuSolver.Api.Models;
using SudokuSolver.SudokuPuzzle;

namespace SudokuSolver.Api.Services
{
    public class SudokuPuzzleMapper
    {
        public SudokuPuzzleMapper ()
        {
        }

        public Puzzle ConvertApiModelToInternalModel (SudokuPuzzleModel apiModel)
        {
            return new Puzzle();
        }

        public SudokuPuzzleModel ConvertInteralModelToApiModel (Puzzle internalModel)
        {
            return new SudokuPuzzleModel();
        }

    }
}
