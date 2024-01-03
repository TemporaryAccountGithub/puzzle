namespace Puzzle
{
    public class PuzzleSolverContext
    {
        private IStrategySearch searchStrategy;

        public PuzzleSolverContext(IStrategySearch searchStrategy)
        {
            this.searchStrategy = searchStrategy;
        }

        public List<PuzzleState> Solve(GenericPuzzle puzzle)
        {
            return searchStrategy.Search(puzzle);
        }
    }
}
