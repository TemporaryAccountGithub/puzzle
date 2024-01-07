using Microsoft.AspNetCore.Mvc;
using Puzzle;
using PuzzleServer.Models;

namespace PuzzleServer.Controllers
{
    public class PuzzleController : ControllerBase
    {
        [HttpPost("puzzleSolver/{type}")]
        public IActionResult PostPuzzle(string type, [FromQuery] string search, [FromBody] PuzzleInputModel model)
        {
            try
            {
                PuzzleSolverContext solver = ParseSearchParam(search);
                PuzzleState initialState = new PuzzleState(ParseToMatrix(model.InitialMatrix));
                PuzzleState finalState = new PuzzleState(ParseToMatrix(model.FinalMatrix));
                GenericPuzzle puzzle;

                switch (type.ToLower())
                {
                    case "movingpuzzle":
                        puzzle = new MovingPuzzle(initialState, finalState);
                        break;

                    case "mazepuzzle":
                        puzzle = new MazePuzzle(initialState, finalState);
                        break;

                    default:
                        return BadRequest($"Puzzle type: {type} is not supported!");
                }

                List<PuzzleState> result = solver.Solve(puzzle);
                if (result.Count == 0)
                {
                    return Ok("No solution for the puzzle");
                }

                return Ok(result.Select(ParseFromMatrixState));
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        private PuzzleSolverContext ParseSearchParam(string searchParam)
        {
            switch (searchParam.ToLower())
            {
                case "bfs":
                    return new PuzzleSolverContext(new SearchBFS());

                case "dfs":
                    return new PuzzleSolverContext(new SearchDFS());

                default:
                    return new PuzzleSolverContext(new SearchBFS());
            }
        }

        private string[][] ParseFromMatrixState(PuzzleState state)
        {
            string[][] result = new string[state.numberOfRows][];

            for (int i = 0; i < state.numberOfRows; i++)
            {
                result[i] = new string[state.numberOfRows];
                for (int j = 0; j < state.numberOfColumns; j++)
                {
                    result[i][j] = state.Matrix[i, j];
                }
            }

            return result;
        }

        private string[,] ParseToMatrix(string[][] arrayOfStringArrays)
        {
            int numberOfRows = arrayOfStringArrays.Length;
            int numberOfColumns = arrayOfStringArrays[0].Length;
            string[,] matrix = new string[numberOfRows, numberOfColumns];

            for (int i = 0; i < numberOfRows; i++)
            {
                string[] stringArray = arrayOfStringArrays[i];
                if (stringArray.Length != numberOfColumns)
                {
                    throw new ArgumentException("Array of string arrays must be a matrix!");
                }

                for (int j = 0; j < numberOfColumns; j++)
                {
                    matrix[i, j] = arrayOfStringArrays[i][j];
                }
            }

            return matrix;
        }
    }
}
