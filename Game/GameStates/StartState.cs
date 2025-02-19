using System;
using Engine;
using Microsoft.Xna.Framework;

class StartState : GameState
{
    Player player;
    Level1 level1;

    public StartState(GameStateManager gameStateManager) : base(gameStateManager)
    {
        AddChild(new SpriteGameObject("Sprites/Backgrounds/spr_state-background", 0f));

        player = new Player();
        AddChild(player);

        level1 = new Level1();
        AddChild(level1);

        player.CurrentLevel = level1;
    }
}
