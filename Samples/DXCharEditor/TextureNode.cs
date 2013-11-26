using DXCharEditor.Controls;
using SharpDX;
using SharpDX.Toolkit.Graphics;
using System;
using System.Windows.Forms;

namespace DXCharEditor
{

    public class TextureNode : TreeViewerNode
    {

        public System.Drawing.Image Image;

        public string TextureName;

        public string SafeTextureName;

        public float ReferenceLength = 1;

        private Texture2D texture;
        public Texture2D Texture
        {
            get { return this.texture; }
            set
            {
                this.texture = value;
                if ( value != null )
                {
                    this.AspectRatio = (float)this.texture.Width / (float)this.texture.Height;
                    this.TextureSize = new Vector2( this.texture.Width, this.texture.Height );
                }
            }
        }
        public Vector2 TextureSize { get; private set; }

        public Matrix Transform { get; private set; }
        public Matrix TransformInv { get; private set; }

        private Vector2 origin;
        public Vector2 Origin
        {
            get
            {
                this.origin.X = (this.texture != null) ? this.texture.Width * this.xCenter : 0;
                this.origin.Y = (this.texture != null) ? this.texture.Height * this.yCenter : 0;
                return this.origin;
            }
        }

        private float nodeSize;
        public float NodeSize 
        {
            get { return this.nodeSize; }
            set { this.nodeSize = Clamp( 0.01f, value, 100f ); Update( true ); }
        }

        private float aspectRatio;
        public float AspectRatio
        {
            get { return this.aspectRatio; }
            set { this.aspectRatio = Clamp( 0.01f, value, 100f ); Update( true ); }
        }


        public float GlobalAspectRatio { get; private set; }

        public Vector2 GlobalPosition { get; private set; }

        private Vector2 position;
        public Vector2 Position
        {
            get { return this.position; }
            set { this.position = value; Update( true ); }
        }

        public float xLocation
        {
            get { return this.position.X; }
            set { this.position.X = Clamp( -1000f, value, 1000f); Update( true ); }
        }

        public float yLocation
        {
            get { return this.position.Y; }
            set { this.position.Y = Clamp( -1000f, value, 1000f ); Update( true ); }
        }

        private Vector2 center;
        public Vector2 Center
        {
            get { return this.center; }
            set { this.center = value; Update( true ); }
        }

        public float xCenter
        {
            get { return this.center.X; }
            set { this.center.X = Clamp( -1000f, value, 1000f ); Update( true ); }
        }

        public float yCenter
        {
            get { return this.center.Y; }
            set { this.center.Y = Clamp( -1000f, value, 1000f ); Update( true ); }
        }

        public Color Color = Color.White;

        public float Alpha
        {
            get { return (float)this.Color.A / (float)byte.MaxValue; }
            set { this.Color.A = (byte)(value * byte.MaxValue); }
        }

        private float rotation;
        public float Rotation 
        {
            get { return this.rotation; }
            set { this.rotation = RotWrap( value, (float)( 2 * Math.PI ) ); Update( true ); }
        }

        public float RotationDegree
        {
            set { this.Rotation = (float)( value * Math.PI / 180.0 ); }
            get { return (float)(this.Rotation * 180.0 / Math.PI); }
        }

        public float GlobalRotation { get; private set; }

        private RectangleF dest;
        public RectangleF Destination { get { return this.dest; } }

        private float layer;
        public float Layer { get { return this.layer; } set { this.layer = Clamp( 0f, value, 1f ); } }

        public TextureNode( string name ) : this( name, 0 ) { }

        public TextureNode( string name, int lastCount )
            : base( name, lastCount )
        {
            this.Layer = 0.5f;
            this.center = new Vector2( .5f, .5f );
            this.NodeSize = 1f;
            this.AspectRatio = 1f;
            Update( false );
        }

        public void SetProperty( string propertyName, object value )
        {
            System.Reflection.PropertyInfo prop = typeof( TextureNode ).GetProperty( propertyName );
            if ( prop != null ) prop.SetValue( this, value, null );
            else Console.WriteLine( "property not found : " + propertyName );
        }

        public object GetProperty( string propertyName )
        {
            System.Reflection.PropertyInfo prop = typeof( TextureNode ).GetProperty( propertyName );
            if ( prop != null ) return prop.GetValue( this, null );
            else throw new Exception( "property not found : " + propertyName );
        }

        public void Update( bool updateChilds )
        {
            if ( this.Parent != null && this.Parent is TextureNode )
            {
                TextureNode parent = this.Parent as TextureNode;
                this.ReferenceLength = parent.ReferenceLength * parent.NodeSize; ;
                this.GlobalRotation = this.Rotation + parent.GlobalRotation;
                this.GlobalAspectRatio = this.AspectRatio;// need rework: +parent.GlobalAspectRatio;
                Vector4 posNew = Vector2.Transform( this.ReferenceLength * this.position, Matrix.RotationZ( parent.GlobalRotation ) );
                this.dest.Location = parent.GlobalPosition + new Vector2( posNew.X, posNew.Y );
            }
            else
            {   // Update Root
                if ( this.TreeView != null )
                {
                    Game1 game = ( this.TreeView.TopLevelControl as Form1 ).Game;
                    this.ReferenceLength = game.ReferenceLength;
                    this.dest.Location = game.GameCenter + this.position * this.ReferenceLength;
                    this.GlobalRotation = this.Rotation;
                    this.GlobalAspectRatio = this.AspectRatio;
                }
            }

            this.dest.Height = this.ReferenceLength * this.NodeSize;
            this.dest.Width = dest.Height * this.GlobalAspectRatio;
            this.GlobalPosition = this.dest.Location;

            this.Transform =
                Matrix.Translation( -new Vector3( this.Destination.Width * this.Center.X, this.Destination.Height * this.Center.Y, 0 ) )
                * Matrix.RotationZ( this.GlobalRotation )
                * Matrix.Translation( new Vector3( this.Destination.X, this.Destination.Y, 0 ) );
            this.TransformInv = Matrix.Invert( this.Transform );

            if ( updateChilds )
            {
                foreach ( TreeNode node in this.Nodes )
                {
                    if ( node is TextureNode ) ( node as TextureNode ).Update( true );
                }
            }
        }

        public void Draw( SpriteBatch spriteBatch )
        {
            if ( Texture != null )//&& this.Checked )
                spriteBatch.Draw( this.texture, this.dest, null, this.Color, this.GlobalRotation, this.Origin, SpriteEffects.None, this.Layer );

            foreach ( TreeNode node in this.Nodes )
                if ( node is TextureNode )
                    ( node as TextureNode ).Draw( spriteBatch );

        }

        public override void Clear()
        {
            if ( this.Image != null ) this.Image.Dispose();

            base.Clear();
        }

        public static float Clamp( float min, float value, float max )
        {
            return Math.Max( min, Math.Min( value, max ) );
        }

        private static float RotWrap( float value, float max )
        {
            float result = value;
            while ( result >= max ) result -= max;
            while ( result < 0 ) result += max;
            return result;
        }
    }

}
