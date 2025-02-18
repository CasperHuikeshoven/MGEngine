using System;
using Engine;

class StartState : GameState
{

    SpriteGameObject test;

    public StartState(GameStateManager gameStateManager) : base(gameStateManager)
    {
        AddChild(new SpriteGameObject("Sprites/Backgrounds/spr_state-background", 0f));

        test = new SpriteGameObject("Sprites/spr_test@3x2", 1f, 5);
        AddChild(test);
    }
}
