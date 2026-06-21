using ArcadianEngine;
using ArcadianEngine.Resources;
using Raylib_cs;
using VerySeriousGame.GameStates;

namespace VerySeriousGame;

public class VerySeriousGame : ArcadianGame<VerySeriousGame>
{
    private RenderPipeline<VerySeriousGame> RenderPipeline = null!;

    public override void OnInitialize()
    {
        RenderPipeline = Context.GetResource<RenderPipeline<VerySeriousGame>>();

        Context.InsertGameState(new GameplayGameState());

        base.OnInitialize();
    }

    public override void OnDraw()
    {
        RenderPipeline.Clear(Color.Black);

        base.OnDraw();
    }
}
