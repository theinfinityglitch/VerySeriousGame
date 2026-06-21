using ArcadianEngine.Components;
using Friflo.Engine.ECS.Systems;
using VerySeriousGame.Components;

namespace VerySeriousGame.Systems;

public class PlayerController : QuerySystem<Player, Transform2D>
{
    protected override void OnUpdate() { }
}
