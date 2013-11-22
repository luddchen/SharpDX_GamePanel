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

        public virtual void Clear()
        {
            foreach ( TreeNode node in this.Nodes )
            {
                if ( node is TreeViewerNode ) ( node as TreeViewerNode ).Clear();
            }
            this.Nodes.Clear();
        }

        public string GetIndexPath()
        {
            string path = "";
            TreeNode t = this;
            int cancelCounter = 0;

            while ( t.Level > 0 && ++cancelCounter < 100 )
            {
                path = t.Parent.Nodes.IndexOf( t ) + ( (path.Length > 0) ? "." + path : "" );
                t = t.Parent;
            }
            return path;
        }

    }

}
