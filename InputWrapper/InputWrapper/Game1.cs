using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace InputWrapper
{
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        Texture2D player1;
        Vector2 player1Position;

        Texture2D player2;
        Vector2 player2Position;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        protected override void Initialize()
        {
            player1Position = new Vector2(10f, 10f);

            player2Position = new Vector2(10f, 250f);
            base.Initialize();
        }

        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            player1 = Content.Load<Texture2D>("UWB-PNG");

            player2 = Content.Load<Texture2D>("UWB-JPG");

        }

        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        protected override void Update(GameTime gameTime)
        {
            if (Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();



            if (Keyboard.GetState().IsKeyDown(Keys.F1))
            {
                graphics.ToggleFullScreen();
                graphics.ApplyChanges();
            }


            //player 1 control
            player1Position += InputWrapper.Thumbstick.Left;


            //player 2 control
            player2Position += InputWrapper.Thumbstick.Right;
           

            MouseState mMouseState = Mouse.GetState();

            if (mMouseState.LeftButton == ButtonState.Pressed)
                player1Position = new Vector2(mMouseState.X, mMouseState.Y);

            if (mMouseState.RightButton == ButtonState.Pressed)
                player2Position = new Vector2(mMouseState.X, mMouseState.Y);


            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            spriteBatch.Begin();
            spriteBatch.Draw(player1, player1Position, Color.White);
            spriteBatch.Draw(player2, player2Position, Color.White);
            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
