using ArcadianEngine;

namespace VerySeriousGame;

internal class Program
{
    private static void Main()
    {
        Game<VerySeriousGame> game = new(
            new VerySeriousGame(),
            "Very Serious Game",
            new(1280, 720)
        );
        game.Run();
    }
}
