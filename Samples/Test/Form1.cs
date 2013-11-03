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
            this.loadTextureToolStripMenuItem.Click += loadTextureToolStripMenuItem_Click;

            this.openFileDialog1.FileOk += openFileDialog1_FileOk;

            this.splitContainer1.Panel1.SizeChanged += Panel1_SizeChanged;
            this.treeView1.Nodes.Add( RootNode = new TextureNode() );
            RootNode.Text = "Root";
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
                }
                else
                {
                    RootNode.Nodes.Add( newNode );
                }
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

    }
}
