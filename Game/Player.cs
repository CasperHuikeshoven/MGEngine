using System;
using Engine;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;


class Player : SpriteGameObject
{

    public const int MovingSpeed = 40;
    public const int JumpHeight = 90;

    public GameWorld CurrentLevel{get; set;}

    public Player() : base("Sprites/spr_player@3x1", 1f)
    {

    }

    public override void HandleInput(InputHelper inputHelper)
    {
        velocity.X = 0;

        if(inputHelper.KeyDown(Keys.D))
        {
            velocity.X = MovingSpeed;
            SheetIndex = 1;
        }
        if(inputHelper.KeyDown(Keys.A))
        {
            velocity.X = -MovingSpeed;
            SheetIndex = 2;
        }

        if(inputHelper.KeyPressed(Keys.Space) && Velocity.Y == 0)
        {
            velocity.Y = -JumpHeight;
        }

    }

    public override void Update(GameTime gameTime)
    {
        velocity.Y += 80 * (float)gameTime.ElapsedGameTime.TotalSeconds;

        if(Velocity.X == 0)
            SheetIndex = 0;

        Vector2 previousPosition = this.LocalPosition;
        this.localPosition.Y += Velocity.Y * (float)gameTime.ElapsedGameTime.TotalSeconds;

        if(CollidesWithWorld())
        {
            this.LocalPosition = previousPosition;
            this.velocity.Y = 0;
        }

        previousPosition = this.LocalPosition;
        this.localPosition.X += Velocity.X * (float)gameTime.ElapsedGameTime.TotalSeconds;

        if(CollidesWithWorld())
            this.LocalPosition = previousPosition;
    }

    public bool CollidesWithWorld()
    {
        for(int x = (int)GlobalPosition.X / 16; x < (int)GlobalPosition.X / 16 + 3; x++)
        {
            for(int y = (int)GlobalPosition.Y / 16; y < (int)GlobalPosition.Y / 16 + 3; y++)
            {
                if(CurrentLevel.HasTileCollision(x,y,BoundingBoxForCollisions))
                    return true;
            }
        }

        return false;
    }

    public Rectangle BoundingBoxForCollisions
    {
        get
        {
            Rectangle bbox = new Rectangle();

            bbox.Width = 12;
            bbox.Height = Height;

            bbox.X = 2 + (int)LocalPosition.X;
            bbox.Y = (int)LocalPosition.Y;

            return bbox;
        }
    }
}