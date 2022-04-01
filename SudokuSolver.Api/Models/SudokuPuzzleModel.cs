
using System;
using System.Runtime.Serialization;

namespace SudokuSolver.Api.Models
{

    public class SudokuPuzzleModel
    {
        public SudokuPuzzleModel()
        {
            Puzzle = CreateEmptyPuzzle();
        }
        public SudokuCellModel[][] Puzzle { get; set; }

        private static SudokuCellModel[][] CreateEmptyPuzzle()
        {
            return new SudokuCellModel[][]
                            {
                    new SudokuCellModel[9] {
                        new SudokuCellModel { Value = null },
                        new SudokuCellModel { Value = null },
                        new SudokuCellModel { Value = null },
                        new SudokuCellModel { Value = null },
                        new SudokuCellModel { Value = null },
                        new SudokuCellModel { Value = null },
                        new SudokuCellModel { Value = null },
                        new SudokuCellModel { Value = null },
                        new SudokuCellModel { Value = null }
                    },
                    new SudokuCellModel[9] {
                        new SudokuCellModel { Value = null },
                        new SudokuCellModel { Value = null },
                        new SudokuCellModel { Value = null },
                        new SudokuCellModel { Value = null },
                        new SudokuCellModel { Value = null },
                        new SudokuCellModel { Value = null },
                        new SudokuCellModel { Value = null },
                        new SudokuCellModel { Value = null },
                        new SudokuCellModel { Value = null }
                    },
                    new SudokuCellModel[9] {
                        new SudokuCellModel { Value = null },
                        new SudokuCellModel { Value = null },
                        new SudokuCellModel { Value = null },
                        new SudokuCellModel { Value = null },
                        new SudokuCellModel { Value = null },
                        new SudokuCellModel { Value = null },
                        new SudokuCellModel { Value = null },
                        new SudokuCellModel { Value = null },
                        new SudokuCellModel { Value = null }
                    },
                    new SudokuCellModel[9] {
                        new SudokuCellModel { Value = null },
                        new SudokuCellModel { Value = null },
                        new SudokuCellModel { Value = null },
                        new SudokuCellModel { Value = null },
                        new SudokuCellModel { Value = null },
                        new SudokuCellModel { Value = null },
                        new SudokuCellModel { Value = null },
                        new SudokuCellModel { Value = null },
                        new SudokuCellModel { Value = null }
                    },
                    new SudokuCellModel[9] {
                        new SudokuCellModel { Value = null },
                        new SudokuCellModel { Value = null },
                        new SudokuCellModel { Value = null },
                        new SudokuCellModel { Value = null },
                        new SudokuCellModel { Value = null },
                        new SudokuCellModel { Value = null },
                        new SudokuCellModel { Value = null },
                        new SudokuCellModel { Value = null },
                        new SudokuCellModel { Value = null }
                    },
                    new SudokuCellModel[9] {
                        new SudokuCellModel { Value = null },
                        new SudokuCellModel { Value = null },
                        new SudokuCellModel { Value = null },
                        new SudokuCellModel { Value = null },
                        new SudokuCellModel { Value = null },
                        new SudokuCellModel { Value = null },
                        new SudokuCellModel { Value = null },
                        new SudokuCellModel { Value = null },
                        new SudokuCellModel { Value = null }
                    },
                    new SudokuCellModel[9] {
                        new SudokuCellModel { Value = null },
                        new SudokuCellModel { Value = null },
                        new SudokuCellModel { Value = null },
                        new SudokuCellModel { Value = null },
                        new SudokuCellModel { Value = null },
                        new SudokuCellModel { Value = null },
                        new SudokuCellModel { Value = null },
                        new SudokuCellModel { Value = null },
                        new SudokuCellModel { Value = null }
                    },
                    new SudokuCellModel[9] {
                        new SudokuCellModel { Value = null },
                        new SudokuCellModel { Value = null },
                        new SudokuCellModel { Value = null },
                        new SudokuCellModel { Value = null },
                        new SudokuCellModel { Value = null },
                        new SudokuCellModel { Value = null },
                        new SudokuCellModel { Value = null },
                        new SudokuCellModel { Value = null },
                        new SudokuCellModel { Value = null }
                    },
                    new SudokuCellModel[9] {
                        new SudokuCellModel { Value = null },
                        new SudokuCellModel { Value = null },
                        new SudokuCellModel { Value = null },
                        new SudokuCellModel { Value = null },
                        new SudokuCellModel { Value = null },
                        new SudokuCellModel { Value = null },
                        new SudokuCellModel { Value = null },
                        new SudokuCellModel { Value = null },
                        new SudokuCellModel { Value = null }
                    }
                            };
        }


    }
}
