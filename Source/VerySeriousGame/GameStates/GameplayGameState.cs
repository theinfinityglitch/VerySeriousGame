using ArcadianEngine;
using ArcadianEngine.Components;
using ArcadianEngine.Core;
using Friflo.Engine.ECS;
using VerySeriousGame.Components;
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
        Context.InsertSystem<Update, PlayerController>(new PlayerController());
        Context.Game.World.CreateEntity(new Player(), new Transform2D());
    }

    public override void OnDraw()
    {
        base.OnDraw();
    }
}
