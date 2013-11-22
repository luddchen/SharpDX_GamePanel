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

        public Pose BasePose { get { return this.Tree.Nodes[ 0 ] as Pose; } }

        public List<Pose> GetAllPoses()
        {
            List<Pose> poses = new List<Pose>();
            foreach ( TreeNode node in this.Tree.Nodes )
            {
                poses.Add( node as Pose );
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
            if ( this.Tree.SelectedNode != null && ( this.Tree.SelectedNode as Pose ).Mode == PoseMode.Collection )
            {
                Pose n = new Pose( "Pose" );
                this.Tree.SelectedNode.Nodes.Add( n );
                this.Tree.SelectedNode = n;
            }
            else
            {
                string name = this.Tree.Nodes.Count == 0 ? "Base" : "Pose";
                Pose n = new Pose( name );
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
                    //( e.Node as Pose ).RestorePose();
                    //( this.TopLevelControl as Form1 ).nodeInfo1.UpdateSelected();
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
                //( this.Tree.SelectedNode as Pose ).InitFromRoot( ( this.TopLevelControl as Form1 ).nodeViewer.Root );
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

        protected override void DeselectButtonClick( object sender, EventArgs e )
        {
            this.Tree.SelectedNode = null;
            ( this.TopLevelControl as Form1 ).poseInfo1.SelectedNode = null;
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // Tree
            // 
            this.Tree.LineColor = System.Drawing.Color.Black;
            // 
            // PoseTreeViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.Name = "PoseTreeViewer";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

    }

}
