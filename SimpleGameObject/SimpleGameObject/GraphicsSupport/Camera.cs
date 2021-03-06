﻿using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleGameObject.GraphicsSupport
{
    static public class Camera
    {
        static private Vector2 sOrigin = Vector2.Zero;      // Origin of the world
        static private float sWidth = 100f;                 // Width of the world
        static private float sRatio = -1f;                  // Ratio between camera window and pixel 
        static private float sHeight = -1f;


        static public Vector2 CameraWindowLowerLeftPosition { get { return sOrigin; } }

        static public Vector2 CameraWindowUpperRightPosition { get { return sOrigin + new Vector2 (sWidth, sHeight); } }


        static private float cameraWindowToPixelRatio()
        {
            if (sRatio < 0f)
                sRatio = (float)Game1.sGraphics.PreferredBackBufferWidth / sWidth;
            return sRatio;
        }

        static public void SetCameraWindow(Vector2 origin, float width)
        {
            sOrigin = origin;
            sWidth = width;
        }


        static public void ComputePixelPosition(Vector2 cameraPosition, out int x, out int y)
        {
            float ratio = cameraWindowToPixelRatio();

            // Convert the position to pixel space
            x = (int)(((cameraPosition.X - sOrigin.X) * ratio) + 0.5f);
            y = (int)(((cameraPosition.Y - sOrigin.Y) * ratio) + 0.5f);

            y = Game1.sGraphics.PreferredBackBufferHeight - y;
        }


        static public Rectangle ComputePixelRectangle(Vector2 position, Vector2 size)
        {
            float ratio = cameraWindowToPixelRatio();

            // Convert size from Camera Window Space to pixel space
            int width = (int)((size.X * ratio) + 0.5f);
            int height = (int)((size.Y * ratio) + 0.5f);

            // Convert the position to pixel space
            int x, y;
            ComputePixelPosition(position, out x, out y);

            // Reference position is the center
            y -= height / 2;
            x -= width / 2;

            return new Rectangle(x, y, width, height);
        }

        public enum CameraWindowCollisionStatus
        {
            Collidetop = 0,
            CollideBottom = 1,
            CollideRight = 3,
            CollideLeft = 2,
            InsideWindow = 4
        };

        static public CameraWindowCollisionStatus CollidedWithCameraWindow(TexturedPrimitive prim)
        {
            Vector2 min = CameraWindowLowerLeftPosition;
            Vector2 max = CameraWindowUpperRightPosition;

            if (prim.maxBound.Y > max.Y)
                return CameraWindowCollisionStatus.Collidetop;

            if (prim.minBound.X < min.X)
                return CameraWindowCollisionStatus.CollideLeft;

            if (prim.maxBound.X > max.X)
                return CameraWindowCollisionStatus.CollideRight;

            if (prim.minBound.Y < min.Y)
                return CameraWindowCollisionStatus.CollideBottom;

            return CameraWindowCollisionStatus.InsideWindow;
        }
    }
}
