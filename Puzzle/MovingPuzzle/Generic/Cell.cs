using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Puzzle.Generic
{
    internal class Cell
    {
        public int RowIndex { get; set; }
        public int ColumnIndex { get; set; }

        public Cell(int rowIndex, int columnIndex)
        {
            RowIndex = rowIndex;
            ColumnIndex = columnIndex;
        }
    }
}
