using Puzzle;

namespace PuzzleTests
{
    [TestClass]
    public class PuzzleSolverTests
    {
        [TestMethod]
        public void given_examplePuzzle_when_solve_then_returnCorrectList()
        {
            PuzzleSolverContext solverContext = new PuzzleSolverContext(new SearchBFS());
            string[,] initialMatrix = { { "3", "2" }, { "X", "1" } };
            PuzzleState initialState = new PuzzleState(initialMatrix);
            string[,] finalMatrix = { { "2", "1" }, { "X", "3" } };
            PuzzleState finalState = new PuzzleState(finalMatrix);
            MovingPuzzle puzzle = new MovingPuzzle(initialState, finalState);
            List<PuzzleState> expectedSteps = new List<PuzzleState>()
            {
                initialState,
                new PuzzleState(new string[,] { { "X", "2" }, { "3", "1" } }),
                new PuzzleState(new string[,] { { "2", "X" }, { "3", "1" } }),
                new PuzzleState(new string[,] { { "2", "1" }, { "3", "X" } }),
                finalState
            };

            CollectionAssert.AreEqual(expectedSteps, solverContext.Solve(puzzle));
        }
    }
}
