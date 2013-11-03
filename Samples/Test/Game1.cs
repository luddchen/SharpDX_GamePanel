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

        public Game1( Control control ) : base( control ) { }

        protected override void Initialize()
        {
            spriteBatch = new SpriteBatch( GraphicsDevice );
        }

        protected override void LoadContent()
        {
            texture = Content.Load<Texture2D>( "Content//Smiley2.png" );
            form.RootNode.texture = Content.Load<Texture2D>( "Content//Galaxy.png" );
        }

        protected override void UnloadContent()
        {
            texture.Dispose();
            spriteBatch.Dispose();
        }

        protected override void Draw( PanelGameTime gameTime)
        {
            form.SetStatus(
                String.Format( "{0:F4} ms / frame  =  {1:F2} fps , Frame {2} , Mouse {3} , GameTime {4} ", 
                                gameTime.ElapsedGameTime.Ticks / 10000.0f, 
                                (float)( 10000000.0f / (float)this.lastFrameElapsedGameTime.Ticks ), 
                                gameTime.FrameCount,
                                this.IsMouseVisible ? "visible" : "invisible",
                                gameTime.TotalGameTime) );

            this.GraphicsDevice.Clear( SharpDX.Color.Black );

            spriteBatch.Begin();
            this.form.RootNode.Draw( spriteBatch, this.Control.Width, this.Control.Height );
            spriteBatch.Draw( texture, new SharpDX.Vector2(20f, 20f), new SharpDX.Color( 0.5f, 0.5f, 0.5f, 0.2f ) );
            spriteBatch.End();
        }

        public TextureNode LoadBackgroundTexture( string name, string safeFileName )
        {
            TextureNode newNode = null;
            Texture2D tex = null;
            try
            {
                tex = Texture2D.Load( this.GraphicsDevice, name );
            }
            catch ( Exception ) 
            {
                //this.form.SetStatus2( "can´t load " + name);
            }
            finally
            {
                if ( tex != null )
                {
                    this.form.SetStatus2( safeFileName );
                    newNode = new TextureNode();
                    newNode.texture = tex;
                    newNode.Text = safeFileName;
                    newNode.width = 0.9f;
                    newNode.height = 0.9f;
                }
            }

            return newNode;
        }

    }

}
