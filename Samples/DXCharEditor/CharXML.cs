using SharpDX;
using System;
using System.IO;
using System.Windows.Forms;
using System.Xml;

namespace DXCharEditor
{

    public class CharXML
    {

        public static void WriteChar( string fileName, TextureNode root )
        {
            XmlTextWriter writer = new XmlTextWriter( fileName, null );

            writer.WriteStartDocument();
            writer.Formatting = Formatting.Indented;
            writer.WriteStartElement( "Char" );

                writer.WriteStartElement( "Nodes" );
                    WriteNode( writer, root, Path.GetFullPath(fileName) );
                writer.WriteEndElement();

            writer.WriteEndElement();
            writer.WriteEndDocument();
            writer.Close();
        }

        private static void WriteNode( XmlTextWriter writer, TextureNode node, string filePath )
        {
            writer.WriteStartElement( "Node" );
            writer.WriteAttributeString( "name", node.Text );

            writer.WriteStartElement( "Position" );
            writer.WriteAttributeString( "x", node.xLocation.ToString() );
            writer.WriteAttributeString( "y", node.yLocation.ToString() );
            writer.WriteEndElement();

            writer.WriteStartElement( "Center" );
            writer.WriteAttributeString( "x", node.xCenter.ToString() );
            writer.WriteAttributeString( "y", node.yCenter.ToString() );
            writer.WriteEndElement();

            if ( node.Texture != null )
            {
                writer.WriteStartElement( "Texture" );
                writer.WriteAttributeString( "name", GetRelativPath( node.TextureName, filePath ) );
                writer.WriteAttributeString( "safeName", node.SafeTextureName );
                writer.WriteEndElement();
            }

            writer.WriteStartElement( "Color" );
            Color color = node.Color;
            writer.WriteAttributeString( "A", color.A.ToString() );
            writer.WriteAttributeString( "R", color.R.ToString() );
            writer.WriteAttributeString( "G", color.G.ToString() );
            writer.WriteAttributeString( "B", color.B.ToString() );
            writer.WriteEndElement();

            writer.WriteStartElement( "Dimension" );
            writer.WriteAttributeString( "Size", node.NodeSize.ToString() );
            writer.WriteAttributeString( "Aspect", node.AspectRatio.ToString() );
            writer.WriteEndElement();

            writer.WriteStartElement( "Rotation" );
            writer.WriteAttributeString( "value", node.Rotation.ToString() );
            writer.WriteEndElement();

            writer.WriteStartElement( "Layer" );
            writer.WriteAttributeString( "value", node.Layer.ToString() );
            writer.WriteEndElement();

            foreach ( TreeNode child in node.Nodes )
            {
                WriteNode( writer, child as TextureNode, filePath );
            }

            writer.WriteEndElement();
        }


        public static TextureNode ReadChar( string fileName, Form1 form )
        {
            TextureNode output = null;

            XmlTextReader reader = new XmlTextReader( fileName );

            try
            {
                while ( reader.Read() )
                {
                    if ( reader.NodeType == XmlNodeType.Element )
                    {
                        if ( reader.Name == "Node" )
                        {
                            output = ReadNode( reader, Path.GetFullPath( fileName ), form );
                        }
                    }
                }

                reader.Close();
            }
            catch ( Exception e )
            {
                Console.WriteLine( e );
            }

            return output;
        }

        private static TextureNode ReadNode( XmlTextReader reader, string path, Form1 form )
        {
            TextureNode output = new TextureNode( reader.GetAttribute(0) );

            while ( reader.Read() )
            {
                if ( reader.NodeType == XmlNodeType.EndElement )
                {
                    if ( reader.Name == "Node" )
                    {
                        return output;
                    }
                }

                if ( reader.NodeType == XmlNodeType.Element )
                {
                    if ( reader.Name == "Node" )
                    {
                        output.Nodes.Add( ReadNode( reader, path, form ) );
                    }

                    if ( reader.Name == "Position" )
                    {
                        output.xLocation = float.Parse( reader.GetAttribute( 0 ) );
                        output.yLocation = float.Parse( reader.GetAttribute( 1 ) );
                    }

                    if ( reader.Name == "Center" )
                    {
                        output.xCenter = float.Parse( reader.GetAttribute( 0 ) );
                        output.yCenter = float.Parse( reader.GetAttribute( 1 ) );
                    }

                    if ( reader.Name == "Texture" )
                    {
                        output.TextureName = Path.GetFullPath( Path.Combine( path, reader.GetAttribute( 0 ) ) );
                        output.SafeTextureName = reader.GetAttribute( 1 );
                        output.Texture =  SharpDX.Toolkit.Graphics.Texture2D.Load( form.Game.GraphicsDevice, output.TextureName );
                        output.Image = System.Drawing.Image.FromFile( output.TextureName );
                        output.Checked = true;
                    }

                    if ( reader.Name == "Color" )
                    {
                        Color color = new Color();
                        color.A = byte.Parse( reader.GetAttribute( 0 ) );
                        color.R = byte.Parse( reader.GetAttribute( 1 ) );
                        color.G = byte.Parse( reader.GetAttribute( 2 ) );
                        color.B = byte.Parse( reader.GetAttribute( 3 ) );
                        output.Color = color;
                    }

                    if ( reader.Name == "Dimension" )
                    {
                        output.NodeSize = float.Parse( reader.GetAttribute( 0 ) );
                        output.AspectRatio = float.Parse( reader.GetAttribute( 1 ) );
                    }

                    if ( reader.Name == "Rotation" )
                    {
                        output.Rotation = float.Parse( reader.GetAttribute( 0 ) );
                    }

                    if ( reader.Name == "Layer" )
                    {
                        output.Layer = float.Parse( reader.GetAttribute( 0 ) );
                    }

                }
            }

            return output;
        }


        private static string GetRelativPath( string filePath, string appPath )
        {
            int index = 0;
            while ( index < filePath.Length && index < appPath.Length )
            {
                index++;
                if ( filePath[ index ] != appPath[ index ] )
                {
                    break;
                }
            }
            string output = filePath.Substring( 0, index );
            string filePathRest = filePath.Substring( index, filePath.Length - index );
            string appPathRest = appPath.Substring( index, appPath.Length - index );

            string prePath = ".." + Path.DirectorySeparatorChar;
            int pos = 0;

            while ( pos < appPathRest.Length 
                &&( index = appPathRest.IndexOf( Path.DirectorySeparatorChar, pos ) ) != -1 )
            {
                prePath += ".." + Path.DirectorySeparatorChar;
                pos += index;
            }

            return Path.Combine(prePath, filePathRest);
        }

    }

}
