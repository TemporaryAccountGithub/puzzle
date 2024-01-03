using Puzzle;

namespace PuzzleTests
{
    [TestClass]
    public class MovingPuzzleTest
    {
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

        [TestMethod]
        public void given_smallestPuzzle_when_getNextMoves_then_returnEmptyList()
        {
            string[,] matrix = { { "X" } };
            PuzzleState state = new PuzzleState(matrix);
            MovingPuzzle puzzle = new MovingPuzzle(null, null);

            var result = puzzle.GetNextPossibleMoves(state);

            Assert.AreEqual(0, result.Count);
        }

        [TestMethod]
        public void given_puzzle_when_getNextMoves_then_returnListWithMoves()
        {
            string[,] matrix = { { "1", "X" } };
            PuzzleState state = new PuzzleState(matrix);
            MovingPuzzle puzzle = new MovingPuzzle(null, null);
            string[,] expectedMatrix = { { "X", "1" } };
            PuzzleState expectedState = new PuzzleState(expectedMatrix);

            var result = puzzle.GetNextPossibleMoves(state);

            Assert.AreEqual(1, result.Count);
            Assert.AreEqual(expectedState, result.First());
        }
    }
}