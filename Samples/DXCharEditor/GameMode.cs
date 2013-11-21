using DXGame;
using SharpDX;
using System;
using System.Windows.Forms;

namespace DXCharEditor
{

    public enum EditorSubMode
    {
        None,
        PosMoveMode,
        CenterMoveMode,
        RotateMode,
        AspectXMode,
        AspectYMode
    }

    public enum EditorMode
    {
        None,
        Move,
        Rotate,
        Aspect
    }

    public class GameMode
    {
        public static Vector2[] ModePoints = 
        {
            // Rotation Points
            new Vector2( 0, 0), new Vector2( 1, 0), new Vector2( 1, 1), new Vector2( 0, 1),
            // Aspect X Points
            new Vector2( 0, 0.5f), new Vector2( 1, 0.5f),
            // Aspect Y Points
            new Vector2( 0.5f, 0), new Vector2( 0.5f, 1)
        };

        private Cursor positionCursor = new Cursor( "Content//positionCursor.ico" );
        private Cursor rotCursor = new Cursor( "Content//rotCursor.ico" );
        private Cursor centerCursor = new Cursor( "Content//centerCursor.ico" );
        private Cursor aspectXCursor = new Cursor( "Content//aspectX.ico" );
        private Cursor aspectYCursor = new Cursor( "Content//aspectY.ico" );

        private DXGameWindow window;

        private Tuple<EditorMode, EditorSubMode, Cursor> Modus;

        public EditorMode Mode { get { return this.Modus.Item1; } }

        public EditorSubMode SubMode { get { return this.Modus.Item2; } }

        public bool IsCurrentlyChanging { get; private set; }

        public bool TextureHovered { get; private set; }

        public Vector2 OldMousePos { get; private set; }

        public Vector2 NewMousePos { get; private set; }

        public Action OnMouseMove;

        public delegate void onMouseWheel( int delta );
        public onMouseWheel OnMouseWheel;

        public GameMode() { }

        public void Initialize( DXGameWindow window )
        {
            this.window = window;
            this.window.Control.MouseDown += control_MouseDown;
            this.window.Control.MouseUp += control_MouseUp;
            this.window.Control.MouseLeave += control_MouseLeave;
            this.window.Control.MouseEnter += control_MouseEnter;
            this.window.Control.MouseMove += Control_MouseMove;
            this.window.Control.MouseWheel += Control_MouseWheel;
            this.TextureHovered = false;
            this.IsCurrentlyChanging = false;
            SetMode( EditorSubMode.None );
        }

        public void SetMode( EditorSubMode newMode )
        {
            if ( !this.IsCurrentlyChanging && this.window != null )
            {
                switch ( newMode )
                {
                    case EditorSubMode.PosMoveMode:
                        SetMode( EditorMode.Move, newMode, positionCursor );
                        break;
                    case EditorSubMode.RotateMode:
                        SetMode( EditorMode.Rotate, newMode, rotCursor );
                        break;
                    case EditorSubMode.CenterMoveMode:
                        SetMode( EditorMode.Move, newMode, centerCursor );
                        break;
                    case EditorSubMode.AspectXMode:
                        SetMode( EditorMode.Aspect, newMode, aspectXCursor );
                        break;
                    case EditorSubMode.AspectYMode:
                        SetMode( EditorMode.Aspect, newMode, aspectYCursor );
                        break;
                    case EditorSubMode.None:
                        SetMode( EditorMode.None, newMode, Cursors.Default );
                        break;
                }
                ( this.window.Cursor as DXGameWindowCursor ).DefaultCursor = this.Modus.Item3;
            }
        }

        private void SetMode( EditorMode mode, EditorSubMode subMode, Cursor cursor )
        {
            this.Modus = new Tuple<EditorMode, EditorSubMode, Cursor>( mode, subMode, cursor );
        }

        public void CheckMouseMode( Vector2 mousePos, Vector2 textureSize, float radius )
        {
            bool result = true;
            if ( mousePos.X > -radius && mousePos.X < textureSize.X + radius
                && mousePos.Y > -radius && mousePos.Y < textureSize.Y + radius )
            {
                int index = 0;
                for ( ; index < GameMode.ModePoints.Length; ++index )
                {
                    if ( Vector2.Distance( mousePos, textureSize * GameMode.ModePoints[ index ] ) < radius ) break;
                }
                if ( index < 4 ) this.SetMode( EditorSubMode.RotateMode );
                else if ( index < 6 ) this.SetMode( EditorSubMode.AspectXMode );
                else if ( index < 8 ) this.SetMode( EditorSubMode.AspectYMode );
                else this.SetMode( EditorSubMode.PosMoveMode );
            }
            else
            {
                this.SetMode( EditorSubMode.None );
                result = false;
            }
            this.TextureHovered = result;
        }

        public bool CurrentlyChanging( TextureNode node )
        {
            bool result = this.IsCurrentlyChanging;
            if ( !this.IsCurrentlyChanging )
            {
                if ( Vector2.Distance( node.GlobalPosition, this.NewMousePos ) < 10 )
                {
                    this.SetMode( EditorSubMode.CenterMoveMode );
                }
                else
                {
                    Vector4 mT = Vector2.Transform( this.NewMousePos, node.TransformInv );
                    this.CheckMouseMode( new Vector2( mT.X, mT.Y ), new Vector2( node.Destination.Width, node.Destination.Height ), 10 );
                }
            }
            return result;
        }

        private void control_MouseEnter( object sender, EventArgs e )
        {
            this.window.Control.Focus();
        }

        private void control_MouseLeave( object sender, EventArgs e )
        {
            this.IsCurrentlyChanging = false;

            ( this.window.Control.TopLevelControl as Form1 ).nodeInfo1.UpdateSelected();
        }

        private void control_MouseUp( object sender, MouseEventArgs e )
        {
            control_MouseLeave( this, EventArgs.Empty );
        }

        private void control_MouseDown( object sender, MouseEventArgs e )
        {
            this.IsCurrentlyChanging = true;
        }

        private void Control_MouseMove( object sender, MouseEventArgs e )
        {
            this.OldMousePos = this.NewMousePos;
            this.NewMousePos = new Vector2( e.X, e.Y );
            if ( this.OnMouseMove != null ) this.OnMouseMove();
        }


        private void Control_MouseWheel( object sender, MouseEventArgs e )
        {
            if ( this.OnMouseWheel != null ) this.OnMouseWheel( e.Delta );
        }

    }

}
