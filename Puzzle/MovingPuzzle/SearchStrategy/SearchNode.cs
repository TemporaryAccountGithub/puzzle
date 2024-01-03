namespace Puzzle
{
    internal class SearchNode
    {
        public PuzzleState State { get; }
        public List<PuzzleState> Path { get; }

        public SearchNode(PuzzleState state, List<PuzzleState> path)
        {
            State = state;
            Path = path;
        }
    }
}
