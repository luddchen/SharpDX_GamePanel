namespace DXCharEditor.Controls
{
    partial class PoseInfo
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
            this.nameBox = new System.Windows.Forms.TextBox();
            this.poseMode = new System.Windows.Forms.CheckBox();
            this.playButton = new System.Windows.Forms.Button();
            this.fpsValue = new System.Windows.Forms.NumericUpDown();
            this.speedLabel = new System.Windows.Forms.Label();
            this.playPanel = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.fpsValue)).BeginInit();
            this.playPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // nameBox
            // 
            this.nameBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.nameBox.Dock = System.Windows.Forms.DockStyle.Top;
            this.nameBox.Location = new System.Drawing.Point(0, 0);
            this.nameBox.Name = "nameBox";
            this.nameBox.ReadOnly = true;
            this.nameBox.Size = new System.Drawing.Size(218, 20);
            this.nameBox.TabIndex = 0;
            // 
            // poseMode
            // 
            this.poseMode.AutoSize = true;
            this.poseMode.Dock = System.Windows.Forms.DockStyle.Top;
            this.poseMode.ForeColor = System.Drawing.Color.White;
            this.poseMode.Location = new System.Drawing.Point(0, 20);
            this.poseMode.Name = "poseMode";
            this.poseMode.Size = new System.Drawing.Size(218, 17);
            this.poseMode.TabIndex = 2;
            this.poseMode.Text = "Pose Collection";
            this.poseMode.UseVisualStyleBackColor = true;
            this.poseMode.Click += new System.EventHandler(this.poseModeClickEvent);
            // 
            // playButton
            // 
            this.playButton.Location = new System.Drawing.Point(52, 16);
            this.playButton.Name = "playButton";
            this.playButton.Size = new System.Drawing.Size(75, 23);
            this.playButton.TabIndex = 3;
            this.playButton.Text = "Play";
            this.playButton.UseVisualStyleBackColor = true;
            this.playButton.Click += new System.EventHandler(this.playButtonClickEvent);
            // 
            // fpsValue
            // 
            this.fpsValue.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.fpsValue.Location = new System.Drawing.Point(52, 58);
            this.fpsValue.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.fpsValue.Name = "fpsValue";
            this.fpsValue.Size = new System.Drawing.Size(78, 20);
            this.fpsValue.TabIndex = 4;
            this.fpsValue.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.fpsValue.Value = new decimal(new int[] {
            15,
            0,
            0,
            0});
            // 
            // speedLabel
            // 
            this.speedLabel.AutoSize = true;
            this.speedLabel.Location = new System.Drawing.Point(49, 42);
            this.speedLabel.Name = "speedLabel";
            this.speedLabel.Size = new System.Drawing.Size(92, 13);
            this.speedLabel.TabIndex = 5;
            this.speedLabel.Text = "interpolation steps";
            // 
            // playPanel
            // 
            this.playPanel.Controls.Add(this.fpsValue);
            this.playPanel.Controls.Add(this.playButton);
            this.playPanel.Controls.Add(this.speedLabel);
            this.playPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.playPanel.Location = new System.Drawing.Point(0, 37);
            this.playPanel.Name = "playPanel";
            this.playPanel.Size = new System.Drawing.Size(218, 100);
            this.playPanel.TabIndex = 6;
            // 
            // PoseInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.playPanel);
            this.Controls.Add(this.poseMode);
            this.Controls.Add(this.nameBox);
            this.Name = "PoseInfo";
            this.Size = new System.Drawing.Size(218, 300);
            this.Click += new System.EventHandler(this.poseModeClickEvent);
            ((System.ComponentModel.ISupportInitialize)(this.fpsValue)).EndInit();
            this.playPanel.ResumeLayout(false);
            this.playPanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox nameBox;
        private System.Windows.Forms.CheckBox poseMode;
        private System.Windows.Forms.Button playButton;
        private System.Windows.Forms.NumericUpDown fpsValue;
        private System.Windows.Forms.Label speedLabel;
        private System.Windows.Forms.Panel playPanel;
    }
}
