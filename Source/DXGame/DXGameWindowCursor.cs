using System;
using System.Drawing;
using System.Windows.Forms;
using XGame;

namespace DXGame
{

    public class DXGameWindowCursor : XGameWindowCursor
    {
        private Control control;

        Cursor invisibleCursor;
        Cursor defaultCursor;

        private delegate void SetCursor( Cursor cursor );
        private SetCursor setCursor;

        public DXGameWindowCursor( Control control )
        {
            if ( control == null ) throw new ArgumentNullException( "control" );
            this.control = control;
            control.MouseEnter += this.MouseEnter;
            control.MouseLeave += this.MouseLeave;

            this.defaultCursor = Cursors.Hand;
            this.invisibleCursor = new Cursor( new Bitmap( 48, 48 ).GetHicon() );
            this.isCursorVisible = true;
            this.inactiveTime = new TimeSpan();
            this.InvisibleTimeout = new TimeSpan( 0, 0, 1 );

            setCursor = delegate( Cursor cursor ) { try { this.control.Cursor = cursor; } catch ( Exception ) { } };

        }

        public override void Update( XGameTime gameTime )
        {
            Point newMousePos = new Point( Cursor.Position.X, Cursor.Position.Y );
            if ( !this.isMouseVisible )
            {
                if ( this.mouseX != newMousePos.X || this.mouseY != newMousePos.Y )
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
                    if ( this.IsMouseOver && !isMouseVisible && isCursorVisible && this.inactiveTime > this.InvisibleTimeout )
                    {
                        this.isCursorVisible = false;
                        SetControlCursor( this.invisibleCursor );
                    }
                }
            }
            this.mouseX = newMousePos.X;
            this.mouseY = newMousePos.Y;
        }

        private void SetControlCursor( Cursor cursor )
        {
            try
            {
                this.control.Invoke( setCursor, cursor );
            }
            catch ( Exception ) { }
        }

        public override void Dispose()
        {
            Console.WriteLine( "DXGameWindowCursor.Dispose .. start" );
            this.control.MouseEnter -= this.MouseEnter;
            this.control.MouseLeave -= this.MouseLeave;
            this.control = null;
            this.invisibleCursor = null;
            this.defaultCursor = null;
            this.setCursor = null;
            Console.WriteLine( "DXGameWindowCursor.Dispose .. done" );
            base.Dispose();
        }

    }

}
