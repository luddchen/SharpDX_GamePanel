using System;
using DXGame;
using System.Windows.Forms;
using SharpDX.Toolkit.Graphics;
using SharpDX;

namespace GameTemplate
{

    public class Game1 : DXGame.DXGame
    {
        Form1 form;

        delegate void SetTitle( string text );
        SetTitle setTitle;

        SpriteBatch spritebatch;
        Texture2D texture;
        Vector2 origin;
        string text;

        float rot = 0f;

        public Game1( Form1 form, Control control )
            : base( control )
        {
            this.form = form;
            setTitle = form.SetTitle;
        }

        protected override void LoadContent()
        {
            this.spritebatch = new SpriteBatch( this.GraphicsDevice );
            this.texture = Content.Load<Texture2D>( "Content//xgame.png" );
            this.origin = new Vector2( this.texture.Width / 2, this.texture.Height / 2 );
        }

        protected override void UnloadContent()
        {
            this.texture.Dispose();
            this.spritebatch.Dispose();
        }

        protected override void Update( XGame.XGameTime gameTime )
        {
            this.rot += (float)((float)Math.PI / 30000000f ) * (float)gameTime.ElapsedGameTime.Ticks;
            if ( this.rot >= 2 * Math.PI ) this.rot = 0f;

            this.text = String.Format( "Game Template ( {0:F2} fps )", 10000000f / (float)gameTime.ElapsedGameTime.Ticks );
        }

        protected override void Draw( XGame.XGameTime gameTime )
        {
            this.form.Invoke( setTitle, new object[] { this.text } );
            Vector2 pos = new Vector2( this.Window.Width * 0.66f, this.Window.Height * 0.5f );

            this.GraphicsDevice.Clear( Color.Black );
            Rectangle dest = new Rectangle( 0, 0, (int)this.Window.Width, (int)this.Window.Height );
            float colVal = (float)( this.rot / (2 * Math.PI) );

            spritebatch.Begin( spritemode: SpriteSortMode.Immediate );
            spritebatch.Draw( this.texture, dest, Color.White );
            spritebatch.Draw( this.texture, pos, null, new Color(.5f, .5f, .5f, colVal), this.rot, this.origin, 0.5f, SpriteEffects.None, 0.5f );
            spritebatch.End();
        }

    }

}
