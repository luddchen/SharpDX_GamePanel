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

        public Game1( Control control ) : base( control ) { }

        protected override void Initialize()
        {
            spriteBatch = new SpriteBatch( Device );
        }

        protected override void LoadContent()
        {
            texture = Texture2D.Load( Device, "Content//test.PNG" );
        }

        protected override void Dispose( bool disposing )
        {
            texture.Dispose();
            spriteBatch.Dispose();
            base.Dispose( disposing );
        }

        protected override void Draw()
        {
            form.SetStatus( String.Format( "{0:F4} ms / frame  =  {1:F2} fps", this.lastFrameElapsedTime.Ticks / 10000.0f, (float)( 10000000.0f / (float)this.lastFrameElapsedTime.Ticks ) ) );

            this.Device.Clear( SharpDX.Color.ForestGreen );

            spriteBatch.Begin();
            spriteBatch.Draw( texture, new SharpDX.Rectangle( 0, 0, this.Control.Width, this.Control.Height ), SharpDX.Color.White );
            spriteBatch.End();
        }

    }

}
