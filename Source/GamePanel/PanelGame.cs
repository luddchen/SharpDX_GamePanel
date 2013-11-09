using SharpDX;
using System;

namespace GamePanel
{

    public partial class PanelGame : IDisposable
    {

        private readonly PanelGamePlatform gamePlatform;


        public PanelGame( System.Windows.Forms.Control control )
        {
            this.gamePlatform = new PanelGamePlatform( this, control );
            this.gamePlatform.ExitCallback = this.UnloadContent;    // ...

            InitServices();

            #region GameLoop stuff
            this.lastUpdateCount = new int[ 4 ];
            this.timer = new TimerTick();
            this.gameTime = new PanelGameTime();

            // Calculate the updateCountAverageSlowLimit (assuming moving average is >=3 )
            // Example for a moving average of 4: updateCountAverageSlowLimit = (2 * 2 + (4 - 2)) / 4 = 1.5f
            const int BadUpdateCountTime = 2; // number of bad frame (a bad frame is a frame that has at least 2 updates)
            var maxLastCount = 2 * Math.Min( BadUpdateCountTime, this.lastUpdateCount.Length );
            this.updateCountAverageSlowLimit = (float)( maxLastCount + ( this.lastUpdateCount.Length - maxLastCount ) ) / this.lastUpdateCount.Length;

            InitGameLoop();
            #endregion
        }

        public bool IsMouseVisible
        {
            get { return this.Window.WindowCursor.IsMouseVisible; }
            set { this.Window.WindowCursor.IsMouseVisible = value; }
        }

        public PanelGameWindow Window
        {
            get
            {
                if ( this.gamePlatform != null )
                {
                    return this.gamePlatform.MainWindow;
                }
                return null;
            }
        }

        public void Run()
        {
            this.gamePlatform.Run();
        }


        private void DrawFrame()
        {
            try
            {
                if ( !this.isExiting && this.isFirstUpdateDone )
                {
                    this.gameTime.Update( this.totalGameTime, this.lastFrameElapsedGameTime, this.drawRunningSlowly );
                    this.gameTime.FrameCount++;

                    this.Window.WindowCursor.UpdateCursor( this.gameTime );

                    //this.graphicsDeviceManager.BeginDraw(); //todo : check
                    this.Window.BeginDraw();    // begin draw to the mainWindow

                    Draw( this.gameTime );
                    DrawGameSystems( this.gameTime );

                    this.gamePlatform.EndAllDraw();
                }
            }
            finally
            {
                this.lastFrameElapsedGameTime = TimeSpan.Zero;
            }
        }


        #region empty virtual methods

        /// <summary>
        /// Called after the Game and GraphicsDevice are created, but before LoadContent..
        /// </summary>
        protected virtual void Initialize() { }

        /// <summary>Loads the content.</summary>
        protected virtual void LoadContent() { }

        /// <summary>
        /// Called after all components are initialized but before the first update in the game loop.
        /// </summary>
        protected virtual void BeginRun() { }

        /// <summary>
        /// Updates the Game
        /// </summary>
        /// <param name="gameTime">Time passed since the last call to Update</param>
        protected virtual void Update( PanelGameTime gameTime ) { }

        /// <summary>
        /// Draws the Game
        /// </summary>
        /// <param name="gameTime">Time passed since the last call to Draw</param>
        protected virtual void Draw( PanelGameTime gameTime ) { }

        /// <summary>
        /// Called after the game loop has stopped running before exiting.
        /// </summary>
        protected virtual void EndRun() { }

        /// <summary>Unloads the content.</summary>
        protected virtual void UnloadContent() { }

        #endregion


        #region IDisposable Member

        public void Dispose()
        {
        }

        #endregion
    }

}