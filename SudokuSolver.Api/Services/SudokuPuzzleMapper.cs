
using SudokuSolver.Api.Models;
using SudokuSolver.SudokuPuzzle;

namespace SudokuSolver.Api.Services
{
    public class SudokuPuzzleMapper
    {
        public SudokuPuzzleMapper()
        {
        }

        public Puzzle ConvertApiModelToInternalModel (SudokuPuzzleModel apiModel)
        {
            int[,] puzzle = new int[9, 9];
            
            for(int i=0; i<9; i++)
            {
                for(int j=0; j<9; j++)
                {
                    puzzle[i,j] = apiModel.Puzzle[i][j].Value ?? 0;
                }
            }
            
            return new Puzzle(puzzle);
        }

        public SudokuPuzzleModel ConvertInteralModelToApiModel (Puzzle internalModel)
        {
            var puzzle = new SudokuPuzzleModel();
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    int? value = null;
                    if (internalModel.GetCell(i, j).Value != 0 )
                    {
                        value = internalModel.GetCell(i, j).Value;
                    }

                    puzzle.Puzzle[i][j] = new SudokuCellModel()
                    {
                        Value = value
                    };
                }
            }

            return puzzle;
        }

    }
}
