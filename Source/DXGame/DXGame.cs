using SharpDX;
using SharpDX.Toolkit;
using SharpDX.Toolkit.Content;
using System;
using System.Windows.Forms;
using XGame;

namespace DXGame
{

    public class DXGame : XGame.XGame
    {
        public GameServiceRegistry Services { get; private set; }

        public ContentManager Content { get; set; }

        public DXGame( Control control )
            : base()
        {
            if ( control == null ) throw new ArgumentNullException( "control" );
            if ( control.TopLevelControl is Form ) ( control.TopLevelControl as Form ).FormClosing += DXGame_FormClosing;
            if ( control.TopLevelControl is Form ) ( control.TopLevelControl as Form ).Disposed += DXGame_Disposed;
            if ( control.TopLevelControl is Form ) ( control.TopLevelControl as Form ).HandleCreated += DXGame_HandleCreated;

            this.Services = new GameServiceRegistry();
            this.Platform = new DXGamePlatform( this, control );
            this.Content = new ContentManager( this.Services );

            this.Content.Resolvers.Add( new FileSystemContentResolver( this.Platform.DefaultAppDirectory ) );

            this.Services.AddService( typeof( IServiceRegistry ), Services );
            this.Services.AddService( typeof( IContentManager ), Content );
            this.IsActive = false;
        }

        private void DXGame_HandleCreated( object sender, EventArgs e )
        {
            this.IsActive = true;
            Console.WriteLine( "handle created" );
        }

        private void DXGame_Disposed( object sender, EventArgs e )
        {
            Console.WriteLine( "disposed signal" );
            this.IsActive = false;
            this.Exit();
        }

        private void DXGame_FormClosing( object sender, FormClosingEventArgs e )
        {
            this.IsActive = false;
            if ( Platform.IsRunning ) e.Cancel = true;
            Console.WriteLine( "closing signal " + e.CloseReason );
            this.Exit();
        }

        public SharpDX.Toolkit.Graphics.GraphicsDevice GraphicsDevice
        {
            get
            {
                return ( this.Platform.DeviceManager as DXGameDeviceManager ).GraphicsDevice;
            }
        }

    }

}
