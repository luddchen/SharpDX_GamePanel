using System;
using System.Windows.Forms;
using XGame;

namespace DXGame
{

    public class DXGamePlatform : XGamePlatform
    {

        public DXGamePlatform( XGame.XGame game, Control control ) : base( game )
        {
            if ( control == null ) throw new ArgumentNullException( "control" );
            this.MainWindow = new DXGameWindow( this, control );
            this.ActiveWindow = this.MainWindow;
            this.allGameWindows.Add( this.MainWindow );
            this.DeviceManager = new DXGameDeviceManager( this );
        }

    }

}
