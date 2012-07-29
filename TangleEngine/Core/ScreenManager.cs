using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using System.Diagnostics;
using Microsoft.Xna.Framework.Input.Touch;

namespace TangleEngine.Core
{
    public class ScreenManager : DrawableGameComponent
    {
        #region Fields

        List<GameScreen> screens = new List<GameScreen>();
        List<GameScreen> tempScreenList = new List<GameScreen>();

        InputState input = new InputState();

        bool isInitialized;
        bool traceEnabled;

        SpriteBatch spriteBatch;
        Texture2D blankTexture;
        
        #endregion

        #region Properties

        public bool TraceEnabled
        {
            get { return traceEnabled; }
            set { traceEnabled = value; }
        }

        #endregion

        #region Initilization
        public ScreenManager(Game game)
            : base(game)
        {
            //TouchPanel
            TouchPanel.EnabledGestures = GestureType.None;
        }

        public override void Initialize()
        {
            base.Initialize();

            isInitialized = true;
        }

        protected override void LoadContent()
        {
            ContentManager content = Game.Content;

            spriteBatch = new SpriteBatch(GraphicsDevice);
            blankTexture = new Texture2D(GraphicsDevice, 16, 16);

            foreach (GameScreen screen in screens)
            {
                screen.Activate(false);
            }
        }

        protected override void UnloadContent()
        {
            foreach (GameScreen screen in screens)
            {
                screen.Unload();
            }
        }
        #endregion

        #region Update and Draw

        public override void Update(GameTime gameTime)
        {
            input.Update();

            tempScreenList.Clear();

            foreach (GameScreen screen in screens)
                tempScreenList.Add(screen);

            bool otherScreenHasFocus = !Game.IsActive;
            bool coveredByOtherScreen = false;

            while (tempScreenList.Count > 0)
            {
                GameScreen screen = tempScreenList[tempScreenList.Count - 1];

                tempScreenList.RemoveAt(tempScreenList.Count - 1);

                screen.Update(gameTime,otherScreenHasFocus,coveredByOtherScreen);

                if (screen.ScreenState == ScreenState.TransitionOn ||
                    screen.ScreenState == ScreenState.Active)
                {
                    if (!otherScreenHasFocus)
                    {
                        screen.HandleInput(gameTime, input);
                        otherScreenHasFocus = true;
                    }

                    if (!screen.IsPopup)
                        coveredByOtherScreen = true;
                }
            }

            if(traceEnabled)
                TraceScreens();
        }
        void TraceScreens()
        {
            List<string> screenNames = new List<string>();

            foreach (GameScreen screen in screens)
                screenNames.Add(screen.GetType().Name);

            Debug.WriteLine(string.Join(", ", screenNames.ToArray()));
        }

        public override void Draw(GameTime gameTime)
        {
            foreach (GameScreen screen in screens)
            {
                if (screen.ScreenState == ScreenState.Hidden)
                    continue;

                screen.Draw(gameTime);
            }
        }

        #endregion

        #region Public Methods

        public void AddScreen(GameScreen screen, PlayerIndex? controllingPlayer)
        {
            screen.ControllingPlayer = controllingPlayer;
            screen.ScreenManager = this;
            screen.IsExiting = false;

            if (isInitialized)
            {
                screen.Activate(false);
            }
            screens.Add(screen);

            TouchPanel.EnabledGestures = screen.EnabledGestures;
        }
        public void RemoveScreen(GameScreen screen)
        {
            if (isInitialized)
            {
                screen.Unload();
            }

            screens.Remove(screen);
            tempScreenList.Remove(screen);

            if (screens.Count > 0)
            {
                TouchPanel.EnabledGestures = screens[screens.Count - 1].EnabledGestures;
            }
        }
        public GameScreen[] GetScreens()
        {
            return screens.ToArray();
        }
        public void FadeBackToBufferToColor(Color color, float alpha)
        {
            spriteBatch.Begin();
            spriteBatch.Draw(blankTexture, GraphicsDevice.Viewport.Bounds, color * alpha);
            spriteBatch.End();

        }

        #endregion

    }
}
