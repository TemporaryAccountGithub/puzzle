namespace Puzzle
{
    internal class PuzzleState
    {
        public string[,] Matrix;

        public PuzzleState(string[,] matrix)
        {
            Matrix = matrix;
        }

        public PuzzleState Copy()
        {
            string[,] newMatrix = new string[Matrix.GetLength(0), Matrix.GetLength(1)];
            Array.Copy(Matrix, newMatrix, newMatrix.Length);

            return new PuzzleState(newMatrix);
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

            return Array.Equals(Matrix, ((PuzzleState)obj).Matrix);
        }

        public override string ToString()
        {
            string result = "";

            for (int i = 0; i < Matrix.GetLength(0); i++)
            {
                for (int j = 0; j < Matrix.GetLength(1); j++)
                {
                    result += Matrix[i, j] + " ";
                }
                result += "\n";
            }

            return result;
        }
    }
}
