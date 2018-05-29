using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FontSupport.GraphicsSupport
{
    class TexturedPrimitive
    {
        protected Texture2D players;
        public Vector2 Position;
        protected Vector2 Size;

        public TexturedPrimitive(String imageName, Vector2 position, Vector2 size)
        {
            players = Game1.sContent.Load<Texture2D>(imageName);
            Position = position;
            Size = size;
        }

        public void Update(Vector2 deltaTranslate, Vector2 deltaScale)
        {
            Position += deltaTranslate;
            Size += deltaScale;
        }

        public void Draw()
        {
            Rectangle destRect = Camera.ComputePixelRectangle(Position, Size);

            Game1.spriteBatch.Draw(players, destRect, Color.White);
        }


    }
}
