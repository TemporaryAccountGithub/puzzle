using NLog;

namespace Puzzle
{
    public class Program
    {
        private static readonly Logger logger = LogManager.GetCurrentClassLogger();
        
        public static void Main(string[] args)
        {
            ConfigLogger();

            string[,] initialMatrix = { { "3", "2" }, { "X", "1" } };
            PuzzleState initialState = new PuzzleState(initialMatrix);
            string[,] finalMatrix = { { "2", "1" }, { "X", "3" } };
            PuzzleState finalState = new PuzzleState(finalMatrix);
            MovingPuzzle puzzle = new MovingPuzzle(initialState, finalState);

            logger.Info("Moving puzzle!\n");
            logger.Info("Going From:");
            logger.Info(initialState);
            logger.Info("To:");
            logger.Info(finalState);
            logger.Info("===================================");

            PuzzleSolverContext solverContext = new PuzzleSolverContext(new SearchDFS());
            foreach (var state in solverContext.Solve(puzzle))
            {
                logger.Info(state);
            }

            logger.Info("\n###################################################\n");

            string[,] initialMazeMatrix =
                {
                    { "0", "0", "0", "0", "0" },
                    { "0", "1", "1", "1", "0" },
                    { "0", "1", "1", "1", "0" },
                    { "0", "1", "1", "1", "0" },
                    { "0", "1", "1", "1", "0" },
                    { "0", "1", "1", "1", "0" },
                    { "X", "1", "1", "1", "0" },
                };
            PuzzleState initialMazeState = new PuzzleState(initialMazeMatrix);
            string[,] finalMazeMatrix =
                {
                    { "0", "0", "0", "0", "0" },
                    { "0", "1", "1", "1", "0" },
                    { "0", "1", "1", "1", "0" },
                    { "0", "1", "1", "1", "0" },
                    { "0", "1", "1", "1", "0" },
                    { "0", "1", "1", "1", "0" },
                    { "0", "1", "1", "1", "X" },
                };
            PuzzleState finalMazeState = new PuzzleState(finalMazeMatrix);
            MazePuzzle mazePuzzle = new MazePuzzle(initialMazeState, finalMazeState);

            logger.Info("Maze puzzle!\n");
            logger.Info("Going From:");
            logger.Info(initialMazeState);
            logger.Info("To:");
            logger.Info(finalMazeState);
            logger.Info("===================================");

            solverContext = new PuzzleSolverContext(new SearchDFS());
            foreach (var state in solverContext.Solve(mazePuzzle))
            {
                logger.Info(state);
            }
        }

        private static void ConfigLogger()
        {
            var config = new NLog.Config.LoggingConfiguration();
            var logconsole = new NLog.Targets.ConsoleTarget("logconsole");
            config.AddRule(LogLevel.Info, LogLevel.Fatal, logconsole);
            NLog.LogManager.Configuration = config;
        }
    }
}
