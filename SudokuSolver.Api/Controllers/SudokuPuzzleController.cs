using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Primitives;
using SudokuSolver.Api.Models;
using SudokuSolver.Api.Services;

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
            SudokuPuzzleModel puzzle = new SudokuPuzzleGateway().GetPuzzle(0);
            return Ok(puzzle);
        }

    }
}
