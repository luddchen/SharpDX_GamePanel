namespace DXCharEditor.Controls
{
    partial class NodeTreeView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NodeTreeView));
            this.nodesLabel = new System.Windows.Forms.Label();
            this.tools = new System.Windows.Forms.ToolStrip();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.searchTextBox = new System.Windows.Forms.ToolStripTextBox();
            this.Tree = new System.Windows.Forms.TreeView();
            this.addItemButton = new System.Windows.Forms.ToolStripButton();
            this.removeItemButton = new System.Windows.Forms.ToolStripButton();
            this.searchButton = new System.Windows.Forms.ToolStripButton();
            this.tools.SuspendLayout();
            this.SuspendLayout();
            // 
            // nodesLabel
            // 
            this.nodesLabel.AutoSize = true;
            this.nodesLabel.BackColor = System.Drawing.Color.Transparent;
            this.nodesLabel.Dock = System.Windows.Forms.DockStyle.Top;
            this.nodesLabel.ForeColor = System.Drawing.Color.White;
            this.nodesLabel.Location = new System.Drawing.Point(3, 3);
            this.nodesLabel.Name = "nodesLabel";
            this.nodesLabel.Padding = new System.Windows.Forms.Padding(3);
            this.nodesLabel.Size = new System.Drawing.Size(44, 19);
            this.nodesLabel.TabIndex = 0;
            this.nodesLabel.Text = "Nodes";
            this.nodesLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tools
            // 
            this.tools.BackColor = System.Drawing.SystemColors.Control;
            this.tools.CanOverflow = false;
            this.tools.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tools.GripMargin = new System.Windows.Forms.Padding(0);
            this.tools.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.tools.ImageScalingSize = new System.Drawing.Size(12, 12);
            this.tools.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addItemButton,
            this.removeItemButton,
            this.toolStripSeparator1,
            this.searchButton,
            this.searchTextBox});
            this.tools.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.Flow;
            this.tools.Location = new System.Drawing.Point(3, 94);
            this.tools.Margin = new System.Windows.Forms.Padding(0, 2, 0, 0);
            this.tools.Name = "tools";
            this.tools.Padding = new System.Windows.Forms.Padding(0);
            this.tools.Size = new System.Drawing.Size(158, 23);
            this.tools.TabIndex = 1;
            this.tools.Text = "toolStrip1";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 23);
            // 
            // searchTextBox
            // 
            this.searchTextBox.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.searchTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.searchTextBox.MaxLength = 20;
            this.searchTextBox.Name = "searchTextBox";
            this.searchTextBox.Overflow = System.Windows.Forms.ToolStripItemOverflow.Never;
            this.searchTextBox.Size = new System.Drawing.Size(70, 23);
            this.searchTextBox.TextChanged += new System.EventHandler(this.SearchTextChanged);
            // 
            // Tree
            // 
            this.Tree.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Tree.CheckBoxes = true;
            this.Tree.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Tree.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Tree.HideSelection = false;
            this.Tree.Location = new System.Drawing.Point(3, 22);
            this.Tree.Name = "Tree";
            this.Tree.Size = new System.Drawing.Size(158, 72);
            this.Tree.TabIndex = 2;
            this.Tree.DrawNode += new System.Windows.Forms.DrawTreeNodeEventHandler(this.DrawNodeEvent);
            this.Tree.BeforeSelect += new System.Windows.Forms.TreeViewCancelEventHandler(this.TreeBeforeSelect);
            this.Tree.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.TreeAfterSelect);
            // 
            // addItemButton
            // 
            this.addItemButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.addItemButton.Image = ((System.Drawing.Image)(resources.GetObject("addItemButton.Image")));
            this.addItemButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.addItemButton.Name = "addItemButton";
            this.addItemButton.Size = new System.Drawing.Size(23, 16);
            this.addItemButton.Text = "Add";
            this.addItemButton.Click += new System.EventHandler(this.addItemClicked);
            // 
            // removeItemButton
            // 
            this.removeItemButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.removeItemButton.Image = ((System.Drawing.Image)(resources.GetObject("removeItemButton.Image")));
            this.removeItemButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.removeItemButton.Name = "removeItemButton";
            this.removeItemButton.Size = new System.Drawing.Size(23, 16);
            this.removeItemButton.Text = "Remove";
            this.removeItemButton.Click += new System.EventHandler(this.RemoveItemClicked);
            // 
            // searchButton
            // 
            this.searchButton.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.searchButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.searchButton.Image = ((System.Drawing.Image)(resources.GetObject("searchButton.Image")));
            this.searchButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.searchButton.Name = "searchButton";
            this.searchButton.Size = new System.Drawing.Size(23, 16);
            this.searchButton.Text = "Search";
            this.searchButton.Click += new System.EventHandler(this.SearchEvent);
            // 
            // NodeTreeView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Controls.Add(this.Tree);
            this.Controls.Add(this.tools);
            this.Controls.Add(this.nodesLabel);
            this.MinimumSize = new System.Drawing.Size(120, 120);
            this.Name = "NodeTreeView";
            this.Padding = new System.Windows.Forms.Padding(3);
            this.Size = new System.Drawing.Size(164, 120);
            this.SizeChanged += new System.EventHandler(this.SizeChangedEvent);
            this.tools.ResumeLayout(false);
            this.tools.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label nodesLabel;
        private System.Windows.Forms.ToolStrip tools;
        private System.Windows.Forms.ToolStripButton addItemButton;
        private System.Windows.Forms.ToolStripButton removeItemButton;
        public System.Windows.Forms.TreeView Tree;
        private System.Windows.Forms.ToolStripTextBox searchTextBox;
        private System.Windows.Forms.ToolStripButton searchButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
    }
}
