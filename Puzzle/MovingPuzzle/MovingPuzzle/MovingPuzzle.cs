namespace Puzzle
{
    internal class MovingPuzzle : GenericPuzzle
    {
        public MovingPuzzle(PuzzleState initialState, PuzzleState finalState) : base(initialState, finalState) { }

        public override List<PuzzleState> GetNextPossibleMoves(PuzzleState state)
        {
            return new List<PuzzleState>();
        }
    }
}
