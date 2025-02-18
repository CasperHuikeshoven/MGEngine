using System;
using Engine;

class MGGame : ExtendedGame
{ 

    public const string Key_StartState = "startState";

    [STAThread]
    static void Main()
    {
        MGGame game = new MGGame();
        game.Run();
    }

    public MGGame()
    {
        GameStateManager.AddGameState(new StartState(GameStateManager), Key_StartState);
        GameStateManager.SwitchState(Key_StartState);
    }

    protected override void Initialize()
    {
        base.Initialize();
    }

    protected override void LoadContent()
    {
        base.LoadContent();
    }

}
