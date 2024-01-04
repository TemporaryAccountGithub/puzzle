namespace Puzzle
{
    public class CellIndex
    {
        public int RowIndex { get; set; }
        public int ColumnIndex { get; set; }

        public CellIndex(int rowIndex, int columnIndex)
        {
            RowIndex = rowIndex;
            ColumnIndex = columnIndex;
        }
    }
}
