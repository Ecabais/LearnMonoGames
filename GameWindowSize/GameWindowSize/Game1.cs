using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace GameWindowSize
{
 
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        Texture2D player1;
        Vector2 player1Position;

        Texture2D player2;
        Vector2 player2Position;

        //window size variable
        const int windowWidth = 1000;
        const int windowHeight = 700;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";

            graphics.PreferredBackBufferHeight = windowHeight;
            graphics.PreferredBackBufferWidth = windowWidth;
        }

        protected override void Initialize()
        {
            //initialize player 1 position on screen
            player1Position = new Vector2(10f, 10f);

            //initialize player 2 position on screen
            player2Position = new Vector2(10f, 250f);

            base.Initialize();
        }

        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            //load player 1 sprite 
            player1 = Content.Load<Texture2D>("UWB-PNG");

            //load player 2 sprite
            player2 = Content.Load<Texture2D>("UWB-JPG");
        }

        protected override void UnloadContent()
        {
           
        }

        protected override void Update(GameTime gameTime)
        {
            //exit game when "back" on controller or "F1" on keyboard is pressed
            if (InputWrapper.Buttons.Back == ButtonState.Pressed)
            {
                this.Exit();
            }

            //toggle fullscreen when "A" on controller or "k" on keyboard is pressed
            if (InputWrapper.Buttons.A == ButtonState.Pressed)
            {
                graphics.ToggleFullScreen();
                graphics.ApplyChanges();
            }

            //player 1 movement control. WASD on keyboard or left thumbstick on controller
            player1Position += InputWrapper.Thumbstick.Left;

            //player 2 movement control. up,down,left,right on keyboard or right thumbstick on controller
            player2Position += InputWrapper.Thumbstick.Right;
           

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            spriteBatch.Begin();

            //draw player1 sprite on screen
            spriteBatch.Draw(player1, player1Position, Color.White);

            //draw player2 sprite on screen
            spriteBatch.Draw(player2, player2Position, Color.White);

            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
