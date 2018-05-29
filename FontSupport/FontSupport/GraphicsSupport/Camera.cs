using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FontSupport.GraphicsSupport
{
    class Camera
    {
        static private Vector2 Origin = Vector2.Zero; //origin of the world
        static private float Width = 100f; //width of the world
        static private float Ratio = -1; //height of the world

        static private float cameraWindowToPixelRatio()
        {
            if (Ratio < 0f)
                Ratio = (float)Game1.graphics.PreferredBackBufferWidth / Width;

            return Ratio;

        }

        static public void SetCameraWindow(Vector2 origin, float width)
        {
            Origin = origin;
            Width = width;
        }

        static public void ComputePixelPosition(Vector2 cameraPosition, out int x, out int y)
        {
            float ratio = cameraWindowToPixelRatio();

            //convert the position to pixel space
            x = (int)(((cameraPosition.X - Origin.X) * ratio) + .5f);
            y = (int)(((cameraPosition.Y - Origin.Y) * ratio) + .5f);

            y = Game1.graphics.PreferredBackBufferHeight - y;
        }

        static public Rectangle ComputePixelRectangle(Vector2 position, Vector2 size)
        {
            float ratio = cameraWindowToPixelRatio();

            //convert size from camera window space to pixel space
            int width = (int)((size.X * ratio) + .5f);
            int height = (int)((size.Y * ratio) + .5f);

            //convert the position to pixel space
            int x, y;
            ComputePixelPosition(position, out x, out y);

            //reference position is the center
            y -= height / 2;
            x -= width / 2;

            return new Rectangle(x, y, width, height);

        }
    }
}
