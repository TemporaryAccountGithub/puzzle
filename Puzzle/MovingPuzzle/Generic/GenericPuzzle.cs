namespace Puzzle
{
    internal abstract class GenericPuzzle
    {
        public PuzzleState InitialState { get; }
        public PuzzleState FinalState { get; }

        public GenericPuzzle(PuzzleState initialState, PuzzleState finalState)
        {
            InitialState = initialState;
            FinalState = finalState;
        }

        public abstract List<PuzzleState> GetNextPossibleMoves(PuzzleState state);
    }
}
