namespace Puzzle
{
    public class PuzzleFactory
    {
        public GenericPuzzle CreatePuzzle(string puzzleType, PuzzleState initialState, PuzzleState finalState)
        {
            switch (puzzleType.ToLower())
            {
                case "movingpuzzle":
                    return new MovingPuzzle(initialState, finalState);

                case "mazepuzzle":
                    return new MazePuzzle(initialState, finalState);

                default:
                    throw new ArgumentException($"Puzzle type: {puzzleType} is not supported!");
            }
        }
    }
}
