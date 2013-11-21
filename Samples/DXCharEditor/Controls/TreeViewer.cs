using System;
using System.Windows.Forms;

namespace DXCharEditor.Controls
{
    public partial class TreeViewer : UserControl
    {
        public TreeViewer()
        {
            InitializeComponent();
        }

        protected virtual void AddNodeClick( object sender, EventArgs e ) 
        {
            if ( this.Tree.SelectedNode == null )
            {
                this.Tree.Nodes.Add( new TreeViewerNode( "Node" ) );
            }
            else
            {
                this.Tree.SelectedNode.Nodes.Add( new TreeViewerNode( "Node" ) );
            }
        }

        protected virtual void RemoveNodeClick( object sender, EventArgs e )
        {
            if ( this.Tree.SelectedNode != null )
                if ( this.Tree.SelectedNode.Parent != null )
                {
                    this.Tree.SelectedNode.Parent.Nodes.Remove( this.Tree.SelectedNode );
                }
                else
                {
                    this.Tree.Nodes.Remove( this.Tree.SelectedNode );
                }
        }

        protected virtual void SearchNodeClick( object sender, EventArgs e )
        {
            if ( this.searchBox.Text.Length > 0 )
            {
                TreeViewerNode node = null;
                foreach ( TreeNode n in this.Tree.Nodes )
                {
                    if ( n is TreeViewerNode ) node = ( n as TreeViewerNode ).SearchNode( this.searchBox.Text );
                    if ( node != null ) break;
                }

                if ( node != null )
                {
                    if ( this.Tree.SelectedNode != node )
                    {
                        this.Tree.SelectedNode = node;
                        this.SearchButton.BackColor = System.Drawing.Color.Green;
                    }
                }
                else
                {
                    this.Tree.SelectedNode = null;
                    this.SearchButton.BackColor = System.Drawing.Color.Red;
                }
            }
        }

        protected virtual void AfterSelectEvent( object sender, TreeViewEventArgs e )
        {

        }

        protected virtual void BeforeSelectEvent( object sender, TreeViewCancelEventArgs e )
        {
            if ( e.Node != this.Tree.SelectedNode )
                this.SearchButton.BackColor = System.Drawing.SystemColors.Control;
        }

        protected virtual void SearchTextChangedEvent( object sender, EventArgs e )
        {
            this.SearchButton.BackColor = System.Drawing.SystemColors.Control;
        }

        protected virtual void DrawNodeEvent( object sender, DrawTreeNodeEventArgs e )
        {
            System.Drawing.Color foreColor;
            if ( e.Node == ( (TreeView)sender ).SelectedNode )
            {
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

        protected virtual void DeselectButtonClick( object sender, EventArgs e ) { }


    }
}
