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
            this.DeselectButton.Enabled = false;
            this.DeselectButton.Visible = false;
        }

        public bool IsLoading = false;

        public Pose BasePose 
        { 
            get 
            { 
                return this.Tree.Nodes.Count > 0 ? this.Tree.Nodes[ 0 ] as Pose : null;
            }
            set
            {
                if ( value != null && this.Tree.Nodes.Count == 0 )
                {
                    this.Tree.Nodes.Add( value );
                    this.Tree.ExpandAll();
                }
            }
        }

        public List<Pose> Poses
        {
            get
            {
                List<Pose> poses = new List<Pose>();
                foreach ( TreeNode node in this.Tree.Nodes )
                {
                    if ( node is Pose ) poses.Add( node as Pose );
                }
                return poses;
            }
            set
            {
                if ( value != null )
                {
                    Clear();
                    foreach ( Pose pose in value )
                    {
                        this.Tree.Nodes.Add( pose );
                    }
                }
            }
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
            if ( this.Tree.SelectedNode != null && this.Tree.SelectedNode is Pose )
            {
                Pose selected = this.Tree.SelectedNode as Pose;
                if ( selected.Mode == PoseMode.Collection )
                {
                    Pose newPose = new Pose( "Pose" + "." + ( selected.CumulatedChildCount + 1 ) );
                    selected.AddNode( newPose );
                    selected.Expand();
                }
                else
                {
                    Pose n = new Pose( this.Tree.Nodes.Count == 0 ? "Base" : "Pose" );
                    this.Tree.Nodes.Add( n );
                    this.Selected = n;
                }
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
                if ( e.Node == this.Tree.Nodes[0] || (e.Node as Pose).Mode == PoseMode.Collection )
                {
                    this.RemoveButton.Enabled = false;
                    ( e.Node as Pose ).CreatePartialRoot();
                }
                else
                {
                    this.RemoveButton.Enabled = true;
                }

                if ( !this.IsLoading )
                {
                    if ( this.BasePose != null ) this.BasePose.RestorePose();
                    ( e.Node as Pose ).RestorePose();
                }
            }
            base.AfterSelectEvent( sender, e );
        }

        protected override void BeforeSelectEvent( object sender, System.Windows.Forms.TreeViewCancelEventArgs e )
        {
            base.BeforeSelectEvent( sender, e );
            if ( this.Tree.SelectedNode != null && this.Tree.SelectedNode != e.Node && !this.IsLoading )
            {
                if ( ( this.Tree.SelectedNode as Pose ) == this.BasePose )
                {
                    ( this.Tree.SelectedNode as Pose ).Create( 
                        ( this.TopLevelControl as Form1 ).nodeViewer.Root, new string[] { "Rotation", "NodeSize" } );
                }
                else
                {
                    ( this.Tree.SelectedNode as Pose ).Create(
                        ( this.TopLevelControl as Form1 ).nodeViewer.Root, new string[] { "Rotation", "NodeSize" } , this.BasePose );
                }
            }
        }

        protected override void DeselectButtonClick( object sender, EventArgs e ) { }

    }

}
