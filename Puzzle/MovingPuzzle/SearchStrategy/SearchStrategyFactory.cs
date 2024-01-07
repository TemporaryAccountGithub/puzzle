namespace Puzzle
{
    public class SearchStrategyFactory
    {
        public IStrategySearch CreateSearchStrategy(string searchType)
        {
            switch (searchType.ToLower())
            {
                case "":
                case "bfs":
                    return new SearchBFS();

                case "dfs":
                    return new SearchDFS();

                default:
                    throw new ArgumentException($"Search type: {searchType} is not supported!");
            }
        }
    }
}
