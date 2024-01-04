using Puzzle;

namespace PuzzleTests
{
    [TestClass]
    public class PuzzleSolverTests
    {
        private MovingPuzzle movingPuzzle;
        private MazePuzzle mazePuzzle;

        [TestInitialize]
        public void Initialize()
        {
            string[,] initialMatrix = { { "3", "2" }, { "X", "1" } };
            PuzzleState initialState = new PuzzleState(initialMatrix);
            string[,] finalMatrix = { { "2", "1" }, { "X", "3" } };
            PuzzleState finalState = new PuzzleState(finalMatrix);
            movingPuzzle = new MovingPuzzle(initialState, finalState);

            string[,] initialMazeMatrix =
                {
                    { "0", "0", "0" },
                    { "X", "1", "0" },
                };
            PuzzleState initialMazeState = new PuzzleState(initialMazeMatrix);
            string[,] finalMazeMatrix =
                {
                    { "0", "0", "0" },
                    { "0", "1", "X" },
                };
            PuzzleState finalMazeState = new PuzzleState(finalMazeMatrix);
            mazePuzzle = new MazePuzzle(initialMazeState, finalMazeState);
        }

        [TestMethod]
        public void given_examplePuzzle_when_solveWithBFS_then_returnCorrectList()
        {
            PuzzleSolverContext solverContext = new PuzzleSolverContext(new SearchBFS());
            List<PuzzleState> expectedSteps = new List<PuzzleState>()
            {
                new PuzzleState(new string[,] { { "3", "2" }, { "X", "1" } }),
                new PuzzleState(new string[,] { { "X", "2" }, { "3", "1" } }),
                new PuzzleState(new string[,] { { "2", "X" }, { "3", "1" } }),
                new PuzzleState(new string[,] { { "2", "1" }, { "3", "X" } }),
                new PuzzleState(new string[,] { { "2", "1" }, { "X", "3" } }),
            };

            CollectionAssert.AreEqual(expectedSteps, solverContext.Solve(movingPuzzle));
        }

        [TestMethod]
        public void given_examplePuzzle_when_solveWithDFS_then_returnCorrectStupidLongList()
        {
            PuzzleSolverContext solverContext = new PuzzleSolverContext(new SearchDFS());
            List<PuzzleState> expectedSteps = new List<PuzzleState>()
            {
                new PuzzleState(new string[,] { { "3", "2" }, { "X", "1" } }),
                new PuzzleState(new string[,] { { "3", "2" }, { "1", "X" } }),
                new PuzzleState(new string[,] { { "3", "X" }, { "1", "2" } }),
                new PuzzleState(new string[,] { { "X", "3" }, { "1", "2" } }),
                new PuzzleState(new string[,] { { "1", "3" }, { "X", "2" } }),
                new PuzzleState(new string[,] { { "1", "3" }, { "2", "X" } }),
                new PuzzleState(new string[,] { { "1", "X" }, { "2", "3" } }),
                new PuzzleState(new string[,] { { "X", "1" }, { "2", "3" } }),
                new PuzzleState(new string[,] { { "2", "1" }, { "X", "3" } })
            };

            CollectionAssert.AreEqual(expectedSteps, solverContext.Solve(movingPuzzle));
        }

        [TestMethod]
        public void given_mazePuzzle_when_solve_then_returnCorrectList()
        {
            PuzzleSolverContext solverContext = new PuzzleSolverContext(new SearchBFS());
            List<PuzzleState> expectedSteps = new List<PuzzleState>()
            {
                new PuzzleState(new string[,] { { "0", "0", "0" }, { "X", "1", "0" } }),
                new PuzzleState(new string[,] { { "X", "0", "0" }, { "0", "1", "0" } }),
                new PuzzleState(new string[,] { { "0", "X", "0" }, { "0", "1", "0" } }),
                new PuzzleState(new string[,] { { "0", "0", "X" }, { "0", "1", "0" } }),
                new PuzzleState(new string[,] { { "0", "0", "0" }, { "0", "1", "X" } })
            };

            CollectionAssert.AreEqual(expectedSteps, solverContext.Solve(mazePuzzle));

        }
    }
}
