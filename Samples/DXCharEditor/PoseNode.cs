using System;
using System.Collections.Generic;

namespace DXCharEditor
{

    public class PoseNode
    {

        public TextureNode Node;

        public Dictionary<string, object> Properties;


        public PoseNode( TextureNode node )
        {
            this.Node = node;
            this.Properties = new Dictionary<string, object>();
        }


        public void SetProperty( string name, object value )
        {
            if ( this.Properties.ContainsKey( name ) )
            {
                this.Properties[ name ] = value;
            }
            else
            {
                this.Properties.Add( name, value );
            }
        }

        public object GetProperty( string name )
        {
            if ( this.Properties.ContainsKey( name ) ) return this.Properties[ name ];
            return null;
        }

        public void InitializeNode()
        {
            foreach ( string name in this.Properties.Keys )
            {
                this.Node.SetProperty( name, this.Properties[ name ] );
            }
        }

        public List<string> GetKeysOfDifferentValues( PoseNode poseNode )
        {
            List<string> keys = new List<string>();
            if ( this.Node == poseNode.Node )
            {
                foreach ( string property in this.Properties.Keys )
                {
                    if ( poseNode.Properties.ContainsKey( property ) )
                    {
                        if ( (float)this.Properties[ property ] != (float)poseNode.Properties[ property ] )
                        {
                            keys.Add( property );
                        }
                    }
                }
            }

            return keys;
        }

        public override bool Equals( object obj )
        {
            if ( !(obj is PoseNode) ) return false;
            if ( this.Node != ( obj as PoseNode ).Node ) return false; 

            bool equals = true;
            foreach ( string property in this.Properties.Keys )
            {
                if ( ( obj as PoseNode ).Properties.ContainsKey( property ) )
                {
                    if ( (float)this.Properties[ property ] != (float)( obj as PoseNode ).Properties[ property ] )
                    {
                        equals = false;
                        break;
                    }
                }
                else
                {
                    equals = false;
                    break;
                }
            }

            return equals;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override string ToString()
        {
            return base.ToString();
        }

        public void Clear()
        {
            this.Node = null;
            this.Properties.Clear();
        }
    }

}
