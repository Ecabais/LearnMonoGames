using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleGameObject.GraphicsSupport
{
    class SoccerBall : TexturedPrimitive
    {
        private Vector2 mDeltaPosition;

        public SoccerBall(Vector2 position, float diameter) :
            base("Soccer", position, new Vector2(diameter, diameter))
        {
            mDeltaPosition.X = (float)(Game1.sRan.NextDouble()) * 2f - 1f;
            mDeltaPosition.Y = (float)(Game1.sRan.NextDouble()) * 2f - 1f;
        }

        public float radius
        {
            get { return mSize.X * .5f; }
            set { mSize.X = 2f * value; mSize.Y = mSize.X; }
        }

        public void Update()
        {
            Camera.CameraWindowCollisionStatus status = Camera.CollidedWithCameraWindow(this);

            switch (status)
            {
                case Camera.CameraWindowCollisionStatus.CollideBottom:
                case Camera.CameraWindowCollisionStatus.Collidetop:
                    mDeltaPosition.Y *= -1;
                    break;
                case Camera.CameraWindowCollisionStatus.CollideLeft:
                case Camera.CameraWindowCollisionStatus.CollideRight:
                    mDeltaPosition.X *= -1;
                    break;
            }

            Position += mDeltaPosition; 


        }
    }
}
