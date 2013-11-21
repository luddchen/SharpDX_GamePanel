using System.Windows.Forms;

namespace DXCharEditor.Controls
{

    public class TreeViewerNode : TreeNode
    {

        public int CumulatedChildCount { get; private set; }

        public TreeViewerNode( string text, int lastCount ) : this(text)
        {
            this.CumulatedChildCount = lastCount;
        }

        public TreeViewerNode( string text )
            : base( text )
        {
        }

        public void AddNode( TreeNode node )
        {
            this.Nodes.Add( node );
            this.CumulatedChildCount++;
        }

        public TreeViewerNode SearchNode( string name )
        {
            if ( this.Text.Contains( name ) ) return this;

            foreach ( TreeNode node in this.Nodes )
            {
                if ( node is TreeViewerNode )
                {
                    TreeViewerNode childNode = ( node as TreeViewerNode ).SearchNode( name );
                    if ( childNode != null )
                    {
                        return childNode;
                    }
                }
            }
            return null;
        }

        public void Clear()
        {
            foreach ( TreeNode node in this.Nodes )
            {
                if ( node is TreeViewerNode ) ( node as TreeViewerNode ).Clear();
            }
            this.Nodes.Clear();
        }

    }

}
