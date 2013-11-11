using SharpDX.Direct3D;
using SharpDX.DXGI;
using SharpDX.Toolkit;
using SharpDX.Toolkit.Graphics;
using System;
using XGame;
using Device = SharpDX.Direct3D11.Device;

namespace DXGame
{

    public class DXGameDeviceManager : IXGameDeviceManager , IGraphicsDeviceManager, IGraphicsDeviceService
    {
        private XGamePlatform platform;

        public Factory Factory { get; private set; }

        public Device Dx11Device { get; private set; }

        public SharpDX.Toolkit.Graphics.GraphicsDevice GraphicsDevice
        {
            get;
            private set;
        }

        public DXGameDeviceManager( XGamePlatform platform )
        {
            if ( platform == null ) throw new ArgumentNullException( "platform" );
            this.platform = platform;
            ( this.platform.Game as DXGame ).Services.AddService( typeof( IGraphicsDeviceManager ), this );
            ( this.platform.Game as DXGame ).Services.AddService( typeof( IGraphicsDeviceService ), this );
        }

        #region IXGameDeviceManager Member

        public void CreateDevice()
        {
            this.Dx11Device = new Device( DriverType.Hardware );
            this.GraphicsDevice = SharpDX.Toolkit.Graphics.GraphicsDevice.New( this.Dx11Device );
            this.Factory = new Factory();
            //this.GraphicsDevice.Disposing += DeviceDisposing;
        }

        public bool BeginDraw()
        {
            if ( this.platform.ActiveWindow == null || !this.platform.ActiveWindow.IsInitialized() )
            {
                return false;
            }

            this.GraphicsDevice.SetRenderTargets( ( this.platform.ActiveWindow as DXGameWindow ).RenderView );
            this.GraphicsDevice.SetViewport( 0, 0, this.platform.ActiveWindow.Width, this.platform.ActiveWindow.Height );

            return true;
        }

        public void EndDraw()
        {
        }

        public void Present()
        {
            ( this.platform.ActiveWindow as DXGameWindow ).SwapChain.Present( 0, PresentFlags.None );
        }

        #endregion

        #region IDisposable Member

        public void Dispose()
        {
            Console.WriteLine( "DXGameDeviceManager.Dispose .. start" );
            this.GraphicsDevice.Dispose();
            this.Dx11Device.Dispose();
            this.Factory.Dispose();
            this.platform = null;
            Console.WriteLine( "DXGameDeviceManager.Dispose .. done" );
        }

        #endregion

        #region IGraphicsDeviceService Member

        public event EventHandler<EventArgs> DeviceChangeBegin;

        public event EventHandler<EventArgs> DeviceChangeEnd;

        public event EventHandler<EventArgs> DeviceCreated;

        public event EventHandler<EventArgs> DeviceDisposing;

        public event EventHandler<EventArgs> DeviceLost;

        protected void OnDeviceChangeBegin( object sender, EventArgs args )
        {
            RaiseEvent( DeviceChangeBegin, sender, args );
        }

        protected void OnDeviceChangeEnd( object sender, EventArgs args )
        {
            RaiseEvent( DeviceChangeEnd, sender, args );
        }

        protected void OnDeviceCreated( object sender, EventArgs args )
        {
            RaiseEvent( DeviceCreated, sender, args );
        }

        protected void OnDeviceDisposing( object sender, EventArgs args )
        {
            RaiseEvent( DeviceDisposing, sender, args );
        }

        protected void OnDeviceLost( object sender, EventArgs args )
        {
            RaiseEvent( DeviceLost, sender, args );
        }

        private void RaiseEvent<T>( EventHandler<T> handler, object sender, T args ) where T : EventArgs
        {
            if ( handler != null )
                handler( sender, args );
        }

        #endregion
    }

}
