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

    public class Pose : TreeViewerNode
    {

        public int DifferentPropertiesCount { get; private set; }

        public PoseMode Mode = PoseMode.Pose;

        public readonly List<PoseNode> PoseNodes;

        public Pose( string name = "Pose" )
            : base( name )
        {
            this.PoseNodes = new List<PoseNode>();
        }

        public void Create( TextureNode root, string[] properties, Pose basePose = null )
        {
            this.ClearPoseNodes();
            this.DifferentPropertiesCount = 0;
            List<TextureNode> nodes = new List<TextureNode>();
            nodes.Add( root );
            int baseIndex = 0;

            while ( nodes.Count > 0 )
            {
                PoseNode pnv = new PoseNode( nodes[ 0 ] );
                foreach ( string property in properties )
                {
                    if ( basePose == null )
                    {
                        pnv.SetProperty( property, nodes[ 0 ].GetProperty( property ) );
                    }
                    else
                    {
                        if ( basePose.PoseNodes.Count > baseIndex && basePose.PoseNodes[ baseIndex ].Properties.ContainsKey( property ) )
                        {
                            float val1 = (float)nodes[ 0 ].GetProperty( property );
                            float val2 = (float)basePose.PoseNodes[ baseIndex ].Properties[ property ];
                            if ( val1 != val2 ) pnv.SetProperty( property, val1 );
                        }
                        else throw new IndexOutOfRangeException( "base pose is not correct initialized" );
                    }
                }
                if ( pnv.Properties.Count > 0 )
                {
                    this.PoseNodes.Add( pnv ); 
                    this.DifferentPropertiesCount += pnv.Properties.Count;
                }
                else { pnv.Clear(); }
                baseIndex++;
                foreach ( TreeNode n in nodes[ 0 ].Nodes ) nodes.Add( n as TextureNode );
                nodes.RemoveAt( 0 );
            }
        }

        public void RestorePose()
        {
            foreach ( PoseNode pose in this.PoseNodes )
            {
                pose.InitializeNode();
            }
        }

        public void MergeAdd( PoseNode poseNode )
        {
            PoseNode target = poseNode;
            foreach ( PoseNode node in this.PoseNodes )
            {
                if ( node.Node == poseNode.Node )
                {
                    target = node;
                    break;
                }
            }

            if ( target == poseNode )
            {
                this.PoseNodes.Add( poseNode );
            }
            else
            {
                foreach ( string property in poseNode.Properties.Keys )
                {
                    target.SetProperty( property, poseNode.Properties[ property ] );
                }
            }
        }


        public PoseNode GetNode( TextureNode node )
        {
            foreach ( PoseNode pnv in this.PoseNodes )
            {
                if ( node == pnv.Node ) return pnv;
            }
            return null;
        }


        private void ClearPoseNodes() 
        {
            foreach ( PoseNode node in this.PoseNodes )
            {
                node.Clear();
            }
            this.PoseNodes.Clear();
        }

    }

}
