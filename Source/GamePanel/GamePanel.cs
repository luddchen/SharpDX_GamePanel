using SharpDX;
using System;
using System.Threading;
using System.Windows.Forms;

namespace GamePanel
{

    public partial class GamePanel : IDisposable
    {
        
        public readonly Control Control;

        private readonly Thread gameThread;

        private readonly PanelGameTime gameTime;

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

        private bool doWork = true;


        public GamePanel( System.Windows.Forms.Control control )
        {
            this.Control = control;
            
            this.gameThread = new Thread( this.Run );

            InitServices();
            InitCursor();

            this.gameTime = new PanelGameTime();
            this.timer = new TimerTick();
            this.accumulatedElapsedGameTime = new TimeSpan();
            this.lastFrameElapsedGameTime = new TimeSpan();
            this.maximumElapsed = (long)( 10000000.0f / targetFps );
        }

        public void Start()
        {
            this.doWork = true;
            this.gameThread.Start();
        }

        public void Stop()
        {
            this.doWork = false;
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
            Dispose();
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
            }
        }


        private void DrawFrame()
        {
            ++this.gameTime.FrameCount;

            this.gameTime.Update( 
                this.gameTime.TotalGameTime + this.lastFrameElapsedGameTime, 
                this.lastFrameElapsedGameTime, 
                false );

            UpdateCursor( this.gameTime );

            Update( this.gameTime );   // temp -> replace

            this.panelDeviceManager.BeginDraw(); //todo : check

            Draw( this.gameTime );

            this.panelDeviceManager.EndDraw();
        }



        protected virtual void Initialize() { }

        protected virtual void LoadContent() { }

        protected virtual void Update( PanelGameTime gameTime ) { }

        protected virtual void Draw( PanelGameTime gameTime ) { }

        protected virtual void UnloadContent() { }


        #region IDisposable Member

        public void Dispose()
        {
        }

        #endregion
    }

}