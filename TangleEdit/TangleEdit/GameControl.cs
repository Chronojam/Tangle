#region File Description
    //
    //  [NC]Harlequin: the fuck is User32?
    //    Chronojam: public class User32
    //{
    //    [DllImport("user32.dll")]
    //    public static extern void SetWindowPos(uint Hwnd, uint Level, int X,
    //        int Y, int W, int H, uint Flags);
    //}
    //    [NC]Harlequin: Oh Jesus
    //
#endregion

#region Using Statements
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using TangleEngine.Core;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using TangleEngine.Entities;
using TangleEngine.Entities.Entity_Behaviours.Brush_Behaviours;
using TangleEngine.Entities.Entity_Behaviours;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Input;
#endregion

namespace TangleEdit
{
    class GameControl : GraphicsDeviceControl
    {
        #region Fields

        List<Camera> Cameras = new List<Camera>();
        List<Entity> BigOlEntityList = new List<Entity>();

        Viewport defaultViewport;
        ContentManager Content;

        RasterizerState rsdefaultViewportState;

        // Textures
        Texture2D testTexture;
        Texture2D testTextureII;

        //BEHAVIOURS

        #endregion

        #region Propertys

        public Texture2D DefaultTexture
        {
            get { return testTexture; }
            protected set { testTexture = value; }
        }
        /*public GraphicsDevice Graphicsdevice
        {
            get { return GraphicsDevice; }
        }*/
        public ContentManager ContentManager
        {
            get { return Content; }
        }

        #endregion

        protected override void Initialize()
        {
            Application.Idle += delegate { Invalidate(); };
            this.Click += new EventHandler(OnClicked);
            LoadContent();
            SetupCameras();
            StartEntCreation();
        }
        protected override void Draw()
        {
           Update_Gametime();
            GraphicsDevice.Clear(Color.Black);

            // DO NOT HARDCODE THIS, YOU WILL FAIL AT LIFE;

            GraphicsDevice.Viewport = defaultViewport;
            GraphicsDevice.DepthStencilState = DepthStencilState.Default;

            foreach (Camera camera in Cameras)
            {
                ViewportDraw(camera);
            }
        }

        #region Public Methods

        /// <summary>
        /// Returns selected Entity data from mouse ray
        /// </summary>
        /// 
        public Entity GetSelectedEntityData()
        {
            float? Collision = 0;
            Entity CollidedEnt = new Entity("tempEnt");

            foreach (Entity ent in BigOlEntityList.Where(e => e.behaviours.Any(b => typeof(SimpleCollide).IsAssignableFrom(b.GetType()))))
            {
                Collision = GetMouseRay(Cameras.ToArray()).Intersects(ent.GetProperty<BoundingBox>("BoundingBox").Value);

                if (Collision.HasValue && Collision != 0.0)
                    return ent;
            }
            return null;
        }
        /// <summary>
        /// sends Position Data data from form for the soon-to-be ent
        /// </summary>
        public Vector3 GetNewEntFinalPosition()
        {
            return GetMouseRay(Cameras.ToArray()).Direction;
        }
        public void AddEntToList(Entity entity)
        {
            BigOlEntityList.Add(entity);
        }
        #endregion


