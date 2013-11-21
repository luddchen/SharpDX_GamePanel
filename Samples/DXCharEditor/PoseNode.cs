using System;
using System.Collections.Generic;
using DXCharEditor.Controls;
using System.Windows.Forms;

namespace DXCharEditor
{

    public enum PoseMode
    {
        Pose,       // contains a intern ?tree? structure of changed Nodes and Values 
        Collection  // contains via TreeNode.Nodes PoseNodes
    }

    public class PoseNode : TreeViewerNode
    {

        public PoseMode Mode = PoseMode.Pose;

        public readonly List<PoseNodeValue> NodeValues;

        public PoseNode( string name = "Pose" )
            : base( name )
        {
            this.NodeValues = new List<PoseNodeValue>();
        }

        public void InitFromRoot( TextureNode root )
        {
            this.NodeValues.Clear();

            List<TextureNode> nodes = new List<TextureNode>();
            nodes.Add( root );
            while ( nodes.Count > 0 )
            {
                PoseNodeValue pnv = new PoseNodeValue( nodes[ 0 ] );
                pnv.SetProperty( "Rotation", nodes[ 0 ].Rotation );
                this.NodeValues.Add( pnv );

                foreach ( TreeNode child in nodes[ 0 ].Nodes )
                {
                    nodes.Add( child as TextureNode );
                }
                nodes.RemoveAt( 0 );
            }

        }

        public void RestorePose()
        {
            foreach ( PoseNodeValue pose in this.NodeValues )
            {
                pose.InitializeNode();
            }
        }



    }

}
