using Puzzle.Generic;

namespace Puzzle
{
    public class PuzzleState
    {
        public string[,] Matrix;
        public int numberOfRows, numberOfColumns;

        public PuzzleState(string[,] matrix)
        {
            numberOfRows = matrix.GetLength(0);
            numberOfColumns = matrix.GetLength(1);
            Matrix = new string[numberOfRows, numberOfColumns];
            Array.Copy(matrix, Matrix, Matrix.Length);
        }

        public PuzzleState Copy()
        {
            string[,] newMatrix = new string[numberOfRows, numberOfColumns];
            Array.Copy(Matrix, newMatrix, newMatrix.Length);

            return new PuzzleState(newMatrix);
        }

        internal bool TrySwapCells(Cell first, Cell second)
        {
            if (!CellInMatix(first) || !CellInMatix(second))
            {
                return false;
            }

            string tmp = Matrix[first.RowIndex, first.ColumnIndex];
            Matrix[first.RowIndex, first.ColumnIndex] = Matrix[second.RowIndex, second.ColumnIndex];
            Matrix[second.RowIndex, second.ColumnIndex] = tmp;

            return true;
        }

        private bool CellInMatix(Cell cell)
        {
            return cell.RowIndex >= 0 && cell.ColumnIndex >= 0 && cell.RowIndex < numberOfRows && cell.ColumnIndex < numberOfColumns;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override bool Equals(object? obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            var otherMatrix = ((PuzzleState)obj).Matrix;

            if ((numberOfRows != otherMatrix.GetLength(0)) || (numberOfColumns != otherMatrix.GetLength(1)))
            {
                return false;
            }

            for (int i = 0; i < numberOfRows; i++)
            {
                for (int j = 0; j < numberOfColumns; j++)
                {
                    if (Matrix[i, j] != otherMatrix[i, j])
                    {
                        return false;
                    }
                }
            }

            return true;

        }

        public override string ToString()
        {
            string result = "";

            for (int i = 0; i < numberOfRows; i++)
            {
                for (int j = 0; j < numberOfColumns; j++)
                {
                    result += Matrix[i, j] + " ";
                }
                result += "\n";
            }

            return result;
        }
    }
}
