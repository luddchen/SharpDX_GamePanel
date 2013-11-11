using System;

namespace XGame
{

    public class XGame
    {

        //public XGameServiceRegistry Services { get; private set; }

        private XGamePlatform platform;

        public XGamePlatform Platform
        {
            get
            {
                if ( this.platform == null ) throw new MemberAccessException( "no Platform set" );
                return this.platform; 
            }
            set
            {
                if ( this.platform != null ) throw new InvalidOperationException( "Platform can be set only once" );
                this.platform = value;
            }
        }

        #region GameLoop Fields

        private readonly XGameTime gameTime;
        private readonly int[] lastUpdateCount;
        private readonly float updateCountAverageSlowLimit;
        private bool isExiting;
        private bool isFirstUpdateDone = false;
        private bool suppressDraw;

        private TimeSpan totalGameTime;
        private TimeSpan inactiveSleepTime;
        private TimeSpan maximumElapsedTime;
        private TimeSpan accumulatedElapsedGameTime;
        private TimeSpan lastFrameElapsedGameTime;
        private int nextLastUpdateCountIndex;
        private bool drawRunningSlowly;
        private bool forceElapsedTimeToZero;
        private bool contentLoaded = false;

        private readonly XTimerTick timer;

        public TimeSpan InactiveSleepTime { get; set; }
        public bool IsActive { get; protected set; }
        public bool IsFixedTimeStep { get; set; }
        public bool IsRunning { get; private set; }
        public bool IsCleanedUp { get; private set; }
        public TimeSpan TargetElapsedTime { get; set; }

        #endregion

        public XGame()
        {
            #region GameLoop stuff

            this.lastUpdateCount = new int[ 4 ];
            this.timer = new XTimerTick();
            this.gameTime = new XGameTime();

            const int BadUpdateCountTime = 2;
            var maxLastCount = 2 * Math.Min( BadUpdateCountTime, this.lastUpdateCount.Length );
            this.updateCountAverageSlowLimit = (float)( maxLastCount + ( this.lastUpdateCount.Length - maxLastCount ) ) / this.lastUpdateCount.Length;

            this.totalGameTime = new TimeSpan();
            this.accumulatedElapsedGameTime = new TimeSpan();
            this.lastFrameElapsedGameTime = new TimeSpan();
            this.IsFixedTimeStep = true;    // false;
            this.maximumElapsedTime = TimeSpan.FromMilliseconds( 500.0 );
            this.inactiveSleepTime = TimeSpan.FromSeconds( 1.0 );
            this.TargetElapsedTime = TimeSpan.FromTicks( 10000000 / 60 );
            this.nextLastUpdateCountIndex = 0;
            this.IsActive = true;

            #endregion
        }

        public void Pause()
        {
            if ( this.IsRunning ) this.IsActive = !this.IsActive;
        }

        public XGameWindow Window
        {
            get
            {
                if ( this.Platform != null )
                {
                    return this.Platform.ActiveWindow;
                }
                return null;
            }
            set
            {
                if ( this.Platform != null )
                {
                    this.Platform.ActiveWindow = value;
                }
            }
        }

        // todo : global MouseVisibilty -> method in XGamePlatform
        public bool IsMouseVisible
        {
            get { return this.Platform.IsMouseVisible; }
            set { this.Platform.IsMouseVisible = value; }
        }

        public void Run() 
        { 
            if (!this.IsRunning) this.Platform.Run(); 
        }

        /// <summary>
        /// Exits the game.
        /// </summary>
        public void Exit()
        {
            this.isExiting = true;
            this.Platform.Exiting = true;
            this.IsRunning = false;
        }

        /// <summary>
        /// Resets the elapsed time counter
        /// </summary>
        public void ResetElapsedTime()
        {
            this.forceElapsedTimeToZero = true;
            this.drawRunningSlowly = false;
            Array.Clear( this.lastUpdateCount, 0, this.lastUpdateCount.Length );
            this.nextLastUpdateCountIndex = 0;
        }

        internal void InitializeBeforeRun()
        {
            Console.WriteLine( "XGame.Initialize" );
            this.IsCleanedUp = false;
            this.Platform.CreateDevice();// or initialize ?!
            //SetupGraphicsDeviceEvents -> move to CreateDevice

            this.Initialize();
            this.InitializePendingGameSystems( false );

            this.LoadContent();
            this.LoadContentSystems();
            this.contentLoaded = true;

            this.InitializePendingGameSystems( true );  // if any new GameSystem arrived, init and load content ?
            this.IsRunning = true;

            this.BeginRun();

            this.timer.Reset();
            this.gameTime.Update( this.totalGameTime, TimeSpan.Zero, false );
            this.gameTime.FrameCount = 0;

            Update( gameTime );
            this.isFirstUpdateDone = true;
        }

        // todo
        private void InitializePendingGameSystems( bool loadContent = false )
        {
            //// Add all game systems that were added to this game instance before the game started.
            //while ( pendingGameSystems.Count != 0 )
            //{
            //    pendingGameSystems[ 0 ].Initialize();

            //    if ( loadContent && pendingGameSystems[ 0 ] is IContentable )
            //    {
            //        ( (IContentable)pendingGameSystems[ 0 ] ).LoadContent();
            //    }

            //    pendingGameSystems.RemoveAt( 0 );
            //}
        }

