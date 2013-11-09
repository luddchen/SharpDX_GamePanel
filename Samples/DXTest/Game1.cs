using SharpDX.Toolkit.Graphics;
using System;
using System.Windows.Forms;
using SharpDX;

namespace DXTest
{

    public class Game1 : DXGame.DXGame
    {

        SpriteBatch spriteBatch;
        Texture2D texture;
        Vector2 origin;
        float rot;

        public Game1( Control control ) : base( control ) { }

        protected override void LoadContent()
        {
            this.spriteBatch = new SpriteBatch( this.GraphicsDevice );
            this.texture = Texture2D.Load( this.GraphicsDevice, "Content//Galaxy.png" );
            this.origin = new Vector2( this.texture.Width / 2 , this.texture.Height / 2 );
        }

        protected override void Update( XGame.XGameTime gameTime )
        {
            this.rot += (float)( gameTime.ElapsedGameTime.Milliseconds * Math.PI / 1000.0 );
            if ( this.rot > 2 * Math.PI ) this.rot = 0;
        }

        protected override void Draw( XGame.XGameTime gameTime )
        {
            this.GraphicsDevice.Clear( SharpDX.Color.BlueViolet );
            this.spriteBatch.Begin();
            this.spriteBatch.Draw( 
                texture,
                new Rectangle( (int)this.Platform.MainWindow.Width / 2, (int)this.Platform.MainWindow.Height / 2, (int)this.Platform.MainWindow.Width, (int)this.Platform.MainWindow.Height ), 
                null, 
                SharpDX.Color.White, 
                rot, 
                this.origin, 
                SpriteEffects.None, 
                0.5f );
            this.spriteBatch.End();
        }
    }

}
