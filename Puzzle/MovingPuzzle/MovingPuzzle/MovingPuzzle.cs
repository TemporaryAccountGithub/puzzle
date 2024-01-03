using Puzzle.Generic;
using System.Collections.Generic;

namespace Puzzle
{
    public class MovingPuzzle : GenericPuzzle
    {
        private const string MovingValue = "X";

        public MovingPuzzle(PuzzleState initialState, PuzzleState finalState) : base(initialState, finalState) { }

        public override List<PuzzleState> GetNextPossibleMoves(PuzzleState state)
        {
            List<PuzzleState> nextPossibleMoves = new List<PuzzleState>();

            CellIndex movingCell = FindMovingCell(state);
            CellIndex[] possibleSwaps =
            [
                new CellIndex(movingCell.RowIndex + 1, movingCell.ColumnIndex),
                new CellIndex(movingCell.RowIndex - 1, movingCell.ColumnIndex),
                new CellIndex(movingCell.RowIndex, movingCell.ColumnIndex + 1),
                new CellIndex(movingCell.RowIndex, movingCell.ColumnIndex - 1)
            ];

            foreach (CellIndex possibleSwap in possibleSwaps)
            {
                TryAddPossibleMove(nextPossibleMoves, movingCell, possibleSwap, state);
            }

            return nextPossibleMoves;
        }

        private CellIndex FindMovingCell(PuzzleState state)
        {
            for (int i = 0; i < state.numberOfRows; i++)
            {
                for (int j = 0; j < state.numberOfColumns; j++)
                {
                    if (state.Matrix[i, j] == MovingValue)
                    {
                        return new CellIndex(i, j);
                    }
                }
            }

            throw new ArgumentException($"Table must contain moving cell with value: {MovingValue}");
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
