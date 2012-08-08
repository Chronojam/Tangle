using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace TangleEngine.Entities.Entity_Behaviours
{
    public interface IDrawableBehaviour
    {
        void Draw(GraphicsDevice graphicsDevice,Matrix World, Matrix View, Matrix Projection);
    }
}
