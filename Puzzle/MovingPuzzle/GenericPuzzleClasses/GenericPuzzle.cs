namespace Puzzle
{
    public abstract class GenericPuzzle
    {
        public PuzzleState InitialState { get; }
        public PuzzleState FinalState { get; }

        public GenericPuzzle(PuzzleState initialState, PuzzleState finalState)
        {
            InitialState = initialState;
            FinalState = finalState;
        }

        public abstract List<PuzzleState> GetNextPossibleMoves(PuzzleState state);

        protected CellIndex FindMovingCell(PuzzleState state, string movingValue)
        {
            for (int i = 0; i < state.numberOfRows; i++)
            {
                for (int j = 0; j < state.numberOfColumns; j++)
                {
                    if (state.Matrix[i, j] == movingValue)
                    {
                        return new CellIndex(i, j);
                    }
                }
            }

            throw new ArgumentException($"Table must contain moving cell with value: {movingValue}");
        }

        protected CellIndex[] GetAdjacentCellIndexes(CellIndex cellIndex)
        {
            return
            [
                new CellIndex(cellIndex.RowIndex + 1, cellIndex.ColumnIndex),
                new CellIndex(cellIndex.RowIndex - 1, cellIndex.ColumnIndex),
                new CellIndex(cellIndex.RowIndex, cellIndex.ColumnIndex + 1),
                new CellIndex(cellIndex.RowIndex, cellIndex.ColumnIndex - 1)
            ];
        }
    }
}
