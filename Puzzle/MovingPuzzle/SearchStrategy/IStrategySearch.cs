namespace Puzzle
{
    internal interface IStrategySearch
    {
        public List<PuzzleState> Search(GenericPuzzle puzzle);
    }
}
