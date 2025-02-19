using System;
using System.IO;
using Engine;
using Microsoft.Xna.Framework;

class Level1 : GameWorld
{

    public Level1() : base("Levels/level1.txt")
    {

    }

    public override void ReadWorld(string filename)
    {
        StreamReader reader = new StreamReader("Content/" + filename);

        string line = reader.ReadLine();
        int currentrow = 0;

        while(line != null)
        {
            for(int i = 0; i < line.Length; i++)
            {
                Tile tile;
                if(line[i] == '#')
                {
                    tile = new GrassTile(true);
                }
                else if(line[i] == '-')
                {
                    tile = new GrassTile(false);
                }
                else
                {
                    tile = new Tile();
                }
                tile.LocalPosition = new Vector2(i * 16, currentrow * 16);
                AddChild(tile);
                tiles[i, currentrow] = tile;
            }
            currentrow++;
            line = reader.ReadLine();
        }

        reader.Close();
    }
}
