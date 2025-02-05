using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Engine
{
    public class ExtendedGame : Game
    {
        private GraphicsDeviceManager graphics;
        private SpriteBatch spriteBatch;

        private List<GameObject> gameObjects;
        private InputHelper inputHelper; 

        public ExtendedGame()
        {
            inputHelper = new InputHelper(this);
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
            spriteBatch = new SpriteBatch(GraphicsDevice);
            gameObjects = new List<GameObject>();
        }

        protected override void Initialize()
        {
            base.Initialize();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
        }

        protected void AddChild(GameObject obj)
        {
            gameObjects.Add(obj);
        }

        protected override void Update(GameTime gameTime)
        {
            inputHelper.Update(gameTime);
            HandleInput(inputHelper);
            foreach(GameObject obj in gameObjects)
                obj.Update(gameTime);
        }

        protected virtual void HandleInput(InputHelper inputHelper)
        {
            foreach(GameObject obj in gameObjects)
                obj.HandleInput(inputHelper);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            spriteBatch.Begin();
            foreach(GameObject obj in gameObjects)
                obj.Draw(spriteBatch, gameTime);
            spriteBatch.End();
        }

        public Vector2 ScreenToWorld(Vector2 pos)
        {
            return Vector2.Zero;
        }
    }
}