using GamePanel;
using SharpDX.Toolkit.Graphics;
using System;
using System.Windows.Forms;

namespace Test
{

    public class Game1 : GamePanel.GamePanel
    {

        public Form1 form;

        SpriteBatch spriteBatch;
        Texture2D texture;
        Texture2D texture2;

        public Game1( Control control ) : base( control ) { }

        protected override void Initialize()
        {
            spriteBatch = new SpriteBatch( GraphicsDevice );
        }

        protected override void LoadContent()
        {
            texture = Content.Load<Texture2D>( "Content//Smiley2.png" );
            texture2 = Content.Load<Texture2D>( "Content//Galaxy.png" );
        }

        protected override void UnloadContent()
        {
            texture.Dispose();
            texture2.Dispose();
            spriteBatch.Dispose();
        }

        protected override void Draw( PanelGameTime gameTime)
        {
            form.SetStatus(
                String.Format( "{0:F4} ms / frame  =  {1:F2} fps , Frame {2} , Mouse {3} {4}", 
                                this.lastFrameElapsedGameTime.Ticks / 10000.0f, 
                                (float)( 10000000.0f / (float)this.lastFrameElapsedGameTime.Ticks ), 
                                gameTime.FrameCount,
                                this.IsMouseVisible ? "visible" : "invisible",
                                this.IsMouseVisible ? "" : (this.isCursorVisible ? "active" : "inactive" ) ) );

            this.GraphicsDevice.Clear( SharpDX.Color.ForestGreen );

            spriteBatch.Begin();
            spriteBatch.Draw( texture2, new SharpDX.Rectangle( 0, 0, this.Control.Width, this.Control.Height ), SharpDX.Color.White );
            spriteBatch.Draw( texture, new SharpDX.Vector2(20f, 20f), new SharpDX.Color( 0.5f, 0.5f, 0.5f, 0.2f ) );
            spriteBatch.End();
        }

    }

}
