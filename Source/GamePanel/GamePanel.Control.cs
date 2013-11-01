using SharpDX.Direct3D;
using SharpDX.Direct3D11;
using SharpDX.DXGI;
using System;
using System.Windows.Forms;
using Device = SharpDX.Direct3D11.Device;

namespace GamePanel
{

    public partial class GamePanel
    {

        protected readonly Control Control;

        private SwapChainDescription desc;
        private SwapChain swapChain;

        private Texture2D backBuffer;
        private RenderTargetView renderView;

        private Factory factory;

        private Device dx11Device;
        public SharpDX.Toolkit.Graphics.GraphicsDevice Device { get; private set; }

        private bool initialized = false;
        private bool firstInit = true;

        private void InitControl()
        {
            this.Control.SizeChanged += Control_SizeChanged;
            this.Control.Disposed += Control_Disposed;

            this.desc = new SwapChainDescription()
            {
                BufferCount = 2,
                ModeDescription = new ModeDescription( this.Control.Width, this.Control.Height, new Rational( 60, 1 ), Format.R8G8B8A8_UNorm ),
                IsWindowed = true,
                OutputHandle = this.Control.Handle,
                SampleDescription = new SampleDescription( 1, 0 ),
                SwapEffect = SwapEffect.Discard,
                Usage = Usage.RenderTargetOutput
            };
        }

        private void InitGraphics()
        {
            this.desc.ModeDescription.Width = this.Control.Width;
            this.desc.ModeDescription.Height = this.Control.Height;

            if ( firstInit )
            {
                this.dx11Device = new Device( DriverType.Hardware );
                this.factory = new Factory();
                this.swapChain = new SwapChain( this.factory, this.dx11Device, this.desc );
                this.Device = SharpDX.Toolkit.Graphics.GraphicsDevice.New( this.dx11Device );
                this.firstInit = false;
            }
            else
            {
                this.renderView.Dispose();
                this.backBuffer.Dispose();
                this.swapChain.Dispose();
                this.swapChain = new SwapChain( this.factory, this.dx11Device, this.desc );
            }

            this.backBuffer = Texture2D.FromSwapChain<Texture2D>( this.swapChain, 0 );
            this.renderView = new RenderTargetView( this.dx11Device, this.backBuffer );

            this.initialized = true;
        }


        private void Control_Disposed( object sender, EventArgs e )
        {
            doWork = false;
        }


        private void Control_SizeChanged( object sender, EventArgs e )
        {
            this.initialized = false;
        }

    }

}
