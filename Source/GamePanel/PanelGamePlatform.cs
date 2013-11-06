using System;
using System.Threading;

namespace GamePanel
{

    public class PanelGamePlatform
    {

        protected PanelGameWindow gameWindow;


        private readonly Thread gameThread;

        internal bool Exiting;

        internal Action InitCallback;
        internal Action RunCallback;
        internal Action ExitCallback;

        public PanelGamePlatform( PanelGame game )
        {
            this.gameThread = new Thread( RenderLoopCallback );
            this.InitCallback = game.InitializeBeforeRun;
            this.RunCallback = game.Tick;
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
