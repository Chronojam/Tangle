using System;
using System.Collections.Generic;
using System.Collections;
// using System.Linq;
using System.Text;
using TangleEngine.Entities.Entity_Properties;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using TangleEngine.Core;
using TangleEngine.Core.Graphics;


namespace TangleEngine.Entities.Entity_Behaviours
{
    public class RenderModel : Behaviour
    {
        #region TopOfClassDec

        Property<Vector3> Position;
        Property<Texture2D> texture;
        Property<Model> cubeModel;

        Matrix[] transforms;

        #endregion

        protected override void Init()
        {
            Position = Parent.GetProperty<Vector3>("Position");
            texture = Parent.GetProperty<Texture2D>("Texture");
            cubeModel = Parent.GetProperty<Model>("Model");
        }

        public override void Update()
        {

        }

        public void Draw(BasicEffect Beffect, GraphicsDevice device, Camera camera)
        {

            device.RasterizerState = RasterizerState.CullNone;

            transforms = new Matrix[cubeModel.Value.Bones.Count];
            cubeModel.Value.CopyAbsoluteBoneTransformsTo(transforms);

            foreach (ModelMesh mesh in cubeModel.Value.Meshes)
            {
                foreach (BasicEffect effect in mesh.Effects)
                {
                    effect.View = camera.ViewMatrix;
                    effect.Projection = camera.ProjectionMatrix;
                    effect.World = Matrix.Identity;
                }
                mesh.Draw();
            }        
        }
    }
}
