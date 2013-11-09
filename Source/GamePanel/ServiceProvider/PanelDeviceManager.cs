using System;

using SharpDX.Direct3D;
using SharpDX.Direct3D11;
using SharpDX.DXGI;
using SharpDX.Toolkit;
using Device = SharpDX.Direct3D11.Device;

namespace GamePanel.ServiceProvider
{ 

    public class PanelDeviceManager : IGraphicsDeviceManager, SharpDX.Toolkit.Graphics.IGraphicsDeviceService, IDisposable
    {

        private Factory factory;

        private Device dx11Device;

        private PanelGame game;


        public PanelDeviceManager( PanelGame game )
        {
            this.game = game;
            this.game.Services.AddService( typeof( IGraphicsDeviceManager ), this );
            this.game.Services.AddService( typeof( SharpDX.Toolkit.Graphics.IGraphicsDeviceService ), this );

            this.dx11Device = new Device( DriverType.Hardware );
            this.GraphicsDevice = SharpDX.Toolkit.Graphics.GraphicsDevice.New( this.dx11Device );
            this.factory = new Factory();
            this.GraphicsDevice.Disposing += DeviceDisposing;
        }


        #region IGraphicsDeviceManager Member

        public void CreateDevice()
        {
            OnDeviceCreated( this, EventArgs.Empty );
        }

        public bool BeginDraw()
        {
            if ( this.game.Window == null || !this.game.Window.IsInitialized(this.dx11Device, this.factory) ) 
            {
                return false; 
            }

            this.GraphicsDevice.SetRenderTargets( this.game.Window.RenderView );
            this.GraphicsDevice.SetViewport( 0, 0, this.game.Window.ClientSize.X, this.game.Window.ClientSize.Y );

            return true;
        }

        public void EndDraw()
        {
            this.game.Window.SwapChain.Present( 0, PresentFlags.None );
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

        public SharpDX.Toolkit.Graphics.GraphicsDevice GraphicsDevice
        {
            get;
            private set;
        }

        #endregion


        #region IDisposable Member

        public void Dispose()
        {
            Console.WriteLine( "PanelDeviceManager.Dispose();" );
            this.game = null;
            OnDeviceDisposing( this, EventArgs.Empty );
            this.GraphicsDevice.Dispose();
            this.dx11Device.Dispose();
            this.factory.Dispose();
        }

        #endregion

    }

}
