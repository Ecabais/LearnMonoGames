using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using TexturedPrimitives.GraphicsSupport;

namespace TexturedPrimitives
{

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

            GraphicsObjects = new TexturedPrimitive[NumObjects];

            GraphicsObjects[0] = new TexturedPrimitive("UWB-JPG", new Vector2(10f, 10f), new Vector2(30f, 30f));
            GraphicsObjects[1] = new TexturedPrimitive("UWB-JPG", new Vector2(200, 200), new Vector2(100, 100));
            GraphicsObjects[2] = new TexturedPrimitive("UWB-PNG", new Vector2(50, 10), new Vector2(30, 30));
            GraphicsObjects[3] = new TexturedPrimitive("UWB-PNG", new Vector2(50, 200), new Vector2(100, 100));
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

            Game1.spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
