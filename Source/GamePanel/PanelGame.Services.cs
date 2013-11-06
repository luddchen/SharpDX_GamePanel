using GamePanel.ServiceProvider;
using SharpDX;
using SharpDX.Toolkit;
using SharpDX.Toolkit.Content;
using SharpDX.Toolkit.Graphics;

namespace GamePanel
{

    public partial class PanelGame
    {

        public GameServiceRegistry Services { get; private set; }

        public ContentManager Content { get; set; }

        private IGraphicsDeviceManager graphicsDeviceManager;
        private IGraphicsDeviceService graphicsDeviceService;

        public GraphicsDevice GraphicsDevice 
        { 
            get { return this.graphicsDeviceService.GraphicsDevice; } 
        }
        

        private void InitServices()
        {
            this.Services = new GameServiceRegistry();
            this.Content = new ContentManager( this.Services );
            this.graphicsDeviceManager = new PanelDeviceManager( this );
            this.graphicsDeviceService = this.graphicsDeviceManager as IGraphicsDeviceService;    // can be removed until gameloop works

            this.Content.Resolvers.Add( new FileSystemContentResolver( this.gamePlatform.DefaultAppDirectory ) );

            this.Services.AddService( typeof( IServiceRegistry ), Services );
            this.Services.AddService( typeof( IContentManager ), Content );
        }


        // todo
        private void InitializePendingGameSystems( bool loadContent = false )
        {
            //// Add all game systems that were added to this game instance before the game started.
            //while ( pendingGameSystems.Count != 0 )
            //{
            //    pendingGameSystems[ 0 ].Initialize();

            //    if ( loadContent && pendingGameSystems[ 0 ] is IContentable )
            //    {
            //        ( (IContentable)pendingGameSystems[ 0 ] ).LoadContent();
            //    }

            //    pendingGameSystems.RemoveAt( 0 );
            //}
        }

        // todo
        private void LoadContentSystems() { }

        // todo
        private void UnloadContentSystems() { }

        // todo
        private void UpdateGameSystems( PanelGameTime gameTime ) { }

        // todo
        private void DrawGameSystems( PanelGameTime gameTime ) { }

    }

}
