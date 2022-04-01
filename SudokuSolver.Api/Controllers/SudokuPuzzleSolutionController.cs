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
    [Route("api/solutions")]
    public class SudokuPuzzleSolutionController : ControllerBase
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

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult Post([FromBody] SudokuPuzzleModel sudokuPuzzle)
        {
            var puzzleMapper = new SudokuPuzzleMapper();
            Puzzle internalPuzzle = puzzleMapper.ConvertApiModelToInternalModel(sudokuPuzzle);
            var puzzleSolver = new PuzzleSolver(internalPuzzle);
            puzzleSolver.Solve();
            SudokuPuzzleModel responsePuzzle = puzzleMapper.ConvertInteralModelToApiModel(internalPuzzle);
            return Ok(responsePuzzle);
        }

    }
}
