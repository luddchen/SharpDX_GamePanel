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

            this.Services = new GameServiceRegistry();
            this.Platform = new DXGamePlatform( this, control );
            this.Content = new ContentManager( this.Services );

            this.Content.Resolvers.Add( new FileSystemContentResolver( this.Platform.DefaultAppDirectory ) );

            this.Services.AddService( typeof( IServiceRegistry ), Services );
            this.Services.AddService( typeof( IContentManager ), Content );
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
