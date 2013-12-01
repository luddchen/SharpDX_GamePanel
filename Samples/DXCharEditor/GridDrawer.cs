using SharpDX;
using SharpDX.Toolkit.Graphics;

namespace DXCharEditor
{
    public class GridDrawer
    {
        const float targetBlockSize = 160;

        public int subDivisions = 10;

        PrimitiveBatch<VertexPositionColor> batch;

        BasicEffect effect;

        GraphicsDevice device;

        DXGame.DXGameWindow window;

        SharpDX.Color[] Colors = { SharpDX.Color.DarkGreen, SharpDX.Color.DarkOliveGreen };

        public GridDrawer( DXGame.DXGameWindow window )
        {
            this.window = window;
            this.device = ( ( window.Platform as DXGame.DXGamePlatform ).DeviceManager as DXGame.DXGameDeviceManager ).GraphicsDevice;
            batch = new PrimitiveBatch<VertexPositionColor>( device );
            effect = new BasicEffect( device )
            {
                VertexColorEnabled = true,
                View = Matrix.Identity,
                Projection = Matrix.Identity,
                World = Matrix.Identity
            };
        }

        public void Draw( Vector2 scroll, float size )
        {
            float width = this.window.Control.ClientSize.Width;
            float height = this.window.Control.ClientSize.Height;
            float bSize = size;
            while ( bSize < targetBlockSize / subDivisions ) bSize *= 2;
            while ( bSize > targetBlockSize ) bSize /= subDivisions;
            Vector2 blockSize = new Vector2( bSize / width, bSize / height );

            Vector2 dest = new Vector2( scroll.X / width, -scroll.Y / height ) * 2;
            int xPos = 0, yPos = 0;

            while ( dest.X > -1 ) { dest.X -= blockSize.X; xPos--; }
            while ( dest.Y > -1 ) { dest.Y -= blockSize.Y; yPos--; }

            VertexPositionColor start = new VertexPositionColor();
            VertexPositionColor end = new VertexPositionColor();

            effect.CurrentTechnique.Passes[ 0 ].Apply();
            batch.Begin();

            start.Position.Y = -1;
            end.Position.Y = 1;
            for ( ; dest.X <= 1; dest.X += blockSize.X, xPos++ )
            {
                start.Color = end.Color = ( xPos % subDivisions == 0 ) ? Colors[ 0 ] : Colors[ 1 ];
                start.Position.X = end.Position.X = dest.X;
                batch.DrawLine( start, end );
            } 

            start.Position.X = -1;
            end.Position.X = 1;
            for ( ; dest.Y <= 1; dest.Y += blockSize.Y, yPos++ )
            {
                start.Color = end.Color = ( yPos % subDivisions == 0 ) ? Colors[ 0 ] : Colors[ 1 ];
                start.Position.Y = end.Position.Y = dest.Y;
                batch.DrawLine( start, end );
            }

            batch.End();
        }

    }
}
