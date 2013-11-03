using System;

using SharpDX.Direct3D;
using SharpDX.Direct3D11;
using SharpDX.DXGI;
using SharpDX.Toolkit;
using Device = SharpDX.Direct3D11.Device;

namespace GamePanel.ServiceProvider
{ 

    class PanelDeviceManager : IGraphicsDeviceManager, SharpDX.Toolkit.Graphics.IGraphicsDeviceService, IDisposable
    {

        private Factory factory;
        private Device dx11Device;
        private SwapChain swapChain;
        private SwapChainDescription desc;

        private Texture2D backBuffer;
        private RenderTargetView renderView;

        private bool initialized = false;
        private bool isFirstInit = true;

        private GamePanel game;


        public PanelDeviceManager( GamePanel game )
        {
            this.game = game;
            this.game.Services.AddService( typeof( IGraphicsDeviceManager ), this );
            this.game.Services.AddService( typeof( SharpDX.Toolkit.Graphics.IGraphicsDeviceService ), this );

            this.dx11Device = new Device( DriverType.Hardware );
            this.GraphicsDevice = SharpDX.Toolkit.Graphics.GraphicsDevice.New( this.dx11Device );
            this.factory = new Factory();

            this.desc = new SwapChainDescription()
            {
                BufferCount = 2,
                ModeDescription = new ModeDescription( this.game.Control.Width, this.game.Control.Height, new Rational( 60, 1 ), Format.R8G8B8A8_UNorm ),
                IsWindowed = true,
                OutputHandle = this.game.Control.Handle,
                SampleDescription = new SampleDescription( 1, 0 ),
                SwapEffect = SwapEffect.Discard,
                Usage = Usage.RenderTargetOutput
            };

            this.game.Control.ClientSizeChanged += Control_ClientSizeChanged;
            this.game.Control.Disposed += Control_Disposed;
        }

        private void InitGraphics()
        {
            this.desc.ModeDescription.Width = this.game.Control.Width;
            this.desc.ModeDescription.Height = this.game.Control.Height;

            if ( !this.isFirstInit )
            {
                this.renderView.Dispose();
                this.backBuffer.Dispose();
                this.swapChain.Dispose();
            }
            else
            {
                this.isFirstInit = false;
            }

            this.swapChain = new SwapChain( this.factory, this.dx11Device, this.desc );
            this.backBuffer = Texture2D.FromSwapChain<Texture2D>( this.swapChain, 0 );
            this.renderView = new RenderTargetView( this.dx11Device, this.backBuffer );

            this.initialized = true;
        }

        private void Control_ClientSizeChanged( object sender, EventArgs e )
        {
            this.initialized = false;
        }

        private void Control_Disposed( object sender, EventArgs e )
        {
            this.game.Stop();
        }


        #region IGraphicsDeviceManager Member

        public bool BeginDraw()
        {
            if ( !this.initialized )
            {
                InitGraphics();
            }

            this.GraphicsDevice.SetRenderTargets( this.renderView );
            this.GraphicsDevice.Viewport = new SharpDX.ViewportF( 0, 0, this.game.Control.Width, this.game.Control.Height );
            return true;
        }

        public void CreateDevice()
        {
            throw new NotImplementedException();
        }

        public void EndDraw()
        {
            this.swapChain.Present( 0, PresentFlags.None );
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
            DeviceChangeBegin( sender, args );
        }

        protected void OnDeviceChangeEnd( object sender, EventArgs args )
        {
            DeviceChangeEnd( sender, args );
        }

        protected void OnDeviceCreated( object sender, EventArgs args )
        {
            DeviceCreated( sender, args );
        }

        protected void OnDeviceDisposing( object sender, EventArgs args )
        {
            DeviceDisposing( sender, args );
        }

        protected void OnDeviceLost( object sender, EventArgs args )
        {
            DeviceLost( sender, args );
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
            this.renderView.Dispose();
            this.backBuffer.Dispose();
            this.swapChain.Dispose();
            this.GraphicsDevice.Dispose();
            this.dx11Device.Dispose();
            this.factory.Dispose();
        }

        #endregion
    }

}
