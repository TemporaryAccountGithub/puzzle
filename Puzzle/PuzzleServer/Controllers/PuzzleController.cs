using Microsoft.AspNetCore.Mvc;
using Puzzle;
using PuzzleServer.Models;

namespace PuzzleServer.Controllers
{
    public class PuzzleController : ControllerBase
    {
        [HttpPost("puzzleSolver/{puzzleType}")]
        public IActionResult PostPuzzle(string puzzleType, [FromQuery] string search, [FromBody] PuzzleInputModel model)
        {
            try
            {
                SearchStrategyFactory searchStrategyFactory = new SearchStrategyFactory();
                PuzzleSolverContext solver = new PuzzleSolverContext(searchStrategyFactory.CreateSearchStrategy(search));

                PuzzleState initialState = new PuzzleState(model.InitialMatrix);
                PuzzleState finalState = new PuzzleState(model.FinalMatrix);

                PuzzleFactory puzzleFactory = new PuzzleFactory();
                GenericPuzzle puzzle = puzzleFactory.CreatePuzzle(puzzleType, initialState, finalState);

                List<PuzzleState> result = solver.Solve(puzzle);

                if (result.Count == 0)
                {
                    return NotFound("No solution for the puzzle");
                }

                return Ok(result.Select(state => state.GetSerializableState()));
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
