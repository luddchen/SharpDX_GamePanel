using System;

namespace DXCharEditor.Controls
{

    public class NodeTreeViewer : TreeViewer
    {

        private bool basePoseSelected = true;

        public NodeTreeViewer()
            : base()
        {
            this.InfoLabel.Text = "Node View";
        }

        public void OnPoseChanged( object sender, DXCharEditor.Controls.TreeViewerEventArgs args )
        {
            this.basePoseSelected = args.IsRoot;
            CaclculateButtonVisibility();
        }

        public TextureNode Root
        {
            get 
            {
                return this.Tree.Nodes.Count > 0 ? this.Tree.Nodes[ 0 ] as TextureNode : null;
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

        protected override void AddNodeClick( object sender, EventArgs e )
        {
            if ( this.Tree.SelectedNode != null && this.Tree.SelectedNode is TextureNode )
            {
                TextureNode selected = this.Tree.SelectedNode as TextureNode;

                string newNodeName = selected.Text;
                if ( newNodeName.Equals( "Root" ) ) newNodeName = "Node";
                newNodeName += "." + ( selected.CumulatedChildCount + 1 );

                TextureNode newNode = new TextureNode( newNodeName );
                newNode.Checked = true;
                selected.AddNode( newNode );
                selected.Expand();
                newNode.Update( false );
                base.AddNodeClick( sender, e );
            }
        }

        protected override void RemoveNodeClick( object sender, EventArgs e )
        {
            if ( this.Tree.SelectedNode != null && this.Tree.SelectedNode.Level > 0 )
            {
                base.RemoveNodeClick( sender, e );
            }
        }

        protected override void AfterSelectEvent( object sender, System.Windows.Forms.TreeViewEventArgs e )
        {
            base.AfterSelectEvent( sender, e );

            CaclculateButtonVisibility();
        }

        private void CaclculateButtonVisibility()
        {
            if ( this.Tree.SelectedNode != null )
            {
                this.AddButton.Enabled = this.basePoseSelected;
                this.RemoveButton.Enabled = this.basePoseSelected & !this.rootSelected;
            }
            else
            {
                this.AddButton.Enabled = false;
                this.RemoveButton.Enabled = false;
            }
        }

        public void SelectNothing()
        {
            this.Selected = null;
        }

    }

}
