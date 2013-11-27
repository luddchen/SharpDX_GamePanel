using System;
using System.Windows.Forms;

namespace DXCharEditor.Controls
{
    public partial class PoseInfo : UserControl
    {
        private bool selectedIsRoot;

        private Pose currentPose;

        private bool IsPlaying;

        private int step;

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
                    this.poseMode.Enabled = !this.selectedIsRoot && value.Nodes.Count == 0;
                    this.playPanel.Visible = value.Mode == PoseMode.Collection && value.Nodes.Count > 1;
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
            this.IsPlaying = false;
        }

        private void PoseInfo_FormClosing( object sender, FormClosingEventArgs e )
        {
            ( this.TopLevelControl as Form1 ).Game.OnDraw -= timer_Tick;
        }

        private void poseModeClickEvent( object sender, EventArgs e )
        {
            if ( this.selectedNode != null )
            {
                this.selectedNode.Mode = this.poseMode.Checked ? PoseMode.Collection : PoseMode.Pose;
                ( this.TopLevelControl as Form1 ).poseViewer.Selected = this.selectedNode;  // ->replace by update ?
            }
        }

        private void playButtonClickEvent( object sender, EventArgs e )
        {
            if ( this.IsPlaying )
            {
                this.IsPlaying = false;
                ( this.TopLevelControl as Form1 ).poseViewer.Enabled = true;
                ( this.TopLevelControl as Form1 ).poseViewer.BasePose.RestorePose();
                this.SelectedNode.RestorePose();
                ( this.TopLevelControl as Form1 ).FormClosing -= PoseInfo_FormClosing;
                ( this.TopLevelControl as Form1 ).Game.OnDraw -= timer_Tick;
            }
            else
            {
                this.IsPlaying = true;
                ( this.TopLevelControl as Form1 ).poseViewer.Enabled = false;
                this.currentPose = this.SelectedNode.Nodes[ 0 ] as Pose;
                ( this.TopLevelControl as Form1 ).poseViewer.BasePose.RestorePose();
                this.currentPose.RestorePose();
                this.step = 0;
                ( this.TopLevelControl as Form1 ).FormClosing += PoseInfo_FormClosing;
                ( this.TopLevelControl as Form1 ).Game.OnDraw += timer_Tick;
            }
        }

        private void timer_Tick( object sender, EventArgs e )
        {
            if ( step <= 0 )
            {
                int index = this.SelectedNode.Nodes.IndexOf( this.currentPose );
                index++;
                if ( index >= this.SelectedNode.Nodes.Count ) index = 0;
                this.currentPose = this.SelectedNode.Nodes[ index ] as Pose;
                step = (int)this.fpsValue.Value;
            }

            foreach ( PoseNode node in this.currentPose.PoseNodes )
            {
                foreach ( string property in node.Properties.Keys )
                {
                    float target = (float)node.Properties[ property ];
                    float source = (float)node.Node.GetProperty( property );
                    float propertyStep = ( target - source );
                    if ( property.Equals( "Rotation" ) )
                    {
                        if ( Math.Abs(propertyStep) > Math.PI )
                        {
                            if (propertyStep > 0) propertyStep -= (float)( Math.PI * 2 );
                            else if (propertyStep < 0) propertyStep += (float)( Math.PI * 2 );
                        }
                        
                    }
                    node.Node.SetProperty( property, source + propertyStep / step );
                }
            }

            step--;
        }

    }
}
