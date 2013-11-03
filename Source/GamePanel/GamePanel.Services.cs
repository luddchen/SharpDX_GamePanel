using GamePanel.ServiceProvider;
using SharpDX;
using SharpDX.Toolkit;
using SharpDX.Toolkit.Content;
using SharpDX.Toolkit.Graphics;
using System;

namespace GamePanel
{

    public partial class GamePanel
    {

        public GameServiceRegistry Services { get; private set; }

        public ContentManager Content { get; set; }

        private PanelDeviceManager panelDeviceManager;

        public GraphicsDevice GraphicsDevice 
        { 
            get { return this.panelDeviceManager.GraphicsDevice; } 
        }
        
        public void InitServices()
        {
            this.Services = new GameServiceRegistry();
            this.Content = new ContentManager( this.Services );
            this.panelDeviceManager = new PanelDeviceManager( this );

            var assemblyUri = new Uri( System.Reflection.Assembly.GetExecutingAssembly().CodeBase );
            this.Content.Resolvers.Add( new FileSystemContentResolver( System.IO.Path.GetDirectoryName( assemblyUri.LocalPath ) ) );

            this.Services.AddService( typeof( IServiceRegistry ), Services );
            this.Services.AddService( typeof( IContentManager ), Content );
        }

    }

}
