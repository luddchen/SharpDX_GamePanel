using SharpDX;
using System;
using System.Windows.Forms;

namespace GamePanel
{

    public class WindowCursor
    {

        private Control control;

        private bool isMouseVisible;
        private bool isMouseOver;
        private bool isCursorVisible;

        Cursor invisibleCursor;
        Cursor defaultCursor;
        TimeSpan invisibleTimeout = new TimeSpan( 0, 0, 1 );    // default timeout for mouse invisibility
        Point mousePos;
        TimeSpan inactiveTime;
        private delegate void SetCursor( Cursor cursor );
        private SetCursor setCursor;


        public WindowCursor( Control control )
        {
            this.control = control;

            this.defaultCursor = Cursors.Hand;
            this.invisibleCursor = new Cursor( new System.Drawing.Bitmap( 48, 48 ).GetHicon() );
            this.isCursorVisible = true;
            this.inactiveTime = new TimeSpan();

            setCursor = delegate( Cursor cursor ) { try { this.control.Cursor = cursor; } catch ( Exception ) { } };

            this.control.MouseEnter += Control_MouseEnter;
            this.control.MouseLeave += Control_MouseLeave;
        }

        public void UpdateCursor( PanelGameTime gameTime )
        {
            Point newMousePos = new Point( Cursor.Position.X, Cursor.Position.Y );
            if ( !this.isMouseVisible )
            {
                if ( this.mousePos.X != newMousePos.X || this.mousePos.Y != newMousePos.Y )
                {
                    this.inactiveTime = new TimeSpan();
                    if ( !this.isCursorVisible )
                    {
                        SetControlCursor( this.defaultCursor );
                        this.isCursorVisible = true;
                    }
                }
                else
                {
                    this.inactiveTime += gameTime.ElapsedGameTime;
                    if ( isMouseOver && !isMouseVisible && isCursorVisible && this.inactiveTime > this.invisibleTimeout )
                    {
                        this.isCursorVisible = false;
                        SetControlCursor( this.invisibleCursor );
                    }
                }
            }
            this.mousePos.X = newMousePos.X;
            this.mousePos.Y = newMousePos.Y;
        }

        /// <summary>
        /// Gets or sets a value indicating whether the mouse should be visible.
        /// </summary>
        /// <value><c>true</c> if the mouse should be visible; otherwise, <c>false</c>.</value>
        public bool IsMouseVisible
        {
            get
            {
                bool visible = this.isMouseVisible;
                if ( !visible )
                {
                    visible = this.isCursorVisible;
                }
                return visible;
            }

            set
            {
                this.isMouseVisible = value;
                if ( value )
                    this.control.Invoke( setCursor, this.defaultCursor );
                else
                    this.inactiveTime = new TimeSpan(); // restart timer
            }
        }

        public bool IsMouseOver
        {
            get { return this.isMouseOver; }
        }

        public Cursor DefaultCursor
        {
            get { return this.defaultCursor; }
            set
            {
                if ( value != null )
                {
                    this.defaultCursor = value;
                }
            }
        }

        public TimeSpan CursurInvisibleTimeout
        {
            get { return this.invisibleTimeout; }
            set { this.invisibleTimeout = value; }
        }

        private void SetControlCursor( Cursor cursor )
        {
            try
            {
                this.control.Invoke( setCursor, cursor );
            }
            catch ( Exception ) { }
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

    }

}
