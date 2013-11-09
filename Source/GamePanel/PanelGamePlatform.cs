using GamePanel.ServiceProvider;
using SharpDX.Toolkit;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Windows.Forms;

namespace GamePanel
{

    public class PanelGamePlatform : IGraphicsDeviceFactory
    {
        public readonly PanelGame Game;

        private PanelGameWindow mainWindow;

        public PanelDeviceManager GraphicsDeviceManager { get; set; }

        public PanelGameWindow MainWindow
        {
            get { return this.mainWindow; }
            set
            {
                if ( value != null )
                {
                    this.mainWindow = value;
                }
            }
        }

        private List<PanelGameWindow> allGameWindows;

        private readonly Thread gameThread;

        internal bool Exiting;

        internal Action InitCallback;
        internal Action RunCallback;
        internal Action ExitCallback;

        public PanelGamePlatform( PanelGame game, Control control )
        {
            this.Game = game;
            this.allGameWindows = new List<PanelGameWindow>();
            this.mainWindow = CreateWindow( control );
            this.allGameWindows.Add( this.mainWindow );

            this.gameThread = new Thread( RenderLoopCallback );
            this.InitCallback = game.InitializeBeforeRun;
            this.RunCallback = game.Tick;
        }

        public PanelGameWindow CreateWindow( Control control )
        {
            return new PanelGameWindow( control, this );
        }

        public void EndAllDraw()
        {
            foreach ( PanelGameWindow panel in this.allGameWindows )
            {
                panel.EndDraw();
            }
        }

        internal void Run()
        {
            InitCallback();
            this.gameThread.Start();
        }

        private void RenderLoopCallback()
        {
            while ( !this.Exiting )
            {
                this.RunCallback();
            }

            if ( this.ExitCallback != null ) this.ExitCallback();
        }

        public string DefaultAppDirectory
        {
            get
            {
                var assemblyUri = new Uri( System.Reflection.Assembly.GetExecutingAssembly().CodeBase );
                return System.IO.Path.GetDirectoryName( assemblyUri.LocalPath );
            }
        }


        #region IGraphicsDeviceFactory Member

        public SharpDX.Toolkit.Graphics.GraphicsDevice CreateDevice( GraphicsDeviceInformation deviceInformation )
        {
            this.GraphicsDeviceManager = new PanelDeviceManager( this.Game );
            this.GraphicsDeviceManager.CreateDevice();
            return this.GraphicsDeviceManager.GraphicsDevice;
        }

        public List<GraphicsDeviceInformation> FindBestDevices( GameGraphicsParameters graphicsParameters )
        {
            throw new NotImplementedException();
        }

        #endregion
    }

}
