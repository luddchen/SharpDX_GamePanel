using System;
using System.Collections.Generic;
using System.Threading;

namespace XGame
{

    public class XGamePlatform
    {
        public XGameWindow MainWindow;

        public readonly XGame Game;

        private IXGameDeviceManager deviceManager;
        public IXGameDeviceManager DeviceManager
        {
            get { return this.deviceManager; }
            set
            {
                if ( this.deviceManager != null ) throw new InvalidOperationException( "DeviceManager can be set only once" );
                this.deviceManager = value;
            }
        }

        protected List<XGameWindow> allGameWindows;

        private readonly Thread gameThread;

        internal bool Exiting;

        internal Action InitCallback;
        internal Action RunCallback;
        internal Action ExitCallback;

        public XGamePlatform( XGame game )
        {
            if ( game == null ) throw new ArgumentNullException( "game" );
            this.Game = game;
            this.gameThread = new Thread( this.RenderLoopCallback );
            this.allGameWindows = new List<XGameWindow>();
            this.InitCallback = game.InitializeBeforeRun;
            this.RunCallback = game.Tick;
        }

        public void Present()
        {
            foreach ( XGameWindow window in this.allGameWindows )
            {
                window.Present();
            }
        }

        private bool isMouseVisible;
        internal bool IsMouseVisible
        {
            get { return this.isMouseVisible; }
            set
            {
                this.isMouseVisible = value;
                foreach ( XGameWindow window in this.allGameWindows )
                {
                    window.Cursor.IsMouseVisible = value;
                }
            }
        }

        internal void Update( XGameTime gameTime )
        {
            foreach ( XGameWindow window in this.allGameWindows )
            {
                window.Cursor.Update( gameTime );
            }
        }

        internal void Run()
        {
            if ( this.InitCallback == null ) { return; }
            this.InitCallback();

            if ( this.RunCallback != null ) this.gameThread.Start();
        }

        private void RenderLoopCallback()
        {
            while ( !this.Exiting )
            {
                this.RunCallback();
            }

            if ( this.ExitCallback != null ) this.ExitCallback();
        }

        internal void CreateDevice()
        {
            this.DeviceManager.CreateDevice();
        }

        public string DefaultAppDirectory
        {
            get
            {
                var assemblyUri = new Uri( System.Reflection.Assembly.GetExecutingAssembly().CodeBase );
                return System.IO.Path.GetDirectoryName( assemblyUri.LocalPath );
            }
        }

        public void Sleep( TimeSpan sleepTime )
        {
            Thread.Sleep( sleepTime );
        }

    }

}
