namespace Puzzle
{
    public class MovingPuzzle : GenericPuzzle
    {
        private const string MovingValue = "X";

        public MovingPuzzle(PuzzleState initialState, PuzzleState finalState) : base(initialState, finalState) { }

        public override List<PuzzleState> GetNextPossibleMoves(PuzzleState state)
        {
            List<PuzzleState> nextPossibleMoves = new List<PuzzleState>();

            CellIndex movingCell = FindMovingCell(state, MovingValue);

            foreach (CellIndex possibleSwap in GetAdjacentCellIndexes(movingCell))
            {
                TryAddPossibleMove(nextPossibleMoves, movingCell, possibleSwap, state);
            }

            return nextPossibleMoves;
        }

        private void TryAddPossibleMove(List<PuzzleState> nextPossibleMoves, CellIndex movingCell, CellIndex secondCell, PuzzleState state)
        {
            if (state.CanSwapCells(movingCell, secondCell))
            {
                PuzzleState copyState = new PuzzleState(state);
                copyState.SwapCells(movingCell, secondCell);
                nextPossibleMoves.Add(copyState);
            }
        }
    }
}
