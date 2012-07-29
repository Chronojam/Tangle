using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TangleEngine.Core.Graphics;
using TangleEngine.Entities.Entity_Properties;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using TangleEngine.Core;
using Microsoft.Xna.Framework.Content;

namespace TangleEngine.Entities.Entity_Behaviours.Brush_Behaviours
{
    public abstract class GeometricPrimitive<VertexType>: Behaviour, IDrawableBehaviour 
        where VertexType : struct, IVertexType
    {
        List<VertexType> vertices = new List<VertexType>();
        List<ushort> indices = new List<ushort>();

        VertexBuffer vertexBuffer;
        IndexBuffer indexBuffer;

        Property<GraphicsDevice> device;
        Property<Effect> effect;
        Property<Camera> camera;

        Property<Vector3> Scale;
        Property<Vector3> Position;
        Property<Vector3> Rotation;
        Property<ContentManager> Content;

        protected Property<PrimitiveType> PrimType { get; private set; }

        protected override void Init()
        {
            effect = Parent.AddProperty<Effect>("Effect");
            PrimType = Parent.AddProperty<PrimitiveType>("PrimitiveType");
            device = Parent.GetProperty<GraphicsDevice>("GraphicsDevice");
            camera = Parent.GetProperty<Camera>("Camera");
            Position = Parent.GetProperty<Vector3>("Position");
            Scale = Parent.GetProperty<Vector3>("Scale");
            Rotation = Parent.GetProperty<Vector3>("Rotation");
            Content = Parent.GetProperty<ContentManager>("Content");

            effect.Value = CreateEffect(device.Value);
            PrimType.Value = GetPrimType();
            CreateGeometry(vertices, indices);
            InitializePrim();
        }

        protected abstract Effect CreateEffect(GraphicsDevice device);
        protected abstract void CreateGeometry(List<VertexType> vertices, List<ushort> indices);
        protected abstract PrimitiveType GetPrimType();

        private void InitializePrim()
        {
            vertexBuffer = new VertexBuffer(device.Value, typeof(VertexType), vertices.Count, BufferUsage.None);
            vertexBuffer.SetData<VertexType>(vertices.ToArray());

            indexBuffer = new IndexBuffer(device.Value, IndexElementSize.SixteenBits, indices.Count, BufferUsage.None);
            indexBuffer.SetData(indices.ToArray());
        }

        protected virtual void SetEffectParameters(Effect effect,Matrix World, Matrix View, Matrix Proj)
        {
            var WVP = effect.Parameters["WorldViewProj"];

            WVP.SetValue(
                Matrix.CreateTranslation(Position.Value) * 
                Matrix.CreateScale(Scale.Value.X, Scale.Value.Y, Scale.Value.Z) * 
                Matrix.CreateRotationX(MathHelper.ToRadians(Rotation.Value.X)) * 
                Matrix.CreateRotationY(MathHelper.ToRadians(Rotation.Value.Y)) * 
                Matrix.CreateRotationZ(MathHelper.ToRadians(Rotation.Value.Z))*
                World*
                View*
                Proj);
        }

        protected int CurrentVertex
        {
            get { return vertices.Count; }
        }

        public override void Update()
        {


        }

        public virtual void Draw(GraphicsDevice device, Matrix World, Matrix View, Matrix Projection)
        {
            device.SetVertexBuffer(vertexBuffer);
            device.Indices = indexBuffer;

            SetEffectParameters(effect.Value, View,Projection,World);

            int PrimCount;

            switch (PrimType.Value)
            {
                case PrimitiveType.LineList:
                    PrimCount = indices.Count / 2;
                    break;
                case PrimitiveType.LineStrip:
                    PrimCount = indices.Count - 1;
                    break;
                case PrimitiveType.TriangleList:
                    PrimCount = indices.Count / 3;
                    break;
                case PrimitiveType.TriangleStrip:
                    PrimCount = indices.Count - 2;
                    break;
                default:
                    throw new InvalidOperationException("SOMETHING HAS GONE WRONG");
            }

            foreach (EffectPass pass in effect.Value.CurrentTechnique.Passes)
            {
                pass.Apply();
                device.DrawIndexedPrimitives(PrimType.Value, 0, 0, vertices.Count, 0, PrimCount);
            }
        }
    }
}
