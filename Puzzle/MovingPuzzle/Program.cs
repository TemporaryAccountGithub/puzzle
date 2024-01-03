using System;

namespace Puzzle
{
    public class Program
    {
        public static void Main(string[] args)
        {
            string[,] matrix = { { "1", "2" }, { "3", "X" } };
            PuzzleState state = new PuzzleState(matrix);
            MovingPuzzle puzzle = new MovingPuzzle(state, state);
            Console.WriteLine(state);
            Console.WriteLine("======================");

            foreach (var state1 in puzzle.GetNextPossibleMoves(state))
            {
                Console.WriteLine(state1);
            }
        }
    }
}
