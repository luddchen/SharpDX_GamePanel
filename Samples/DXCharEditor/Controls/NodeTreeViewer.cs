using System;

namespace DXCharEditor.Controls
{

    public class NodeTreeViewer : TreeViewer
    {

        public NodeTreeViewer()
            : base()
        {
            this.InfoLabel.Text = "Node View";
        }

        public TextureNode Root
        {
            get { return this.Tree.Nodes[ 0 ] as TextureNode; }
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
            if ( e.Node != null )
            {
                if ( e.Node.Level != 0 )
                {
                    this.RemoveButton.Enabled = true;
                }
                else
                {
                    this.RemoveButton.Enabled = false;
                }
            }
        }

    }

}
