using SharpDX;
using SharpDX.DXGI;
using System;

namespace GamePanel
{

    public partial class GamePanel
    {

        public readonly System.Windows.Forms.Control Control;

        private readonly TimerTick timer;

        private TimeSpan accumulatedElapsedGameTime;
        protected TimeSpan lastFrameElapsedGameTime;

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

        protected long currentFrame = 0;

        private bool doWork = true;


        public GamePanel( System.Windows.Forms.Control control )
        {
            this.Control = control; 
            this.Control.Disposed += Control_Disposed;

            InitServices();

            this.timer = new TimerTick();
            this.accumulatedElapsedGameTime = new TimeSpan();
            this.lastFrameElapsedGameTime = new TimeSpan();
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
                this.lastFrameElapsedGameTime = this.timer.ElapsedAdjustedTime;
                DrawFrame();
            }
            else
            {
                this.accumulatedElapsedGameTime += this.timer.ElapsedAdjustedTime;

                if ( this.accumulatedElapsedGameTime.Ticks > this.maximumElapsed )
                {
                    this.lastFrameElapsedGameTime = this.accumulatedElapsedGameTime;
                    this.accumulatedElapsedGameTime = new TimeSpan();
                    DrawFrame();
                }
                else
                {
                    // sleep
                }
            }
        }


        private void DrawFrame()
        {
            ++currentFrame;

            this.graphicsDeviceManager.BeginDraw(); //todo : check

            Draw();

            this.graphicsDeviceManager.EndDraw();
        }


        protected virtual void Draw() { }


        private void Control_Disposed( object sender, EventArgs e )
        {
            doWork = false;
        }

        protected virtual void Dispose( bool disposing )
        {
            // graphicsdevicemanager dispose !?
        }

    }

}