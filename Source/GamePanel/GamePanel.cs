using SharpDX;
using SharpDX.DXGI;
using System;

namespace GamePanel
{

    public partial class GamePanel
    {
        private TimerTick timer;
        private TimeSpan accumulatedElapsedTime;
        protected TimeSpan lastFrameElapsedTime;
        private float targetFps = 60.0f;
        public float TargetFps
        {
            get { return targetFps; }
            set 
            { 
                this.targetFps = value;
                this.maximumElapsed = (long)( 10000000.0f / targetFps );
            }
        }
        private long maximumElapsed;
        public bool IsFixedTimeStep = true;

        private bool doWork = true;


        public GamePanel( System.Windows.Forms.Control control )
        {
            this.Control = control;
            InitControl();
        }


        private void InitTimer()
        {
            this.timer = new TimerTick();
            this.accumulatedElapsedTime = new TimeSpan();
            this.lastFrameElapsedTime = new TimeSpan();
            this.maximumElapsed = (long)( 10000000.0f / targetFps );
        }


        protected virtual void Initialize() { }


        protected virtual void LoadContent() { }


        protected virtual void UnloadContent() { }


        public void Start()
        {
            System.Threading.Thread newThread;
            newThread = new System.Threading.Thread( this.Run );
            newThread.Start();
        }


        private void Run()
        {
            InitGraphics();
            InitTimer();
            Initialize();
            LoadContent();

            while ( this.doWork )
            {
                Tick();
            }

            UnloadContent();

            Dispose( true );
        }


        private void Tick()
        {
            this.timer.Tick();

            if ( !this.IsFixedTimeStep )
            {
                this.lastFrameElapsedTime = this.timer.ElapsedAdjustedTime;
                DrawFrame();
            }
            else
            {
                this.accumulatedElapsedTime += this.timer.ElapsedAdjustedTime;

                if ( this.accumulatedElapsedTime.Ticks > this.maximumElapsed )
                {
                    this.lastFrameElapsedTime = this.accumulatedElapsedTime;
                    this.accumulatedElapsedTime = new TimeSpan();
                    DrawFrame();
                }
            }
        }


        private void DrawFrame()
        {
            if ( !this.initialized )
            {
                InitGraphics();
            }

            this.Device.Viewport = new SharpDX.ViewportF( 0, 0, this.Control.Width, this.Control.Height );
            this.Device.SetRenderTargets( this.renderView );

            Draw();

            this.swapChain.Present( 0, PresentFlags.None );
        }


        protected virtual void Draw() { }


        protected virtual void Dispose( bool disposing )
        {
            this.renderView.Dispose();
            this.backBuffer.Dispose();
            this.swapChain.Dispose();
            this.factory.Dispose();
            this.Device.Dispose();
            this.dx11Device.Dispose();
        }

    }

}