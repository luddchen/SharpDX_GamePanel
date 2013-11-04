namespace Test
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
            this.components = new System.ComponentModel.Container();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.menuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showMouseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.hideMouseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.statusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.splitContainer = new System.Windows.Forms.SplitContainer();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.newNodeContextItem = new System.Windows.Forms.ToolStripMenuItem();
            this.removeNodeItem = new System.Windows.Forms.ToolStripMenuItem();
            this.layerValue = new System.Windows.Forms.NumericUpDown();
            this.layerLabel = new System.Windows.Forms.Label();
            this.alphaValue = new System.Windows.Forms.NumericUpDown();
            this.alphaLabel = new System.Windows.Forms.Label();
            this.colorButton = new System.Windows.Forms.Button();
            this.yValue = new System.Windows.Forms.NumericUpDown();
            this.xValue = new System.Windows.Forms.NumericUpDown();
            this.heightValue = new System.Windows.Forms.NumericUpDown();
            this.widthValue = new System.Windows.Forms.NumericUpDown();
            this.yLabel = new System.Windows.Forms.Label();
            this.xLabel = new System.Windows.Forms.Label();
            this.heightLabel = new System.Windows.Forms.Label();
            this.widthLabel = new System.Windows.Forms.Label();
            this.nodeNameLabel = new System.Windows.Forms.Label();
            this.rotationLabel = new System.Windows.Forms.Label();
            this.rotationValue = new System.Windows.Forms.NumericUpDown();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.colorDialog = new System.Windows.Forms.ColorDialog();
            this.parentRotationCheckBox = new System.Windows.Forms.CheckBox();
            this.menuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).BeginInit();
            this.splitContainer.Panel1.SuspendLayout();
            this.splitContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.layerValue)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.alphaValue)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.yValue)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xValue)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.heightValue)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.widthValue)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rotationValue)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuToolStripMenuItem,
            this.gameToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(739, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // menuToolStripMenuItem
            // 
            this.menuToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exitToolStripMenuItem});
            this.menuToolStripMenuItem.Name = "menuToolStripMenuItem";
            this.menuToolStripMenuItem.Size = new System.Drawing.Size(50, 20);
            this.menuToolStripMenuItem.Text = "Menu";
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(92, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            // 
            // gameToolStripMenuItem
            // 
            this.gameToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.showMouseToolStripMenuItem,
            this.hideMouseToolStripMenuItem});
            this.gameToolStripMenuItem.Name = "gameToolStripMenuItem";
            this.gameToolStripMenuItem.Size = new System.Drawing.Size(50, 20);
            this.gameToolStripMenuItem.Text = "Game";
            // 
            // showMouseToolStripMenuItem
            // 
            this.showMouseToolStripMenuItem.Name = "showMouseToolStripMenuItem";
            this.showMouseToolStripMenuItem.Size = new System.Drawing.Size(142, 22);
            this.showMouseToolStripMenuItem.Text = "Show Mouse";
            // 
            // hideMouseToolStripMenuItem
            // 
            this.hideMouseToolStripMenuItem.Name = "hideMouseToolStripMenuItem";
            this.hideMouseToolStripMenuItem.Size = new System.Drawing.Size(142, 22);
            this.hideMouseToolStripMenuItem.Text = "Hide Mouse";
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 428);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(739, 22);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // statusLabel1
            // 
            this.statusLabel1.Name = "statusLabel1";
            this.statusLabel1.Size = new System.Drawing.Size(67, 17);
            this.statusLabel1.Text = "StatusLabel";
            // 
            // splitContainer
            // 
            this.splitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer.Location = new System.Drawing.Point(0, 24);
            this.splitContainer.Name = "splitContainer";
            // 
            // splitContainer.Panel1
            // 
            this.splitContainer.Panel1.BackColor = System.Drawing.SystemColors.Info;
            this.splitContainer.Panel1.Controls.Add(this.splitContainer1);
            this.splitContainer.Size = new System.Drawing.Size(739, 404);
            this.splitContainer.SplitterDistance = 246;
            this.splitContainer.TabIndex = 2;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.treeView1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.parentRotationCheckBox);
            this.splitContainer1.Panel2.Controls.Add(this.layerValue);
            this.splitContainer1.Panel2.Controls.Add(this.layerLabel);
            this.splitContainer1.Panel2.Controls.Add(this.alphaValue);
            this.splitContainer1.Panel2.Controls.Add(this.alphaLabel);
            this.splitContainer1.Panel2.Controls.Add(this.colorButton);
            this.splitContainer1.Panel2.Controls.Add(this.yValue);
            this.splitContainer1.Panel2.Controls.Add(this.xValue);
            this.splitContainer1.Panel2.Controls.Add(this.heightValue);
            this.splitContainer1.Panel2.Controls.Add(this.widthValue);
            this.splitContainer1.Panel2.Controls.Add(this.yLabel);
            this.splitContainer1.Panel2.Controls.Add(this.xLabel);
            this.splitContainer1.Panel2.Controls.Add(this.heightLabel);
            this.splitContainer1.Panel2.Controls.Add(this.widthLabel);
            this.splitContainer1.Panel2.Controls.Add(this.nodeNameLabel);
            this.splitContainer1.Panel2.Controls.Add(this.rotationLabel);
            this.splitContainer1.Panel2.Controls.Add(this.rotationValue);
            this.splitContainer1.Size = new System.Drawing.Size(246, 404);
            this.splitContainer1.SplitterDistance = 194;
            this.splitContainer1.TabIndex = 0;
            // 
            // treeView1
            // 
            this.treeView1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.treeView1.ContextMenuStrip = this.contextMenuStrip1;
            this.treeView1.Location = new System.Drawing.Point(0, 0);
            this.treeView1.Name = "treeView1";
            this.treeView1.Size = new System.Drawing.Size(246, 196);
            this.treeView1.TabIndex = 0;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newNodeContextItem,
            this.removeNodeItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(150, 48);
            // 
            // newNodeContextItem
            // 
            this.newNodeContextItem.Name = "newNodeContextItem";
            this.newNodeContextItem.Size = new System.Drawing.Size(149, 22);
            this.newNodeContextItem.Text = "Add Node";
            // 
            // removeNodeItem
            // 
            this.removeNodeItem.Name = "removeNodeItem";
            this.removeNodeItem.Size = new System.Drawing.Size(149, 22);
            this.removeNodeItem.Text = "Remove Node";
            // 
            // layerValue
            // 
            this.layerValue.DecimalPlaces = 2;
            this.layerValue.Increment = new decimal(new int[] {
            5,
            0,
            0,
            131072});
            this.layerValue.Location = new System.Drawing.Point(18, 103);
            this.layerValue.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.layerValue.Name = "layerValue";
            this.layerValue.Size = new System.Drawing.Size(46, 20);
            this.layerValue.TabIndex = 17;
            // 
            // layerLabel
            // 
            this.layerLabel.AutoSize = true;
            this.layerLabel.Location = new System.Drawing.Point(15, 88);
            this.layerLabel.Name = "layerLabel";
            this.layerLabel.Size = new System.Drawing.Size(33, 13);
            this.layerLabel.TabIndex = 16;
            this.layerLabel.Text = "Layer";
            // 
            // alphaValue
            // 
            this.alphaValue.Location = new System.Drawing.Point(175, 162);
            this.alphaValue.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.alphaValue.Name = "alphaValue";
            this.alphaValue.Size = new System.Drawing.Size(54, 20);
            this.alphaValue.TabIndex = 15;
            // 
            // alphaLabel
            // 
            this.alphaLabel.AutoSize = true;
            this.alphaLabel.Location = new System.Drawing.Point(172, 146);
            this.alphaLabel.Name = "alphaLabel";
            this.alphaLabel.Size = new System.Drawing.Size(34, 13);
            this.alphaLabel.TabIndex = 14;
            this.alphaLabel.Text = "Alpha";
            // 
            // colorButton
            // 
            this.colorButton.Location = new System.Drawing.Point(104, 159);
            this.colorButton.Name = "colorButton";
            this.colorButton.Size = new System.Drawing.Size(47, 23);
            this.colorButton.TabIndex = 13;
            this.colorButton.Text = "Color";
            this.colorButton.UseVisualStyleBackColor = true;
            // 
            // yValue
            // 
            this.yValue.DecimalPlaces = 2;
            this.yValue.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.yValue.Location = new System.Drawing.Point(175, 104);
            this.yValue.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.yValue.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            -2147483648});
            this.yValue.Name = "yValue";
            this.yValue.Size = new System.Drawing.Size(49, 20);
            this.yValue.TabIndex = 12;
            // 
            // xValue
            // 
            this.xValue.DecimalPlaces = 2;
            this.xValue.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.xValue.Location = new System.Drawing.Point(104, 104);
            this.xValue.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.xValue.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            -2147483648});
            this.xValue.Name = "xValue";
            this.xValue.Size = new System.Drawing.Size(49, 20);
            this.xValue.TabIndex = 11;
            // 
            // heightValue
            // 
            this.heightValue.DecimalPlaces = 2;
            this.heightValue.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.heightValue.Location = new System.Drawing.Point(104, 46);
            this.heightValue.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.heightValue.Name = "heightValue";
            this.heightValue.Size = new System.Drawing.Size(49, 20);
            this.heightValue.TabIndex = 10;
            // 
            // widthValue
            // 
            this.widthValue.DecimalPlaces = 2;
            this.widthValue.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.widthValue.Location = new System.Drawing.Point(175, 46);
            this.widthValue.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.widthValue.Name = "widthValue";
            this.widthValue.Size = new System.Drawing.Size(49, 20);
            this.widthValue.TabIndex = 9;
            // 
            // yLabel
            // 
            this.yLabel.AutoSize = true;
            this.yLabel.Location = new System.Drawing.Point(172, 88);
            this.yLabel.Name = "yLabel";
            this.yLabel.Size = new System.Drawing.Size(14, 13);
            this.yLabel.TabIndex = 8;
            this.yLabel.Text = "Y";
            // 
            // xLabel
            // 
            this.xLabel.AutoSize = true;
            this.xLabel.Location = new System.Drawing.Point(101, 88);
            this.xLabel.Name = "xLabel";
            this.xLabel.Size = new System.Drawing.Size(14, 13);
            this.xLabel.TabIndex = 7;
            this.xLabel.Text = "X";
            // 
            // heightLabel
            // 
            this.heightLabel.AutoSize = true;
            this.heightLabel.Location = new System.Drawing.Point(172, 30);
            this.heightLabel.Name = "heightLabel";
            this.heightLabel.Size = new System.Drawing.Size(38, 13);
            this.heightLabel.TabIndex = 6;
            this.heightLabel.Text = "Height";
            // 
            // widthLabel
            // 
            this.widthLabel.AutoSize = true;
            this.widthLabel.Location = new System.Drawing.Point(101, 30);
            this.widthLabel.Name = "widthLabel";
            this.widthLabel.Size = new System.Drawing.Size(35, 13);
            this.widthLabel.TabIndex = 5;
            this.widthLabel.Text = "Width";
            // 
            // nodeNameLabel
            // 
            this.nodeNameLabel.AutoSize = true;
            this.nodeNameLabel.Location = new System.Drawing.Point(56, 1);
            this.nodeNameLabel.Name = "nodeNameLabel";
            this.nodeNameLabel.Size = new System.Drawing.Size(36, 13);
            this.nodeNameLabel.TabIndex = 2;
            this.nodeNameLabel.Text = "Image";
            // 
            // rotationLabel
            // 
            this.rotationLabel.AutoSize = true;
            this.rotationLabel.Location = new System.Drawing.Point(12, 31);
            this.rotationLabel.Name = "rotationLabel";
            this.rotationLabel.Size = new System.Drawing.Size(47, 13);
            this.rotationLabel.TabIndex = 1;
            this.rotationLabel.Text = "Rotation";
            this.rotationLabel.Click += new System.EventHandler(this.label1_Click);
            // 
            // rotationValue
            // 
            this.rotationValue.DecimalPlaces = 2;
            this.rotationValue.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.rotationValue.Location = new System.Drawing.Point(15, 47);
            this.rotationValue.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.rotationValue.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            -2147483648});
            this.rotationValue.Name = "rotationValue";
            this.rotationValue.Size = new System.Drawing.Size(49, 20);
            this.rotationValue.TabIndex = 0;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // parentRotationCheckBox
            // 
            this.parentRotationCheckBox.AutoSize = true;
            this.parentRotationCheckBox.Location = new System.Drawing.Point(18, 66);
            this.parentRotationCheckBox.Name = "parentRotationCheckBox";
            this.parentRotationCheckBox.Size = new System.Drawing.Size(54, 17);
            this.parentRotationCheckBox.TabIndex = 18;
            this.parentRotationCheckBox.Text = "relativ";
            this.parentRotationCheckBox.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(739, 450);
            this.Controls.Add(this.splitContainer);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Test";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.splitContainer.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).EndInit();
            this.splitContainer.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.contextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.layerValue)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.alphaValue)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.yValue)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xValue)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.heightValue)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.widthValue)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rotationValue)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem menuToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel statusLabel1;
        private System.Windows.Forms.SplitContainer splitContainer;
        private System.Windows.Forms.ToolStripMenuItem gameToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem showMouseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem hideMouseToolStripMenuItem;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.Label rotationLabel;
        private System.Windows.Forms.NumericUpDown rotationValue;
        private System.Windows.Forms.Label nodeNameLabel;
        private System.Windows.Forms.NumericUpDown yValue;
        private System.Windows.Forms.NumericUpDown xValue;
        private System.Windows.Forms.NumericUpDown heightValue;
        private System.Windows.Forms.NumericUpDown widthValue;
        private System.Windows.Forms.Label yLabel;
        private System.Windows.Forms.Label xLabel;
        private System.Windows.Forms.Label heightLabel;
        private System.Windows.Forms.Label widthLabel;
        private System.Windows.Forms.Button colorButton;
        private System.Windows.Forms.ColorDialog colorDialog;
        private System.Windows.Forms.NumericUpDown alphaValue;
        private System.Windows.Forms.Label alphaLabel;
        private System.Windows.Forms.NumericUpDown layerValue;
        private System.Windows.Forms.Label layerLabel;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem newNodeContextItem;
        private System.Windows.Forms.ToolStripMenuItem removeNodeItem;
        private System.Windows.Forms.CheckBox parentRotationCheckBox;
    }
}

