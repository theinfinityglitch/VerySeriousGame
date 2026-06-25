using System.Numerics;
using ArcadianEngine;
using ArcadianEngine.Components;
using ArcadianEngine.Core;
using Friflo.Engine.ECS;
using VerySeriousGame.Components;
using VerySeriousGame.Resources;
using VerySeriousGame.Systems;

namespace VerySeriousGame.GameStates;

public class GameplayGameState : State<VerySeriousGame>
{
    public override void OnEnter()
    {
        SetupGameScene();
        base.OnEnter();
    }

    private void SetupGameScene()
    {
        Context.InsertResource(new RunManager()).GenerateStartData();
        Context.InsertSystem<Update, PlayerController>(new PlayerController(Context));
        Context.InsertSystem<Draw, PlayerRender>(new PlayerRender(Context));

        Context.Game.World.CreateEntity(
            new Player(),
            new Roulette(),
            new Transform2D(new Vector2(640, 320))
        );
    }

    public override void OnDraw()
    {
        base.OnDraw();
    }
}
