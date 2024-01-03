using System;

namespace Puzzle
{
    public class Program
    {
        public static void Main(string[] args)
        {
            string[,] initialMatrix = { { "3", "2" }, { "X", "1" } };
            PuzzleState initialState = new PuzzleState(initialMatrix);
            string[,] finalMatrix = { { "2", "1" }, { "X", "3" } };
            PuzzleState finalState = new PuzzleState(finalMatrix);
            MovingPuzzle puzzle = new MovingPuzzle(initialState, finalState);

            Console.WriteLine("Going From:");
            Console.WriteLine(initialState);
            Console.WriteLine("To:");
            Console.WriteLine(finalState);
            Console.WriteLine("===================================");

            PuzzleSolverContext solverContext = new PuzzleSolverContext(new SearchBFS());
            foreach (var state in solverContext.Solve(puzzle))
            {
                Console.WriteLine(state);
            }
        }
    }
}
