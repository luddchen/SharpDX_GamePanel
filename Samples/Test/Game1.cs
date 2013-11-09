using GamePanel;
using SharpDX.Toolkit.Graphics;
using System;
using System.Windows.Forms;

namespace Test
{

    public class Game1 : GamePanel.PanelGame
    {

        public Form1 form;

        public TextureNode selected;

        SpriteBatch spriteBatch;

        int updates;

        public Game1( Control control ) : base( control ) { }

        protected override void Initialize()
        {
            Console.WriteLine( "Game1.Initialize();" );
        }

        protected override void BeginRun()
        {
            Console.WriteLine( "Game1.BeginRun();" );
        }

        protected override void EndRun()
        {
            Console.WriteLine( "Game1.EndRun();" );
        }

        protected override void LoadContent()
        {
            Console.WriteLine( "Game1.Loadcontent();" );
            spriteBatch = new SpriteBatch( GraphicsDevice );
        }

        protected override void UnloadContent()
        {
            Console.WriteLine( "Game1.Unloadcontent();" );
            spriteBatch.Dispose();
        }

        protected override void Update( PanelGameTime gameTime )
        {
            updates++;
        }

        protected override void Draw( PanelGameTime gameTime )
        {
            form.SetStatus(
                String.Format( "{0:F4} ms / frame  =  {1:F2} fps , Frame {2} , Mouse {3} , GameTime {4} , Updates {5} ", 
                                gameTime.ElapsedGameTime.Ticks / 10000.0f, 
                                (float)( 10000000.0f / (float)gameTime.ElapsedGameTime.Ticks ), 
                                gameTime.FrameCount,
                                this.IsMouseVisible ? "visible" : "invisible",
                                gameTime.TotalGameTime,
                                updates) );
            updates = 0;

            if ( this.form.RootNode != null )
            {
                this.GraphicsDevice.Clear( SharpDX.Color.Black );
                SharpDX.Rectangle dest = 
                    new SharpDX.Rectangle( 
                        this.Window.ClientSize.X / 2, 
                        this.Window.ClientSize.Y / 2, 
                        this.Window.ClientSize.X, 
                        this.Window.ClientSize.Y );

                spriteBatch.Begin( spritemode: SpriteSortMode.BackToFront );
                this.form.RootNode.Draw( spriteBatch, dest, 0f );
                spriteBatch.End();
            }
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

                    newNode.icon = System.Drawing.Image.FromFile( name );
                }
            }

            return newNode;
        }

    }

}
