using SharpDX;
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

        public Color Color = Color.White;

        public Texture2D texture;

        public float width = 1.0f;

        public float height = 1.0f;

        public float layer = 1.0f;

        public TextureNode() : base()
        {
        }

        public Vector2 center;

        public bool relativRotation = false;

        private float rotation;

        public float rotFactor = 0.0f;

        private Vector2 origin;

        private Rectangle dest;

        public void Draw( SpriteBatch spriteBatch, Rectangle parentDest, float parentRotation )//float parentWidth, float parentHeight, Vector2 parentCenter )
        {
            float nodeWidth = width * parentDest.Width;
            float nodeHeight = height * parentDest.Height;

            this.rotation += (float)( Math.PI / 100 ) * rotFactor;
            if ( this.rotation > Math.PI * 2 ) this.rotation = 0f;

            dest.Width = (int)nodeWidth;
            dest.Height = (int)nodeHeight;
            float parentRot = parentRotation;
            
            Vector2 relPos = new Vector2( center.X * parentDest.Width, center.Y * parentDest.Height );
            relPos = (Vector2)Vector2.Transform( relPos, Matrix.RotationZ( parentRot ) );

            dest.X = (int)( parentDest.X + relPos.X );
            dest.Y = (int)( parentDest.Y + relPos.Y );

            float nodeRotation = rotation + ( relativRotation ? parentRotation : 0 );

            if ( texture != null )
            {
                origin.X = texture.Width / 2;
                origin.Y = texture.Height / 2;

                spriteBatch.Draw( texture, dest, null, Color, nodeRotation, origin, SpriteEffects.None, layer );
            }

            foreach ( TextureNode node in this.Nodes )
            {
                node.Draw( spriteBatch, dest, nodeRotation );
            }
        }


    }

}
