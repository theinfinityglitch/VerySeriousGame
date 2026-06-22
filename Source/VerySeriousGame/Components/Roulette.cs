using ArcadianEngine;
using Friflo.Engine.ECS;

namespace VerySeriousGame.Components;

public struct Roulette() : IComponent
{
    [Export]
    public float OuterRadius = 150.0f;

    [Export]
    public float InnerRadius = 100.0f;

    [Export]
    public float RotationSpeed = 1.25f;

    [Export]
    public float CurrentAngle = 0.0f;

    [Export]
    public int SegmentsCount = 8;
}

