﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using System.Threading;

#pragma warning disable 67

namespace TangleEdit
{
    class GraphicsDeviceService : IGraphicsDeviceService
    {

        static GraphicsDeviceService singletonInstance;
        static int referenceCount;

        GraphicsDeviceService(IntPtr windowHandle, int width, int height)
        {
            parameters = new PresentationParameters();

            parameters.BackBufferWidth = Math.Max(width, 1);
            parameters.BackBufferHeight = Math.Max(height, 1);
            parameters.BackBufferFormat = SurfaceFormat.Color;
            parameters.DepthStencilFormat = DepthFormat.Depth24;
            parameters.DeviceWindowHandle = windowHandle;
            parameters.PresentationInterval = PresentInterval.Immediate;
            parameters.IsFullScreen = false;

            graphicsDevice = new GraphicsDevice(GraphicsAdapter.DefaultAdapter, GraphicsProfile.Reach, parameters);
        }

        public static GraphicsDeviceService AddRef(IntPtr windowHandle, int width, int height)
        {
            if (Interlocked.Increment(ref referenceCount) == 1)
            {
                singletonInstance = new GraphicsDeviceService(windowHandle, width, height);
            }
            return singletonInstance;
        }

        public void Release(bool disposing)
        {
            if (Interlocked.Decrement(ref referenceCount) == 0)
            {
                if (disposing)
                {
                    if (DeviceDisposing != null)
                    {
                        DeviceDisposing(this, EventArgs.Empty);

                        graphicsDevice.Dispose();
                    }
                }
                graphicsDevice = null;
            }
        }

        public void ResetDevice(int width, int height)
        {
            if (DeviceResetting != null)
                DeviceResetting(this, EventArgs.Empty);

            parameters.BackBufferWidth = Math.Max(parameters.BackBufferWidth, width);
            parameters.BackBufferHeight = Math.Max(parameters.BackBufferHeight, height);

            graphicsDevice.Reset(parameters);

            if (DeviceReset != null)
                DeviceReset(this, EventArgs.Empty);
        }

        public GraphicsDevice GraphicsDevice
        {
            get { return graphicsDevice; }
        }

        GraphicsDevice graphicsDevice;
        PresentationParameters parameters;

        public event EventHandler<EventArgs> DeviceCreated;
        public event EventHandler<EventArgs> DeviceDisposing;
        public event EventHandler<EventArgs> DeviceReset;
        public event EventHandler<EventArgs> DeviceResetting;
    }
}
