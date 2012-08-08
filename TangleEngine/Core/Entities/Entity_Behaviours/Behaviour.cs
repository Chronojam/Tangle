using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;

namespace TangleEngine.Entities.Entity_Behaviours
{
    public abstract class Behaviour
    {
        public Entity Parent
        {
            get;
            private set;
        }

        public void Attach(Entity entity)
        {

            if (Parent != null)
                throw new InvalidOperationException("Cannot attach a behaviour to two entities");


            Parent = entity;
            Init();
        }

        protected abstract void Init();
        public abstract void Update();
    }
}
