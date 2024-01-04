using Puzzle;

namespace PuzzleTests
{
    [TestClass]
    public class MazePuzzleTests
    {
        string[,] matrix = { { "0", "0", "0" }, { "X", "1", "0" } };
        string[,] matrixWithInvalidChar = { { "2", "0", "0" }, { "X", "1", "0" }, };
        string[,] matrixWithNoMovingValue = { { "1", "0", "0" }, { "0", "1", "0" }, };
        string[,] matrixWithDoubleMovingValue = { { "1", "0", "0" }, { "X", "1", "X" }, };

        [TestMethod]
        public void given_simplePuzzle_when_createPuzzle_then_puzzleCreated()
        {
            PuzzleState state = new PuzzleState(matrix);
            MazePuzzle puzzle = new MazePuzzle(state, state);
            PuzzleState expected = new PuzzleState(matrix);

            Assert.AreEqual(expected, puzzle.InitialState);
            Assert.AreEqual(expected, puzzle.FinalState);
        }

        [TestMethod]
        public void given_invalidCharacterInMatrix_when_createPuzzle_then_throwException()
        {
            Assert.ThrowsException<ArgumentException>(() => new MazePuzzle(new PuzzleState(matrix), new PuzzleState(matrixWithInvalidChar)));
        }

        [TestMethod]
        public void given_noMovingValue_when_createPuzzle_then_throwException()
        {
            Assert.ThrowsException<ArgumentException>(() => new MazePuzzle(new PuzzleState(matrixWithNoMovingValue), new PuzzleState(matrix)));
        }

        [TestMethod]
        public void given_duplicateMovingValue_when_createPuzzle_then_throwException()
        {
            Assert.ThrowsException<ArgumentException>(() => new MazePuzzle(new PuzzleState(matrix), new PuzzleState(matrixWithDoubleMovingValue)));
        }

        [TestMethod]
        public void given_inconsistantSize_when_createPuzzle_then_throwException()
        {
            string[,] finalMatrix = { { "0", "0", "0", "0" }, { "X", "1", "0", "0" } };

            Assert.ThrowsException<ArgumentException>(() => new MazePuzzle(new PuzzleState(matrix), new PuzzleState(finalMatrix)));
        }

        [TestMethod]
        public void given_inconsistantValue_when_createPuzzle_then_throwException()
        {
            string[,] finalMatrix = { { "0", "0", "0" }, { "X", "0", "0" } };

            Assert.ThrowsException<ArgumentException>(() => new MazePuzzle(new PuzzleState(matrix), new PuzzleState(finalMatrix)));
        }
    }
}
