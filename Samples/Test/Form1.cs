using System;
using System.Windows.Forms;

namespace Test
{

    public partial class Form1 : Form
    {

        private delegate void StatusInfo( string text );

        private StatusInfo SetInfo;
        private StatusInfo SetTitle;

        private Game1 game;

        public TextureNode RootNode;

        public Form1()
        {
            InitializeComponent();

            this.exitToolStripMenuItem.Click += exitToolStripMenuItem_Click;
            SetInfo = delegate( string text ) { this.statusLabel1.Text = text; };
            SetTitle = delegate( string text ) { this.Text = text; };
            
            game = new Game1( this.splitContainer.Panel2 );
            game.form = this;
            game.Start();

            this.showMouseToolStripMenuItem.Click += showMouseToolStripMenuItem_Click;
            this.hideMouseToolStripMenuItem.Click += hideMouseToolStripMenuItem_Click;
            this.newNodeContextItem.Click += loadTextureToolStripMenuItem_Click;
            this.removeNodeItem.Click += removeNodeItem_Click;

            this.openFileDialog1.FileOk += openFileDialog1_FileOk;

            this.splitContainer1.Panel1.SizeChanged += Panel1_SizeChanged;
            this.treeView1.Nodes.Add( RootNode = new TextureNode() );
            RootNode.Text = "Root";

            this.treeView1.AfterSelect += treeView1_AfterSelect;
            this.rotationValue.ValueChanged += rotationValue_ValueChanged;
            this.widthValue.ValueChanged += widthValue_ValueChanged;
            this.heightValue.ValueChanged += heightValue_ValueChanged;
            this.xValue.ValueChanged += xValue_ValueChanged;
            this.yValue.ValueChanged += yValue_ValueChanged;
            this.colorButton.Click += colorButton_Click;
            this.alphaValue.ValueChanged += alphaValue_ValueChanged;
            this.layerValue.ValueChanged += layerValue_ValueChanged;
            this.parentRotationCheckBox.CheckedChanged += parentRotationCheckBox_CheckedChanged;
        }

        private void parentRotationCheckBox_CheckedChanged( object sender, EventArgs e )
        {
            if ( this.treeView1.SelectedNode != null && this.treeView1.SelectedNode is TextureNode )
            {
                ( this.treeView1.SelectedNode as TextureNode ).relativRotation = this.parentRotationCheckBox.Checked;
            }
        }

        private void removeNodeItem_Click( object sender, EventArgs e )
        {
            if ( this.treeView1.SelectedNode != null && this.treeView1.SelectedNode is TextureNode && this.treeView1.SelectedNode.Level != 0 )
            {
                this.treeView1.SelectedNode.Parent.Nodes.Remove( this.treeView1.SelectedNode );
            }
        }

        private void layerValue_ValueChanged( object sender, EventArgs e )
        {
            if ( this.treeView1.SelectedNode != null && this.treeView1.SelectedNode is TextureNode )
            {
                ( this.treeView1.SelectedNode as TextureNode ).layer = (float)this.layerValue.Value;
            }
        }

        private void alphaValue_ValueChanged( object sender, EventArgs e )
        {
            if ( this.treeView1.SelectedNode != null && this.treeView1.SelectedNode is TextureNode )
            {
                TextureNode node = this.treeView1.SelectedNode as TextureNode;
                SharpDX.Color nodeColor = node.Color;
                nodeColor.A = (byte)(this.alphaValue.Value);
                node.Color = nodeColor;
            }
        }

        private void colorButton_Click( object sender, EventArgs e )
        {
            if ( this.treeView1.SelectedNode != null && this.treeView1.SelectedNode is TextureNode )
            {
                TextureNode node = this.treeView1.SelectedNode as TextureNode;
                SharpDX.Color nodeColor = node.Color;
                System.Drawing.Color col = System.Drawing.Color.FromArgb( nodeColor.A, nodeColor.R, nodeColor.G, nodeColor.B );
                this.colorDialog.Color = col;

                if ( this.colorDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK )
                {
                    col = this.colorDialog.Color;
                    nodeColor.R = col.R;
                    nodeColor.G = col.G;
                    nodeColor.B = col.B;
                    node.Color = nodeColor;
                }
            }
        }

        private void yValue_ValueChanged( object sender, EventArgs e )
        {
            if ( this.treeView1.SelectedNode != null && this.treeView1.SelectedNode is TextureNode )
            {
                TextureNode node = this.treeView1.SelectedNode as TextureNode;
                SharpDX.Vector2 center = node.center;
                center.Y = (float)this.yValue.Value;
                node.center = center;
            }
        }

