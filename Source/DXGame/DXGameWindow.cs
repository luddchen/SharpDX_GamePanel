using SharpDX;
using SharpDX.Direct3D11;
using SharpDX.DXGI;
using System;
using System.Windows.Forms;
using XGame;

namespace DXGame
{

    public class DXGameWindow : XGameWindow
    {

        public readonly Control Control;

        public SwapChain SwapChain { get; private set; }
        private SwapChainDescription desc;
        private Texture2D backBuffer;

        public RenderTargetView RenderView { get; private set; }

        private bool initialized = false;
        private bool isFirstInitDone = false;

        public DXGameWindow( XGamePlatform platform, Control control ) : base( platform )
        {
            if ( control == null ) throw new ArgumentNullException( "control" );
            this.Control = control;
            this.Control.Disposed += Control_Disposed;
            this.Cursor = new DXGameWindowCursor( control );

            this.Control_ClientSizeChanged( this, EventArgs.Empty );

            this.desc = new SwapChainDescription()
            {
                BufferCount = 2,
                ModeDescription = new ModeDescription( (int)this.Width, (int)this.Height, new Rational( 60, 1 ), Format.R8G8B8A8_UNorm ),
                IsWindowed = true,
                OutputHandle = this.Control.Handle,
                SampleDescription = new SampleDescription( 1, 0 ),
                SwapEffect = SwapEffect.Discard,
                Usage = Usage.RenderTargetOutput
            };

            this.Control.ClientSizeChanged += Control_ClientSizeChanged;
        }

        public override bool IsInitialized()
        {
            if ( this.initialized ) return true;
            SharpDX.Direct3D11.Device device = ( this.Platform.DeviceManager as DXGameDeviceManager ).Dx11Device;
            Factory factory = ( this.Platform.DeviceManager as DXGameDeviceManager ).Factory;
            if ( device == null || factory == null ) return false;

            this.desc.ModeDescription.Width = (int)this.Width;
            this.desc.ModeDescription.Height = (int)this.Height;

            Dispose();

            this.SwapChain = new SwapChain( factory, device, this.desc );
            this.backBuffer = Texture2D.FromSwapChain<Texture2D>( this.SwapChain, 0 );
            this.RenderView = new RenderTargetView( device, this.backBuffer );
            this.isFirstInitDone = true;
            this.initialized = true;
            return true;
        }

        private void Control_ClientSizeChanged( object sender, EventArgs e )
        {
            this.initialized = false;
            this.Width = this.Control.ClientSize.Width;
            this.Height = this.Control.ClientSize.Height;
        }

        private void Control_Disposed( object sender, EventArgs e )
        {
            this.Platform.Game.Exit();
        }

        public override void Dispose()
        {
            if ( this.isFirstInitDone )
            {
                this.RenderView.Dispose();
                this.backBuffer.Dispose();
                this.SwapChain.Dispose();
            }
        }

    }

}
