using ArcadianEngine;
using ArcadianEngine.Resources;
using Raylib_cs;

namespace VerySeriousGame;

public class VerySeriousGame : ArcadianGame<VerySeriousGame>
{
    private RenderPipeline<VerySeriousGame> RenderPipeline = null!;

    public override void OnInitialize()
    {
        RenderPipeline = Context.GetResource<RenderPipeline<VerySeriousGame>>();

        base.OnInitialize();
    }

    public override void OnDraw()
    {
        RenderPipeline.Clear(Color.Black);

        base.OnDraw();
    }
}