        // todo
        private void LoadContentSystems() { }

        // todo
        private void UnloadContentSystems() { }

        // todo
        private void UpdateGameSystems( XGameTime gameTime ) { }

        // todo
        private void DrawGameSystems( XGameTime gameTime ) { }

        internal void Tick()
        {
            if ( this.isExiting ) { return; }

            if ( !this.IsActive && this.Platform != null ) 
            { 
                this.Platform.Sleep( this.inactiveSleepTime ); 
                return; 
            }

            this.timer.Tick();

            var elapsedAdjustedTime = this.timer.ElapsedAdjustedTime;

            if ( this.forceElapsedTimeToZero )
            {
                elapsedAdjustedTime = TimeSpan.Zero;
                this.forceElapsedTimeToZero = false;
            }

            if ( elapsedAdjustedTime > this.maximumElapsedTime )
            {
                elapsedAdjustedTime = this.maximumElapsedTime;
            }

            bool suppressNextDraw = true;
            int updateCount = 1;
            var singleFrameElapsedTime = elapsedAdjustedTime;

            // fixed Timestep
            if ( this.IsFixedTimeStep )
            {
                if ( Math.Abs( elapsedAdjustedTime.Ticks - this.TargetElapsedTime.Ticks ) < ( this.TargetElapsedTime.Ticks >> 6 ) )
                {
                    elapsedAdjustedTime = this.TargetElapsedTime;
                }

                this.accumulatedElapsedGameTime += elapsedAdjustedTime;

                updateCount = (int)( this.accumulatedElapsedGameTime.Ticks / this.TargetElapsedTime.Ticks );

                if ( updateCount == 0 ) return;

                this.lastUpdateCount[ this.nextLastUpdateCountIndex ] = updateCount;
                float updateCountMean = 0;
                for ( int i = 0; i < this.lastUpdateCount.Length; i++ )
                {
                    updateCountMean += this.lastUpdateCount[ i ];
                }

                updateCountMean /= lastUpdateCount.Length;
                this.nextLastUpdateCountIndex = ( this.nextLastUpdateCountIndex + 1 ) % this.lastUpdateCount.Length;

                this.drawRunningSlowly = updateCountMean > this.updateCountAverageSlowLimit;

                this.accumulatedElapsedGameTime = new TimeSpan( this.accumulatedElapsedGameTime.Ticks - ( updateCount * TargetElapsedTime.Ticks ) );
                singleFrameElapsedTime = TargetElapsedTime;
            }
            else
            // no fixed Timestep
            {
                Array.Clear( this.lastUpdateCount, 0, this.lastUpdateCount.Length );
                this.nextLastUpdateCountIndex = 0;
                this.drawRunningSlowly = false;
            }


            this.lastFrameElapsedGameTime = TimeSpan.Zero;
            for ( ; updateCount > 0 && !this.isExiting; updateCount-- )
            {
                this.gameTime.Update( this.totalGameTime, singleFrameElapsedTime, this.drawRunningSlowly );
                try
                {
                    Update( this.gameTime );
                    UpdateGameSystems( this.gameTime );

                    suppressNextDraw &= this.suppressDraw;
                    suppressDraw = false;
                }
                finally
                {
                    this.lastFrameElapsedGameTime += singleFrameElapsedTime;
                    this.totalGameTime += singleFrameElapsedTime;
                }
            }


            if ( !suppressNextDraw )
            {
                DrawFrame();
            }

        }

        private void DrawFrame()
        {
            try
            {
                if ( !this.isExiting && this.isFirstUpdateDone )
                {
                    this.gameTime.Update( this.totalGameTime, this.lastFrameElapsedGameTime, this.drawRunningSlowly );
                    this.gameTime.FrameCount++;

                    this.Platform.Update( this.gameTime );  // cursor visibility update

                    this.Platform.MainWindow.BeginDraw();
                    Draw( this.gameTime );
                    this.Platform.MainWindow.EndDraw();

                    DrawGameSystems( this.gameTime );

                    this.Platform.Present();
                }
            }
            finally
            {
                this.lastFrameElapsedGameTime = TimeSpan.Zero;
            }
        }

        internal void CleanUpAfterRun()
        {
            this.EndRun();
            if ( this.contentLoaded )
            {
                this.UnloadContent();
                this.UnloadContentSystems();
            }
            Console.WriteLine( "XGame.CleanUp .. start" );
            //todo : dispose stuff
            this.Dispose();
            this.platform.Dispose();
            //this.platform = null;
            Console.WriteLine( "XGame.CleanUp .. done" );
            this.IsCleanedUp = true;
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
        protected virtual void Update( XGameTime gameTime ) { }

        /// <summary>
        /// Draws the Game
        /// </summary>
        /// <param name="gameTime">Time passed since the last call to Draw</param>
        protected virtual void Draw( XGameTime gameTime ) { }

        /// <summary>
        /// Called after the game loop has stopped running before exiting.
        /// </summary>
        protected virtual void EndRun() { }

        /// <summary>Unloads the content.</summary>
        protected virtual void UnloadContent() { }

        protected virtual void Dispose() { }

        #endregion

    }

}
