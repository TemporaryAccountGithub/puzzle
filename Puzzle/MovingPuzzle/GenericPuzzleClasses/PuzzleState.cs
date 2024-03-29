﻿namespace Puzzle
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

        public PuzzleState(string[][] arrayOfStringArrays)
        {
            numberOfRows = arrayOfStringArrays.Length;
            numberOfColumns = arrayOfStringArrays[0].Length;
            Matrix = new string[numberOfRows, numberOfColumns];

            for (int i = 0; i < numberOfRows; i++)
            {
                string[] stringArray = arrayOfStringArrays[i];
                if (stringArray.Length != numberOfColumns)
                {
                    throw new ArgumentException("Array of string arrays must be a matrix!");
                }

                for (int j = 0; j < numberOfColumns; j++)
                {
                    Matrix[i, j] = arrayOfStringArrays[i][j];
                }
            }
        }

        public PuzzleState(PuzzleState otherState) : this(otherState.Matrix) { }

        public string[][] GetSerializableState()
        {
            string[][] result = new string[numberOfRows][];

            for (int i = 0; i < numberOfRows; i++)
            {
                result[i] = new string[numberOfRows];
                for (int j = 0; j < numberOfColumns; j++)
                {
                    result[i][j] = Matrix[i, j];
                }
            }

            return result;
        }

        internal void SwapCells(CellIndex first, CellIndex second)
        {
            string tmp = Matrix[first.RowIndex, first.ColumnIndex];
            Matrix[first.RowIndex, first.ColumnIndex] = Matrix[second.RowIndex, second.ColumnIndex];
            Matrix[second.RowIndex, second.ColumnIndex] = tmp;
        }

        private bool CellInMatix(CellIndex cell)
        {
            return cell.RowIndex >= 0 && cell.ColumnIndex >= 0 && cell.RowIndex < numberOfRows && cell.ColumnIndex < numberOfColumns;
        }
        internal bool CanSwapCells(CellIndex first, CellIndex second)
        {
            return CellInMatix(first) && CellInMatix(second);
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
            string result = "\n";

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
