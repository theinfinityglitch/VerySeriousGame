using System.Numerics;
using ArcadianEngine;
using ArcadianEngine.Components;
using ArcadianEngine.Resources;
using Friflo.Engine.ECS;
using Friflo.Engine.ECS.Systems;
using Raylib_cs;
using VerySeriousGame.Components;

namespace VerySeriousGame.Systems;

public class PlayerRender(GameContext<VerySeriousGame> context)
    : QuerySystem<Player, Roulette, Transform2D>
{
    private readonly GameContext<VerySeriousGame> Context = context;
    private RenderPipeline<VerySeriousGame> RenderPipeline = null!;

    protected override void OnAddStore(EntityStore store)
    {
        RenderPipeline = Context.GetResource<RenderPipeline<VerySeriousGame>>();

        base.OnAddStore(store);
    }

    protected override void OnUpdate()
    {
        Query.ForEachEntity(
            (ref player, ref roulette, ref transform, entity) =>
            {
                DrawPlayer(ref transform);
                DrawRoulette(ref roulette, ref transform);
            }
        );
    }

    private void DrawPlayer(ref Transform2D transform)
    {
        RenderPipeline.DrawRectangle(
            new Rectangle(
                transform.GlobalPosition,
                transform.GlobalScale * new Vector2(32.0f, 32.0f)
            ),
            transform.GlobalScale * new Vector2(16.0f, 16.0f),
            transform.GlobalRotation,
            Color.White,
            0
        );
    }

    private void DrawRoulette(ref Roulette roulette, ref Transform2D transform)
    {
        float segmentAngle = 360.0f / roulette.SegmentsCount;

        foreach (var i in Enumerable.Range(0, roulette.SegmentsCount))
        {
            float startAngle = roulette.CurrentAngle + (i * segmentAngle);
            float endAngle = startAngle + segmentAngle;

            // Alternate colors: 0 is Green (0), odd numbers are Red, even are Black
            Color segmentColor;
            if (i % 2 == 1)
                segmentColor = Color.LightGray;
            else
                segmentColor = Color.White;

            // Draw pie-like sector
            RenderPipeline.DrawRing(
                transform.GlobalPosition,
                roulette.InnerRadius,
                roulette.OuterRadius,
                startAngle,
                endAngle,
                36,
                segmentColor,
                1
            );
        }

        float pointerSize = roulette.OuterRadius - roulette.InnerRadius;

        Vector2 p1 = new(
            transform.GlobalPosition.X - roulette.OuterRadius,
            transform.GlobalPosition.Y
        );
        Vector2 p2 = new(
            transform.GlobalPosition.X - roulette.OuterRadius + pointerSize,
            transform.GlobalPosition.Y + 15
        );
        Vector2 p3 = new(
            transform.GlobalPosition.X - roulette.OuterRadius + pointerSize,
            transform.GlobalPosition.Y - 15
        );
        RenderPipeline.DrawTriangle(p1, p2, p3, Color.Yellow, 2);
    }
}
