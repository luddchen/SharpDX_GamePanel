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

        public static void WriteChar( string fileName, TextureNode root, List<Pose> poseList, Pose basePose )
        {
            XmlTextWriter writer = new XmlTextWriter( fileName, null );

            writer.WriteStartDocument();
            writer.Formatting = Formatting.Indented;
            writer.WriteStartElement( "Char" ); // + char name ?

                writer.WriteStartElement( "Nodes" );
                    WriteNode( writer, root, Path.GetFullPath(fileName) );
                writer.WriteEndElement();

                if ( basePose != null && poseList.IndexOf( basePose ) != -1 && poseList.Count > 1 )
                {
                    writer.WriteStartElement( "Poses" );
                    foreach ( Pose pose in poseList ) { writePose( writer, pose, basePose, root ); }
                    writer.WriteEndElement();
                }

            writer.WriteEndElement();
            writer.WriteEndDocument();
            writer.Close();
        }

        private static void writePose( XmlTextWriter writer, Pose pose, Pose basePose, TextureNode root )
        {
            if ( basePose != pose ) { // exclude BasePose
                PoseMode poseMode = pose.Mode;
                WriteElement( writer, "Pose", new string[] { "name", "type" }, new string[] { pose.Text, poseMode.ToString() } );

                if ( pose.PoseNodes.Count > 0 && poseMode == PoseMode.Pose ) {
                    foreach ( PoseNode poseNode in pose.PoseNodes ) {
                        PoseNode baseNode = basePose.GetNode( poseNode.Node );  // check null ?

                        string[] values = { poseNode.Node.Text, poseNode.Node.GetIndexPath() };
                        WriteElement( writer, "PoseNode", new string[] { "name", "path" }, values );

                        foreach ( string property in poseNode.Properties.Keys ) {
                            string[] pValues = new string[] { property, poseNode.Properties[ property ].ToString() };
                            WriteElement( writer, "Property", new string[] { "name", "value" }, pValues, true );
                        }

                        writer.WriteEndElement();
                    }
                }
                else
                    { WriteElement( writer, "Equals", new string[] { "Pose" }, new String[] { basePose.Text }, true ); }

                foreach ( TreeNode subPose in pose.Nodes ) { writePose( writer, subPose as Pose, basePose, root ); }

                writer.WriteEndElement();
            }
        }

        private static void WriteNode( XmlTextWriter writer, TextureNode node, string filePath )
        {
            WriteElement( writer, "Node", new string[] { "name" }, new string[] { node.Text } );

                WriteElement( writer, "Position", new string[] { "x", "y" }, new string[] { node.xLocation.ToString(), node.yLocation.ToString() }, true );
                WriteElement( writer, "Center", new string[] { "x", "y" }, new string[] { node.xCenter.ToString(), node.yCenter.ToString() }, true );

                if ( node.Texture != null )
                {
                    WriteElement( writer, "Texture", new string[] { "name", "safeName" }, new string[] { GetRelativPath( node.TextureName, filePath ), node.SafeTextureName }, true );
                }

                Color color = node.Color;
                WriteElement( writer, "Color", new string[] { "A", "R", "G", "B" }, new string[] { color.A.ToString(), color.R.ToString(), color.G.ToString(), color.B.ToString() }, true );
                WriteElement( writer, "Dimension", new string[] { "Size", "Aspect" }, new string[] { node.NodeSize.ToString(), node.AspectRatio.ToString() }, true );
                WriteElement( writer, "Rotation", new string[] { "value" }, new string[] { node.Rotation.ToString() }, true );
                WriteElement( writer, "Layer", new string[] { "value" }, new string[] { node.Layer.ToString() }, true );

                foreach ( TreeNode child in node.Nodes )
                {
                    WriteNode( writer, child as TextureNode, filePath );
                }

            writer.WriteEndElement();
        }


        public static TextureNode ReadChar( string fileName, Form1 form )
        {
            TextureNode root = null;
            Pose basePose = null;
            List<Pose> allPoses = new List<Pose>();
            XmlTextReader reader = new XmlTextReader( fileName );

            try
            {
                while ( reader.Read() )
                {
                    if ( reader.NodeType == XmlNodeType.Element )
                    {
                        if ( reader.Name == "Node" ) { root = ReadNode( reader, Path.GetFullPath( fileName ), form ); }

                        if ( reader.Name == "Pose" && root != null )
                        {
                            Pose pose = ReadPose( reader, root );
                            if ( pose != null ) allPoses.Add( pose );
                        }
                    }

                    if ( root != null && basePose == null )
                    {
                        basePose = new Pose( "Base" );
                        basePose.Create( root, new string[] { "Rotation", "NodeSize" } );
                        allPoses.Add( basePose );
                    }
                }

                reader.Close();
                form.poseViewer.Poses = allPoses;
                form.poseViewer.Selected = basePose;
            }
            catch ( Exception e )
            {
                Console.WriteLine( e );
            }

            return root;
        }

        private static Pose ReadPose( XmlTextReader reader, TextureNode root )
        {
            Pose pose = new Pose( reader.GetAttribute( 0 ) );
            pose.Mode = reader.GetAttribute( 1 ).Equals( PoseMode.Collection.ToString() ) ? PoseMode.Collection : PoseMode.Pose;

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
                        PoseNode poseNode = new PoseNode( node as TextureNode );

                        ReadProperty( reader, poseNode );
                        pose.MergeAdd( poseNode );
                    }

                    if ( reader.Name == "Pose" )    // if Pose is collection
                    {
                        Pose pose2 = ReadPose( reader, root );
                        pose.Nodes.Add( pose2 ); 
                    }
                }
            }

            return pose;
        }

        private static void ReadProperty( XmlTextReader reader, PoseNode poseNode )
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
                        output.Texture = form.Game.Content.Load<SharpDX.Toolkit.Graphics.Texture2D>( output.TextureName );
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

        #region intern help methods

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
        
        private static void WriteElement( XmlTextWriter writer, string element, string[] attr, string[] value, bool close = false )
        {
            writer.WriteStartElement( element );
            for ( int index = 0; index < attr.Length && index < value.Length; index++ ) writer.WriteAttributeString( attr[index], value[index] );
            if ( close ) writer.WriteEndElement();
        }

        #endregion

    }

}
