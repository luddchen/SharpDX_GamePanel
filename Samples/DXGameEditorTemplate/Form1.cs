using System;
using System.Windows.Forms;


namespace GameEditorTemplate
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            Game1 game = new Game1( this, this.editorSplitPanel1.CenterPanel );
            game.Run();
        }

        public void SetStatusText( string text )
        {
            this.statusLabel.Text = text;
        }

        private void exitClick( object sender, EventArgs e )
        {
            this.Close();
        }

        private void toolsVisible( object sender, EventArgs e )
        {
            this.tools.Visible = !this.tools.Visible;
        }

        private void statusVisible( object sender, EventArgs e )
        {
            this.status.Visible = !this.status.Visible;
        }

        private void rightVisible( object sender, EventArgs e )
        {
            this.editorSplitPanel1.RightSplit.Panel2Collapsed = !this.editorSplitPanel1.RightSplit.Panel2Collapsed;
        }

        private void leftVisible( object sender, EventArgs e )
        {
            this.editorSplitPanel1.LeftSplit.Panel1Collapsed = !this.editorSplitPanel1.LeftSplit.Panel1Collapsed;
        }

        private void bottomVisible( object sender, EventArgs e )
        {
            this.editorSplitPanel1.BottomSplit.Panel2Collapsed = !this.editorSplitPanel1.BottomSplit.Panel2Collapsed;
        }

        private void topVisible( object sender, EventArgs e )
        {
            this.editorSplitPanel1.TopSplit.Panel1Collapsed = !this.editorSplitPanel1.TopSplit.Panel1Collapsed;
        }

        private void infoClick( object sender, EventArgs e )
        {
            DXControls.InfoForm info = new DXControls.InfoForm();
            info.ShowDialog();
        }

        private void gameModeClick( object sender, EventArgs e )
        {
            this.editorSplitPanel1.GameMode = this.gameModeToolStripMenuItem.Checked;
            this.status.Visible = !this.gameModeToolStripMenuItem.Checked;
            this.tools.Visible = !this.gameModeToolStripMenuItem.Checked;
            if ( this.gameModeToolStripMenuItem.Checked )
            {
                this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            }
            else
            {
                this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;
            }
        }
    }
}
