using System;
using System.Collections.Generic;
using DXCharEditor.Controls;
using System.Windows.Forms;

namespace DXCharEditor
{

    public enum PoseMode
    {
        Pose,
        Collection
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
            foreach ( PoseNode poseNode in this.PoseNodes )
            {
                poseNode.InitializeNode();
            }
        }

        public void MergeAdd( PoseNode poseNode, bool deepCopy = false )
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
                if ( deepCopy )
                {
                    PoseNode newNode = new PoseNode( poseNode.Node );
                    foreach ( string property in poseNode.Properties.Keys )
                    {
                        newNode.SetProperty( property, poseNode.Properties[ property ] );
                    }
                    this.PoseNodes.Add( newNode );
                }
                else
                {
                    this.PoseNodes.Add( poseNode );
                }
            }
            else
            {
                foreach ( string property in poseNode.Properties.Keys )
                {
                    target.SetProperty( property, poseNode.Properties[ property ] );
                }
            }
        }

        public void ComplementaryAdd( Pose pose )
        {
            foreach ( PoseNode poseNode in pose.PoseNodes )
            {
                PoseNode ownNode = this.GetNode( poseNode.Node );
                if ( ownNode == null )
                {
                    PoseNode newNode = new PoseNode( poseNode.Node );
                    foreach ( string property in poseNode.Properties.Keys )
                    {
                        newNode.SetProperty( property, poseNode.Properties[ property ] );
                    }
                    this.PoseNodes.Add( newNode );
                }
                else
                {
                    foreach ( string property in poseNode.Properties.Keys )
                    {
                        if ( !ownNode.Properties.ContainsKey( property ) )
                        {
                            ownNode.SetProperty( property, poseNode.Properties[ property ] );
                        }
                    }
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

        public override void Clear()
        {
            ClearPoseNodes();
            base.Clear();
        }


        public void CreatePartialRoot()
        {
            ClearPoseNodes();
            int counter = 0;
            if ( this.TreeView != null && this.TreeView.Nodes.Count > 0 )
            {
                Pose basePose = ( this.TreeView.Nodes[ 0 ] ) as Pose;

                foreach ( TreeNode child in this.Nodes )
                {
                    foreach ( PoseNode childNode in ( child as Pose ).PoseNodes )
                    {
                        this.MergeAdd( childNode, true );
                    }
                }

                foreach ( PoseNode poseNode in this.PoseNodes )
                {
                    PoseNode baseNode = basePose.GetNode( poseNode.Node );
                    if ( baseNode != null )
                    {
                        List<string> keys = new List<string>( poseNode.Properties.Keys );

                        foreach ( string property in keys )
                        {
                            poseNode.Properties[ property ] = baseNode.Properties[ property ];
                            counter++;
                        }
                    }
                }

                foreach ( TreeNode child in this.Nodes )
                {
                    ( child as Pose ).ComplementaryAdd( this );
                }
            }
        }

    }

}
