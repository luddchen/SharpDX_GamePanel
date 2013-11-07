using SharpDX.Toolkit;
using System;
using System.Threading;
using System.Windows.Forms;

namespace GamePanel
{

    public class PanelGamePlatform
    {
        public readonly PanelGame Game;

        protected PanelGameWindow mainWindow;

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


        private readonly Thread gameThread;

        internal bool Exiting;

        internal Action InitCallback;
        internal Action RunCallback;
        internal Action ExitCallback;

        public PanelGamePlatform( PanelGame game )
        {
            this.Game = game;
            this.mainWindow = CreateWindow( game.Control );

            this.gameThread = new Thread( RenderLoopCallback );
            this.InitCallback = game.InitializeBeforeRun;
            this.RunCallback = game.Tick;
        }

        public PanelGameWindow CreateWindow( Control control )
        {
            return new PanelGameWindow( control );
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

    }

}
