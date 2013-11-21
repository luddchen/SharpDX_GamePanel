using DXCharEditor.Controls;
namespace DXCharEditor
{
    partial class Form1
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose( bool disposing )
        {
            if ( disposing && ( components != null ) )
            {
                components.Dispose();
            }
            base.Dispose( disposing );
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.menu = new System.Windows.Forms.MenuStrip();
            this.fileMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.fileMenuNewItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fileMenuLoadItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fileMenuSaveItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fileMenuExitItem = new System.Windows.Forms.ToolStripMenuItem();
            this.poseMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.poseMenuSaveValuesItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.helpMenuInfoItem = new System.Windows.Forms.ToolStripMenuItem();
            this.testModeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.modeBox = new System.Windows.Forms.ToolStripComboBox();
            this.status = new System.Windows.Forms.StatusStrip();
            this.statusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.tools = new System.Windows.Forms.ToolStrip();
            this.editorSplitPanel1 = new DXControls.EditorSplitPanel();
            this.resetZoomScrollButton = new System.Windows.Forms.Button();
            this.nodeSplit = new System.Windows.Forms.SplitContainer();
            this.nodeViewer = new DXCharEditor.Controls.NodeTreeViewer();
            this.nodeInfo1 = new DXCharEditor.Controls.NodeInfo();
            this.poseSplit = new System.Windows.Forms.SplitContainer();
            this.poseViewer = new DXCharEditor.Controls.PoseTreeViewer();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.poseInfo1 = new DXCharEditor.Controls.PoseInfo();
            this.menu.SuspendLayout();
            this.status.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.editorSplitPanel1.BottomSplit)).BeginInit();
            this.editorSplitPanel1.BottomSplit.Panel1.SuspendLayout();
            this.editorSplitPanel1.BottomSplit.SuspendLayout();
            this.editorSplitPanel1.CenterPanel.SuspendLayout();
            this.editorSplitPanel1.LeftPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.editorSplitPanel1.LeftSplit)).BeginInit();
            this.editorSplitPanel1.LeftSplit.Panel2.SuspendLayout();
            this.editorSplitPanel1.LeftSplit.SuspendLayout();
            this.editorSplitPanel1.RightPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.editorSplitPanel1.RightSplit)).BeginInit();
            this.editorSplitPanel1.RightSplit.Panel1.SuspendLayout();
            this.editorSplitPanel1.RightSplit.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.editorSplitPanel1.TopSplit)).BeginInit();
            this.editorSplitPanel1.TopSplit.SuspendLayout();
            this.editorSplitPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nodeSplit)).BeginInit();
            this.nodeSplit.Panel1.SuspendLayout();
            this.nodeSplit.Panel2.SuspendLayout();
            this.nodeSplit.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.poseSplit)).BeginInit();
            this.poseSplit.Panel1.SuspendLayout();
            this.poseSplit.Panel2.SuspendLayout();
            this.poseSplit.SuspendLayout();
            this.SuspendLayout();
            // 
            // menu
            // 
            this.menu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileMenu,
            this.poseMenu,
            this.helpMenu,
            this.modeBox});
            this.menu.Location = new System.Drawing.Point(0, 0);
            this.menu.Name = "menu";
            this.menu.Size = new System.Drawing.Size(889, 27);
            this.menu.TabIndex = 0;
            this.menu.Text = "menuStrip1";
            // 
            // fileMenu
            // 
            this.fileMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileMenuNewItem,
            this.fileMenuLoadItem,
            this.fileMenuSaveItem,
            this.fileMenuExitItem});
            this.fileMenu.Name = "fileMenu";
            this.fileMenu.Size = new System.Drawing.Size(37, 23);
            this.fileMenu.Text = "File";
            // 
            // fileMenuNewItem
            // 
            this.fileMenuNewItem.Name = "fileMenuNewItem";
            this.fileMenuNewItem.Size = new System.Drawing.Size(100, 22);
            this.fileMenuNewItem.Text = "New";
            this.fileMenuNewItem.Click += new System.EventHandler(this.newClickEvent);
            // 
            // fileMenuLoadItem
            // 
            this.fileMenuLoadItem.Name = "fileMenuLoadItem";
            this.fileMenuLoadItem.Size = new System.Drawing.Size(100, 22);
            this.fileMenuLoadItem.Text = "Load";
            this.fileMenuLoadItem.Click += new System.EventHandler(this.LoadClickEvent);
            // 
            // fileMenuSaveItem
            // 
            this.fileMenuSaveItem.Name = "fileMenuSaveItem";
            this.fileMenuSaveItem.Size = new System.Drawing.Size(100, 22);
            this.fileMenuSaveItem.Text = "Save";
            this.fileMenuSaveItem.Click += new System.EventHandler(this.saveClickEvent);
            // 
            // fileMenuExitItem
            // 
            this.fileMenuExitItem.Name = "fileMenuExitItem";
            this.fileMenuExitItem.Size = new System.Drawing.Size(100, 22);
            this.fileMenuExitItem.Text = "Exit";
            this.fileMenuExitItem.Click += new System.EventHandler(this.exitClick);
            // 
            // poseMenu
            // 
            this.poseMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.poseMenuSaveValuesItem});
            this.poseMenu.Name = "poseMenu";
            this.poseMenu.Size = new System.Drawing.Size(44, 23);
            this.poseMenu.Text = "Pose";
            // 
            // poseMenuSaveValuesItem
            // 
            this.poseMenuSaveValuesItem.Name = "poseMenuSaveValuesItem";
            this.poseMenuSaveValuesItem.Size = new System.Drawing.Size(135, 22);
            this.poseMenuSaveValuesItem.Text = "Save Values";
            this.poseMenuSaveValuesItem.Click += new System.EventHandler(this.poseSaveValuesEvent);
            // 
            // helpMenu
            // 
            this.helpMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.helpMenuInfoItem,
            this.testModeToolStripMenuItem});
            this.helpMenu.Name = "helpMenu";
            this.helpMenu.Size = new System.Drawing.Size(44, 23);
            this.helpMenu.Text = "Help";
            // 
            // helpMenuInfoItem
            // 
            this.helpMenuInfoItem.Name = "helpMenuInfoItem";
            this.helpMenuInfoItem.Size = new System.Drawing.Size(127, 22);
            this.helpMenuInfoItem.Text = "Info";
            this.helpMenuInfoItem.Click += new System.EventHandler(this.infoClick);
            // 
            // testModeToolStripMenuItem
            // 
            this.testModeToolStripMenuItem.Name = "testModeToolStripMenuItem";
            this.testModeToolStripMenuItem.Size = new System.Drawing.Size(127, 22);
            this.testModeToolStripMenuItem.Text = "TestMode";
            this.testModeToolStripMenuItem.Click += new System.EventHandler(this.testModeClick);
            // 
            // modeBox
            // 
            this.modeBox.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.modeBox.FlatStyle = System.Windows.Forms.FlatStyle.Standard;
            this.modeBox.Items.AddRange(new object[] {
            "Node Mode",
            "Pose Mode"});
            this.modeBox.Name = "modeBox";
            this.modeBox.Size = new System.Drawing.Size(121, 23);
            this.modeBox.SelectedIndexChanged += new System.EventHandler(this.modeBoxSelectionChanged);
            // 
            // status
            // 
            this.status.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statusLabel});
            this.status.Location = new System.Drawing.Point(0, 500);
            this.status.Name = "status";
            this.status.Size = new System.Drawing.Size(889, 22);
            this.status.TabIndex = 1;
            this.status.Text = "statusStrip1";
            // 
            // statusLabel
            // 
            this.statusLabel.Name = "statusLabel";
            this.statusLabel.Size = new System.Drawing.Size(38, 17);
            this.statusLabel.Text = "status";
            // 
            // tools
            // 
            this.tools.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.tools.Location = new System.Drawing.Point(0, 27);
            this.tools.Name = "tools";
            this.tools.Size = new System.Drawing.Size(889, 25);
            this.tools.TabIndex = 2;
            this.tools.Text = "toolStrip1";
            // 
            // editorSplitPanel1
            // 
            this.editorSplitPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.editorSplitPanel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(70)))), ((int)(((byte)(90)))));
            // 
            // editorSplitPanel1.Bottom.Panel2
            // 
            this.editorSplitPanel1.BottomPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(85)))), ((int)(((byte)(105)))));
            this.editorSplitPanel1.BottomPanelCollapsed = false;
            // 
            // editorSplitPanel1.Bottom
            // 
            this.editorSplitPanel1.BottomSplit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.editorSplitPanel1.BottomSplit.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.editorSplitPanel1.BottomSplit.Location = new System.Drawing.Point(0, 0);
            this.editorSplitPanel1.BottomSplit.Name = "Bottom";
            this.editorSplitPanel1.BottomSplit.Orientation = System.Windows.Forms.Orientation.Horizontal;
            this.editorSplitPanel1.BottomSplit.Size = new System.Drawing.Size(685, 448);
            this.editorSplitPanel1.BottomSplit.SplitterDistance = 418;
            this.editorSplitPanel1.BottomSplit.TabIndex = 0;
            this.editorSplitPanel1.BottomSplitPosition = 418;
            // 
            // editorSplitPanel1.Top.Panel2
            // 
            this.editorSplitPanel1.CenterPanel.BackColor = System.Drawing.Color.Black;
            this.editorSplitPanel1.CenterPanel.Controls.Add(this.resetZoomScrollButton);
            this.editorSplitPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.editorSplitPanel1.GameMode = false;
            // 
            // editorSplitPanel1.Left.Panel1
            // 
            this.editorSplitPanel1.LeftPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(85)))), ((int)(((byte)(105)))));
            this.editorSplitPanel1.LeftPanel.Controls.Add(this.nodeSplit);
            this.editorSplitPanel1.LeftPanelCollapsed = false;
            // 
            // editorSplitPanel1.Left
            // 
            this.editorSplitPanel1.LeftSplit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.editorSplitPanel1.LeftSplit.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.editorSplitPanel1.LeftSplit.Location = new System.Drawing.Point(0, 0);
            this.editorSplitPanel1.LeftSplit.Name = "Left";
            this.editorSplitPanel1.LeftSplit.Panel1MinSize = 200;
            this.editorSplitPanel1.LeftSplit.Size = new System.Drawing.Size(889, 448);
            this.editorSplitPanel1.LeftSplit.SplitterDistance = 200;
            this.editorSplitPanel1.LeftSplit.TabIndex = 0;
            this.editorSplitPanel1.LeftSplitPosition = 200;
            this.editorSplitPanel1.Location = new System.Drawing.Point(0, 52);
            this.editorSplitPanel1.Name = "editorSplitPanel1";
            // 
            // editorSplitPanel1.Right.Panel2
            // 
            this.editorSplitPanel1.RightPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(85)))), ((int)(((byte)(105)))));
            this.editorSplitPanel1.RightPanel.Controls.Add(this.poseSplit);
            this.editorSplitPanel1.RightPanelCollapsed = false;
            // 
            // editorSplitPanel1.Right
            // 
            this.editorSplitPanel1.RightSplit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.editorSplitPanel1.RightSplit.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.editorSplitPanel1.RightSplit.Location = new System.Drawing.Point(0, 0);
            this.editorSplitPanel1.RightSplit.Name = "Right";
            this.editorSplitPanel1.RightSplit.Panel2MinSize = 200;
            this.editorSplitPanel1.RightSplit.Size = new System.Drawing.Size(685, 418);
            this.editorSplitPanel1.RightSplit.SplitterDistance = 481;
            this.editorSplitPanel1.RightSplit.TabIndex = 0;
            this.editorSplitPanel1.RightSplitPosition = 481;
            this.editorSplitPanel1.Size = new System.Drawing.Size(889, 448);
            this.editorSplitPanel1.TabIndex = 3;
            // 
            // editorSplitPanel1.Top.Panel1
            // 
            this.editorSplitPanel1.TopPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(85)))), ((int)(((byte)(105)))));
            this.editorSplitPanel1.TopPanelCollapsed = false;
            // 
            // editorSplitPanel1.Top
            // 
            this.editorSplitPanel1.TopSplit.AccessibleName = "";
            this.editorSplitPanel1.TopSplit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.editorSplitPanel1.TopSplit.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.editorSplitPanel1.TopSplit.Location = new System.Drawing.Point(0, 0);
            this.editorSplitPanel1.TopSplit.Name = "Top";
            this.editorSplitPanel1.TopSplit.Orientation = System.Windows.Forms.Orientation.Horizontal;
            this.editorSplitPanel1.TopSplit.Size = new System.Drawing.Size(481, 418);
            this.editorSplitPanel1.TopSplit.SplitterDistance = 25;
            this.editorSplitPanel1.TopSplit.TabIndex = 0;
            this.editorSplitPanel1.TopSplitPosition = 25;
            // 
            // resetZoomScrollButton
            // 
            this.resetZoomScrollButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.resetZoomScrollButton.Image = global::DXCharEditor.Properties.Resources.resetZoomScroll1;
            this.resetZoomScrollButton.Location = new System.Drawing.Point(1, 1);
            this.resetZoomScrollButton.Name = "resetZoomScrollButton";
            this.resetZoomScrollButton.Size = new System.Drawing.Size(40, 40);
            this.resetZoomScrollButton.TabIndex = 0;
            this.resetZoomScrollButton.Text = " ";
            this.resetZoomScrollButton.UseVisualStyleBackColor = true;
            this.resetZoomScrollButton.Click += new System.EventHandler(this.resetZoomScrollClickEvent);
            // 
            // nodeSplit
            // 
            this.nodeSplit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.nodeSplit.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.nodeSplit.Location = new System.Drawing.Point(0, 0);
            this.nodeSplit.Name = "nodeSplit";
            this.nodeSplit.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // nodeSplit.Panel1
            // 
            this.nodeSplit.Panel1.Controls.Add(this.nodeViewer);
            this.nodeSplit.Panel1.Padding = new System.Windows.Forms.Padding(1);
            this.nodeSplit.Panel1MinSize = 160;
            // 
            // nodeSplit.Panel2
            // 
            this.nodeSplit.Panel2.Controls.Add(this.nodeInfo1);
            this.nodeSplit.Panel2.Padding = new System.Windows.Forms.Padding(1);
            this.nodeSplit.Panel2MinSize = 150;
            this.nodeSplit.Size = new System.Drawing.Size(200, 448);
            this.nodeSplit.SplitterDistance = 186;
            this.nodeSplit.TabIndex = 0;
            // 
            // nodeViewer
            // 
            this.nodeViewer.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.nodeViewer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.nodeViewer.Location = new System.Drawing.Point(1, 1);
            this.nodeViewer.MinimumSize = new System.Drawing.Size(160, 160);
            this.nodeViewer.Name = "nodeViewer";
            this.nodeViewer.Padding = new System.Windows.Forms.Padding(3);
            this.nodeViewer.Size = new System.Drawing.Size(198, 184);
            this.nodeViewer.TabIndex = 0;
            // 
            // nodeInfo1
            // 
            this.nodeInfo1.AutoSize = true;
            this.nodeInfo1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.nodeInfo1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.nodeInfo1.Location = new System.Drawing.Point(1, 1);
            this.nodeInfo1.MinimumSize = new System.Drawing.Size(200, 150);
            this.nodeInfo1.Name = "nodeInfo1";
            this.nodeInfo1.SelectedNode = null;
            this.nodeInfo1.Size = new System.Drawing.Size(200, 256);
            this.nodeInfo1.TabIndex = 0;
            // 
            // poseSplit
            // 
            this.poseSplit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.poseSplit.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.poseSplit.Location = new System.Drawing.Point(0, 0);
            this.poseSplit.Name = "poseSplit";
            this.poseSplit.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // poseSplit.Panel1
            // 
            this.poseSplit.Panel1.Controls.Add(this.poseViewer);
            this.poseSplit.Panel1.Padding = new System.Windows.Forms.Padding(1);
            this.poseSplit.Panel1MinSize = 160;
            // 
            // poseSplit.Panel2
            // 
            this.poseSplit.Panel2.Controls.Add(this.poseInfo1);
            this.poseSplit.Panel2MinSize = 150;
            this.poseSplit.Size = new System.Drawing.Size(200, 418);
            this.poseSplit.SplitterDistance = 200;
            this.poseSplit.TabIndex = 0;
            // 
            // poseViewer
            // 
            this.poseViewer.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.poseViewer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.poseViewer.Location = new System.Drawing.Point(1, 1);
            this.poseViewer.MinimumSize = new System.Drawing.Size(160, 160);
            this.poseViewer.Name = "poseViewer";
            this.poseViewer.Padding = new System.Windows.Forms.Padding(3);
            this.poseViewer.Size = new System.Drawing.Size(198, 198);
            this.poseViewer.TabIndex = 0;
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.FileOk += new System.ComponentModel.CancelEventHandler(this.SaveFileOkEvent);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.FileOk += new System.ComponentModel.CancelEventHandler(this.LoadFileOkEvent);
            // 
            // poseInfo1
            // 
            this.poseInfo1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.poseInfo1.Location = new System.Drawing.Point(0, 0);
            this.poseInfo1.Name = "poseInfo1";
            this.poseInfo1.Padding = new System.Windows.Forms.Padding(3);
            this.poseInfo1.SelectedNode = null;
            this.poseInfo1.Size = new System.Drawing.Size(200, 214);
            this.poseInfo1.TabIndex = 0;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(889, 522);
            this.Controls.Add(this.editorSplitPanel1);
            this.Controls.Add(this.tools);
            this.Controls.Add(this.status);
            this.Controls.Add(this.menu);
            this.MainMenuStrip = this.menu;
            this.MinimumSize = new System.Drawing.Size(450, 450);
            this.Name = "Form1";
            this.Text = "DX Char Editor";
            this.menu.ResumeLayout(false);
            this.menu.PerformLayout();
            this.status.ResumeLayout(false);
            this.status.PerformLayout();
            this.editorSplitPanel1.BottomSplit.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.editorSplitPanel1.BottomSplit)).EndInit();
            this.editorSplitPanel1.BottomSplit.ResumeLayout(false);
            this.editorSplitPanel1.CenterPanel.ResumeLayout(false);
            this.editorSplitPanel1.LeftPanel.ResumeLayout(false);
            this.editorSplitPanel1.LeftSplit.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.editorSplitPanel1.LeftSplit)).EndInit();
            this.editorSplitPanel1.LeftSplit.ResumeLayout(false);
            this.editorSplitPanel1.RightPanel.ResumeLayout(false);
            this.editorSplitPanel1.RightSplit.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.editorSplitPanel1.RightSplit)).EndInit();
            this.editorSplitPanel1.RightSplit.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.editorSplitPanel1.TopSplit)).EndInit();
            this.editorSplitPanel1.TopSplit.ResumeLayout(false);
            this.editorSplitPanel1.ResumeLayout(false);
            this.nodeSplit.Panel1.ResumeLayout(false);
            this.nodeSplit.Panel2.ResumeLayout(false);
            this.nodeSplit.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nodeSplit)).EndInit();
            this.nodeSplit.ResumeLayout(false);
            this.poseSplit.Panel1.ResumeLayout(false);
            this.poseSplit.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.poseSplit)).EndInit();
            this.poseSplit.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menu;
        private System.Windows.Forms.ToolStripMenuItem fileMenu;
        private System.Windows.Forms.ToolStripMenuItem fileMenuExitItem;
        private System.Windows.Forms.ToolStripMenuItem helpMenu;
        private System.Windows.Forms.ToolStripMenuItem helpMenuInfoItem;
        private System.Windows.Forms.StatusStrip status;
        private System.Windows.Forms.ToolStrip tools;
        private System.Windows.Forms.ToolStripStatusLabel statusLabel;
        private System.Windows.Forms.ToolStripMenuItem testModeToolStripMenuItem;
        private DXControls.EditorSplitPanel editorSplitPanel1;
        private System.Windows.Forms.SplitContainer nodeSplit;
        public Controls.NodeInfo nodeInfo1;
        private System.Windows.Forms.ToolStripComboBox modeBox;
        private System.Windows.Forms.SplitContainer poseSplit;
        private System.Windows.Forms.ToolStripMenuItem fileMenuSaveItem;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.ToolStripMenuItem fileMenuLoadItem;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.ToolStripMenuItem fileMenuNewItem;
        private System.Windows.Forms.Button resetZoomScrollButton;
        public PoseTreeViewer poseViewer;
        public NodeTreeViewer nodeViewer;
        private System.Windows.Forms.ToolStripMenuItem poseMenu;
        private System.Windows.Forms.ToolStripMenuItem poseMenuSaveValuesItem;
        public PoseInfo poseInfo1;
    }
}

