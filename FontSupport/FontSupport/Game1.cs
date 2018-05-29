using FontSupport.GraphicsSupport;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace FontSupport
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        static public GraphicsDeviceManager graphics;
        static public SpriteBatch spriteBatch;
        static public ContentManager sContent;

        


        //will be used to set window size
        const int windowWidth = 1000;
        const int windowHeight = 700;

        const int NumObjects = 4;

        TexturedPrimitive[] GraphicsObjects;

        int CurrentIndex = 0;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            Game1.sContent = Content; //add this when having trouble with loading textures in texturedPrimitive class

            graphics.PreferredBackBufferWidth = windowWidth;
            graphics.PreferredBackBufferHeight = windowHeight;
        }

        protected override void Initialize()
        {

            base.Initialize();
        }


        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            //define camera window bounds
            Camera.SetCameraWindow(new Vector2(10f, 20f), 100);

            GraphicsObjects = new TexturedPrimitive[NumObjects];

            GraphicsObjects[0] = new TexturedPrimitive("UWB-JPG", new Vector2(15f, 25f), new Vector2(10f, 10f));
            GraphicsObjects[1] = new TexturedPrimitive("UWB-JPG", new Vector2(35, 60), new Vector2(50, 50));
            GraphicsObjects[2] = new TexturedPrimitive("UWB-PNG", new Vector2(105, 25), new Vector2(10, 10));
            GraphicsObjects[3] = new TexturedPrimitive("UWB-PNG", new Vector2(90, 60), new Vector2(35, 35));
        }

        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }


        protected override void Update(GameTime gameTime)
        {

            if (InputWrapper.Buttons.Back == ButtonState.Pressed)
                this.Exit();

            if (InputWrapper.Buttons.A == ButtonState.Pressed)
                graphics.ToggleFullScreen();

            if (InputWrapper.Buttons.X == ButtonState.Pressed)
                CurrentIndex = (CurrentIndex + 1) % NumObjects;

            GraphicsObjects[CurrentIndex].Update(InputWrapper.Thumbstick.Left, InputWrapper.Thumbstick.Right);



            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            

            Game1.spriteBatch.Begin();

            foreach (TexturedPrimitive p in GraphicsObjects)
            {
                p.Draw();
            }

            Font.PrintStatus("Selected object is: " + CurrentIndex + " Location: " + GraphicsObjects[CurrentIndex].Position, null);

            Font.PrintStatusAt(GraphicsObjects[CurrentIndex].Position, "Selected", Color.Red);

            Game1.spriteBatch.End();

            base.Draw(gameTime);
        }

    }
}
