using NLog;

namespace Puzzle
{
    public class SearchBFS : IStrategySearch
    {
        private static readonly Logger logger = LogManager.GetCurrentClassLogger();
        public List<PuzzleState> Search(GenericPuzzle puzzle)
        {
            List<PuzzleState> visited = new List<PuzzleState>();
            Queue<SearchNode> searchQueue = new Queue<SearchNode>();
            searchQueue.Enqueue(new SearchNode(puzzle.InitialState, new List<PuzzleState> { puzzle.InitialState }));

            while (searchQueue.Count > 0)
            {
                SearchNode currentNode = searchQueue.Dequeue();
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
                        searchQueue.Enqueue(new SearchNode(neighbor, newPath));
                    }
                }
            }

            logger.Warn("No Solution found!");
            return new List<PuzzleState>();
        }
    }
}
