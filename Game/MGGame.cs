using System;
using Engine;

class MGGame : ExtendedGame
{
    [STAThread]
    static void Main()
    {
        MGGame game = new MGGame();
        game.Run();
    }

    public MGGame()
    {
        
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
