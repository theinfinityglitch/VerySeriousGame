using System.Numerics;
using ArcadianEngine;
using ArcadianEngine.Components;
using Friflo.Engine.ECS;
using Friflo.Engine.ECS.Systems;
using Raylib_cs;
using VerySeriousGame.Components;
using VerySeriousGame.Resources;

namespace VerySeriousGame.Systems;

public class PlayerController(GameContext<VerySeriousGame> context)
    : QuerySystem<Player, Roulette, Transform2D>
{
    private readonly GameContext<VerySeriousGame> Context = context;
    private RunManager _runManager = null!;

    protected override void OnAddStore(EntityStore store)
    {
        _runManager = Context.GetResource<RunManager>();

        base.OnAddStore(store);
    }

    protected override void OnUpdate()
    {
        Query.ForEachEntity(
            (ref player, ref roulette, ref transform, entity) =>
            {
                HandlePlayerController(ref player, ref transform);
                HandleRoulette(ref roulette);
            }
        );
    }

    private void HandlePlayerController(ref Player player, ref Transform2D transform)
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
    }

    private void HandleRoulette(ref Roulette roulette)
    {
        // Rotate the roulette
        roulette.CurrentAngle += roulette.RotationSpeed;

        if (roulette.CurrentAngle >= 360.0f)
            roulette.CurrentAngle -= 360.0f;

        // Get the current hovered segment
        float segmentAngle = 360.0f / roulette.SegmentsCount;
        float localAngle = 180.0f - roulette.CurrentAngle;
        localAngle %= 360.0f;

        if (localAngle < 0)
            localAngle += 360.0f;

        roulette.SelectedSegment = (int)(localAngle / segmentAngle);

        if (
            Raylib.IsKeyPressed(KeyboardKey.Space)
            && _runManager.EquippedSpells.TryGetValue(roulette.SelectedSegment, out var spell)
        )
            Console.WriteLine(spell.ToString());
    }
}
