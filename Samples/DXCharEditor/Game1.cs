using System;
using DXGame;
using SharpDX.Toolkit.Graphics;
using SharpDX;
using System.Windows.Forms;

namespace DXCharEditor
{
    public class Game1 : DXGame.DXGame
    {
        private TextureNode selectedNode;

        public readonly Form1 form;

        public float ReferenceFactor { get; private set; }
        public Vector2 Scroll { get; private set; }
        public bool DrawGrid { get; set; }

        public EventHandler OnDraw;

        public void ResetZoomScroll()
        {
            this.ReferenceFactor = 0.2f;
            this.Scroll = Vector2.Zero;
        }

        Color backColor = new Color( 0.5f, 0.5f, 0.5f );
        Color overlayColor = new Color( 0.3f, 0.35f, 0.3f );

        private GameMode Mode;

        SpriteBatch spritebatch;

        DXTexture xGameTex, centerTex, overlayTex, circleTex, background;
        
        public Game1( Form1 form, Control control )
            : base( control )
        {
            this.form = form;
            this.IsMouseVisible = true;
            ResetZoomScroll();
            this.Mode = new GameMode();
            this.form.nodeViewer.SelectedChanged += nodeViewer_SelectedChanged;
            this.form.poseViewer.SelectedChanged += poseViewer_SelectedChanged;
        }

        private void poseViewer_SelectedChanged( object sender, Controls.TreeViewerEventArgs args )
        {
            this.Mode.BasePoseSelected = args.IsRoot;
        }

        private void nodeViewer_SelectedChanged( object sender, Controls.TreeViewerEventArgs args )
        {
            this.selectedNode = args.Node as TextureNode;
        }

        protected override void BeginRun()
        {
            this.Mode.Initialize( this.Window as DXGameWindow );
            this.Mode.OnMouseMove = this.OnMouseMove;
            this.Mode.OnMouseWheel = this.OnMouseWheel;
        }

        private void UpdateNodeInfo()
        {
            this.form.nodeInfo1.SelectedNode = this.form.nodeInfo1.SelectedNode;
        }

        private void OnMouseWheel( int delta )
        {
            float reSize = ( delta > 0 ) ? 0.95f : 1.05f;
            if ( this.Mode.TextureHovered && this.form.nodeInfo1.SelectedNode != null && this.form.nodeInfo1.SelectedNode.Texture != null )
            {
                this.form.nodeInfo1.SelectedNode.NodeSize *= reSize;
                UpdateNodeInfo();
            }
            else
            {
                this.ReferenceFactor *= reSize;
                this.form.nodeViewer.Root.Update( true );
            }
        }

        private void OnMouseMove()
        {
            if ( this.selectedNode != null )
            {
                TextureNode n = this.selectedNode;

                if ( this.Mode.CurrentlyChanging( n ) )
                {
                    switch ( this.Mode.Mode )
                    {
                        case EditorMode.None:
                            this.Scroll += ( this.Mode.NewMousePos - this.Mode.OldMousePos );
                            this.form.nodeViewer.Root.Update( true );
                            break;

                        case EditorMode.Rotate:
                            Vector2 oldVec = this.Mode.OldMousePos - n.GlobalPosition;
                            Vector2 newVec = this.Mode.NewMousePos - n.GlobalPosition;
                            double arc = Math.Atan2( newVec.Y, newVec.X ) - Math.Atan2( oldVec.Y, oldVec.X );
                            double newRot = n.Rotation + arc;
                            if ( newRot < 0 ) newRot += 2 * Math.PI;
                            if ( newRot >= 2 * Math.PI ) newRot -= 2 * Math.PI;

                            n.Rotation = (float)newRot;
                            break;

                        case EditorMode.Move:
                            Vector2 mouseDiff = this.Mode.NewMousePos - this.Mode.OldMousePos;
                            Vector4 diff = Vector2.Transform( mouseDiff, Matrix.RotationZ( -( n.GlobalRotation - n.Rotation ) ) );
                            Vector2 diffXY = new Vector2( diff.X, diff.Y );
                            if ( this.Mode.SubMode == EditorSubMode.CenterMoveMode )
                            {
                                Vector4 diff2 = Vector2.Transform( mouseDiff, Matrix.RotationZ( -n.GlobalRotation ) );
                                n.xCenter += diff2.X / n.Destination.Width;
                                n.yCenter += diff2.Y / n.Destination.Height;
                            }
                            n.Position += diffXY / n.ReferenceLength;
                            break;

                        case EditorMode.Aspect:
                            Vector4 oldM = Vector2.Transform( this.Mode.OldMousePos, n.TransformInv );
                            Vector4 newM = Vector2.Transform( this.Mode.NewMousePos, n.TransformInv );
                            if ( this.Mode.SubMode == EditorSubMode.AspectXMode )
                            {
                                float differ = ( newM.X < n.Destination.Width / 2 ) ? ( newM.X - oldM.X ) : ( oldM.X - newM.X );
                                n.AspectRatio -= differ / ( 0.5f * n.Destination.Width / n.AspectRatio );
                            }
                            else if ( this.Mode.SubMode == EditorSubMode.AspectYMode )
                            {
                                float differ = ( newM.Y < n.Destination.Height / 2 ) ? ( newM.Y - oldM.Y ) : ( oldM.Y - newM.Y );
                                n.AspectRatio += differ / ( 0.5f * n.Destination.Height / n.AspectRatio );
                                n.NodeSize *= 1 - ( differ / ( 0.5f * n.Destination.Height ) );
                            }
                            break;
                    }

                    //UpdateNodeInfo();
                } 
            }
        }

