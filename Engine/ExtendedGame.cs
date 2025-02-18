using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Engine
{
    public class ExtendedGame : Game
    {
        private GraphicsDeviceManager graphics;
        private SpriteBatch spriteBatch;

        private List<GameObject> gameObjects;
        private InputHelper inputHelper; 

        protected static Point WorldSize {get; set;}
        protected static Point WindowSize {get; set;}

        public ExtendedGame()
        {
            inputHelper = new InputHelper(this);
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
            gameObjects = new List<GameObject>();

            WorldSize = new Point(320, 180);
            WindowSize = new Point(1280, 720);

            ChangeScreen(false);
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

            // Change screen to fullscreen or unfullscreen by pressing f5
            if(inputHelper.KeyPressed(Keys.F5))
                ChangeScreen(!IsFullScreen);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            spriteBatch.Begin();
            foreach(GameObject obj in gameObjects)
                obj.Draw(spriteBatch, gameTime);
            spriteBatch.End();
        }

        /// <summary>
        /// Property for setting and getting the value of fullscreen
        /// </summary>
        protected bool IsFullScreen
        {
            get
            {
                return graphics.IsFullScreen;
            }
            set
            {
                graphics.IsFullScreen = value;
            }
        }

        protected void ChangeScreen(bool fullscreen)
        {
            IsFullScreen = fullscreen;

            Point screenSize;

            if(!IsFullScreen)
            {
                screenSize.X = WindowSize.X;
                screenSize.Y = WindowSize.Y; 
            } 
            else
            {
                screenSize = new Point(GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width, GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height);
            }

            graphics.PreferredBackBufferWidth = screenSize.X;
            graphics.PreferredBackBufferHeight = screenSize.Y;

            graphics.ApplyChanges();

            
        }

        public Vector2 ScreenToWorld(Vector2 screenPosition)
        {
            Vector2 viewportTopLeft = new Vector2(GraphicsDevice.Viewport.X, GraphicsDevice.Viewport.Y);
            float screenToWorld = WorldSize.X / (float) GraphicsDevice.Viewport.Width;
            return (screenPosition - viewportTopLeft) * screenToWorld;
        }
    }
}