namespace DXCharEditor.Controls
{
    partial class TreeViewer
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

        #region Vom Komponenten-Designer generierter Code

        /// <summary> 
        /// Erforderliche Methode für die Designerunterstützung. 
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TreeViewer));
            this.InfoLabel = new System.Windows.Forms.Label();
            this.tools = new System.Windows.Forms.ToolStrip();
            this.AddButton = new System.Windows.Forms.ToolStripButton();
            this.RemoveButton = new System.Windows.Forms.ToolStripButton();
            this.DeselectButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.SearchButton = new System.Windows.Forms.ToolStripButton();
            this.searchBox = new System.Windows.Forms.ToolStripTextBox();
            this.Tree = new System.Windows.Forms.TreeView();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.tools.SuspendLayout();
            this.SuspendLayout();
            // 
            // InfoLabel
            // 
            this.InfoLabel.AutoSize = true;
            this.InfoLabel.Dock = System.Windows.Forms.DockStyle.Top;
            this.InfoLabel.ForeColor = System.Drawing.Color.White;
            this.InfoLabel.Location = new System.Drawing.Point(3, 3);
            this.InfoLabel.Margin = new System.Windows.Forms.Padding(3);
            this.InfoLabel.Name = "InfoLabel";
            this.InfoLabel.Padding = new System.Windows.Forms.Padding(0, 0, 2, 2);
            this.InfoLabel.Size = new System.Drawing.Size(63, 15);
            this.InfoLabel.TabIndex = 0;
            this.InfoLabel.Text = "TreeViewer";
            this.InfoLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tools
            // 
            this.tools.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tools.GripMargin = new System.Windows.Forms.Padding(0);
            this.tools.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.tools.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.AddButton,
            this.RemoveButton,
            this.DeselectButton,
            this.toolStripSeparator1,
            this.SearchButton,
            this.searchBox});
            this.tools.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.Flow;
            this.tools.Location = new System.Drawing.Point(3, 158);
            this.tools.Name = "tools";
            this.tools.Padding = new System.Windows.Forms.Padding(2);
            this.tools.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.tools.Size = new System.Drawing.Size(189, 27);
            this.tools.TabIndex = 1;
            this.tools.Text = "tool";
            // 
            // AddButton
            // 
            this.AddButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.AddButton.Image = ((System.Drawing.Image)(resources.GetObject("AddButton.Image")));
            this.AddButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.AddButton.Name = "AddButton";
            this.AddButton.Size = new System.Drawing.Size(23, 20);
            this.AddButton.Text = "add node";
            this.AddButton.Click += new System.EventHandler(this.AddNodeClick);
            // 
            // RemoveButton
            // 
            this.RemoveButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.RemoveButton.Image = ((System.Drawing.Image)(resources.GetObject("RemoveButton.Image")));
            this.RemoveButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.RemoveButton.Name = "RemoveButton";
            this.RemoveButton.Size = new System.Drawing.Size(23, 20);
            this.RemoveButton.Text = "remove node";
            this.RemoveButton.Click += new System.EventHandler(this.RemoveNodeClick);
            // 
            // DeselectButton
            // 
            this.DeselectButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.DeselectButton.Image = ((System.Drawing.Image)(resources.GetObject("DeselectButton.Image")));
            this.DeselectButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.DeselectButton.Name = "DeselectButton";
            this.DeselectButton.Size = new System.Drawing.Size(23, 20);
            this.DeselectButton.Text = "select nothing";
            this.DeselectButton.Click += new System.EventHandler(this.DeselectButtonClick);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 23);
            // 
            // SearchButton
            // 
            this.SearchButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.SearchButton.Image = ((System.Drawing.Image)(resources.GetObject("SearchButton.Image")));
            this.SearchButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.SearchButton.Name = "SearchButton";
            this.SearchButton.Size = new System.Drawing.Size(23, 20);
            this.SearchButton.Text = "search node";
            this.SearchButton.Click += new System.EventHandler(this.SearchNodeClick);
            // 
            // searchBox
            // 
            this.searchBox.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.searchBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.searchBox.MaxLength = 30;
            this.searchBox.Name = "searchBox";
            this.searchBox.Size = new System.Drawing.Size(70, 23);
            this.searchBox.TextChanged += new System.EventHandler(this.SearchTextChangedEvent);
            // 
            // Tree
            // 
            this.Tree.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Tree.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Tree.DrawMode = System.Windows.Forms.TreeViewDrawMode.OwnerDrawText;
            this.Tree.HideSelection = false;
            this.Tree.Location = new System.Drawing.Point(3, 18);
            this.Tree.Name = "Tree";
            this.Tree.Size = new System.Drawing.Size(189, 140);
            this.Tree.TabIndex = 2;
            this.Tree.DrawNode += new System.Windows.Forms.DrawTreeNodeEventHandler(this.DrawNodeEvent);
            this.Tree.BeforeSelect += new System.Windows.Forms.TreeViewCancelEventHandler(this.BeforeSelectEvent);
            this.Tree.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.AfterSelectEvent);
            // 
            // imageList1
            // 
            this.imageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.imageList1.ImageSize = new System.Drawing.Size(16, 16);
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // TreeViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Controls.Add(this.Tree);
            this.Controls.Add(this.tools);
            this.Controls.Add(this.InfoLabel);
            this.MinimumSize = new System.Drawing.Size(160, 160);
            this.Name = "TreeViewer";
            this.Padding = new System.Windows.Forms.Padding(3);
            this.Size = new System.Drawing.Size(195, 188);
            this.tools.ResumeLayout(false);
            this.tools.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ImageList imageList1;
        protected System.Windows.Forms.Label InfoLabel;
        protected System.Windows.Forms.ToolStrip tools;
        protected System.Windows.Forms.ToolStripButton AddButton;
        protected System.Windows.Forms.ToolStripButton RemoveButton;
        protected System.Windows.Forms.ToolStripButton SearchButton;
        protected System.Windows.Forms.ToolStripTextBox searchBox;
        protected System.Windows.Forms.ToolStripButton DeselectButton;
        private System.Windows.Forms.ToolTip toolTip1;
        protected System.Windows.Forms.TreeView Tree;
    }
}
