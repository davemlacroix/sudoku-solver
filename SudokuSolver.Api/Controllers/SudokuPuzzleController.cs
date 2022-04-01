using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Primitives;
using SudokuSolver.Api.Models;
using SudokuSolver.Api.Services;
using SudokuSolver.Other;
using SudokuSolver.SudokuPuzzle;

namespace SudokuSolver.Api.Controllers
{
    [ApiController]
    [Produces("application/json")]
    [Route("api/puzzles/{id?}")]
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
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult Get(int? id)
        {
            SudokuPuzzleModel puzzle = new SudokuPuzzleGateway().GetPuzzle(id);
            if(puzzle != null)
            {
                return Ok(puzzle);
            }
            return NotFound();
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult Post([FromBody] SudokuPuzzleModel sudokuPuzzle)
        {
            var puzzleMapper = new SudokuPuzzleMapper();
            Puzzle internalPuzzle = puzzleMapper.ConvertApiModelToInternalModel(sudokuPuzzle);
            var puzzleSolver = new PuzzleSolver(internalPuzzle);

            var response = new ValidatedPuzzleResponse()
            { 
                Valid = puzzleSolver.PuzzleIsValid()
            };
            return Ok(response);
        }

    }
}
