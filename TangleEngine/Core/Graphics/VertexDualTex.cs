using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace TangleEngine.Core.Graphics
{
    public struct VertexDualTex : IVertexType
    {
             Vector3 vertexPosition;
             Vector3 vertexNormal;
             Vector2 TextureCoordinate1;
             Vector2 TextureCoordinate2;
             Color vertexColor;

             public Vector3 Position
             {
                 get { return vertexPosition; }
                 set { vertexPosition = value; }
             }
             public Vector3 Normal
             {
                 get { return vertexNormal; }
                 set { vertexNormal = value; }
             }
             public Vector2 TextureCoord1
             {
                 get { return TextureCoordinate1; }
                 set { TextureCoordinate1 = value; }
             }
             public Vector2 TextureCoord2
             {
                 get { return TextureCoordinate2; }
                 set { TextureCoordinate2 = value; }
             }
             public Color Colour
             {
                 get { return vertexColor; }
                 set { vertexColor = value; }
             }

            public VertexDualTex(Vector3 pos, Vector2 texcoord1, Vector2 texcoord2, Vector3 normal, Color Colour)
            {
                vertexPosition = pos;
                vertexNormal = normal;
                TextureCoordinate1 = texcoord1;
                TextureCoordinate2 = texcoord2;
                vertexColor = Colour;
            }

            public static readonly VertexDeclaration VertexDeclaration = new VertexDeclaration
            (
                    new VertexElement(0, VertexElementFormat.Vector3, VertexElementUsage.Position, 0),
                    new VertexElement(12, VertexElementFormat.Vector3, VertexElementUsage.Normal, 0),
                    new VertexElement(24, VertexElementFormat.Vector2, VertexElementUsage.TextureCoordinate, 0),
                    new VertexElement(32, VertexElementFormat.Vector2, VertexElementUsage.TextureCoordinate, 1),
                    new VertexElement(40, VertexElementFormat.Color, VertexElementUsage.Color,0)
            );

            VertexDeclaration IVertexType.VertexDeclaration
            {
                get { return VertexDeclaration; }
            }
    }
}
