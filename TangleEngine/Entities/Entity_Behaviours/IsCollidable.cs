using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TangleEngine.Entities.Entity_Properties;
using Microsoft.Xna.Framework;

namespace TangleEngine.Entities.Entity_Behaviours
{
    public class IsCollidable : Behaviour, IName
    {
        Property<Vector3> Position;
        Property<Vector3> Scale;

        public BoundingBox bb;

        protected override void Init()
        {
            Position = Parent.GetProperty<Vector3>("Position");
            Scale = Parent.GetProperty<Vector3>("Scale");

            bb = new BoundingBox(Position.Value - Scale.Value / 2, Position.Value + Scale.Value /2);
        }

        public override void Update()
        {
            bb = new BoundingBox(Position.Value - Scale.Value / 2, Position.Value + Scale.Value / 2);
        }

        public virtual void Name(string name)
        {
            name = "IsCollidable";
        }

    }
}
