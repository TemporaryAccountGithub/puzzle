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
                PuzzleState initialState = new PuzzleState(ParseFromArrayOfArraysToMatrix(model.InitialMatrix));
                PuzzleState finalState = new PuzzleState(ParseFromArrayOfArraysToMatrix(model.FinalMatrix));
                GenericPuzzle puzzle = ParsePuzzleType(type, initialState, finalState);
                List<PuzzleState> result = solver.Solve(puzzle);

                if (result.Count == 0)
                {
                    return Ok("No solution for the puzzle");
                }

                return Ok(result.Select(ParseFromMatrixStateToArrayOfArrays));
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        private GenericPuzzle ParsePuzzleType(string type, PuzzleState initialState, PuzzleState finalState) 
        {
            switch (type.ToLower())
            {
                case "movingpuzzle":
                    return new MovingPuzzle(initialState, finalState);

                case "mazepuzzle":
                    return new MazePuzzle(initialState, finalState);

                default:
                    throw new ArgumentException($"Puzzle type: {type} is not supported!");
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

        private string[][] ParseFromMatrixStateToArrayOfArrays(PuzzleState state)
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

        private string[,] ParseFromArrayOfArraysToMatrix(string[][] arrayOfStringArrays)
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
