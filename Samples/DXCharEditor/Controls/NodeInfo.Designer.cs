namespace DXCharEditor.Controls
{
    partial class NodeInfo
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
            this.nodeName = new System.Windows.Forms.TextBox();
            this.parameterTablePanel = new System.Windows.Forms.TableLayoutPanel();
            this.textureBox = new System.Windows.Forms.PictureBox();
            this.textureLabel = new System.Windows.Forms.Label();
            this.locationLabel = new System.Windows.Forms.Label();
            this.locationTablePanel = new System.Windows.Forms.TableLayoutPanel();
            this.xLocationLabel = new System.Windows.Forms.Label();
            this.yLocationLabel = new System.Windows.Forms.Label();
            this.yLocation = new System.Windows.Forms.NumericUpDown();
            this.xLocation = new System.Windows.Forms.NumericUpDown();
            this.dimensionLabel = new System.Windows.Forms.Label();
            this.sizeTablePanel = new System.Windows.Forms.TableLayoutPanel();
            this.aspectLabel = new System.Windows.Forms.Label();
            this.sizeLabel = new System.Windows.Forms.Label();
            this.NodeSize = new System.Windows.Forms.NumericUpDown();
            this.AspectRatio = new System.Windows.Forms.NumericUpDown();
            this.centerLabel = new System.Windows.Forms.Label();
            this.centerTablePanel = new System.Windows.Forms.TableLayoutPanel();
            this.xCenterLabel = new System.Windows.Forms.Label();
            this.yCenterLabel = new System.Windows.Forms.Label();
            this.xCenter = new System.Windows.Forms.NumericUpDown();
            this.yCenter = new System.Windows.Forms.NumericUpDown();
            this.colorTablePanel = new System.Windows.Forms.TableLayoutPanel();
            this.Alpha = new System.Windows.Forms.NumericUpDown();
            this.alphaLabel = new System.Windows.Forms.Label();
            this.colorButton = new System.Windows.Forms.Button();
            this.colorValueLabel = new System.Windows.Forms.Label();
            this.colorLabel = new System.Windows.Forms.Label();
            this.otherLabel = new System.Windows.Forms.Label();
            this.rotationTablePanel = new System.Windows.Forms.TableLayoutPanel();
            this.RotationDegree = new System.Windows.Forms.NumericUpDown();
            this.rotationValueLabel = new System.Windows.Forms.Label();
            this.layerLabel = new System.Windows.Forms.Label();
            this.Layer = new System.Windows.Forms.NumericUpDown();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.parameterTablePanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.textureBox)).BeginInit();
            this.locationTablePanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.yLocation)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xLocation)).BeginInit();
            this.sizeTablePanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NodeSize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.AspectRatio)).BeginInit();
            this.centerTablePanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.xCenter)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.yCenter)).BeginInit();
            this.colorTablePanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Alpha)).BeginInit();
            this.rotationTablePanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.RotationDegree)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Layer)).BeginInit();
            this.SuspendLayout();
            // 
            // nodeName
            // 
            this.nodeName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.nodeName.Dock = System.Windows.Forms.DockStyle.Top;
            this.nodeName.HideSelection = false;
            this.nodeName.Location = new System.Drawing.Point(0, 0);
            this.nodeName.Margin = new System.Windows.Forms.Padding(0);
            this.nodeName.MaxLength = 20;
            this.nodeName.Name = "nodeName";
            this.nodeName.Size = new System.Drawing.Size(200, 20);
            this.nodeName.TabIndex = 1;
            this.nodeName.Text = "Node Name";
            this.nodeName.TextChanged += new System.EventHandler(this.nodeNameChanged);
            // 
            // parameterTablePanel
            // 
            this.parameterTablePanel.AutoScroll = true;
            this.parameterTablePanel.AutoSize = true;
            this.parameterTablePanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.parameterTablePanel.ColumnCount = 1;
            this.parameterTablePanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.parameterTablePanel.Controls.Add(this.textureBox, 0, 0);
            this.parameterTablePanel.Controls.Add(this.textureLabel, 0, 1);
            this.parameterTablePanel.Controls.Add(this.locationLabel, 0, 2);
            this.parameterTablePanel.Controls.Add(this.locationTablePanel, 0, 3);
            this.parameterTablePanel.Controls.Add(this.dimensionLabel, 0, 4);
            this.parameterTablePanel.Controls.Add(this.sizeTablePanel, 0, 5);
            this.parameterTablePanel.Controls.Add(this.centerLabel, 0, 6);
            this.parameterTablePanel.Controls.Add(this.centerTablePanel, 0, 7);
            this.parameterTablePanel.Controls.Add(this.colorTablePanel, 0, 9);
            this.parameterTablePanel.Controls.Add(this.colorLabel, 0, 8);
            this.parameterTablePanel.Controls.Add(this.otherLabel, 0, 10);
            this.parameterTablePanel.Controls.Add(this.rotationTablePanel, 0, 11);
            this.parameterTablePanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.parameterTablePanel.Location = new System.Drawing.Point(0, 20);
            this.parameterTablePanel.Name = "parameterTablePanel";
            this.parameterTablePanel.RowCount = 12;
            this.parameterTablePanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.parameterTablePanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.parameterTablePanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.parameterTablePanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.parameterTablePanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.parameterTablePanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.parameterTablePanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.parameterTablePanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.parameterTablePanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.parameterTablePanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.parameterTablePanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.parameterTablePanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.parameterTablePanel.Size = new System.Drawing.Size(200, 130);
            this.parameterTablePanel.TabIndex = 6;
            // 
            // textureBox
            // 
            this.textureBox.BackColor = System.Drawing.Color.Gray;
            this.textureBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.textureBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textureBox.Cursor = System.Windows.Forms.Cursors.Hand;
            this.textureBox.Dock = System.Windows.Forms.DockStyle.Left;
            this.textureBox.Location = new System.Drawing.Point(6, 3);
            this.textureBox.Margin = new System.Windows.Forms.Padding(6, 3, 6, 3);
            this.textureBox.MinimumSize = new System.Drawing.Size(100, 100);
            this.textureBox.Name = "textureBox";
            this.textureBox.Size = new System.Drawing.Size(171, 100);
            this.textureBox.TabIndex = 18;
            this.textureBox.TabStop = false;
            this.textureBox.Click += new System.EventHandler(this.textureClicked);
            // 
            // textureLabel
            // 
            this.textureLabel.AutoSize = true;
            this.textureLabel.Dock = System.Windows.Forms.DockStyle.Left;
            this.textureLabel.ForeColor = System.Drawing.Color.White;
            this.textureLabel.Location = new System.Drawing.Point(3, 106);
            this.textureLabel.MinimumSize = new System.Drawing.Size(0, 20);
            this.textureLabel.Name = "textureLabel";
            this.textureLabel.Size = new System.Drawing.Size(74, 20);
            this.textureLabel.TabIndex = 17;
            this.textureLabel.Text = "Texture Name";
            this.textureLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // locationLabel
            // 
            this.locationLabel.AutoSize = true;
            this.locationLabel.Dock = System.Windows.Forms.DockStyle.Left;
            this.locationLabel.ForeColor = System.Drawing.Color.White;
            this.locationLabel.Location = new System.Drawing.Point(3, 126);
            this.locationLabel.MinimumSize = new System.Drawing.Size(0, 20);
            this.locationLabel.Name = "locationLabel";
            this.locationLabel.Size = new System.Drawing.Size(48, 20);
            this.locationLabel.TabIndex = 16;
            this.locationLabel.Text = "Location";
            this.locationLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // locationTablePanel
            // 
            this.locationTablePanel.AutoSize = true;
            this.locationTablePanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.locationTablePanel.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.locationTablePanel.ColumnCount = 2;
            this.locationTablePanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.locationTablePanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.locationTablePanel.Controls.Add(this.xLocationLabel, 0, 0);
            this.locationTablePanel.Controls.Add(this.yLocationLabel, 0, 1);
            this.locationTablePanel.Controls.Add(this.yLocation, 1, 1);
            this.locationTablePanel.Controls.Add(this.xLocation, 1, 0);
            this.locationTablePanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.locationTablePanel.GrowStyle = System.Windows.Forms.TableLayoutPanelGrowStyle.FixedSize;
            this.locationTablePanel.Location = new System.Drawing.Point(20, 149);
            this.locationTablePanel.Margin = new System.Windows.Forms.Padding(20, 3, 3, 3);
            this.locationTablePanel.Name = "locationTablePanel";
            this.locationTablePanel.RowCount = 2;
            this.locationTablePanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.locationTablePanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.locationTablePanel.Size = new System.Drawing.Size(177, 47);
            this.locationTablePanel.TabIndex = 15;
            // 
            // xLocationLabel
            // 
            this.xLocationLabel.AutoSize = true;
            this.xLocationLabel.Dock = System.Windows.Forms.DockStyle.Left;
            this.xLocationLabel.ForeColor = System.Drawing.Color.White;
            this.xLocationLabel.Location = new System.Drawing.Point(4, 1);
            this.xLocationLabel.Name = "xLocationLabel";
            this.xLocationLabel.Size = new System.Drawing.Size(14, 22);
            this.xLocationLabel.TabIndex = 8;
            this.xLocationLabel.Text = "X";
            this.xLocationLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // yLocationLabel
            // 
            this.yLocationLabel.AutoSize = true;
            this.yLocationLabel.Dock = System.Windows.Forms.DockStyle.Left;
            this.yLocationLabel.ForeColor = System.Drawing.Color.White;
            this.yLocationLabel.Location = new System.Drawing.Point(4, 24);
            this.yLocationLabel.Name = "yLocationLabel";
            this.yLocationLabel.Size = new System.Drawing.Size(14, 22);
            this.yLocationLabel.TabIndex = 9;
            this.yLocationLabel.Text = "Y";
            this.yLocationLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // yLocation
            // 
            this.yLocation.AutoSize = true;
            this.yLocation.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.yLocation.DecimalPlaces = 2;
            this.yLocation.Dock = System.Windows.Forms.DockStyle.Fill;
            this.yLocation.Increment = new decimal(new int[] {
            5,
            0,
            0,
            131072});
            this.yLocation.Location = new System.Drawing.Point(92, 27);
            this.yLocation.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.yLocation.Minimum = new decimal(new int[] {
            1000,
            0,
            0,
            -2147483648});
            this.yLocation.Name = "yLocation";
            this.yLocation.Size = new System.Drawing.Size(81, 16);
            this.yLocation.TabIndex = 11;
            this.yLocation.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.yLocation.ValueChanged += new System.EventHandler(this.NumericValueChanged);
            // 
            // xLocation
            // 
            this.xLocation.AutoSize = true;
            this.xLocation.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.xLocation.DecimalPlaces = 2;
            this.xLocation.Dock = System.Windows.Forms.DockStyle.Fill;
            this.xLocation.Increment = new decimal(new int[] {
            5,
            0,
            0,
            131072});
            this.xLocation.Location = new System.Drawing.Point(92, 4);
            this.xLocation.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.xLocation.Minimum = new decimal(new int[] {
            1000,
            0,
            0,
            -2147483648});
            this.xLocation.Name = "xLocation";
            this.xLocation.Size = new System.Drawing.Size(81, 16);
            this.xLocation.TabIndex = 10;
            this.xLocation.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.xLocation.ValueChanged += new System.EventHandler(this.NumericValueChanged);
            // 
            // dimensionLabel
            // 
            this.dimensionLabel.AutoSize = true;
            this.dimensionLabel.ForeColor = System.Drawing.Color.White;
            this.dimensionLabel.Location = new System.Drawing.Point(3, 199);
            this.dimensionLabel.MinimumSize = new System.Drawing.Size(0, 20);
            this.dimensionLabel.Name = "dimensionLabel";
            this.dimensionLabel.Size = new System.Drawing.Size(56, 20);
            this.dimensionLabel.TabIndex = 14;
            this.dimensionLabel.Text = "Dimension";
            this.dimensionLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // sizeTablePanel
            // 
            this.sizeTablePanel.AutoSize = true;
            this.sizeTablePanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.sizeTablePanel.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.sizeTablePanel.ColumnCount = 2;
            this.sizeTablePanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.sizeTablePanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.sizeTablePanel.Controls.Add(this.aspectLabel, 0, 1);
            this.sizeTablePanel.Controls.Add(this.sizeLabel, 0, 0);
            this.sizeTablePanel.Controls.Add(this.NodeSize, 1, 0);
            this.sizeTablePanel.Controls.Add(this.AspectRatio, 1, 1);
            this.sizeTablePanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.sizeTablePanel.GrowStyle = System.Windows.Forms.TableLayoutPanelGrowStyle.FixedSize;
            this.sizeTablePanel.Location = new System.Drawing.Point(20, 222);
            this.sizeTablePanel.Margin = new System.Windows.Forms.Padding(20, 3, 3, 3);
            this.sizeTablePanel.Name = "sizeTablePanel";
            this.sizeTablePanel.RowCount = 2;
            this.sizeTablePanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.sizeTablePanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.sizeTablePanel.Size = new System.Drawing.Size(177, 47);
            this.sizeTablePanel.TabIndex = 13;
            // 
            // aspectLabel
            // 
            this.aspectLabel.AutoSize = true;
            this.aspectLabel.Dock = System.Windows.Forms.DockStyle.Left;
            this.aspectLabel.ForeColor = System.Drawing.Color.White;
            this.aspectLabel.Location = new System.Drawing.Point(4, 24);
            this.aspectLabel.Name = "aspectLabel";
            this.aspectLabel.Size = new System.Drawing.Size(68, 22);
            this.aspectLabel.TabIndex = 4;
            this.aspectLabel.Text = "Aspect Ratio";
            this.aspectLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // sizeLabel
            // 
            this.sizeLabel.AutoSize = true;
            this.sizeLabel.Dock = System.Windows.Forms.DockStyle.Left;
            this.sizeLabel.ForeColor = System.Drawing.Color.White;
            this.sizeLabel.Location = new System.Drawing.Point(4, 1);
            this.sizeLabel.Name = "sizeLabel";
            this.sizeLabel.Size = new System.Drawing.Size(27, 22);
            this.sizeLabel.TabIndex = 5;
            this.sizeLabel.Text = "Size";
            this.sizeLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // NodeSize
            // 
            this.NodeSize.AutoSize = true;
            this.NodeSize.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.NodeSize.DecimalPlaces = 2;
            this.NodeSize.Dock = System.Windows.Forms.DockStyle.Fill;
            this.NodeSize.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.NodeSize.Location = new System.Drawing.Point(92, 4);
            this.NodeSize.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.NodeSize.Name = "NodeSize";
            this.NodeSize.Size = new System.Drawing.Size(81, 16);
            this.NodeSize.TabIndex = 6;
            this.NodeSize.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.NodeSize.Value = new decimal(new int[] {
            10,
            0,
            0,
            65536});
            this.NodeSize.ValueChanged += new System.EventHandler(this.NumericValueChanged);
            // 
            // AspectRatio
            // 
            this.AspectRatio.AutoSize = true;
            this.AspectRatio.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.AspectRatio.DecimalPlaces = 2;
            this.AspectRatio.Dock = System.Windows.Forms.DockStyle.Fill;
            this.AspectRatio.Increment = new decimal(new int[] {
            5,
            0,
            0,
            131072});
            this.AspectRatio.Location = new System.Drawing.Point(92, 27);
            this.AspectRatio.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.AspectRatio.Name = "AspectRatio";
            this.AspectRatio.Size = new System.Drawing.Size(81, 16);
            this.AspectRatio.TabIndex = 7;
            this.AspectRatio.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.AspectRatio.Value = new decimal(new int[] {
            10,
            0,
            0,
            65536});
            this.AspectRatio.ValueChanged += new System.EventHandler(this.NumericValueChanged);
            // 
            // centerLabel
            // 
            this.centerLabel.AutoSize = true;
            this.centerLabel.ForeColor = System.Drawing.Color.White;
            this.centerLabel.Location = new System.Drawing.Point(3, 272);
            this.centerLabel.MinimumSize = new System.Drawing.Size(0, 20);
            this.centerLabel.Name = "centerLabel";
            this.centerLabel.Size = new System.Drawing.Size(38, 20);
            this.centerLabel.TabIndex = 12;
            this.centerLabel.Text = "Center";
            this.centerLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // centerTablePanel
            // 
            this.centerTablePanel.AutoSize = true;
            this.centerTablePanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.centerTablePanel.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.centerTablePanel.ColumnCount = 2;
            this.centerTablePanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.centerTablePanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.centerTablePanel.Controls.Add(this.xCenterLabel, 0, 0);
            this.centerTablePanel.Controls.Add(this.yCenterLabel, 0, 1);
            this.centerTablePanel.Controls.Add(this.xCenter, 1, 0);
            this.centerTablePanel.Controls.Add(this.yCenter, 1, 1);
            this.centerTablePanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.centerTablePanel.GrowStyle = System.Windows.Forms.TableLayoutPanelGrowStyle.FixedSize;
            this.centerTablePanel.Location = new System.Drawing.Point(20, 295);
            this.centerTablePanel.Margin = new System.Windows.Forms.Padding(20, 3, 3, 3);
            this.centerTablePanel.Name = "centerTablePanel";
            this.centerTablePanel.RowCount = 2;
            this.centerTablePanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.centerTablePanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.centerTablePanel.Size = new System.Drawing.Size(177, 55);
            this.centerTablePanel.TabIndex = 11;
            // 
            // xCenterLabel
            // 
            this.xCenterLabel.AutoSize = true;
            this.xCenterLabel.Dock = System.Windows.Forms.DockStyle.Left;
            this.xCenterLabel.ForeColor = System.Drawing.Color.White;
            this.xCenterLabel.Location = new System.Drawing.Point(4, 1);
            this.xCenterLabel.Name = "xCenterLabel";
            this.xCenterLabel.Size = new System.Drawing.Size(14, 26);
            this.xCenterLabel.TabIndex = 15;
            this.xCenterLabel.Text = "X";
            this.xCenterLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // yCenterLabel
            // 
            this.yCenterLabel.AutoSize = true;
            this.yCenterLabel.Dock = System.Windows.Forms.DockStyle.Left;
            this.yCenterLabel.ForeColor = System.Drawing.Color.White;
            this.yCenterLabel.Location = new System.Drawing.Point(4, 28);
            this.yCenterLabel.Name = "yCenterLabel";
            this.yCenterLabel.Size = new System.Drawing.Size(14, 26);
            this.yCenterLabel.TabIndex = 16;
            this.yCenterLabel.Text = "Y";
            this.yCenterLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // xCenter
            // 
            this.xCenter.AutoSize = true;
            this.xCenter.DecimalPlaces = 2;
            this.xCenter.Dock = System.Windows.Forms.DockStyle.Top;
            this.xCenter.Increment = new decimal(new int[] {
            5,
            0,
            0,
            131072});
            this.xCenter.Location = new System.Drawing.Point(92, 4);
            this.xCenter.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.xCenter.Minimum = new decimal(new int[] {
            1000,
            0,
            0,
            -2147483648});
            this.xCenter.Name = "xCenter";
            this.xCenter.Size = new System.Drawing.Size(81, 20);
            this.xCenter.TabIndex = 17;
            this.xCenter.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.xCenter.ValueChanged += new System.EventHandler(this.NumericValueChanged);
            // 
            // yCenter
            // 
            this.yCenter.AutoSize = true;
            this.yCenter.DecimalPlaces = 2;
            this.yCenter.Dock = System.Windows.Forms.DockStyle.Top;
            this.yCenter.Increment = new decimal(new int[] {
            5,
            0,
            0,
            131072});
            this.yCenter.Location = new System.Drawing.Point(92, 31);
            this.yCenter.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.yCenter.Minimum = new decimal(new int[] {
            1000,
            0,
            0,
            -2147483648});
            this.yCenter.Name = "yCenter";
            this.yCenter.Size = new System.Drawing.Size(81, 20);
            this.yCenter.TabIndex = 18;
            this.yCenter.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.yCenter.ValueChanged += new System.EventHandler(this.NumericValueChanged);
            // 
            // colorTablePanel
            // 
            this.colorTablePanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.colorTablePanel.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.colorTablePanel.ColumnCount = 2;
            this.colorTablePanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.colorTablePanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.colorTablePanel.Controls.Add(this.Alpha, 1, 1);
            this.colorTablePanel.Controls.Add(this.alphaLabel, 0, 1);
            this.colorTablePanel.Controls.Add(this.colorButton, 1, 0);
            this.colorTablePanel.Controls.Add(this.colorValueLabel, 0, 0);
            this.colorTablePanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.colorTablePanel.GrowStyle = System.Windows.Forms.TableLayoutPanelGrowStyle.FixedSize;
            this.colorTablePanel.Location = new System.Drawing.Point(20, 376);
            this.colorTablePanel.Margin = new System.Windows.Forms.Padding(20, 3, 3, 3);
            this.colorTablePanel.Name = "colorTablePanel";
            this.colorTablePanel.RowCount = 2;
            this.colorTablePanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.colorTablePanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.colorTablePanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.colorTablePanel.Size = new System.Drawing.Size(177, 57);
            this.colorTablePanel.TabIndex = 10;
            // 
            // Alpha
            // 
            this.Alpha.AutoSize = true;
            this.Alpha.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.Alpha.DecimalPlaces = 2;
            this.Alpha.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Alpha.Increment = new decimal(new int[] {
            5,
            0,
            0,
            131072});
            this.Alpha.Location = new System.Drawing.Point(92, 34);
            this.Alpha.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.Alpha.Name = "Alpha";
            this.Alpha.Size = new System.Drawing.Size(81, 16);
            this.Alpha.TabIndex = 13;
            this.Alpha.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.Alpha.Value = new decimal(new int[] {
            10,
            0,
            0,
            65536});
            this.Alpha.ValueChanged += new System.EventHandler(this.NumericValueChanged);
            // 
            // alphaLabel
            // 
            this.alphaLabel.AutoSize = true;
            this.alphaLabel.Dock = System.Windows.Forms.DockStyle.Left;
            this.alphaLabel.ForeColor = System.Drawing.Color.White;
            this.alphaLabel.Location = new System.Drawing.Point(4, 31);
            this.alphaLabel.Name = "alphaLabel";
            this.alphaLabel.Size = new System.Drawing.Size(34, 25);
            this.alphaLabel.TabIndex = 14;
            this.alphaLabel.Text = "Alpha";
            this.alphaLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // colorButton
            // 
            this.colorButton.AutoSize = true;
            this.colorButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.colorButton.Dock = System.Windows.Forms.DockStyle.Top;
            this.colorButton.Location = new System.Drawing.Point(92, 4);
            this.colorButton.MinimumSize = new System.Drawing.Size(5, 5);
            this.colorButton.Name = "colorButton";
            this.colorButton.Size = new System.Drawing.Size(81, 23);
            this.colorButton.TabIndex = 15;
            this.colorButton.Text = " ";
            this.colorButton.UseVisualStyleBackColor = true;
            this.colorButton.Click += new System.EventHandler(this.colorClick);
            // 
            // colorValueLabel
            // 
            this.colorValueLabel.AutoSize = true;
            this.colorValueLabel.Dock = System.Windows.Forms.DockStyle.Left;
            this.colorValueLabel.ForeColor = System.Drawing.Color.White;
            this.colorValueLabel.Location = new System.Drawing.Point(4, 1);
            this.colorValueLabel.Name = "colorValueLabel";
            this.colorValueLabel.Size = new System.Drawing.Size(31, 29);
            this.colorValueLabel.TabIndex = 16;
            this.colorValueLabel.Text = "Color";
            this.colorValueLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // colorLabel
            // 
            this.colorLabel.AutoSize = true;
            this.colorLabel.Dock = System.Windows.Forms.DockStyle.Left;
            this.colorLabel.ForeColor = System.Drawing.Color.White;
            this.colorLabel.Location = new System.Drawing.Point(3, 353);
            this.colorLabel.MinimumSize = new System.Drawing.Size(0, 20);
            this.colorLabel.Name = "colorLabel";
            this.colorLabel.Size = new System.Drawing.Size(31, 20);
            this.colorLabel.TabIndex = 6;
            this.colorLabel.Text = "Color";
            this.colorLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // otherLabel
            // 
            this.otherLabel.AutoSize = true;
            this.otherLabel.Dock = System.Windows.Forms.DockStyle.Left;
            this.otherLabel.ForeColor = System.Drawing.Color.White;
            this.otherLabel.Location = new System.Drawing.Point(3, 436);
            this.otherLabel.MinimumSize = new System.Drawing.Size(0, 20);
            this.otherLabel.Name = "otherLabel";
            this.otherLabel.Size = new System.Drawing.Size(33, 20);
            this.otherLabel.TabIndex = 19;
            this.otherLabel.Text = "Other";
            this.otherLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // rotationTablePanel
            // 
            this.rotationTablePanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.rotationTablePanel.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.rotationTablePanel.ColumnCount = 2;
            this.rotationTablePanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.rotationTablePanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.rotationTablePanel.Controls.Add(this.RotationDegree, 1, 0);
            this.rotationTablePanel.Controls.Add(this.rotationValueLabel, 0, 0);
            this.rotationTablePanel.Controls.Add(this.layerLabel, 0, 1);
            this.rotationTablePanel.Controls.Add(this.Layer, 1, 1);
            this.rotationTablePanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.rotationTablePanel.Location = new System.Drawing.Point(20, 459);
            this.rotationTablePanel.Margin = new System.Windows.Forms.Padding(20, 3, 3, 3);
            this.rotationTablePanel.Name = "rotationTablePanel";
            this.rotationTablePanel.RowCount = 2;
            this.rotationTablePanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.rotationTablePanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.rotationTablePanel.Size = new System.Drawing.Size(177, 52);
            this.rotationTablePanel.TabIndex = 20;
            // 
            // RotationDegree
            // 
            this.RotationDegree.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.RotationDegree.DecimalPlaces = 2;
            this.RotationDegree.Dock = System.Windows.Forms.DockStyle.Fill;
            this.RotationDegree.Location = new System.Drawing.Point(92, 4);
            this.RotationDegree.Maximum = new decimal(new int[] {
            360,
            0,
            0,
            0});
            this.RotationDegree.Name = "RotationDegree";
            this.RotationDegree.Size = new System.Drawing.Size(81, 16);
            this.RotationDegree.TabIndex = 0;
            this.RotationDegree.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.RotationDegree.ValueChanged += new System.EventHandler(this.NumericValueChanged);
            // 
            // rotationValueLabel
            // 
            this.rotationValueLabel.AutoSize = true;
            this.rotationValueLabel.Dock = System.Windows.Forms.DockStyle.Left;
            this.rotationValueLabel.ForeColor = System.Drawing.Color.White;
            this.rotationValueLabel.Location = new System.Drawing.Point(4, 1);
            this.rotationValueLabel.Name = "rotationValueLabel";
            this.rotationValueLabel.Size = new System.Drawing.Size(47, 22);
            this.rotationValueLabel.TabIndex = 1;
            this.rotationValueLabel.Text = "Rotation";
            this.rotationValueLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // layerLabel
            // 
            this.layerLabel.AutoSize = true;
            this.layerLabel.Dock = System.Windows.Forms.DockStyle.Left;
            this.layerLabel.ForeColor = System.Drawing.Color.White;
            this.layerLabel.Location = new System.Drawing.Point(4, 24);
            this.layerLabel.Name = "layerLabel";
            this.layerLabel.Size = new System.Drawing.Size(33, 27);
            this.layerLabel.TabIndex = 2;
            this.layerLabel.Text = "Layer";
            this.layerLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Layer
            // 
            this.Layer.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.Layer.DecimalPlaces = 2;
            this.Layer.Increment = new decimal(new int[] {
            5,
            0,
            0,
            131072});
            this.Layer.Location = new System.Drawing.Point(92, 27);
            this.Layer.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.Layer.Name = "Layer";
            this.Layer.Size = new System.Drawing.Size(71, 16);
            this.Layer.TabIndex = 3;
            this.Layer.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.Layer.ValueChanged += new System.EventHandler(this.NumericValueChanged);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.FileOk += new System.ComponentModel.CancelEventHandler(this.fileOkEvent);
            // 
            // NodeInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.parameterTablePanel);
            this.Controls.Add(this.nodeName);
            this.MinimumSize = new System.Drawing.Size(200, 150);
            this.Name = "NodeInfo";
            this.Size = new System.Drawing.Size(200, 150);
            this.parameterTablePanel.ResumeLayout(false);
            this.parameterTablePanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.textureBox)).EndInit();
            this.locationTablePanel.ResumeLayout(false);
            this.locationTablePanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.yLocation)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xLocation)).EndInit();
            this.sizeTablePanel.ResumeLayout(false);
            this.sizeTablePanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NodeSize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.AspectRatio)).EndInit();
            this.centerTablePanel.ResumeLayout(false);
            this.centerTablePanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.xCenter)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.yCenter)).EndInit();
            this.colorTablePanel.ResumeLayout(false);
            this.colorTablePanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Alpha)).EndInit();
            this.rotationTablePanel.ResumeLayout(false);
            this.rotationTablePanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.RotationDegree)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Layer)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel parameterTablePanel;
        private System.Windows.Forms.Label colorLabel;
        private System.Windows.Forms.TableLayoutPanel colorTablePanel;
        private System.Windows.Forms.NumericUpDown Alpha;
        private System.Windows.Forms.Label alphaLabel;
        private System.Windows.Forms.Button colorButton;
        private System.Windows.Forms.Label centerLabel;
        private System.Windows.Forms.TableLayoutPanel centerTablePanel;
        private System.Windows.Forms.Label xCenterLabel;
        private System.Windows.Forms.Label yCenterLabel;
        private System.Windows.Forms.NumericUpDown xCenter;
        private System.Windows.Forms.NumericUpDown yCenter;
        private System.Windows.Forms.Label dimensionLabel;
        private System.Windows.Forms.TableLayoutPanel sizeTablePanel;
        private System.Windows.Forms.Label aspectLabel;
        private System.Windows.Forms.Label sizeLabel;
        private System.Windows.Forms.NumericUpDown NodeSize;
        private System.Windows.Forms.NumericUpDown AspectRatio;
        private System.Windows.Forms.PictureBox textureBox;
        private System.Windows.Forms.Label textureLabel;
        private System.Windows.Forms.Label locationLabel;
        private System.Windows.Forms.TableLayoutPanel locationTablePanel;
        private System.Windows.Forms.Label xLocationLabel;
        private System.Windows.Forms.Label yLocationLabel;
        private System.Windows.Forms.NumericUpDown yLocation;
        private System.Windows.Forms.NumericUpDown xLocation;
        private System.Windows.Forms.TextBox nodeName;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Label otherLabel;
        private System.Windows.Forms.TableLayoutPanel rotationTablePanel;
        private System.Windows.Forms.NumericUpDown RotationDegree;
        private System.Windows.Forms.Label colorValueLabel;
        private System.Windows.Forms.Label rotationValueLabel;
        private System.Windows.Forms.Label layerLabel;
        private System.Windows.Forms.NumericUpDown Layer;
    }
}
