﻿using NLog;

namespace Puzzle
{
    public class MazePuzzle : GenericPuzzle
    {
        private const string MovingValue = "X";
        private const string EmptyValue = "0";
        private const string WallValue = "1";

        public MazePuzzle(PuzzleState initialState, PuzzleState finalState) : base(initialState, finalState)
        {
            ValidateState(initialState);
            ValidateState(finalState);
            ValidatePuzzle();
        }

        public override List<PuzzleState> GetNextPossibleMoves(PuzzleState state)
        {
            ValidateState(state);
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
            if (state.CanSwapCells(movingCell, secondCell) && (state.Matrix[secondCell.RowIndex, secondCell.ColumnIndex] == "0"))
            {
                PuzzleState copyState = new PuzzleState(state);
                copyState.SwapCells(movingCell, secondCell);
                nextPossibleMoves.Add(copyState);
            }
        }

        private void ValidateState(PuzzleState state) 
        {
            bool haveMovingValue = false;

            for (int i = 0; i < state.numberOfRows; i++)
            {
                for (int j = 0; j < state.numberOfColumns; j++)
                {
                    string currentValue = state.Matrix[i, j];
                    if (currentValue == MovingValue)
                    {
                        if (haveMovingValue)
                        {
                            throw new ArgumentException($"There can be only one moving cell with value: {MovingValue}!");
                        }
                        haveMovingValue = true;
                    }
                    else if (currentValue != WallValue && currentValue != EmptyValue)
                    {
                        throw new ArgumentException($"Cannot contain invalid values: {currentValue}!");
                    }
                }
            }

            if (!haveMovingValue)
            {
                throw new ArgumentException($"Must contain one moving cell with value: {MovingValue}!");
            }
        }

        private void ValidatePuzzle()
        {
            if ((InitialState.numberOfRows != FinalState.numberOfRows) || (FinalState.numberOfColumns != InitialState.numberOfColumns))
            {
                throw new ArgumentException("Initial and Final puzzle states must have the same dimensions!");
            }

            for (int i = 0; i < InitialState.numberOfRows; i++)
            {
                for (int j = 0; j < InitialState.numberOfColumns; j++)
                {
                    string initialCellValue = InitialState.Matrix[i, j];
                    string finalCellValue = FinalState.Matrix[i, j];
                    if ((initialCellValue != MovingValue) && (finalCellValue != MovingValue) && (initialCellValue != finalCellValue))
                    {
                        throw new ArgumentException("Initial and final states in maze puzzle do not match!");
                    }
                }
            }
        }
    }
}