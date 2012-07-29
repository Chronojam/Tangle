using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace TangleEngine.Core
{
    public class Camera
    {
        public Camera()
        {

        }

        public Vector3 Position
        {
            get;
            set;
        }
        public Vector3 LookAt
        {
            get;
            set;
        }
        public BoundingFrustum Fust_View
        {
            get;
            private set;
        }
        public Matrix ViewMatrix
        {
            get;
            private set;
        }
        public Matrix ProjectionMatrix
        {
            get;
            set;
        }
        public Vector3 UpVector
        {
            get;
            set;
        }
        public void Update()
        {
            this.ViewMatrix =
                Matrix.CreateLookAt(this.Position, this.LookAt, this.UpVector);
            this.Fust_View =
                new BoundingFrustum(ViewMatrix * ProjectionMatrix);
        }
    }
}
