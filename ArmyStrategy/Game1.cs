using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using ArmyStrategy;
using Org.XmlPull.V1;
using Microsoft.Xna.Framework.Input.Touch;

namespace StrategyGame
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        public static int ScreenH, ScreenW;

        static ArmyStrategy.ArmyStrategy CurrentGame;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            ScreenH = _graphics.PreferredBackBufferHeight;
            ScreenW = _graphics.PreferredBackBufferWidth;
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            CurrentGame = new ArmyStrategy.ArmyStrategy();

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

        }

        protected override void Update(GameTime gameTime)
        {
            TouchIn();

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.White);
            _spriteBatch.Begin();

            _spriteBatch.End();
            base.Draw(gameTime);
        }



        private void TouchIn()
        {
            var touches = TouchPanel.GetState();

            TouchLocation prevLoc;
            Vector2 delta;
            foreach (var touch in touches)
            {
                if (!touch.TryGetPreviousLocation(out prevLoc)) continue;

                delta = touch.Position - prevLoc.Position;


            }
        }
    }
}