using NLog;

namespace Puzzle
{
    public class SearchDFS : IStrategySearch
    {
        private static readonly Logger logger = LogManager.GetCurrentClassLogger();

        public List<PuzzleState> Search(GenericPuzzle puzzle)
        {
            List<PuzzleState> visited = new List<PuzzleState>();
            Stack<SearchNode> searchStack = new Stack<SearchNode>();
            searchStack.Push(new SearchNode(puzzle.InitialState, new List<PuzzleState> { puzzle.InitialState }));

            while (searchStack.Count > 0)
            {
                SearchNode currentNode = searchStack.Pop();
                visited.Add(currentNode.State);

                if (currentNode.State.Equals(puzzle.FinalState))
                {
                    logger.Info("Solution found!");
                    return currentNode.Path;
                }

                foreach (PuzzleState neighbor in puzzle.GetNextPossibleMoves(currentNode.State))
                {
                    if (!visited.Contains(neighbor))
                    {
                        List<PuzzleState> newPath = new List<PuzzleState>(currentNode.Path) { neighbor };
                        searchStack.Push(new SearchNode(neighbor, newPath));
                    }
                }
            }

            logger.Warn("No Solution found!");
            return new List<PuzzleState>();
        }
    }
}
