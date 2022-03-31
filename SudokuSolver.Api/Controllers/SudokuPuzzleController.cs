using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Primitives;
using SudokuSolver.Api.Models;

namespace SudokuSolver.Api.Controllers
{
    [ApiController]
    [Produces("application/json")]
    [Route("api/puzzles")]
    public class SudokuPuzzleController : ControllerBase
    {

        
        [HttpHead]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult Head()
        {
            return Ok();
        }

        [HttpOptions]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult Options()
        {
            Response.Headers.Add("Allow", new StringValues(new[] { "HEAD", "GET", "OPTIONS" }));
            return Ok();
        }


        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult Get()
        {
            SudokuPuzzleModel puzzle = GetSudokuPuzzle();
            return Ok(puzzle);
        }

        private SudokuPuzzleModel GetSudokuPuzzle()
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
    }
}
