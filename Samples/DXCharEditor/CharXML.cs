using SharpDX;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using System.Xml;

namespace DXCharEditor
{

    public class CharXML
    {

        public static void WriteChar( string fileName, TextureNode root, List<PoseNode> poses )
        {
            XmlTextWriter writer = new XmlTextWriter( fileName, null );

            writer.WriteStartDocument();
            writer.Formatting = Formatting.Indented;
            writer.WriteStartElement( "Char" );

                writer.WriteStartElement( "Nodes" );
                    WriteNode( writer, root, Path.GetFullPath(fileName) );
                writer.WriteEndElement();

                writer.WriteStartElement( "Poses" );
                foreach ( PoseNode node in poses )
                {
                    writePose( writer, node, root );
                }
                writer.WriteEndElement();

            writer.WriteEndElement();
            writer.WriteEndDocument();
            writer.Close();
        }

        private static void writePose( XmlTextWriter writer, PoseNode pose, TextureNode root )
        {
            writer.WriteStartElement( "Pose" );
            writer.WriteAttributeString( "name", pose.Text );

            foreach ( PoseNodeValue poseNodeValue in pose.NodeValues )
            {
                writer.WriteStartElement( "PoseNode" );
                writer.WriteAttributeString( "name", poseNodeValue.Node.Text );
                string path = "";
                TreeNode t = poseNodeValue.Node;
                int cancelCounter = 0;
                while ( t != root && ++cancelCounter < 100 )
                {
                    path = t.Parent.Nodes.IndexOf( t ) + "." + path;
                    t = t.Parent;
                }
                writer.WriteAttributeString( "path", path );
                PoseMode poseMode = pose.Mode;
                writer.WriteAttributeString( "type", poseMode.ToString() );

                foreach ( string property in poseNodeValue.Properties.Keys )
                {
                    writer.WriteStartElement( "Property" );
                    writer.WriteAttributeString( "name", property );
                    writer.WriteAttributeString( "value", poseNodeValue.Properties[property].ToString() );
                    writer.WriteEndElement();
                }

                writer.WriteEndElement();
            }

            writer.WriteEndElement();
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
                Console.WriteLine( node.TextureName + "  " + filePath + "  " + GetRelativPath( node.TextureName, filePath ) );
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
            TextureNode root = null;

            XmlTextReader reader = new XmlTextReader( fileName );

            try
            {
                while ( reader.Read() )
                {
                    if ( reader.NodeType == XmlNodeType.Element )
                    {
                        if ( reader.Name == "Node" )
                        {
                            root = ReadNode( reader, Path.GetFullPath( fileName ), form );
                        }

                        if ( reader.Name == "Pose" && root != null )
                        {
                            form.poseViewer.IsLoading = true;

                            PoseNode pose = ReadPose( reader, root );
                            form.poseViewer.Tree.Nodes.Add( pose );
                            form.poseViewer.Tree.SelectedNode = pose;
                            pose.RestorePose();

                            form.poseViewer.IsLoading = false;
                        }
                    }
                }

                reader.Close();
            }
            catch ( Exception e )
            {
                Console.WriteLine( e );
            }

            return root;
        }

        private static PoseNode ReadPose( XmlTextReader reader, TextureNode root )
        {
            PoseNode pose = new PoseNode( reader.GetAttribute( 0 ) );

            while ( reader.Read() ) 
            {
                if ( reader.NodeType == XmlNodeType.EndElement )
                {
                    if ( reader.Name == "Pose" )
                    {
                        return pose;
                    }
                }

                if ( reader.NodeType == XmlNodeType.Element )
                {
                    if ( reader.Name == "PoseNode" )
                    {
                        string[] path = reader.GetAttribute( 1 ).Split( '.' ); 
                        TreeNode node = root;
                        node = root;
                        for ( int index = 0; index < path.Length; index++ )
                        {
                            if ( path.Length > 0 )
                            {
                                int i = 0;
                                if ( int.TryParse( path[ index ], out i ) )
                                {
                                    node = node.Nodes[ i ];
                                }
                            }
                        }
                        PoseNodeValue poseNode = new PoseNodeValue( node as TextureNode );

                        ReadProperty( reader, poseNode );
                        pose.NodeValues.Add( poseNode );
                    }

                    if ( reader.Name == "Pose" )
                    {
                        PoseNode pose2 = ReadPose( reader, root );
                        pose.Nodes.Add( pose2 );
                    }
                }
            }
            return pose;
        }

        private static void ReadProperty( XmlTextReader reader, PoseNodeValue poseNode )
        {
            while ( reader.Read() )
            {
                if ( reader.NodeType == XmlNodeType.EndElement )
                {
                    if ( reader.Name == "PoseNode" )
                    {
                        break;
                    }
                }

                if ( reader.NodeType == XmlNodeType.Element )
                {
                    if ( reader.Name == "Property" )
                    {
                        string pName = reader.GetAttribute( 0 );
                        float pValue = float.Parse( reader.GetAttribute( 1 ) );
                        poseNode.SetProperty( pName, pValue );
                    }
                }

            }
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
            string fileDirectory = Path.GetDirectoryName( filePath );
            string appDirectory = Path.GetDirectoryName( appPath );
            int index = 0;
            while ( index < fileDirectory.Length && index < appDirectory.Length )
            {
                if ( fileDirectory[ index ] != appDirectory[ index ] )
                {
                    break;
                }
                index++;
            }
            string output = fileDirectory.Substring( 0, index );
            string filePathRest = fileDirectory.Substring( index, fileDirectory.Length - index ) + Path.GetFileName(filePath);
            string appPathRest = appDirectory.Substring( index, appDirectory.Length - index );

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
