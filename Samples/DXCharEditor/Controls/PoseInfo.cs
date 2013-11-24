using System;
using System.Windows.Forms;

namespace DXCharEditor.Controls
{
    public partial class PoseInfo : UserControl
    {
        private bool selectedIsRoot;

        public void OnSelectedChanged( object sender, DXCharEditor.Controls.TreeViewerEventArgs args )
        {
            this.selectedIsRoot = args.IsRoot;
            this.SelectedNode = args.Node as Pose;
        }

        private Pose selectedNode;
        private Pose SelectedNode
        {
            get { return this.selectedNode; }
            set
            {
                this.selectedNode = value;
                if ( value != null )
                {
                    this.nameBox.Text = value.Text;
                    this.poseMode.Checked = value.Mode == PoseMode.Collection;
                    this.poseMode.Enabled = !this.selectedIsRoot;
                }
                else
                {
                    this.nameBox.Text = "";
                    this.poseMode.Checked = false;
                }
            }
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