        #region Helper Methods
        // Helper method for GetselectedEntityData() -> Returns mouseray from current camera
        private Ray GetMouseRay(params Camera[] Cameras)
        {
            System.Drawing.Point mousePoint = System.Windows.Forms.Cursor.Position;
            mousePoint = this.PointToClient(mousePoint);
            Vector2 MouseCoords = new Vector2(mousePoint.X, mousePoint.Y);

            foreach (Camera camera in Cameras)
            {
                if (camera.Viewport.Bounds.Contains(mousePoint.X, mousePoint.Y))
                {
                    Vector3 vec0 = camera.Viewport.Unproject(
                    new Vector3(MouseCoords, 0),
                    camera.ProjectionMatrix, camera.ViewMatrix, Matrix.Identity);

                    Vector3 vec1 = camera.Viewport.Unproject(
                    new Vector3(MouseCoords, 1),
                    camera.ProjectionMatrix, camera.ViewMatrix, Matrix.Identity);

                    Vector3 mouseDirection = vec1 - vec0;
                    mouseDirection.Normalize();

                    return new Ray(vec0, mouseDirection);
                }
            }
            return new Ray();
        }
        // Helper method for init() -> loads all defaultViewport Assets (Textures, models etc)
        private void LoadContent()
        {
            rsdefaultViewportState = new RasterizerState();
            Content = new ContentManager(this.Services, "D://Users//Calum//documents//visual studio 2010//Projects//Tangle//TangleEdit//TangleEdit//bin//x86//Debug//Content");
            
            testTexture = Content.Load<Texture2D>("crate");
            testTextureII = Content.Load<Texture2D>("Bricks");

            rsdefaultViewportState.CullMode = CullMode.CullCounterClockwiseFace;
            rsdefaultViewportState.FillMode = FillMode.Solid;
        }
        // Helper method for init()  -> Creates defaultViewport entitys (XYZ plane etc)
        private void StartEntCreation()
        {
            Entity ThreeDReference = new Entity("XYZ Planes");
            ThreeDReference.AddProperty<GraphicsDevice>("GraphicsDevice", GraphicsDevice);
            ThreeDReference.AddProperty<Vector3>("Position", new Vector3(0, 0, 0));
            ThreeDReference.AddProperty<Vector3>("Scale", new Vector3(1));
            ThreeDReference.AddProperty<Vector3>("Rotation", new Vector3(0, 0, 0));
            ThreeDReference.AddProperty<Plane>("PlaneZX", new Plane(Vector3.Up,0f));
            ThreeDReference.AddProperty<Plane>("PlaneYX", new Plane(Vector3.Transform(Vector3.Backward,Matrix.CreateRotationZ(MathHelper.PiOver2)),0f));
            ThreeDReference.AddProperty<Plane>("PlaneYZ", new Plane(Vector3.Transform(Vector3.Right, Matrix.CreateRotationX(MathHelper.PiOver2)), 0f));

            ThreeDReference.AddBehaviour(new RefPlane(50, Matrix.Identity, Color.DarkGreen));
            ThreeDReference.AddBehaviour(new RefPlane(50, Matrix.CreateRotationZ(MathHelper.PiOver2), Color.DarkRed));
            ThreeDReference.AddBehaviour(new RefPlane(50, Matrix.CreateRotationX(MathHelper.PiOver2), Color.OliveDrab));

            BigOlEntityList.Add(ThreeDReference);

            Entity TestEnt = new Entity("VertexCrate");
            
            TestEnt.AddProperty<Vector3>("Position", new Vector3(0, 0, 0));
            TestEnt.AddProperty<Vector3>("Scale", new Vector3(2, 2, 2));
            TestEnt.AddProperty<Vector3>("Rotation", new Vector3(0, 0, 0));
            TestEnt.AddProperty<BoundingBox>("BoundingBox", new BoundingBox());
            TestEnt.AddProperty<Texture2D>("FrontTex", testTextureII);
            TestEnt.AddProperty<Texture2D>("BackTex", testTextureII);
            TestEnt.AddProperty<Texture2D>("RightTex", testTextureII);
            TestEnt.AddProperty<Texture2D>("LeftTex", testTextureII);
            TestEnt.AddProperty<Texture2D>("TopTex", testTexture);
            TestEnt.AddProperty<Texture2D>("BottomTex", testTexture);
            TestEnt.AddProperty<GraphicsDevice>("GraphicsDevice", GraphicsDevice);
            TestEnt.AddProperty<ContentManager>("Content", Content);
            TestEnt.AddBehaviour(new Brush_Cube());
            TestEnt.AddBehaviour(new SimpleCollide());
            BigOlEntityList.Add(TestEnt);

            Entity TestEntII = new Entity("VertexCrateII");

            TestEntII.AddProperty<Vector3>("Position", new Vector3(0, 2, 0));
            TestEntII.AddProperty<Vector3>("Scale", new Vector3(2, 2, 2));
            TestEntII.AddProperty<Vector3>("Rotation", new Vector3(0, 0, 0));
            TestEntII.AddProperty<BoundingBox>("BoundingBox", new BoundingBox());
            TestEntII.AddProperty<Texture2D>("FrontTex", testTextureII);
            TestEntII.AddProperty<Texture2D>("BackTex", testTextureII);
            TestEntII.AddProperty<Texture2D>("RightTex", testTextureII);
            TestEntII.AddProperty<Texture2D>("LeftTex", testTextureII);
            TestEntII.AddProperty<Texture2D>("TopTex", testTexture);
            TestEntII.AddProperty<Texture2D>("BottomTex", testTexture);
            TestEntII.AddProperty<GraphicsDevice>("GraphicsDevice", GraphicsDevice);
            TestEntII.AddProperty<ContentManager>("Content", Content);
            TestEntII.AddBehaviour(new Brush_Cube());
            TestEntII.AddBehaviour(new SimpleCollide());
            BigOlEntityList.Add(TestEntII);

            Entity TestEntIII = new Entity("VertexCrateIII");

            TestEntIII.AddProperty<Vector3>("Position", new Vector3(0, 0, 5));
            TestEntIII.AddProperty<Vector3>("Scale", new Vector3(2, 2, 2));
            TestEntIII.AddProperty<Vector3>("Rotation", new Vector3(0, 0, 0));
            TestEntIII.AddProperty<BoundingBox>("BoundingBox", new BoundingBox());
            TestEntIII.AddProperty<Texture2D>("FrontTex", testTextureII);
            TestEntIII.AddProperty<Texture2D>("BackTex", testTextureII);
            TestEntIII.AddProperty<Texture2D>("RightTex", testTextureII);
            TestEntIII.AddProperty<Texture2D>("LeftTex", testTextureII);
            TestEntIII.AddProperty<Texture2D>("TopTex", testTexture);
            TestEntIII.AddProperty<Texture2D>("BottomTex", testTexture);
            TestEntIII.AddProperty<GraphicsDevice>("GraphicsDevice", GraphicsDevice);
            TestEntIII.AddProperty<ContentManager>("Content", Content);
            TestEntIII.AddBehaviour(new Brush_Cube());
            TestEntIII.AddBehaviour(new SimpleCollide());
            BigOlEntityList.Add(TestEntIII);
            
        }
        // Helper method for init() -> Creates cameras and viewports, adds to list.
        private void SetupCameras()
        {
            defaultViewport = GraphicsDevice.Viewport;

            defaultViewport.Width = 800;
            defaultViewport.Height = 600;

            Viewport viewPortPerspective = new Viewport(defaultViewport.Width / 2, defaultViewport.Height / 2, defaultViewport.Width / 2, defaultViewport.Height / 2);
            Viewport viewPortTop = new Viewport(defaultViewport.Width / 2, 0, defaultViewport.Width / 2, defaultViewport.Height / 2);
            Viewport viewPortFront = new Viewport(0, 0, defaultViewport.Width / 2, defaultViewport.Height / 2);
            Viewport viewPortSide = new Viewport(0, defaultViewport.Height / 2, defaultViewport.Width / 2, defaultViewport.Height / 2);

            Camera camera = new Camera();
            Camera cameraTop = new Camera();
            Camera cameraSide = new Camera();
            Camera cameraFront = new Camera();

            camera.Viewport = viewPortPerspective;
            cameraTop.Viewport = viewPortTop;
            cameraFront.Viewport = viewPortFront;
            cameraSide.Viewport = viewPortSide;

            camera.ProjectionMatrix = Matrix.CreatePerspectiveFieldOfView(MathHelper.PiOver4, viewPortPerspective.AspectRatio, 1.0f, 1000f);
            cameraTop.ProjectionMatrix = Matrix.CreatePerspectiveFieldOfView(MathHelper.PiOver4, viewPortSide.AspectRatio, 1.0f, 1000f);
            cameraSide.ProjectionMatrix = Matrix.CreatePerspectiveFieldOfView(MathHelper.PiOver4, viewPortTop.AspectRatio, 1.0f, 1000f);
            cameraFront.ProjectionMatrix = Matrix.CreatePerspectiveFieldOfView(MathHelper.PiOver4, viewPortFront.AspectRatio, 1.0f, 1000f);

            camera.Position = new Vector3(10, 10, 10);
            cameraTop.Position = new Vector3(0, 15, 0);
            cameraSide.Position = new Vector3(15, 0, 0);
            cameraFront.Position = new Vector3(0, 0, 15);

            cameraTop.LookAt = Vector3.Zero;
            cameraSide.LookAt = Vector3.Zero;
            cameraFront.LookAt = Vector3.Zero;
            camera.LookAt = Vector3.Zero;

            cameraTop.UpVector = new Vector3(1, 0, 0);
            camera.UpVector = new Vector3(0, 1, 0);
            cameraFront.UpVector = new Vector3(0, 1, 0);
            cameraSide.UpVector = new Vector3(0, 1, 0);

            Cameras.Add(camera);
            Cameras.Add(cameraTop);
            Cameras.Add(cameraSide);
            Cameras.Add(cameraFront);
        }
        // Helper method for Draw() -> Draws all ents inside each camera view
        private void ViewportDraw(Camera camera)
        {
            GraphicsDevice.Viewport = camera.Viewport;

            foreach (Entity ent in BigOlEntityList)
            {
                ent.Draw(GraphicsDevice, Matrix.Identity, camera.ViewMatrix, camera.ProjectionMatrix);
            }
        }
        // Helper method for Draw() -> Pre-Draw updating goes here
        private void Update_Gametime()
        {
            foreach (Camera camera in Cameras)
            {
                camera.Update();
            }

            foreach (Entity ent in BigOlEntityList)
            {
                ent.Update();
            }
        }
        // Event Handler 
        float? planeCollision;
        private void OnClicked(object sender, EventArgs e)
        {
            planeCollision = 
                GetMouseRay(Cameras.ToArray()).Intersects(BigOlEntityList[0].GetProperty<Plane>("PlaneZX").Value);
            if (planeCollision.HasValue)
                MessageBox.Show("I HIT XZPLANE AT: " + planeCollision.ToString());
            else
            {
                planeCollision =
                    GetMouseRay(Cameras.ToArray()).Intersects(BigOlEntityList[0].GetProperty<Plane>("PlaneYX").Value);
                if (planeCollision.HasValue)
                    MessageBox.Show("I HIT YX PLANE AT: " + planeCollision.ToString());
                else
                {
                    planeCollision =
                        GetMouseRay(Cameras.ToArray()).Intersects(BigOlEntityList[0].GetProperty<Plane>("PlaneYZ").Value);
                    if (planeCollision.HasValue)
                        MessageBox.Show("I HIT YZ PLANE AT: " + planeCollision.ToString());

                }
            }
        }


        #endregion

    }
}
