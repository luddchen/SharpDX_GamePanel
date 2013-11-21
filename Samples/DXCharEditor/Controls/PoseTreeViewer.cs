using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace DXCharEditor.Controls
{

    public class PoseTreeViewer : TreeViewer
    {

        public PoseTreeViewer()
            : base()
        {
            this.InfoLabel.Text = "Pose View";
            this.Tree.LabelEdit = true;
            this.Tree.BeforeLabelEdit += Tree_BeforeLabelEdit;
            this.Tree.AfterLabelEdit += Tree_AfterLabelEdit;
        }

        public bool IsLoading = false;

        public PoseNode BasePose { get { return this.Tree.Nodes[ 0 ] as PoseNode; } }

        public List<PoseNode> GetAllPoses()
        {
            List<PoseNode> poses = new List<PoseNode>();
            foreach ( TreeNode node in this.Tree.Nodes )
            {
                poses.Add( node as PoseNode );
            }
            return poses;
        }

        private void Tree_AfterLabelEdit( object sender, System.Windows.Forms.NodeLabelEditEventArgs e )
        {
            if ( e.Label.Length < 1 ) e.CancelEdit = true;
        }

        private void Tree_BeforeLabelEdit( object sender, System.Windows.Forms.NodeLabelEditEventArgs e )
        {
            if ( e.Node == this.Tree.Nodes[ 0 ] ) e.CancelEdit = true;
        }

        protected override void AddNodeClick( object sender, EventArgs e )
        {
            if ( this.Tree.SelectedNode != null && ( this.Tree.SelectedNode as PoseNode ).Mode == PoseMode.Collection )
            {
                PoseNode n = new PoseNode( "Pose" );
                this.Tree.SelectedNode.Nodes.Add( n );
                this.Tree.SelectedNode = n;
            }
            else
            {
                string name = this.Tree.Nodes.Count == 0 ? "Base" : "Pose";
                PoseNode n = new PoseNode( name );
                this.Tree.Nodes.Add( n );
                this.Tree.SelectedNode = n;
            }
        }

        protected override void RemoveNodeClick( object sender, EventArgs e )
        {
            if ( this.Tree.SelectedNode != this.Tree.Nodes[ 0 ] )
            {
                base.RemoveNodeClick( sender, e );
            }
        }

        protected override void AfterSelectEvent( object sender, System.Windows.Forms.TreeViewEventArgs e )
        {
            if ( e.Node != null )
            {
                if ( e.Node == this.Tree.Nodes[0] )
                {
                    this.RemoveButton.Enabled = false;
                }
                else
                {
                    this.RemoveButton.Enabled = true;
                }

                if ( !this.IsLoading )
                {
                    ( e.Node as PoseNode ).RestorePose();
                    ( this.TopLevelControl as Form1 ).nodeInfo1.UpdateSelected();
                }
            }
        }

        protected override void BeforeSelectEvent( object sender, System.Windows.Forms.TreeViewCancelEventArgs e )
        {
            base.BeforeSelectEvent( sender, e );
            if ( this.Tree.SelectedNode != null && this.Tree.SelectedNode != e.Node && !this.IsLoading )
            {
                ( this.Tree.SelectedNode as PoseNode ).InitFromRoot( ( this.TopLevelControl as Form1 ).nodeViewer.Root );
            }
        }

        protected override void DeselectButtonClick( object sender, EventArgs e )
        {
            this.Tree.SelectedNode = null;
            ( this.TopLevelControl as Form1 ).poseInfo1.SelectedNode = null;
        }

    }

}
