using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleGameObject.GraphicsSupport
{
    public class TexturedPrimitive
    {
        // Support for drawing the image
        protected Texture2D mImage;     // The UWB-JPG.jpg image to be loaded
        protected Vector2 mPosition;    // Center position of image
        protected Vector2 mSize;        // Size of the image to be drawn

        public Vector2 maxBound { get { return mPosition - (0.5f * mSize); } }

        public Vector2 minBound { get { return mPosition + (.5f * mSize); } }


        public TexturedPrimitive(String imageName, Vector2 position, Vector2 size)
        {
            mImage = Game1.sContent.Load<Texture2D>(imageName);
            mPosition = position;
            mSize = size;
        }

        // accessors
        public Vector2 Position { get { return mPosition; } set { mPosition = value; } }
        public Vector2 Size { get { return mSize; } set { mSize = value; } }

        public void Update(Vector2 deltaTranslate, Vector2 deltaScale)
        {
            mPosition += deltaTranslate;
            mSize += deltaScale;
        }

        public void Draw()
        {
            // Defines location and size of the texture
            Rectangle destRect = Camera.ComputePixelRectangle(Position, Size);

            Game1.sSpriteBatch.Draw(mImage, destRect, Color.White);
        }
    }
}
