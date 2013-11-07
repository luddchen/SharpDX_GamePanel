using SharpDX;
using SharpDX.Direct3D11;
using SharpDX.DXGI;
using System;
using System.Windows.Forms;

namespace GamePanel
{

    public class PanelGameWindow : IDisposable
    {

        public readonly Control Control;

        public SwapChain SwapChain { get; private set; }
        private SwapChainDescription desc;
        private Texture2D backBuffer;

        public RenderTargetView RenderView { get; private set; }

        private bool initialized = false;
        private bool isFirstInitDone = false;

        public PanelGameWindow( Control control )
        {
            this.Control = control;
            this.clientSize = new Point( this.Control.ClientSize.Width, this.Control.ClientSize.Height );

            this.desc = new SwapChainDescription()
            {
                BufferCount = 2,
                ModeDescription = new ModeDescription( this.clientSize.X, this.clientSize.Y, new Rational( 60, 1 ), Format.R8G8B8A8_UNorm ),
                IsWindowed = true,
                OutputHandle = this.Control.Handle,
                SampleDescription = new SampleDescription( 1, 0 ),
                SwapEffect = SwapEffect.Discard,
                Usage = Usage.RenderTargetOutput
            };

            this.Control.ClientSizeChanged += Control_ClientSizeChanged;
        }

        public bool IsInitialized( SharpDX.Direct3D11.Device device, Factory factory )
        {
            if ( this.initialized ) return true;
            if ( device == null || factory == null ) return false;

            this.desc.ModeDescription.Width = this.clientSize.X;
            this.desc.ModeDescription.Height = this.clientSize.Y;

            Dispose();

            this.SwapChain = new SwapChain( factory, device, this.desc );
            this.backBuffer = Texture2D.FromSwapChain<Texture2D>( this.SwapChain, 0 );
            this.RenderView = new RenderTargetView( device, this.backBuffer );
            this.isFirstInitDone = true;
            this.initialized = true;
            return true;
        }


        private Point clientSize;
        public Point ClientSize { get { return this.clientSize; } }

        private void Control_ClientSizeChanged( object sender, EventArgs e )
        {
            this.initialized = false;
            this.clientSize.X = this.Control.ClientSize.Width;
            this.clientSize.Y = this.Control.ClientSize.Height;
        }


        #region IDisposable Member

        public void Dispose()
        {
            if ( this.isFirstInitDone )
            {
                this.RenderView.Dispose();
                this.backBuffer.Dispose();
                this.SwapChain.Dispose();
            }
        }

        #endregion
    }

}
