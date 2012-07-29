using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TangleEngine.Entities.Entity_Behaviours;
using TangleEngine.Entities.Entity_Properties;
using Microsoft.Xna.Framework;
using TangleEngine.Entities;
using Microsoft.Xna.Framework.Graphics;
using TangleEngine.Core;
using TangleEngine.Entities.Entity_Behaviours.Brush_Behaviours;

namespace TangleEdit
{
    class Grabable : Behaviour
    {
        Property<Vector3> Position;
        Property<Vector3> Scale;

        Brush_Cube RenderTestI;
        Brush_Cube RenderTestII;
        Brush_Cube RenderTestIII;

        IsCollidable CollideI;
        IsCollidable CollideII;
        IsCollidable CollideIII;

        Entity YEnt;
        Entity XEnt;
        Entity ZEnt;

        public Grabable()
        {
            YEnt = new Entity("Up/Down");
            XEnt = new Entity("Left/Right");
            ZEnt = new Entity("Forward/Backward");

            RenderTestI = new Brush_Cube();
            RenderTestII = new Brush_Cube();
            RenderTestIII = new Brush_Cube();

            CollideI = new IsCollidable();
            CollideII = new IsCollidable();
            CollideIII = new IsCollidable();
        }

        protected override void Init()
        {
            Position = Parent.GetProperty<Vector3>("Position");
            Scale = Parent.GetProperty<Vector3>("Scale");

            XEnt.AddProperty<Vector3>("Position", new Vector3((float)(Position.Value.X + Scale.Value.X * 0.5), Position.Value.Y, Position.Value.Z));
            XEnt.AddProperty<Vector3>("Scale", new Vector3(0, 0, 0));
            XEnt.AddProperty<Color>("Color", Color.Red);
            XEnt.AddBehaviour(CollideII);
            XEnt.AddBehaviour(RenderTestII);

            YEnt.AddProperty<Vector3>("Position", new Vector3(Position.Value.X, (float)(Position.Value.Y + Scale.Value.Y * 0.5), Position.Value.Z));
            YEnt.AddProperty<Vector3>("Scale", new Vector3(0, 0, 0));
            YEnt.AddProperty<Color>("Color", Color.Green);
            YEnt.AddBehaviour(CollideI);
            YEnt.AddBehaviour(RenderTestI);

            ZEnt.AddProperty<Vector3>("Position", new Vector3(Position.Value.X, Position.Value.Y, (float)(Position.Value.Z + Scale.Value.Z * 0.5)));
            ZEnt.AddProperty<Vector3>("Scale", new Vector3(0, 0, 0));
            ZEnt.AddProperty<Color>("Color", Color.Blue);
            ZEnt.AddBehaviour(CollideIII);
            ZEnt.AddBehaviour(RenderTestIII);
        }

        public override void Update()
        {
            XEnt.AddProperty<Vector3>("Position", new Vector3((float)(Position.Value.X + Scale.Value.X * 0.5), Position.Value.Y, Position.Value.Z));
            YEnt.AddProperty<Vector3>("Position", new Vector3(Position.Value.X, (float)(Position.Value.Y + Scale.Value.Y * 0.5), Position.Value.Z));
            ZEnt.AddProperty<Vector3>("Position", new Vector3(Position.Value.X, Position.Value.Y, (float)(Position.Value.Z + Scale.Value.Z * 0.5)));

            XEnt.Update();
            YEnt.Update();
            ZEnt.Update();         
        }

        public void Draw()
        {
            /*
            RenderTestI.Draw();
            RenderTestII.Draw();
            RenderTestIII.Draw();
             * */
        }
    }
}
