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
            // PoseInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.poseMode);
            this.Controls.Add(this.nameBox);
            this.Name = "PoseInfo";
            this.Size = new System.Drawing.Size(218, 300);
            this.Click += new System.EventHandler(this.poseModeClickEvent);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox nameBox;
        private System.Windows.Forms.CheckBox poseMode;
    }
}
