using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Engine
{
    public class GameObject
    {

        public Vector2 LocalPosition{get; set;}

        public GameObject()
        {

        }

        public virtual void Update(GameTime gameTime)
        {

        }

        public virtual void HandleInput(InputHelper inputHelper)
        {

        }

        public virtual void Draw(SpriteBatch spriteBatch, GameTime gameTime)
        {
            
        }
    }
}