using System;
using System.Drawing;
using System.Windows.Forms;
using SharpDX.Toolkit.Graphics;

namespace DXCharEditor.Controls
{
    public partial class NodeInfo : UserControl
    {
        private bool selectedIsRoot;

        public NodeInfo()
        {
            InitializeComponent();
        }

        public void UpdateSelected() { this.SelectedNode = this.selectedNode; }

        public void OnSelectedChanged( object sender, DXCharEditor.Controls.TreeViewerEventArgs args )
        {
            this.selectedIsRoot = args.IsRoot;
            this.SelectedNode = args.Node as TextureNode;
        }

        public void OnPoseChanged( object sender, DXCharEditor.Controls.TreeViewerEventArgs args )
        {
            this.locationLabel.Visible = args.IsRoot;
            this.locationTablePanel.Visible = args.IsRoot;
            this.centerLabel.Visible = args.IsRoot;
            this.centerTablePanel.Visible = args.IsRoot;
            this.textureBox.Enabled = args.IsRoot;
            this.textureLabel.Visible = args.IsRoot;
            this.colorLabel.Visible = args.IsRoot;
            this.colorTablePanel.Visible = args.IsRoot;
            UpdateSelected();
        }

        private TextureNode selectedNode;
        public TextureNode SelectedNode 
        {
            get { return this.selectedNode; }
            set
            {
                this.selectedNode = value;
                if ( value != null )
                {
                    this.parameterTablePanel.Visible = true;
                    if ( this.selectedNode.Image != null )
                    {
                        this.textureBox.BackgroundImage = this.selectedNode.Image;
                    }
                    else
                    {
                        this.textureBox.BackgroundImage = null;
                    }
                    this.xLocation.Value = (decimal)this.selectedNode.xLocation;
                    this.yLocation.Value = (decimal)this.selectedNode.yLocation;
                    this.xCenter.Value = (decimal)this.selectedNode.xCenter;
                    this.yCenter.Value = (decimal)this.selectedNode.yCenter;
                    this.NodeSize.Value = (decimal)this.selectedNode.NodeSize;
                    this.AspectRatio.Value = (decimal)this.selectedNode.AspectRatio;
                    this.textureLabel.Text = this.selectedNode.SafeTextureName;
                    SharpDX.Color nodeColor = this.selectedNode.Color;
                    this.colorButton.BackColor = Color.FromArgb( nodeColor.R, nodeColor.G, nodeColor.B );
                    this.Alpha.Value = (decimal)( (float)nodeColor.A / byte.MaxValue );
                    this.RotationDegree.Value = (decimal)this.selectedNode.RotationDegree;
                    this.Layer.Value = (decimal)this.selectedNode.Layer;

                    this.nodeName.Text = this.selectedNode.Text;
                    this.nodeName.Enabled = !this.selectedIsRoot;
                }
                else
                {
                    this.nodeName.Text = "";
                    this.parameterTablePanel.Visible = false;
                }
            }
        }

        private void colorClick( object sender, System.EventArgs e )
        {
            if ( this.selectedNode != null )
            {
                ColorDialog colorDialog = new ColorDialog();
                colorDialog.Color = this.colorButton.BackColor;
                colorDialog.FullOpen = true;
                colorDialog.SolidColorOnly = false;
                colorDialog.AllowFullOpen = true;
                colorDialog.AnyColor = true;
                if ( colorDialog.ShowDialog() == DialogResult.OK )
                {
                    this.colorButton.BackColor = colorDialog.Color;
                    if ( this.selectedNode != null )
                    {
                        TextureNode node = this.selectedNode;
                        SharpDX.Color color = node.Color;
                        SharpDX.Color nodeColor = 
                            new SharpDX.Color( colorDialog.Color.R, colorDialog.Color.G, colorDialog.Color.B, color.A );
                        node.Color = nodeColor;
                    }
                }
            }
        }

        private void NumericValueChanged( object sender, EventArgs e )
        {
            if ( this.selectedNode != null )
            {
                this.selectedNode.SetProperty( ( sender as Control ).Name, (float)( sender as NumericUpDown ).Value );
            }
        }

        private void nodeNameChanged( object sender, EventArgs e )
        {
            if ( this.selectedNode != null )
            {
                this.selectedNode.Text = this.nodeName.Text;
            }

        }

        private void textureClicked( object sender, EventArgs e )
        {
            this.openFileDialog1.ShowDialog();
        }

        private void fileOkEvent( object sender, System.ComponentModel.CancelEventArgs e )
        {
            if ( this.selectedNode != null )
            {
                Texture2D tex = ( this.TopLevelControl as Form1 ).Game.Content.Load<Texture2D>( this.openFileDialog1.FileName );
                if ( tex != null )
                {
                    this.selectedNode.Image = System.Drawing.Image.FromFile( this.openFileDialog1.FileName );
                    this.selectedNode.Texture = tex;
                    this.selectedNode.TextureName = this.openFileDialog1.FileName;
                    this.selectedNode.SafeTextureName = this.openFileDialog1.SafeFileName;
                    this.UpdateSelected();
                }
            }
        }

    }
}
