// Copyright (c) 2013 GamePanel - Ludwig Ringler
//
// // Copyright (c) 2010-2013 SharpDX - Alexandre Mutel
// 
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
// 
// The above copyright notice and this permission notice shall be included in
// all copies or substantial portions of the Software.
// 
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
// THE SOFTWARE.

using SharpDX;
using SharpDX.Toolkit.Graphics;
using System;

namespace GamePanel
{

    public partial class PanelGame
    {
        private readonly PanelGameTime gameTime;
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

        private readonly TimerTick timer;

        public TimeSpan InactiveSleepTime { get; set; }
        public bool IsActive { get; private set; }
        public bool IsFixedTimeStep { get; set; }
        public bool IsRunning { get; private set; }
        public TimeSpan TargetElapsedTime { get; set; }

        private void InitGameLoop()
        {
            this.totalGameTime = new TimeSpan();
            this.accumulatedElapsedGameTime = new TimeSpan();
            this.lastFrameElapsedGameTime = new TimeSpan();
            this.IsFixedTimeStep = true;    // false;
            this.maximumElapsedTime = TimeSpan.FromMilliseconds( 500.0 );
            this.inactiveSleepTime = TimeSpan.FromSeconds( 1.0 );
            this.TargetElapsedTime = TimeSpan.FromTicks( 10000000 / 60 );
            this.nextLastUpdateCountIndex = 0;

            this.IsActive = true;
        }

        /// <summary>
        /// Exits the game.
        /// </summary>
        public void Exit()
        {
            this.isExiting = true;
            this.gamePlatform.Exiting = true;
            if ( this.IsRunning )
            {
                EndRun();
                this.IsRunning = false;
            }
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
            // Make sure that the device is already created
            this.gamePlatform.CreateDevice( new SharpDX.Toolkit.GraphicsDeviceInformation() );
            this.graphicsDeviceManager = this.Services.GetService( typeof( SharpDX.Toolkit.IGraphicsDeviceManager ) ) as SharpDX.Toolkit.IGraphicsDeviceManager;
            SetupGraphicsDeviceEvents();

            // Initialize this instance and all game systems
            Initialize();

            // If there were any new game systems added in initialize, we should remove them here
            InitializePendingGameSystems( false );

            // Load the content of the game
            LoadContent();
            LoadContentSystems();
            this.contentLoaded = true;

            // if any new GameSystem arrived, init and load content -> dont know if necessary
            InitializePendingGameSystems( true );

            this.IsRunning = true;

            BeginRun();

            this.timer.Reset();
            this.gameTime.Update( this.totalGameTime, TimeSpan.Zero, false );
            this.gameTime.FrameCount = 0;

            // Run the first time an update
            Update( gameTime );
            this.isFirstUpdateDone = true;
        }


        internal void Tick()
        {
            if ( this.isExiting ) { return; }

            if ( !this.IsActive ) { Utilities.Sleep( this.inactiveSleepTime ); }

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


        private void SetupGraphicsDeviceEvents()
        {
            this.graphicsDeviceService = this.Services.GetService( typeof( IGraphicsDeviceService ) ) as IGraphicsDeviceService;

            if ( this.graphicsDeviceService == null )
            {
                throw new InvalidOperationException( "No GraphicsDeviceService found" );
            }

            if ( this.graphicsDeviceService.GraphicsDevice == null )
            {
                throw new InvalidOperationException( "No GraphicsDevice found" );
            }

            this.graphicsDeviceService.DeviceCreated += graphicsDeviceService_DeviceCreated;
            this.graphicsDeviceService.DeviceDisposing += graphicsDeviceService_DeviceDisposing;
        }

        private void graphicsDeviceService_DeviceCreated( object sender, EventArgs e )
        {
            LoadContent();
        }

        private void graphicsDeviceService_DeviceDisposing( object sender, EventArgs e )
        {
            Content.Unload();

            if ( contentLoaded )
            {
                UnloadContent();
                UnloadContentSystems();
                contentLoaded = false;
            }
        }

    }

}
