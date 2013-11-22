//using DXControls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DXCharEditor
{
    public partial class Form1 : Form
    {
        public readonly Game1 Game;
        System.Timers.Timer timer;

        public Form1()
        {
            InitializeComponent();

            Game = new Game1( this, this.Editor.CenterPanel );
            Game.Run();

            this.timer = new System.Timers.Timer();
            this.timer.Elapsed += timer_Elapsed;
            this.timer.Enabled = false;

            createRootItem();
            this.nodeViewer.SelectedChanged += this.nodeInfo1.OnSelectedChanged;
            this.poseViewer.SelectedChanged += this.poseInfo1.OnSelectedChanged;
            this.poseViewer.SelectedChanged += this.nodeInfo1.OnPoseChanged;
            this.poseViewer.SelectedChanged += this.nodeViewer.OnPoseChanged;

            this.modeBox.SelectedIndex = 1;

            this.tools.Visible = false;

            this.Editor.CenterPanel.ClientSizeChanged += CenterPanel_ClientSizeChanged;
        }

        private void CenterPanel_ClientSizeChanged( object sender, EventArgs e )
        {
            resetZoomScrollClickEvent( this, EventArgs.Empty );
        }

        private void PoseTreeAfterSelect( object sender, TreeViewEventArgs e )
        {
            if ( e.Node != null && e.Node is Pose )
            {
                this.poseInfo1.SelectedNode = e.Node as Pose;
            }
        }

        private void createRootItem()
        {
            TextureNode root = new TextureNode( "Root" );
            root.Checked = true;
            this.nodeViewer.Tree.Nodes.Add( root );
            this.nodeViewer.Tree.SelectedNode = root;
            //this.nodeViewer.Tree.ExpandAll();

            Pose basePose = new Pose( "Base" );
            this.poseViewer.Tree.Nodes.Add( basePose );
            this.poseViewer.Tree.SelectedNode = basePose;
        }

        public DXControls.EditorSplitPanel Editor
        {
            get { return this.editorSplitPanel1; }
        }


        public void SetStatusText( string text )
        {
            this.statusLabel.Text = text;
        }

        private void exitClick( object sender, EventArgs e )
        {
            this.Close();
        }

        private void infoClick( object sender, EventArgs e )
        {
            DXControls.InfoForm info = new DXControls.InfoForm();
            info.ShowDialog();
        }

        private void testModeClick( object sender, EventArgs e )
        {
            this.menu.Visible = false;
            this.tools.Visible = false;
            this.status.Visible = false;
            this.Editor.GameMode = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.timer.Interval = 5000;
            this.timer.Enabled = true;
        }

        private void timer_Elapsed( object sender, System.Timers.ElapsedEventArgs e )
        {
            this.timer.Enabled = false;
            SetBorder setBorder = SetEditorStyle;
            this.Invoke( setBorder, new object[] { } );
        }

        delegate void SetBorder();
     
        private void SetEditorStyle()
        {
            this.menu.Visible = true;
            this.tools.Visible = false;
            this.status.Visible = true;
            this.Editor.GameMode = false;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;
        }

        private void NodeSelectedEvent( object sender, TreeViewEventArgs e )
        {
            if ( e.Node is TextureNode )
            {
                this.nodeInfo1.SelectedNode = e.Node as TextureNode;
            }
            else
            {
                this.nodeInfo1.SelectedNode = null;
            }
        }

        private void modeBoxSelectionChanged( object sender, EventArgs e )
        {
            switch ( this.modeBox.SelectedIndex )
            {
                case 0: SetNodeMode();
                    break;
                case 1: SetPoseMode();
                    break;
            }
        }

        private void SetNodeMode()
        {
            this.Editor.LeftPanelCollapsed = false;
            this.Editor.RightPanelCollapsed = true;
            this.Editor.TopPanelCollapsed = true;
            this.Editor.BottomPanelCollapsed = true;
        }

        private void SetPoseMode()
        {
            this.Editor.LeftPanelCollapsed = false;
            this.Editor.RightPanelCollapsed = false;
            this.Editor.TopPanelCollapsed = true;
            this.Editor.BottomPanelCollapsed = true;
        }

        private void saveClickEvent( object sender, EventArgs e )
        {
            this.saveFileDialog1.ShowDialog();
        }

        private void SaveFileOkEvent( object sender, CancelEventArgs e )
        {
            CharXML.WriteChar( this.saveFileDialog1.FileName, this.nodeViewer.Root, this.poseViewer.GetAllPoses(), this.poseViewer.BasePose );
            this.statusLabel.Text = Path.GetFileName( this.saveFileDialog1.FileName );
        }

        private void LoadClickEvent( object sender, EventArgs e )
        {
            this.openFileDialog1.ShowDialog();
        }

        private void LoadFileOkEvent( object sender, CancelEventArgs e )
        {
            clearTree();
            this.nodeViewer.Tree.Nodes.Add( CharXML.ReadChar( this.openFileDialog1.FileName, this ) );
            this.nodeViewer.Tree.ExpandAll();
            this.nodeViewer.Root.Update( true );
            this.statusLabel.Text = this.openFileDialog1.SafeFileName;
            this.nodeViewer.SelectNothing();
        }

        private void newClickEvent( object sender, EventArgs e )
        {
            clearTree();
            createRootItem();
        }

        private void clearTree()
        {
            // todo ask if sure
            this.nodeViewer.Root.Clear();
            this.nodeViewer.Tree.Nodes.Clear();

            // todo clean up node references
            this.poseViewer.Tree.Nodes.Clear();
        }

        private void resetZoomScrollClickEvent( object sender, EventArgs e )
        {
            this.Game.ResetZoomScroll();
            this.nodeViewer.Root.Update( true );
        }

    }
}
