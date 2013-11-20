using SharpDX;
using SharpDX.Toolkit.Graphics;

namespace DXGame
{

    public class DXTexture
    {
        public DXTexture( Texture2D tex )
        {
            this.Texture = tex;
        }

        private Texture2D texture;
        public Texture2D Texture
        {
            get { return this.texture; }
            set
            {
                this.texture = value;
                if ( value != null )
                {
                    this.Size = new Vector2( this.texture.Width, this.texture.Height );
                    this.Origin = this.Size / 2;
                    this.Color = Color.White;
                }
            }
        }


        public Vector2 Origin { get; set; }

        public Vector2 Size { get; private set; }

        public Color Color { get; set; }

    }

}
