using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FontSupport.GraphicsSupport
{
    static class Font
    {
        static private SpriteFont theFont = null; //declare spritefont
        static private Color defaultColor = Color.Black; //black as defualt color of font
        static private Vector2 statusLocation = new Vector2(5, 5); //initialize location of font

        static private void LoadFont()
        {
            //for demo purposes load arial.spritefont
            if (null == theFont)
                theFont = Game1.sContent.Load<SpriteFont>("Arial");
        }

        static private Color ColorToUse(Nullable<Color> c)
        {
            return (null == c) ? defaultColor : (Color)c;
        }

        static public void PrintStatusAt(Vector2 pos, String msg, Nullable<Color> drawColor)
        {
            LoadFont();
            Color useColor = ColorToUse(drawColor);

            int pixelX, pixelY;

            Camera.ComputePixelPosition(pos, out pixelX, out pixelY);
            Game1.spriteBatch.DrawString(theFont, msg, new Vector2(pixelX, pixelY), useColor);


        }

        static public void PrintStatus(String msg, Nullable<Color> drawColor)
        {
            LoadFont();
            Color useColor = ColorToUse(drawColor);

            Game1.spriteBatch.DrawString(theFont, msg, statusLocation, useColor);
        }
    }
}