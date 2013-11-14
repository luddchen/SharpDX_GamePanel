using System;

namespace XGame
{
    public abstract class XGameWindow : IDisposable
    {
        public XGamePlatform Platform { get; private set; }

        public bool IsEndDrawRequired { get; protected set; }

        private XGameWindowCursor cursor;
        public XGameWindowCursor Cursor
        {
            get { return this.cursor; }
            set 
            {
                if ( this.cursor != null ) throw new InvalidOperationException( "Cursor can be set only once" );
                this.cursor = value;
            }
        }

        public XGameWindow( XGamePlatform platform )
        {
            if ( platform == null ) throw new ArgumentNullException( "platform" );
            this.Platform = platform;
        }

        public void BeginDraw() 
        {
            //this.Platform.MainWindow = this;
            this.Platform.ActiveWindow = this;
            this.Platform.DeviceManager.BeginDraw();
        }

        public void EndDraw()
        {
            //this.Platform.MainWindow = this;
            this.Platform.ActiveWindow = this;
            this.Platform.DeviceManager.EndDraw();
        }

        public void Present()
        {
            //this.Platform.MainWindow = this;
            this.Platform.ActiveWindow = this;
            this.Platform.DeviceManager.Present();
        }

        public abstract bool IsInitialized();

        public virtual float Width { get; protected set; }
        public virtual float Height { get; protected set; }

        #region IDisposable Member

        private bool disposed = false;

        public void Dispose()
        {
            Console.WriteLine( "XGameWindow.Dispose .. start" );
            Dispose(true);
            GC.SuppressFinalize( this );
            Console.WriteLine( "XGameWindow.Dispose .. done" );
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if ( this.cursor != null )
                {
                    this.cursor.Dispose();
                    this.cursor = null;
                }
                this.Platform = null;
                disposed = true;
            }
        }

        ~XGameWindow()
        {
            Dispose (false);
        }

        #endregion
    }
}
