using ArcadianEngine;
using Friflo.Engine.ECS;

namespace VerySeriousGame.Components;

public struct Player() : IComponent
{
    [Export]
    public float PlayerSpeed = 480;
}
