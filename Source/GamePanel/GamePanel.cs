using SharpDX;
using SharpDX.DXGI;
using System;
using System.Threading;
using System.Windows.Forms;

namespace GamePanel
{

    public partial class GamePanel : IDisposable
    {
        Cursor invisibleCursor;
        Cursor defaultCursor;
        TimeSpan invisibleTimeout = new TimeSpan( 0, 0, 1 );    // default 2 seconds timeout for mouse invisibility
        Point mousePos;
        TimeSpan inactiveTime;
        private delegate void SetCursor( Cursor cursor );
        private SetCursor setCursor;
        protected bool isCursorVisible { get; private set; }
        
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

        private bool isMouseVisible;
        private bool isMouseOver;

        private bool doWork = true;


        public GamePanel( System.Windows.Forms.Control control )
        {
            this.Control = control;
            this.Control.MouseEnter += Control_MouseEnter;
            this.Control.MouseLeave += Control_MouseLeave;

            this.defaultCursor = Cursors.Hand;
            this.invisibleCursor = new Cursor( new System.Drawing.Bitmap( 48, 48 ).GetHicon() );
            this.isCursorVisible = true;

            setCursor = delegate( Cursor cursor ) { try { this.Control.Cursor = cursor; } finally { } };
            
            this.gameThread = new Thread( this.Run );

            InitServices();

            this.gameTime = new PanelGameTime();
            this.timer = new TimerTick();
            this.accumulatedElapsedGameTime = new TimeSpan();
            this.lastFrameElapsedGameTime = new TimeSpan();
            this.maximumElapsed = (long)( 10000000.0f / targetFps );

            this.inactiveTime = new TimeSpan();
        }

        private void Control_MouseEnter( object sender, EventArgs e )
        {
            this.isMouseOver = true;
            if ( !this.isMouseVisible )
            {
                this.inactiveTime = new TimeSpan(); // restart "timer" on mouse enter and mouseinvisible
                this.isCursorVisible = true;
            }
        }

        private void Control_MouseLeave( object sender, EventArgs e )
        {
            this.isMouseOver = false;
        }

        /// <summary>
        /// Gets or sets a value indicating whether the mouse should be visible.
        /// </summary>
        /// <value><c>true</c> if the mouse should be visible; otherwise, <c>false</c>.</value>
        public bool IsMouseVisible
        {
            get { return this.isMouseVisible; }

            set
            {
                this.isMouseVisible = value;
                if (value) 
                    this.Control.Invoke( setCursor, this.defaultCursor );
                else
                    this.inactiveTime = new TimeSpan(); // restart timer
            }
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

            Point newMousePos = new Point( Cursor.Position.X, Cursor.Position.Y );
            if ( !this.isMouseVisible )
            {
                if ( this.mousePos.X != newMousePos.X || this.mousePos.Y != newMousePos.Y )
                {
                    this.inactiveTime = new TimeSpan();
                    this.Control.Invoke( setCursor, this.defaultCursor );
                    this.isCursorVisible = true;
                }
                else
                {
                    this.inactiveTime += this.timer.ElapsedAdjustedTime;
                    if ( isMouseOver && isCursorVisible && !isMouseVisible && this.inactiveTime.TotalMilliseconds > 2000 )
                    {
                        this.isCursorVisible = false;
                        this.Control.Invoke( setCursor, this.invisibleCursor );
                    }
                }
            }
            this.mousePos.X = newMousePos.X;
            this.mousePos.Y = newMousePos.Y;

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
            ++this.gameTime.FrameCount;

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