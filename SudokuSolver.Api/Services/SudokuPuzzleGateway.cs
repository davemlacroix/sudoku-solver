using SudokuSolver.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SudokuSolver.Api.Services
{
    public class SudokuPuzzleGateway
    {
        public SudokuPuzzleModel GetPuzzle(int? id)
        {
            switch (id)
            {
                case null:
                case 0:
                    return GetSudokuPuzzle0();
                case 1:
                    return GetSudokuPuzzle1();
                case 2:
                    return GetSudokuPuzzle2();
                default:
                    return null;
            }
        }


        private SudokuPuzzleModel GetSudokuPuzzle0()
        {
            return new SudokuPuzzleModel
            {
                Puzzle = new SudokuCellModel[][]
                {
                    new SudokuCellModel[9] {
                        new SudokuCellModel { Value = null },
                        new SudokuCellModel { Value = null },
                        new SudokuCellModel { Value = 3 },
                        new SudokuCellModel { Value = null },
                        new SudokuCellModel { Value = 2 },
                        new SudokuCellModel { Value = null },
                        new SudokuCellModel { Value = 6 },
                        new SudokuCellModel { Value = null },
                        new SudokuCellModel { Value = null }
                    },
                    new SudokuCellModel[9] {
                        new SudokuCellModel { Value = 9 },
                        new SudokuCellModel { Value = null },
                        new SudokuCellModel { Value = null },
                        new SudokuCellModel { Value = 3 },
                        new SudokuCellModel { Value = null },
                        new SudokuCellModel { Value = 5 },
                        new SudokuCellModel { Value = null },
                        new SudokuCellModel { Value = null },
                        new SudokuCellModel { Value = 1 }
                    },
                    new SudokuCellModel[9] {
                        new SudokuCellModel { Value = null },
                        new SudokuCellModel { Value = null },
                        new SudokuCellModel { Value = 1 },
                        new SudokuCellModel { Value = 8 },
                        new SudokuCellModel { Value = null },
                        new SudokuCellModel { Value = 6 },
                        new SudokuCellModel { Value = 4 },
                        new SudokuCellModel { Value = null },
                        new SudokuCellModel { Value = null }
                    },
                    new SudokuCellModel[9] {
                        new SudokuCellModel { Value = null },
                        new SudokuCellModel { Value = null },
                        new SudokuCellModel { Value = 8 },
                        new SudokuCellModel { Value = 1 },
                        new SudokuCellModel { Value = null },
                        new SudokuCellModel { Value = 2 },
                        new SudokuCellModel { Value = 9 },
                        new SudokuCellModel { Value = null },
                        new SudokuCellModel { Value = null }
                    },
                    new SudokuCellModel[9] {
                        new SudokuCellModel { Value = 7 },
                        new SudokuCellModel { Value = null },
                        new SudokuCellModel { Value = null },
                        new SudokuCellModel { Value = null },
                        new SudokuCellModel { Value = null },
                        new SudokuCellModel { Value = null },
                        new SudokuCellModel { Value = null },
                        new SudokuCellModel { Value = null },
                        new SudokuCellModel { Value = 8 }
                    },
                    new SudokuCellModel[9] {
                        new SudokuCellModel { Value = null },
                        new SudokuCellModel { Value = null },
                        new SudokuCellModel { Value = 6 },
                        new SudokuCellModel { Value = 7 },
                        new SudokuCellModel { Value = null },
                        new SudokuCellModel { Value = 8 },
                        new SudokuCellModel { Value = 2 },
                        new SudokuCellModel { Value = null },
                        new SudokuCellModel { Value = null }
                    },
                    new SudokuCellModel[9] {
                        new SudokuCellModel { Value = null },
                        new SudokuCellModel { Value = null },
                        new SudokuCellModel { Value = 2 },
                        new SudokuCellModel { Value = 6 },
                        new SudokuCellModel { Value = null },
                        new SudokuCellModel { Value = 9 },
                        new SudokuCellModel { Value = 5 },
                        new SudokuCellModel { Value = null },
                        new SudokuCellModel { Value = null }
                    },
                    new SudokuCellModel[9] {
                        new SudokuCellModel { Value = 8 },
                        new SudokuCellModel { Value = null },
                        new SudokuCellModel { Value = null },
                        new SudokuCellModel { Value = 2 },
                        new SudokuCellModel { Value = null },
                        new SudokuCellModel { Value = 3 },
                        new SudokuCellModel { Value = null },
                        new SudokuCellModel { Value = null },
                        new SudokuCellModel { Value = 9 }
                    },
                    new SudokuCellModel[9] {
                        new SudokuCellModel { Value = null },
                        new SudokuCellModel { Value = null },
                        new SudokuCellModel { Value = 5 },
                        new SudokuCellModel { Value = null },
                        new SudokuCellModel { Value = 1 },
                        new SudokuCellModel { Value = null },
                        new SudokuCellModel { Value = 3 },
                        new SudokuCellModel { Value = null },
                        new SudokuCellModel { Value = null }
                    }
                }
            };
        }
        private SudokuPuzzleModel GetSudokuPuzzle1()
        {
            return new SudokuPuzzleModel
            {
                Puzzle = new SudokuCellModel[][]
                {
                        new SudokuCellModel[9] {
                            new SudokuCellModel { Value = null },
                            new SudokuCellModel { Value = 7 },
                            new SudokuCellModel { Value = 1 },
                            new SudokuCellModel { Value = null },
                            new SudokuCellModel { Value = 9 },
                            new SudokuCellModel { Value = null },
                            new SudokuCellModel { Value = 8 },
                            new SudokuCellModel { Value = null },
                            new SudokuCellModel { Value = null }
                        },
                        new SudokuCellModel[9] {
                            new SudokuCellModel { Value = null },
                            new SudokuCellModel { Value = null },
                            new SudokuCellModel { Value = null },
                            new SudokuCellModel { Value = 3 },
                            new SudokuCellModel { Value = null },
                            new SudokuCellModel { Value = 6 },
                            new SudokuCellModel { Value = null },
                            new SudokuCellModel { Value = null },
                            new SudokuCellModel { Value = null }
                        },
                        new SudokuCellModel[9] {
                            new SudokuCellModel { Value = 4 },
                            new SudokuCellModel { Value = 9 },
                            new SudokuCellModel { Value = null },
                            new SudokuCellModel { Value = null },
                            new SudokuCellModel { Value = null },
                            new SudokuCellModel { Value = null },
                            new SudokuCellModel { Value = 7 },
                            new SudokuCellModel { Value = null },
                            new SudokuCellModel { Value = 5 }
                        },
                        new SudokuCellModel[9] {
                            new SudokuCellModel { Value = null },
                            new SudokuCellModel { Value = 1 },
                            new SudokuCellModel { Value = null },
                            new SudokuCellModel { Value = 9 },
                            new SudokuCellModel { Value = null },
                            new SudokuCellModel { Value = null },
                            new SudokuCellModel { Value = null },
                            new SudokuCellModel { Value = null },
                            new SudokuCellModel { Value = null }
                        },
                        new SudokuCellModel[9] {
                            new SudokuCellModel { Value = 9 },
                            new SudokuCellModel { Value = null },
                            new SudokuCellModel { Value = 2 },
                            new SudokuCellModel { Value = null },
                            new SudokuCellModel { Value = null },
                            new SudokuCellModel { Value = null },
                            new SudokuCellModel { Value = 6 },
                            new SudokuCellModel { Value = null },
                            new SudokuCellModel { Value = 3 }
                        },
                        new SudokuCellModel[9] {
                            new SudokuCellModel { Value = null },
                            new SudokuCellModel { Value = null },
                            new SudokuCellModel { Value = null },
                            new SudokuCellModel { Value = null },
                            new SudokuCellModel { Value = null },
                            new SudokuCellModel { Value = 8 },
                            new SudokuCellModel { Value = null },
                            new SudokuCellModel { Value = 2 },
                            new SudokuCellModel { Value = null }
                        },
                        new SudokuCellModel[9] {
                            new SudokuCellModel { Value = 8 },
                            new SudokuCellModel { Value = null },
                            new SudokuCellModel { Value = 5 },
                            new SudokuCellModel { Value = null },
                            new SudokuCellModel { Value = null },
                            new SudokuCellModel { Value = null },
                            new SudokuCellModel { Value = null },
                            new SudokuCellModel { Value = 7 },
                            new SudokuCellModel { Value = 6 }
                        },
                        new SudokuCellModel[9] {
                            new SudokuCellModel { Value = null },
                            new SudokuCellModel { Value = null },
                            new SudokuCellModel { Value = null },
                            new SudokuCellModel { Value = 6 },
                            new SudokuCellModel { Value = null },
                            new SudokuCellModel { Value = 7 },
                            new SudokuCellModel { Value = null },
                            new SudokuCellModel { Value = null },
                            new SudokuCellModel { Value = null }
                        },
                        new SudokuCellModel[9] {
                            new SudokuCellModel { Value = null },
                            new SudokuCellModel { Value = null },
                            new SudokuCellModel { Value = 7 },
                            new SudokuCellModel { Value = null },
                            new SudokuCellModel { Value = 4 },
                            new SudokuCellModel { Value = null },
                            new SudokuCellModel { Value = 3 },
                            new SudokuCellModel { Value = 5 },
                            new SudokuCellModel { Value = null }
                        }
                }
            };
        }
        private SudokuPuzzleModel GetSudokuPuzzle2()
        {
            return new SudokuPuzzleModel
            {
                Puzzle = new SudokuCellModel[][]
                {
                        new SudokuCellModel[9] {
                            new SudokuCellModel { Value = 7 },
                            new SudokuCellModel { Value = 1 },
                            new SudokuCellModel { Value = null },
                            new SudokuCellModel { Value = null },
                            new SudokuCellModel { Value = null },
                            new SudokuCellModel { Value = null },
                            new SudokuCellModel { Value = null },
                            new SudokuCellModel { Value = 9 },
                            new SudokuCellModel { Value = null }
                        },
                        new SudokuCellModel[9] {
                            new SudokuCellModel { Value = null },
                            new SudokuCellModel { Value = 4 },
                            new SudokuCellModel { Value = null },
                            new SudokuCellModel { Value = null },
                            new SudokuCellModel { Value = 1 },
                            new SudokuCellModel { Value = null },
                            new SudokuCellModel { Value = null },
                            new SudokuCellModel { Value = 3 },
                            new SudokuCellModel { Value = null }
                        },
                        new SudokuCellModel[9] {
                            new SudokuCellModel { Value = null },
                            new SudokuCellModel { Value = null },
                            new SudokuCellModel { Value = null },
                            new SudokuCellModel { Value = null },
                            new SudokuCellModel { Value = 7 },
                            new SudokuCellModel { Value = 2 },
                            new SudokuCellModel { Value = null },
                            new SudokuCellModel { Value = 6 },
                            new SudokuCellModel { Value = null }
                        },
                        new SudokuCellModel[9] {
                            new SudokuCellModel { Value = 9 },
                            new SudokuCellModel { Value = null },
                            new SudokuCellModel { Value = null },
                            new SudokuCellModel { Value = null },
                            new SudokuCellModel { Value = null },
                            new SudokuCellModel { Value = 4 },
                            new SudokuCellModel { Value = null },
                            new SudokuCellModel { Value = null },
                            new SudokuCellModel { Value = 5 }
                        },
                        new SudokuCellModel[9] {
                            new SudokuCellModel { Value = null },
                            new SudokuCellModel { Value = 3 },
                            new SudokuCellModel { Value = 5 },
                            new SudokuCellModel { Value = 1 },
                            new SudokuCellModel { Value = null },
                            new SudokuCellModel { Value = null },
                            new SudokuCellModel { Value = 9 },
                            new SudokuCellModel { Value = null },
                            new SudokuCellModel { Value = null }
                        },
                        new SudokuCellModel[9] {
                            new SudokuCellModel { Value = null },
                            new SudokuCellModel { Value = null },
                            new SudokuCellModel { Value = null },
                            new SudokuCellModel { Value = 5 },
                            new SudokuCellModel { Value = null },
                            new SudokuCellModel { Value = null },
                            new SudokuCellModel { Value = 6 },
                            new SudokuCellModel { Value = null },
                            new SudokuCellModel { Value = 8 }
                        },
                        new SudokuCellModel[9] {
                            new SudokuCellModel { Value = 1 },
                            new SudokuCellModel { Value = null },
                            new SudokuCellModel { Value = null },
                            new SudokuCellModel { Value = 2 },
                            new SudokuCellModel { Value = null },
                            new SudokuCellModel { Value = 9 },
                            new SudokuCellModel { Value = 7 },
                            new SudokuCellModel { Value = null },
                            new SudokuCellModel { Value = null }
                        },
                        new SudokuCellModel[9] {
                            new SudokuCellModel { Value = 6 },
                            new SudokuCellModel { Value = null },
                            new SudokuCellModel { Value = 9 },
                            new SudokuCellModel { Value = null },
                            new SudokuCellModel { Value = null },
                            new SudokuCellModel { Value = null },
                            new SudokuCellModel { Value = null },
                            new SudokuCellModel { Value = 8 },
                            new SudokuCellModel { Value = null }
                        },
                        new SudokuCellModel[9] {
                            new SudokuCellModel { Value = null },
                            new SudokuCellModel { Value = null },
                            new SudokuCellModel { Value = 7 },
                            new SudokuCellModel { Value = 6 },
                            new SudokuCellModel { Value = 4 },
                            new SudokuCellModel { Value = null },
                            new SudokuCellModel { Value = null },
                            new SudokuCellModel { Value = null },
                            new SudokuCellModel { Value = 9 }
                        }
                }
            };
        }
    }
}
