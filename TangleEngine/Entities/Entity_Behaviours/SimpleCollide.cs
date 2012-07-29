using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TangleEngine.Entities.Entity_Properties;
using Microsoft.Xna.Framework;

namespace TangleEngine.Entities.Entity_Behaviours
{
    public class SimpleCollide : Behaviour
    {
        Property<Vector3> Position;
        Property<Vector3> Scale;
        BoundingBox bb;

        protected override void Init()
        {
            Position = Parent.GetProperty<Vector3>("Position");
            Scale = Parent.GetProperty<Vector3>("Scale");

            bb = new BoundingBox(Position.Value - Scale.Value / 2, Position.Value + Scale.Value /2);
        }
        public override void Update()
        {
            Parent.GetProperty<BoundingBox>("BoundingBox").Value = new BoundingBox(Position.Value * 2 - Scale.Value /2, Position.Value * 2 + Scale.Value /2);    
        }
    }
}
