using System.Numerics;
using ArcadianEngine.Components;
using Friflo.Engine.ECS.Systems;
using Raylib_cs;
using VerySeriousGame.Components;

namespace VerySeriousGame.Systems;

public class PlayerController() : QuerySystem<Player, Roulette, Transform2D>
{
    protected override void OnUpdate()
    {
        Query.ForEachEntity(
            (ref player, ref roulette, ref transform, entity) =>
            {
                HandlePlayerController(ref player, ref transform);

                roulette.CurrentAngle += roulette.RotationSpeed;
                if (roulette.CurrentAngle >= 360.0f)
                    roulette.CurrentAngle -= 360.0f;
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
}
