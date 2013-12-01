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
        System.Timers.Timer timer2;

        public Form1()
        {
            this.Opacity = 0.0;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Enabled = false;

            InitializeComponent();

            Game = new Game1( this, this.Editor.CenterPanel );
            Game.Run();

            this.timer = new System.Timers.Timer();
            this.timer.Elapsed += timer_Elapsed;
            this.timer.Enabled = false;
            this.timer2 = new System.Timers.Timer( 10 );
            this.timer2.Elapsed += timer2_Elapsed;
            this.timer2.Enabled = false;
            setOpac = OpacSet;

            createRootItem();
            this.nodeViewer.SelectedChanged += this.nodeInfo1.OnSelectedChanged;
            this.poseViewer.SelectedChanged += this.poseInfo1.OnSelectedChanged;
            this.poseViewer.SelectedChanged += this.nodeInfo1.OnPoseChanged;
            this.poseViewer.SelectedChanged += this.nodeViewer.OnPoseChanged;
            this.tools.Visible = false;
            this.Editor.BottomPanelCollapsed = true;

            this.Editor.CenterPanel.ClientSizeChanged += CenterPanel_ClientSizeChanged;
            this.HandleCreated += Form1_HandleCreated;
        }

        private void Form1_HandleCreated( object sender, EventArgs e )
        {
            this.timer2.Enabled = true;
        }

        private void timer2_Elapsed( object sender, System.Timers.ElapsedEventArgs e )
        {
            Invoke( setOpac );
        }

        delegate void SetOpac();
        SetOpac setOpac;

        private void OpacSet()
        {
            if ( this.Opacity < 1.0 ) this.Opacity += 0.01;
            else
            {
                this.timer2.Enabled = false;
                this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;
                this.Enabled = true;
            }
        }

        private void CenterPanel_ClientSizeChanged( object sender, EventArgs e )
        {
            resetZoomScrollClickEvent( this, EventArgs.Empty );
        }

        private void createRootItem()
        {
            TextureNode root = new TextureNode( "Root" );
            root.Checked = true;
            this.nodeViewer.Root = root;
            this.nodeViewer.Selected = root;

            Pose basePose = new Pose( "Base" );
            this.poseViewer.BasePose = basePose;
            this.poseViewer.Selected = basePose;

            resetZoomScrollClickEvent( this, EventArgs.Empty );
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

        private void saveClickEvent( object sender, EventArgs e )
        {
            this.saveFileDialog1.ShowDialog();
        }

        private void SaveFileOkEvent( object sender, CancelEventArgs e )
        {
            this.poseViewer.Selected = this.poseViewer.BasePose;
            CharXML.WriteChar( this.saveFileDialog1.FileName, this.nodeViewer.Root, this.poseViewer.Poses, this.poseViewer.BasePose );
            this.statusLabel.Text = Path.GetFileName( this.saveFileDialog1.FileName );
        }

        private void LoadClickEvent( object sender, EventArgs e )
        {
            this.openFileDialog1.ShowDialog();
        }

        private void LoadFileOkEvent( object sender, CancelEventArgs e )
        {
            this.nodeViewer.SelectNothing();
            clearTree();
            TextureNode newRoot = CharXML.ReadChar( this.openFileDialog1.FileName, this );
            if ( newRoot != null )
            {
                this.nodeViewer.Root = newRoot;
                this.nodeViewer.Root.Update( true );
                this.statusLabel.Text = this.openFileDialog1.SafeFileName;
            }
            else
            {
                clearTree();
                createRootItem();
            }
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
            this.Game.Pause();
            while ( this.Game.IsActive ) { }

            this.poseViewer.Clear();
            this.nodeViewer.Clear();

            this.Game.Pause();
        }

        private void resetZoomScrollClickEvent( object sender, EventArgs e )
        {
            this.Game.ResetZoomScroll();
            this.nodeViewer.Root.Update( true );
        }

        private void gridOffItemClicked( object sender, EventArgs e )
        {
            uncheckGridItems();
            this.gridOffItem.Checked = true;
            this.Game.DrawGrid = false;
        }

        private void gridX2ItemClicked( object sender, EventArgs e )
        {
            uncheckGridItems();
            this.gridX2Item.Checked = true;
            this.Game.DrawGrid = true;
            this.Game.gridDrawer.subDivisions = 2;
        }

        private void gridX5ItemClicked( object sender, EventArgs e )
        {
            uncheckGridItems();
            this.gridX5Item.Checked = true;
            this.Game.DrawGrid = true;
            this.Game.gridDrawer.subDivisions = 5;
        }

        private void gridX10ItemClicked( object sender, EventArgs e )
        {
            uncheckGridItems();
            this.gridX10Item.Checked = true;
            this.Game.DrawGrid = true;
            this.Game.gridDrawer.subDivisions = 10;
        }

        private void uncheckGridItems()
        {
            this.gridOffItem.Checked = false;
            this.gridX2Item.Checked = false;
            this.gridX5Item.Checked = false;
            this.gridX10Item.Checked = false;
        }

    }
}
