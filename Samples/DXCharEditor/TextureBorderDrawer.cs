using SharpDX;
using SharpDX.Toolkit.Graphics;

namespace DXCharEditor
{
    public class TextureBorderDrawer
    {

        PrimitiveBatch<VertexPositionColor> batch;

        BasicEffect effect;

        VertexPositionColor[] vertices;

        public TextureBorderDrawer( GraphicsDevice device )
        {
            batch = new PrimitiveBatch<VertexPositionColor>( device );
            effect = new BasicEffect( device )
            {
                VertexColorEnabled = true,
                View = Matrix.Identity,
                Projection = Matrix.Identity,
                World = Matrix.Identity
            };
            vertices = new VertexPositionColor[ 9 ];
            for ( int index = 0; index < 9; index++ )
            {
                vertices[ index ].Color = ( index % 2 == 0 ) ? SharpDX.Color.Green : SharpDX.Color.Yellow;
            }
        }

        public void Draw( TextureNode node, float width, float height )
        {
            for ( int index = 0; index < 4; index++ )
            {
                Vector2 vec = GameMode.ModePoints[ index ] * new Vector2( node.Destination.Width, node.Destination.Height );
                Vector4 pos = Vector2.Transform( vec, node.Transform );
                Vector3 pos2 = new Vector3( 2 * pos.X / width - 1.0f, 2 * pos.Y / -height + 1.0f , 0 );
                vertices[ index * 2 ].Position = pos2;
            }
            for ( int index = 0; index < 4; index++ )
            {
                vertices[index * 2 + 1].Position = (vertices[index * 2].Position + vertices[index * 2 + 2].Position ) / 2; 
            }


            vertices[ 8 ] = vertices[ 0 ];

            effect.CurrentTechnique.Passes[ 0 ].Apply();
            batch.Begin();
            batch.Draw( PrimitiveType.LineStrip, vertices );
            batch.End();
        }

    }
}
