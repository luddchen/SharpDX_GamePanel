using System;
using System.Collections.Generic;

namespace DXCharEditor
{

    public class PoseNodeValue
    {

        public readonly TextureNode Node;

        public readonly Dictionary<string, object> Properties;


        public PoseNodeValue( TextureNode node )
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

    }

}
