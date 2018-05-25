using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace GameWindowSize
{
<<<<<<< HEAD
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
=======
 
>>>>>>> 68c80d1902b4f2c0177966969956ed8cb316b3df
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

<<<<<<< HEAD
=======
        Texture2D player1;
        Vector2 player1Position;

        Texture2D player2;
        Vector2 player2Position;

        //window size variable
        const int windowWidth = 1000;
        const int windowHeight = 700;

>>>>>>> 68c80d1902b4f2c0177966969956ed8cb316b3df
        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
<<<<<<< HEAD
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
=======

            graphics.PreferredBackBufferHeight = windowHeight;
            graphics.PreferredBackBufferWidth = windowWidth;
        }

        protected override void Initialize()
        {
            //initialize player 1 position on screen
            player1Position = new Vector2(10f, 10f);

            //initialize player 2 position on screen
            player2Position = new Vector2(10f, 250f);
>>>>>>> 68c80d1902b4f2c0177966969956ed8cb316b3df

            base.Initialize();
        }

<<<<<<< HEAD
        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
=======
>>>>>>> 68c80d1902b4f2c0177966969956ed8cb316b3df
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

<<<<<<< HEAD
            // TODO: use this.Content to load your game content here
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here
=======
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
           
>>>>>>> 68c80d1902b4f2c0177966969956ed8cb316b3df

            base.Update(gameTime);
        }

<<<<<<< HEAD
        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
=======
>>>>>>> 68c80d1902b4f2c0177966969956ed8cb316b3df
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

<<<<<<< HEAD
            // TODO: Add your drawing code here
=======
            spriteBatch.Begin();

            //draw player1 sprite on screen
            spriteBatch.Draw(player1, player1Position, Color.White);

            //draw player2 sprite on screen
            spriteBatch.Draw(player2, player2Position, Color.White);

            spriteBatch.End();
>>>>>>> 68c80d1902b4f2c0177966969956ed8cb316b3df

            base.Draw(gameTime);
        }
    }
}
