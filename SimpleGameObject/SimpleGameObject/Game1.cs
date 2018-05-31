using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using SimpleGameObject.GraphicsSupport;
using SimpleGameObject.Input;
using System;

namespace SimpleGameObject
{
    public class Game1 : Game
    {
        #region Class variables defined to be globally accessible!!

        static public SpriteBatch sSpriteBatch;  // Drawing support
        static public ContentManager sContent;   // Loading textures
        static public GraphicsDeviceManager sGraphics; // Current display size
        #endregion

        #region Preferred Window Size
        // Prefer window size
        // Convention: "k" to begin constant variable names
        const int kWindowWidth = 1000;
        const int kWindowHeight = 700;
        #endregion 

        static public Random sRan;

        TexturedPrimitive mUWBLogo;
        SoccerBall mBall;

        Vector2 mSoccerPosition = new Vector2(50, 50);
        float mSoccerBallRadius = 3f;

        // Work with Textured Primitive and SoccerBall Class


        public Game1()
        {
            Game1.sRan = new Random(); 

            // Content resource loading support
            Content.RootDirectory = "Content";
            Game1.sContent = Content;

            // Create graphics device to access window size
            Game1.sGraphics = new GraphicsDeviceManager(this);
            // Set prefer window size
            Game1.sGraphics.PreferredBackBufferWidth = kWindowWidth;
            Game1.sGraphics.PreferredBackBufferHeight = kWindowHeight;

        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            Game1.sSpriteBatch = new SpriteBatch(GraphicsDevice);

            // Define Camera Window Bounds
            Camera.SetCameraWindow(new Vector2(10f, 20f), 100f);

            // Create the primitives
            mUWBLogo = new TexturedPrimitive("UWB-PNG", new Vector2(30f, 30f), new Vector2(20f ,20f));
            mBall = new SoccerBall(mSoccerPosition, mSoccerBallRadius * 2f);
        }

      
        protected override void Update(GameTime gameTime)
        {
            // Allows the game to exit
            if (InputWrapper.Buttons.Back == ButtonState.Pressed)
                this.Exit();

            #region Control the UWB Logo position with left thumb stick
            mUWBLogo.Update(InputWrapper.ThumbSticks.Left, Vector2.Zero);
            #endregion

            #region Let the SoccerBall update itself, and let user control its size with the right thumb stick
            mBall.Update();
            mBall.Update(Vector2.Zero, InputWrapper.ThumbSticks.Right);

            if (InputWrapper.Buttons.A == ButtonState.Pressed)
                mBall = new SoccerBall(mSoccerPosition, mSoccerBallRadius * 2f);
            #endregion


            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            // Clear to background color
            GraphicsDevice.Clear(Color.CornflowerBlue);

            Game1.sSpriteBatch.Begin(); // Initialize drawing support

            mUWBLogo.Draw();
            mBall.Draw();

            FontSupport.PrintStatus("Ball Position", null);

            FontSupport.PrintStatusAt(mUWBLogo.Position, mUWBLogo.Position.ToString(), Color.White);
            FontSupport.PrintStatusAt(mBall.Position, "Radius" + mBall.radius, Color.Red);

            Game1.sSpriteBatch.End(); // Inform graphics system we are done drawing

            base.Draw(gameTime);
        }
    }
}
