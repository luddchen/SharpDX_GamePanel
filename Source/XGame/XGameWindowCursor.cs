using System;

namespace XGame
{

    public abstract class XGameWindowCursor : IDisposable
    {

        protected bool isCursorVisible;
        protected bool isMouseVisible;

        protected float mouseX;
        protected float mouseY;

        protected TimeSpan inactiveTime;

        public TimeSpan InvisibleTimeout;

        public virtual bool IsMouseVisible 
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
            }
        }

        public bool IsMouseOver { get; private set; }


        public abstract void Update( XGameTime gameTime );


        // predefined EventHandler
        protected void MouseEnter( object sender, EventArgs e )
        {
            this.IsMouseOver = true;
            if ( !this.isMouseVisible )
            {
                this.inactiveTime = new TimeSpan();
                this.isCursorVisible = true;
            }
        }

        // predefined EventHandler
        protected void MouseLeave( object sender, EventArgs e )
        {
            this.IsMouseOver = false;
        }

        #region IDisposable Member

        public virtual void Dispose() 
        {
            Console.WriteLine( "XGameWindowCursor.Dispose" );
        }

        #endregion
    }

}
