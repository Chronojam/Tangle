using System;
using System.Collections.Generic;
using System.Linq;
using TangleEngine.Core;
using TangleEngine.Entities;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using TangleEngine.Entities.Entity_Behaviours.Brush_Behaviours;
using TangleEngine.Entities.Entity_Behaviours;

namespace TangleEdit
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        SpriteFont font;
        Viewport Default;
        Viewport Perspective;
        Viewport Top;
        Viewport Side;
        Viewport Front;

        Camera camera;
        Camera cameraTop;
        Camera cameraSide;
        Camera cameraFront;
        
        private IntPtr drawSurface;

        //Box
        RasterizerState rsDefaultState;

        //HappyFunEnts

        List<Entity> BigOlEntityList = new List<Entity>();

        // Entity TestEnt;
        Texture2D testTexture;
        Texture2D testTextureII;
        Brush_Cube CrateTest;
        IsCollidable Collide;

        //3dReference
        Main mainForm = new Main();
        
        public Game1()
        {
            mainForm.Show();
            mainForm.FormClosed += (a, b) => this.Exit();

            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            this.drawSurface = mainForm.getDrawSurface();
            graphics.PreparingDeviceSettings += new EventHandler<PreparingDeviceSettingsEventArgs>(graphics_PreparingDeviceSettings);
            System.Windows.Forms.Control.FromHandle((this.Window.Handle)).VisibleChanged += new EventHandler(Game1_VisibleChanged);
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            SetupCameras();

            graphics.PreferredBackBufferHeight = 600;
            graphics.PreferredBackBufferWidth = 800;
            graphics.PreferMultiSampling = true;
            graphics.ApplyChanges();
            
            CrateTest = new Brush_Cube();
            Collide = new IsCollidable();
            rsDefaultState = new RasterizerState();

            this.IsMouseVisible = true;
            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            font = Content.Load<SpriteFont>("Instruction");

            testTexture = Content.Load<Texture2D>("crate");
            testTextureII = Content.Load<Texture2D>("Bricks");

            Entity TestEnt = new Entity("VertexCrate");
            TestEnt.AddProperty<Vector3>("Position", new Vector3(0, 0, 0));
            TestEnt.AddProperty<Vector3>("Scale", new Vector3(2, 2, 2));
            TestEnt.AddProperty<Vector3>("Rotation", new Vector3(0,0,0));
            TestEnt.AddProperty<Texture2D>("Texture", testTexture);
            TestEnt.AddProperty<Texture2D>("BrickTexture", testTextureII);
            TestEnt.AddProperty<GraphicsDevice>("GraphicsDevice", GraphicsDevice);
            TestEnt.AddProperty<ContentManager>("Content", Content);
            TestEnt.AddBehaviour(CrateTest);
            TestEnt.AddBehaviour(Collide);
            BigOlEntityList.Add(TestEnt);

            Entity ThreeDReference = new Entity("XZ Plane");
            ThreeDReference.AddProperty<GraphicsDevice>("GraphicsDevice", GraphicsDevice);
            ThreeDReference.AddProperty<Vector3>("Position", new Vector3(0, 0, 0));
            ThreeDReference.AddProperty<Vector3>("Scale", new Vector3(1));
            ThreeDReference.AddProperty<Vector3>("Rotation", new Vector3(0, 0, 0));
            ThreeDReference.AddBehaviour(new RefPlane(50, Matrix.Identity, Color.DarkGreen));
            ThreeDReference.AddBehaviour(new RefPlane(50, Matrix.CreateRotationZ(MathHelper.PiOver2), Color.DarkRed));
            ThreeDReference.AddBehaviour(new RefPlane(50, Matrix.CreateRotationX(MathHelper.PiOver2), Color.OliveDrab));

            BigOlEntityList.Add(ThreeDReference);

            rsDefaultState.CullMode = CullMode.CullCounterClockwiseFace;
            rsDefaultState.FillMode = FillMode.Solid;

        }

        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }
        MouseState oldstate;
        protected override void Update(GameTime gameTime)
        {
            MouseState ms = Mouse.GetState();

            camera.Update();
            cameraTop.Update();
            cameraSide.Update();
            cameraFront.Update();

            foreach (Entity ent in BigOlEntityList)
            {
                ent.Update();
            }

            if (ms.LeftButton == ButtonState.Pressed && oldstate.LeftButton != ButtonState.Pressed)
            {
                float? Collision;
                GetMouseRay(camera,cameraTop,cameraSide,cameraFront, Perspective,Top,Side,Front).Intersects(ref Collide.bb, out Collision);

                if (Collision.HasValue && Collision != 0.0)
                {
                    mainForm.PropertiesForm.GetEntityData(Collide.Parent);
                }
                else
                {
                    //mainForm.PropertiesForm.ClearProperties();
                }
            }

            User32.SetWindowPos((uint)this.Window.Handle, 0, mainForm.Location.X, mainForm.Location.Y + 29, graphics.PreferredBackBufferWidth, graphics.PreferredBackBufferHeight, 0);
            oldstate = ms;
            base.Update(gameTime);
        }
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            // DO NOT HARDCODE THIS, YOU WILL FAIL AT LIFE;
            
            GraphicsDevice.Viewport = Default;
            GraphicsDevice.DepthStencilState = DepthStencilState.Default;

            ViewportDraw(Perspective, camera);
            ViewportDraw(Top, cameraTop);
            ViewportDraw(Side, cameraSide);
            ViewportDraw(Front, cameraFront);

            base.Draw(gameTime);
        }
        private void ViewportDraw(Viewport viewport, Camera camera)
        {
            GraphicsDevice.Viewport = viewport;
            foreach (Entity ent in BigOlEntityList)
            {
                ent.Draw(GraphicsDevice, Matrix.Identity,camera.ViewMatrix,camera.ProjectionMatrix);
            }
        }
        private Ray GetMouseRay(Camera Perspective_Camera, Camera Top_Camera, Camera Side_Camera, Camera Front_Camera, params Viewport[] Viewport)
        {
            Vector2 MouseCoords = new Vector2(Mouse.GetState().X, Mouse.GetState().Y);
            Camera CurrentCamera = new Camera();

            for (int i = 0; i < 4; i++)
            {
                if (Viewport[i].Bounds.Intersects(new Rectangle((int)MouseCoords.X, (int)MouseCoords.Y,1,1)))
                {
                    if (i == 0) {CurrentCamera = Perspective_Camera;}
                    if (i == 1) {CurrentCamera = Top_Camera;}
                    if (i == 2) {CurrentCamera = Side_Camera;}
                    if (i == 3) {CurrentCamera = Front_Camera;}

                    Vector3 vec0 = Viewport[i].Unproject(
                    new Vector3(MouseCoords, 0),
                    CurrentCamera.ProjectionMatrix, CurrentCamera.ViewMatrix, Matrix.Identity);

                    Vector3 vec1 = Viewport[i].Unproject(
                    new Vector3(MouseCoords, 1),
                    CurrentCamera.ProjectionMatrix, CurrentCamera.ViewMatrix, Matrix.Identity);

                    Vector3 mouseDirection = vec1 - vec0;
                    mouseDirection.Normalize();

                    return new Ray(vec0, mouseDirection);
                }
            }

            return new Ray();
            
        }

        void graphics_PreparingDeviceSettings(object sender, PreparingDeviceSettingsEventArgs e)
        {
            e.GraphicsDeviceInformation.PresentationParameters.DeviceWindowHandle = drawSurface;
        }
        private void Game1_VisibleChanged(object sender, EventArgs e)
        {
            if (System.Windows.Forms.Control.FromHandle((this.Window.Handle)).Visible == true)
                System.Windows.Forms.Control.FromHandle((this.Window.Handle)).Visible = false;
        }

        private void SetupCameras()
        {
            Default = GraphicsDevice.Viewport;

            Default.Width = 800;
            Default.Height = 600;

            Perspective = new Viewport(Default.Width / 2, Default.Height /2, Default.Width /2, Default.Height /2);
            Top = new Viewport(Default.Width / 2, 0, Default.Width / 2, Default.Height / 2);
            Front = new Viewport(0, 0, Default.Width / 2, Default.Height / 2);
            Side = new Viewport(0, Default.Height / 2, Default.Width / 2, Default.Height / 2);

            camera = new Camera();
            cameraTop = new Camera();
            cameraSide = new Camera();
            cameraFront = new Camera();

            camera.ProjectionMatrix = Matrix.CreatePerspectiveFieldOfView(MathHelper.PiOver4, Perspective.AspectRatio, 1.0f, 1000f);
            cameraTop.ProjectionMatrix = Matrix.CreatePerspectiveFieldOfView(MathHelper.PiOver4, Side.AspectRatio, 1.0f, 1000f);
            cameraSide.ProjectionMatrix = Matrix.CreatePerspectiveFieldOfView(MathHelper.PiOver4, Top.AspectRatio, 1.0f, 1000f);
            cameraFront.ProjectionMatrix = Matrix.CreatePerspectiveFieldOfView(MathHelper.PiOver4, Front.AspectRatio, 1.0f, 1000f);

            camera.Position = new Vector3(6, 6, 6);
            cameraTop.Position = new Vector3(0, 10, 0);
            cameraSide.Position = new Vector3(10, 0, 0);
            cameraFront.Position = new Vector3(0, 0, 10);

            cameraTop.LookAt = Vector3.Zero;
            cameraSide.LookAt = Vector3.Zero;
            cameraFront.LookAt = Vector3.Zero;
            camera.LookAt = Vector3.Zero;

            cameraTop.UpVector = new Vector3(1, 0, 0);
            camera.UpVector = new Vector3(0, 1, 0);
            cameraFront.UpVector = new Vector3(0, 1, 0);
            cameraSide.UpVector = new Vector3(0, 1, 0);

            
        }


    }
}