        protected override void LoadContent()
        {
            this.spritebatch = new SpriteBatch( this.GraphicsDevice );
            this.xGameTex = new DXTexture( Content.Load<Texture2D>( "Content//xgame.png" ) );
            this.centerTex = new DXTexture( Content.Load<Texture2D>( "Content//center.png" ) );
            this.overlayTex = new DXTexture( Content.Load<Texture2D>( "Content//overlay.png" ) );
            this.circleTex = new DXTexture( Content.Load<Texture2D>( "Content//OuterCircle.png" ) );
            this.background = new DXTexture( Content.Load<Texture2D>( "Content//background.png" ) );
        }

        protected override void UnloadContent()
        {
            this.spritebatch.Dispose();
        }

        public Vector2 GameCenter
        {
            get {
                return ( this.Window != null ) ? new Vector2( this.Window.Width * 0.5f, this.Window.Height * 0.5f ) + this.Scroll : Vector2.Zero;
        }
        }

        public float ReferenceLength 
        { 
            get 
            { 
                return (this.Window != null) ? this.Window.Height * this.ReferenceFactor : 1f; 
            } 
        }

        protected override void Draw( XGame.XGameTime gameTime )
        {
            this.GraphicsDevice.Clear( Color.Black );

            if ( this.OnDraw != null ) this.OnDraw( this, EventArgs.Empty );

            if ( this.DrawGrid && this.Window != null )
            {
                float bSize = this.ReferenceLength * 4;
                while ( bSize < 256 ) bSize *= 2;
                while ( bSize > 512 ) bSize /= 2;
                RectangleF dest =
                    new RectangleF(
                        this.Scroll.X + ( this.Window as DXGameWindow ).Control.ClientSize.Width / 2,
                        this.Scroll.Y + ( this.Window as DXGameWindow ).Control.ClientSize.Height / 2,
                        bSize, bSize );
                while ( dest.X > 0 ) dest.X -= bSize;
                while ( dest.Y > 0 ) dest.Y -= bSize;

                spritebatch.Begin();

                for ( ; dest.X < ( this.Window as DXGameWindow ).Control.ClientSize.Width; dest.X += bSize )
                {
                    RectangleF dest2 = new RectangleF( dest.X, dest.Y, dest.Width, dest.Height );
                    for ( ; dest2.Y < ( this.Window as DXGameWindow ).Control.ClientSize.Height; dest2.Y += bSize )
                    {
                        spritebatch.Draw( this.background.Texture, dest2, backColor );
                    }
                }
                spritebatch.End();
            }

            spritebatch.Begin( spritemode: SpriteSortMode.BackToFront );
            if ( ( this.form.nodeViewer.Root != null ) ) this.form.nodeViewer.Root.Draw(spritebatch );
            spritebatch.End();

            if ( this.selectedNode != null )
            {
                TextureNode n = this.selectedNode;

                spritebatch.Begin();

                spritebatch.Draw(
                    this.overlayTex.Texture, n.Destination, null, this.overlayColor,
                    n.GlobalRotation, n.Center * this.overlayTex.Size, SpriteEffects.None, 0.6f );

                if ( n.Texture != null )
                {
                    Color c = n.Color;
                    c.A = byte.MaxValue;
                    spritebatch.Draw( n.Texture, n.Destination, null, c, n.GlobalRotation, n.Origin, SpriteEffects.None, 0.5f );
                }

                if ( this.Mode.BasePoseSelected )
                {
                    spritebatch.Draw(
                        this.centerTex.Texture, n.GlobalPosition, null, Color.Red, 0,
                        this.centerTex.Origin, 0.25f, SpriteEffects.None, 0f );
                }

                Vector4 point;
                Vector2 vec;
                for ( int index = 0; index < ( this.Mode.BasePoseSelected ? 8 : 4 ); index++ )
                {
                    vec = GameMode.ModePoints[index];
                    point = Vector2.Transform( new Vector2( vec.X * n.Destination.Width, vec.Y * n.Destination.Height ), n.Transform );
                    spritebatch.Draw( 
                        this.circleTex.Texture, new Vector2( point.X, point.Y ), null, Color.White, 
                        n.GlobalRotation, this.circleTex.Origin, 0.025f, SpriteEffects.None, 0f );
                }

                spritebatch.End();
            }
        }

    }
}