        private void xValue_ValueChanged( object sender, EventArgs e )
        {
            if ( this.treeView1.SelectedNode != null && this.treeView1.SelectedNode is TextureNode )
            {
                TextureNode node = this.treeView1.SelectedNode as TextureNode;
                SharpDX.Vector2 center = node.center;
                center.X = (float)this.xValue.Value;
                node.center = center;
            }
        }

        private void heightValue_ValueChanged( object sender, EventArgs e )
        {
            if ( this.treeView1.SelectedNode != null && this.treeView1.SelectedNode is TextureNode )
            {
                ( this.treeView1.SelectedNode as TextureNode ).height = (float)this.heightValue.Value;
            }
        }

        private void widthValue_ValueChanged( object sender, EventArgs e )
        {
            if ( this.treeView1.SelectedNode != null && this.treeView1.SelectedNode is TextureNode )
            {
                ( this.treeView1.SelectedNode as TextureNode ).width = (float)this.widthValue.Value;
            }
        }

        private void rotationValue_ValueChanged( object sender, EventArgs e )
        {
            if ( this.treeView1.SelectedNode != null && this.treeView1.SelectedNode is TextureNode )
            {
                ( this.treeView1.SelectedNode as TextureNode ).rotFactor = (float)this.rotationValue.Value;
            }
        }

        private void treeView1_AfterSelect( object sender, TreeViewEventArgs e )
        {
            if ( e.Node is TextureNode )
            {
                this.nodeNameLabel.Text = e.Node.Text;
                this.rotationValue.Value = (decimal)( e.Node as TextureNode ).rotFactor;
                this.widthValue.Value = (decimal)( e.Node as TextureNode ).width;
                this.heightValue.Value = (decimal)( e.Node as TextureNode ).height;
                SharpDX.Vector2 center = ( e.Node as TextureNode ).center;
                this.xValue.Value = (decimal)center.X;
                this.yValue.Value = (decimal)center.Y;
                SharpDX.Color col = ( e.Node as TextureNode ).Color;
                this.alphaValue.Value = (decimal)col.A;
                this.layerValue.Value = (decimal)( e.Node as TextureNode ).layer;
                this.parentRotationCheckBox.Checked = ( e.Node as TextureNode ).relativRotation;
                game.selected = e.Node as TextureNode;
            }
        }

        private void Panel1_SizeChanged( object sender, EventArgs e )
        {
            this.treeView1.Size = this.splitContainer1.Panel1.ClientSize;
        }

        private void openFileDialog1_FileOk( object sender, System.ComponentModel.CancelEventArgs e )
        {
            TextureNode newNode = game.LoadBackgroundTexture( this.openFileDialog1.FileName, this.openFileDialog1.SafeFileName );
            if ( newNode != null )
            {
                if ( this.treeView1.SelectedNode != null )
                {
                    this.treeView1.SelectedNode.Nodes.Add( newNode );
                    if ( ( this.treeView1.SelectedNode as TextureNode ).layer > 0.01f )
                    {
                        newNode.layer = ( this.treeView1.SelectedNode as TextureNode ).layer - 0.01f;
                    }
                }
                else
                {
                    RootNode.Nodes.Add( newNode );
                    if ( RootNode.layer > 0.01f )
                    {
                        newNode.layer = RootNode.layer - 0.01f;
                    }
                }
                this.treeView1.ExpandAll();
            }
        }

        private void loadTextureToolStripMenuItem_Click( object sender, EventArgs e )
        {
            this.openFileDialog1.ShowDialog();
        }

        private void hideMouseToolStripMenuItem_Click( object sender, EventArgs e )
        {
            game.IsMouseVisible = false;
        }

        private void showMouseToolStripMenuItem_Click( object sender, EventArgs e )
        {
            game.IsMouseVisible = true;
        }

        private void exitToolStripMenuItem_Click( object sender, System.EventArgs e )
        {
            this.Close();
        }

        public void SetStatus( string text )
        {
            if ( this.InvokeRequired )
            {
                try { this.Invoke( SetInfo, new object[] { text } ); }
                catch ( ObjectDisposedException) { }
            }
            else
            {
                this.statusLabel1.Text = text;
            }
        }

        public void SetStatus2( string text )
        {
            if ( this.InvokeRequired )
            {
                try { this.Invoke( SetTitle, new object[] { text } ); }
                catch ( ObjectDisposedException) { }
            }
            else
            {
                SetTitle( text );
                //this.treeView1.Nodes.Add( text );
            }
        }

        private void label1_Click( object sender, EventArgs e )
        {

        }

    }
}
