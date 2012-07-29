using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using TangleEngine.Core;
using TangleEngine.Entities.Entity_Behaviours;
using TangleEngine.Entities.Entity_Behaviours.Brush_Behaviours;

namespace TangleEdit
{
    class RefPlane : GeometricPrimitive<VertexPositionColor>
    {
        RasterizerState rs = new RasterizerState();
        int size;
        Color colour;
        Matrix rotation;

        public RefPlane(int size,Matrix Rotation, Color colour)
        {
            this.size = size;
            this.rotation = Rotation;
            this.colour = colour;
        }

        protected override void CreateGeometry(List<VertexPositionColor> vertices, List<ushort> indices)
        {
            Matrix Offset;
            Offset = Matrix.CreateTranslation(-size / 2f, 0, -size / 2f) * rotation;
            rs.CullMode = CullMode.CullClockwiseFace;
            rs.FillMode = FillMode.WireFrame;


            for (int x = 0; x < size; x++)
            {
                for (int z = 0; z < size; z++)
                {
                    vertices.Add(new VertexPositionColor(Vector3.Transform(new Vector3(x, 0, z), Offset), colour));
                }
            }

            for (int x = 0; x < size - 1; x++)
            {
                for (int z = 0; z < size - 1; z++)
                {
                    indices.Add((ushort)(x * size + z));
                    indices.Add((ushort)(x * size + z + 1));
                }
            }

            for (int z = 0; z < size - 1; z++)
            {
                for (int x = 0; x < size - 1; x++)
                {
                    indices.Add((ushort)(z * size + x));
                    indices.Add((ushort)(z * size + x + size));
                }
            }
        }

        protected override PrimitiveType GetPrimType()
        {
            return PrimitiveType.LineList;
        }

        public override void Update()
        {

        }

        protected override Effect CreateEffect(GraphicsDevice device)
        {
            BasicEffect effect = new BasicEffect(device);
            effect.VertexColorEnabled = true;
            effect.Alpha = 0.5f;

            return effect;
        }

        public override void Draw(GraphicsDevice graphicsDevice, Matrix World, Matrix View, Matrix Proj)
        {
            RasterizerState rsnew = graphicsDevice.RasterizerState;
            graphicsDevice.RasterizerState = rs;
            base.Draw(graphicsDevice,World,View,Proj);

            graphicsDevice.RasterizerState = rsnew;
        }
    }
}
