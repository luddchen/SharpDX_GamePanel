using System;

namespace XGame
{
    public abstract class XGameWindow : IDisposable
    {
        public readonly XGamePlatform Platform;

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
            this.Platform.MainWindow = this;
            this.Platform.DeviceManager.BeginDraw();
        }

        public void EndDraw()
        {
            this.Platform.MainWindow = this;
            this.Platform.DeviceManager.EndDraw();
        }

        public void Present()
        {
            this.Platform.MainWindow = this;
            this.Platform.DeviceManager.Present();
        }

        public abstract bool IsInitialized();

        public virtual float Width { get; protected set; }
        public virtual float Height { get; protected set; }

        #region IDisposable Member

        public virtual void Dispose() { }

        #endregion
    }
}
