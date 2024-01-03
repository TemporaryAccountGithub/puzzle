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

            Cell movingCell = FindMovingCell(state);
            Cell[] possibleSwaps = new Cell[4] 
            {
                new Cell(movingCell.RowIndex + 1, movingCell.ColumnIndex),
                new Cell(movingCell.RowIndex - 1, movingCell.ColumnIndex),
                new Cell(movingCell.RowIndex, movingCell.ColumnIndex + 1),
                new Cell(movingCell.RowIndex, movingCell.ColumnIndex - 1)
            }; 

            foreach (Cell possibleSwap in possibleSwaps) 
            {
                TryAddState(nextPossibleMoves, movingCell, possibleSwap, state);
            }

            return nextPossibleMoves;
        }

        private Cell FindMovingCell(PuzzleState state) 
        {
            for (int i = 0; i < state.Matrix.GetLength(0); i++)
            {
                for (int j = 0; j < state.Matrix.GetLength(1); j++)
                {
                    if (state.Matrix[i, j] == MovingValue)
                    {
                        return new Cell(i, j);
                    }
                }
            }

            return new Cell(-1, -1);
        }

        private void TryAddState(List<PuzzleState> nextPossibleMoves, Cell MovingCell, Cell secondCell, PuzzleState state)
        {
            PuzzleState copyState = state.Copy();
            if (copyState.TrySwapCells(MovingCell, secondCell))
            {
                nextPossibleMoves.Add(copyState);
            }
        }
    }
}
