using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TangleEngine.Entities.Entity_Properties;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using TangleEngine.Core.Graphics;
using TangleEngine.Core;
using Microsoft.Xna.Framework.Content;

namespace TangleEngine.Entities.Entity_Behaviours.Brush_Behaviours
{
    public class Brush_Cube : GeometricPrimitive<VertexDualTex>
    {

        public Brush_Cube()
        {

            
        }
        protected override void CreateGeometry(List<VertexDualTex> vertices, List<ushort> indices)
        {
            // BottomFace
            vertices.Add(new VertexDualTex(new Vector3(-0.5f, -0.5f, -0.5f), Vector2.Zero, Vector2.Zero, Vector3.Down, Color.White));
            vertices.Add(new VertexDualTex(new Vector3(-0.5f, -0.5f, 0.5f), Vector2.UnitX, Vector2.UnitX, Vector3.Down, Color.White));
            vertices.Add(new VertexDualTex(new Vector3(0.5f, -0.5f, 0.5f), Vector2.One, Vector2.One, Vector3.Down, Color.White));
            vertices.Add(new VertexDualTex(new Vector3(0.5f, -0.5f, -0.5f), Vector2.UnitY, Vector2.UnitY, Vector3.Down, Color.White));

            // TopFace

            vertices.Add(new VertexDualTex(new Vector3(-0.5f, 0.5f, -0.5f), Vector2.Zero, Vector2.Zero, Vector3.Up, Color.White));
            vertices.Add(new VertexDualTex(new Vector3(-0.5f, 0.5f, 0.5f), Vector2.UnitY, Vector2.UnitY, Vector3.Up, Color.White));
            vertices.Add(new VertexDualTex(new Vector3(0.5f, 0.5f, 0.5f), Vector2.One, Vector2.One, Vector3.Up, Color.White));
            vertices.Add(new VertexDualTex(new Vector3(0.5f, 0.5f, -0.5f), Vector2.UnitX, Vector2.UnitX, Vector3.Up, Color.White));

            // BackFace

            vertices.Add(new VertexDualTex(new Vector3(-0.5f, 0.5f, 0.5f), Vector2.Zero, Vector2.Zero, Vector3.Backward, Color.White));
            vertices.Add(new VertexDualTex(new Vector3(-0.5f, -0.5f, 0.5f), Vector2.UnitY, Vector2.UnitY, Vector3.Backward, Color.White));
            vertices.Add(new VertexDualTex(new Vector3(0.5f, -0.5f, 0.5f), Vector2.One, Vector2.One, Vector3.Backward, Color.White));
            vertices.Add(new VertexDualTex(new Vector3(0.5f, 0.5f, 0.5f), Vector2.UnitX, Vector2.UnitX, Vector3.Backward, Color.White));

            // FrontFace

            vertices.Add(new VertexDualTex(new Vector3(-0.5f, 0.5f, -0.5f), Vector2.Zero, Vector2.Zero, Vector3.Forward, Color.White));
            vertices.Add(new VertexDualTex(new Vector3(-0.5f, -0.5f, -0.5f), Vector2.UnitX, Vector2.UnitX, Vector3.Forward, Color.White));
            vertices.Add(new VertexDualTex(new Vector3(0.5f, -0.5f, -0.5f), Vector2.One, Vector2.One, Vector3.Forward, Color.White));
            vertices.Add(new VertexDualTex(new Vector3(0.5f, 0.5f, -0.5f), Vector2.UnitY, Vector2.UnitY, Vector3.Forward, Color.White));

            //LeftFace

            vertices.Add(new VertexDualTex(new Vector3(-0.5f, -0.5f, -0.5f), Vector2.Zero, Vector2.Zero, Vector3.Left, Color.White));
            vertices.Add(new VertexDualTex(new Vector3(-0.5f, -0.5f, 0.5f), Vector2.UnitX, Vector2.UnitX, Vector3.Left, Color.White));
            vertices.Add(new VertexDualTex(new Vector3(-0.5f, 0.5f, 0.5f), Vector2.One, Vector2.One, Vector3.Left, Color.White));
            vertices.Add(new VertexDualTex(new Vector3(-0.5f, 0.5f, -0.5f), Vector2.UnitY, Vector2.UnitY, Vector3.Left, Color.White));

            //RightFace

            vertices.Add(new VertexDualTex(new Vector3(0.5f, -0.5f, -0.5f), Vector2.Zero, Vector2.Zero, Vector3.Right, Color.White));
            vertices.Add(new VertexDualTex(new Vector3(0.5f, -0.5f, 0.5f), Vector2.UnitX, Vector2.UnitX, Vector3.Right, Color.White));
            vertices.Add(new VertexDualTex(new Vector3(0.5f, 0.5f, 0.5f), Vector2.One, Vector2.One, Vector3.Right, Color.White));
            vertices.Add(new VertexDualTex(new Vector3(0.5f, 0.5f, -0.5f), Vector2.UnitY, Vector2.UnitY, Vector3.Right, Color.White));


            // INDICES  

            indices.Add(0);
            indices.Add(2);
            indices.Add(3);
            indices.Add(0);
            indices.Add(1);
            indices.Add(2);

            //top face
            indices.Add(4);
            indices.Add(6);
            indices.Add(5);
            indices.Add(4);
            indices.Add(7);
            indices.Add(6);

            //back face
            indices.Add(8);
            indices.Add(10);
            indices.Add(9);
            indices.Add(8);
            indices.Add(11);
            indices.Add(10);

            //front face
            indices.Add(12);
            indices.Add(13);
            indices.Add(14);
            indices.Add(12);
            indices.Add(14);
            indices.Add(15);

            //left face
            indices.Add(16);
            indices.Add(19);
            indices.Add(18);
            indices.Add(16);
            indices.Add(18);
            indices.Add(17);

            //right face
            indices.Add(20);
            indices.Add(21);
            indices.Add(22);
            indices.Add(20);
            indices.Add(22);
            indices.Add(23);
        }
        protected override PrimitiveType GetPrimType()
        {
            return PrimitiveType.TriangleList;
        }
        protected override Effect CreateEffect(GraphicsDevice device)
        {
            return Parent.GetProperty<ContentManager>("Content").Value.Load<Effect>("Cube_Effect");
        }

        protected override void SetEffectParameters(Effect effect, Matrix World, Matrix View, Matrix Proj)
        {
            effect.Parameters["FrontTexture"].SetValue(Parent.GetProperty<Texture2D>("Texture").Value);
            effect.Parameters["BackTexture"].SetValue(Parent.GetProperty<Texture2D>("Texture").Value);
            effect.Parameters["RightTexture"].SetValue(Parent.GetProperty<Texture2D>("BrickTexture").Value);
            effect.Parameters["LeftTexture"].SetValue(Parent.GetProperty<Texture2D>("BrickTexture").Value);
            effect.Parameters["BottomTexture"].SetValue(Parent.GetProperty<Texture2D>("BrickTexture").Value);
            effect.Parameters["TopTexture"].SetValue(Parent.GetProperty<Texture2D>("BrickTexture").Value);

            base.SetEffectParameters(effect,World,View,Proj);
        }


        public override void Update()
        {
            base.Update();
        }

    }

}
