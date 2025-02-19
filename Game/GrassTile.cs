using System;
using Engine;

class GrassTile : Tile
{

    public GrassTile(bool b)
    {
        HasCollision = true;
        if(b)
            sprite = new SpriteGameObject("Sprites/spr_tiles@2x1", .5f);
        else
            sprite = new SpriteGameObject("Sprites/spr_tiles@2x1", .5f, 1);
        
        sprite.Parent = this;
    }
}
