using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TangleEngine.Entities.Entity_Behaviours;
using Microsoft.Xna.Framework;

namespace TangleEdit.Editor_Behaviours
{
    class Planes : Behaviour
    {
        int Size;
        Matrix Rotation;

        public Planes(int size, Matrix rotation)
        {
            this.Size = size;
            this.Rotation = rotation;
        }
        protected override void Init()
        {
            
        }

        public override void Update()
        {
            
        }
    }
}
