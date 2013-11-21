using System;
using System.Windows.Forms;

namespace DXCharEditor.Controls
{
    public partial class PoseInfo : UserControl
    {
        private PoseNode selectedNode;
        public PoseNode SelectedNode
        {
            get { return this.selectedNode; }
            set
            {
                this.selectedNode = value;
                if ( value != null )
                {
                    CalculateDifferentNodeCount();
                    this.nameBox.Text = value.Text;
                    this.poseMode.Checked = value.Mode == PoseMode.Collection;
                }
                else
                {
                    this.nameBox.Text = "";
                    this.poseMode.Checked = false;
                }
            }
        }

        private void CalculateDifferentNodeCount()
        {
            int count = 0;
            for ( int i = 0; i < this.selectedNode.NodeValues.Count; i++ )
            {
                if ( (float)this.selectedNode.NodeValues[ i ].Properties[ "Rotation" ] 
                    != (float)( this.TopLevelControl as Form1 ).poseViewer.BasePose.NodeValues[ i ].Properties[ "Rotation" ] )
                {
                    ++count;
                }
            }
            Console.WriteLine( count );
        }

        public PoseInfo()
        {
            InitializeComponent();
        }

        private void poseModeClickEvent( object sender, EventArgs e )
        {
            if ( this.selectedNode != null )
            {
                this.selectedNode.Mode = this.poseMode.Checked ? PoseMode.Collection : PoseMode.Pose;
                Console.WriteLine( this.selectedNode.Mode );
            }
        }
    }
}
