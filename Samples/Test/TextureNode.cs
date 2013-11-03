using SharpDX.Toolkit.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Test
{

    public class TextureNode : TreeNode
    {

        public Texture2D texture;

        public float width = 1.0f;

        public float height = 1.0f;

        public TextureNode() : base()
        {
        }

        public void Draw( SpriteBatch spriteBatch, float parentWidth, float parentHeight )
        {
            float texWidth = width * parentWidth;
            float texHeight = height * parentHeight;
            spriteBatch.Draw( texture, new SharpDX.Rectangle( 0, 0, (int)texWidth, (int)texHeight ), new SharpDX.Color( 1f, 1f, 1f, 0.5f ) );

            foreach ( TextureNode node in this.Nodes )
            {
                node.Draw( spriteBatch, texWidth, texHeight );
            }
        }


    }

}
