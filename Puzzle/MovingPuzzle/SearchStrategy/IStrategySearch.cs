namespace Puzzle
{
    public interface IStrategySearch
    {
        public List<PuzzleState> Search(GenericPuzzle puzzle);
    }
}
