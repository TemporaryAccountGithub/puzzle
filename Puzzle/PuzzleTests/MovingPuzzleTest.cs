using Puzzle;

namespace PuzzleTests
{
    [TestClass]
    public class MovingPuzzleTest
    {
        private MovingPuzzle movingPuzzle;

        [TestMethod]
        public void given_simplePuzzle_when_createPuzzle_then_initialStateCreated()
        {
            string[,] matrix = { { "1", "2" }, { "3", "X" } };
            PuzzleState initalState = new PuzzleState(matrix);
            matrix[0, 0] = "4";
            PuzzleState finalState = new PuzzleState(matrix);
            MovingPuzzle puzzle = new MovingPuzzle(initalState, finalState);

            Assert.AreEqual(initalState, puzzle.InitialState);
        }

        [TestMethod]
        public void given_simplePuzzle_when_createPuzzle_then_finalStateCreated()
        {
            string[,] matrix = { { "1", "2" }, { "3", "X" } };
            PuzzleState initalState = new PuzzleState(matrix);
            matrix[0, 0] = "4";
            PuzzleState finalState = new PuzzleState(matrix);
            MovingPuzzle puzzle = new MovingPuzzle(initalState, finalState);

            Assert.AreEqual(finalState, puzzle.FinalState);
        }
    }
}