using System.Numerics;
using ArcadianEngine;
using ArcadianEngine.Components;
using ArcadianEngine.Resources;
using Friflo.Engine.ECS;
using Friflo.Engine.ECS.Systems;
using Raylib_cs;
using VerySeriousGame.Components;

namespace VerySeriousGame.Systems;

public class PlayerController(GameContext<VerySeriousGame> cx) : QuerySystem<Player, Transform2D>
{
    private readonly GameContext<VerySeriousGame> Context = cx;
    private RenderPipeline<VerySeriousGame> RenderPipeline = null!;

    protected override void OnAddStore(EntityStore store)
    {
        RenderPipeline = Context.GetResource<RenderPipeline<VerySeriousGame>>();

        base.OnAddStore(store);
    }

    protected override void OnUpdate()
    {
        Query.ForEachEntity(
            (ref player, ref transform, entity) =>
            {
                var direction = Vector2.Zero;

                if (Raylib.IsKeyDown(KeyboardKey.A))
                    direction.X -= 1;
                if (Raylib.IsKeyDown(KeyboardKey.D))
                    direction.X += 1;
                if (Raylib.IsKeyDown(KeyboardKey.W))
                    direction.Y -= 1;
                if (Raylib.IsKeyDown(KeyboardKey.S))
                    direction.Y += 1;

                transform.Position += direction * player.PlayerSpeed * Raylib.GetFrameTime();

                RenderPipeline.DrawRectangle(
                    new Rectangle(transform.Position, transform.Scale * new Vector2(32.0f, 32.0f)),
                    transform.Scale * new Vector2(16.0f, 16.0f),
                    transform.Rotation,
                    Color.White
                );
            }
        );
    }
}
