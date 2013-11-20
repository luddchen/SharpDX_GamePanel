using System;
using System.Windows.Forms;

namespace DXCharEditor.Controls
{

    public partial class NodeTreeView : UserControl
    {

        public NodeTreeView()
        {
            InitializeComponent();
            this.Tree.DrawMode = TreeViewDrawMode.OwnerDrawText;
        }

        protected virtual void addItemClicked( object sender, EventArgs e )
        {
            if ( this.Tree.SelectedNode != null && this.Tree.SelectedNode is TextureNode )
            {
                TextureNode selected = this.Tree.SelectedNode as TextureNode;

                string newNodeName = selected.Text;
                if ( newNodeName.Equals( "Root" ) ) newNodeName = "Node";
                newNodeName += "." + (selected.CumulatedChildCount + 1);

                TextureNode newNode = new TextureNode( newNodeName );
                newNode.Checked = true;
                selected.AddNode( newNode );
                selected.Expand();
            }
        }

        private void RemoveItemClicked( object sender, EventArgs e )
        {
            if ( this.Tree.SelectedNode != null && this.Tree.SelectedNode.Level > 0 )
            {
                this.Tree.SelectedNode.Parent.Nodes.Remove( this.Tree.SelectedNode );
            }
        }

        private void TreeAfterSelect( object sender, TreeViewEventArgs e )
        {
            if ( e.Node != null )
            {
                if ( e.Node.Level != 0 )
                {
                    this.removeItemButton.Enabled = true;
                }
                else
                {
                    this.removeItemButton.Enabled = false;
                }
            }
        }

        private void SizeChangedEvent( object sender, EventArgs e ) 
        {
            float minDim = (float)Math.Min( this.Size.Width, this.Size.Height );
            this.Tree.Font = new System.Drawing.Font( this.Tree.Font.FontFamily, minDim / 20f );
            this.nodesLabel.Font = new System.Drawing.Font( this.nodesLabel.Font.FontFamily, minDim / 20f ); 
            this.tools.ImageScalingSize = new System.Drawing.Size( (int)( minDim / 16f ), (int)( minDim / 16f ) );
            this.tools.Height = (int)( minDim / 20f );
            Console.WriteLine( this.Tree.Font.Size );
        }

        private void SearchEvent( object sender, EventArgs e )
        {
            if ( this.searchTextBox.Text.Length > 0 )
            {
                TextureNode Root = this.Tree.Nodes[ 0 ] as TextureNode;
                TextureNode node = Root.SearchChild( this.searchTextBox.Text );
                if ( node != null )
                {
                    if ( this.Tree.SelectedNode != node )
                    {
                        this.Tree.SelectedNode = node;
                        this.searchButton.BackColor = System.Drawing.Color.Green;
                    }
                }
                else
                {
                    this.Tree.SelectedNode = null;
                    this.searchButton.BackColor = System.Drawing.Color.Red;
                }
            }
        }

        private void SearchTextChanged( object sender, EventArgs e )
        {
            this.searchButton.BackColor = System.Drawing.SystemColors.Control;
        }

        private void TreeBeforeSelect( object sender, TreeViewCancelEventArgs e )
        {
            if ( e.Node != this.Tree.SelectedNode )
            {
                this.searchButton.BackColor = System.Drawing.SystemColors.Control;
            }
        }

        private void DrawNodeEvent( object sender, DrawTreeNodeEventArgs e )
        {
            System.Drawing.Color foreColor;
            if ( e.Node == ( (TreeView)sender ).SelectedNode )
            {
                // is selected, draw a HightliteText rectangle under the text
                foreColor = System.Drawing.SystemColors.HighlightText;
                e.Graphics.FillRectangle( System.Drawing.SystemBrushes.Highlight, e.Bounds );
                ControlPaint.DrawFocusRectangle( e.Graphics, e.Bounds, foreColor, System.Drawing.SystemColors.Highlight );
            }
            else
            {
                foreColor = ( e.Node.ForeColor == System.Drawing.Color.Empty ) ? ( (TreeView)sender ).ForeColor : e.Node.ForeColor;
                e.Graphics.FillRectangle( System.Drawing.SystemBrushes.Window, e.Bounds );
            }

            TextRenderer.DrawText(
                e.Graphics,
                e.Node.Text,
                e.Node.NodeFont ?? e.Node.TreeView.Font,
                e.Bounds,
                foreColor,
                TextFormatFlags.GlyphOverhangPadding );
        }


    }

}
