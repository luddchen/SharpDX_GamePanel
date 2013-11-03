using System;
using System.Windows.Forms;

namespace Test
{

    public partial class Form1 : Form
    {

        private delegate void StatusInfo( string text );

        private StatusInfo SetInfo;

        private Game1 game;

        public Form1()
        {
            InitializeComponent();

            this.exitToolStripMenuItem.Click += exitToolStripMenuItem_Click;
            SetInfo = delegate( string text )
            {
                this.statusLabel1.Text = text;
            };
            
            game = new Game1( this.splitContainer.Panel2 );
            game.form = this;
            game.Start();

            this.showMouseToolStripMenuItem.Click += showMouseToolStripMenuItem_Click;
            this.hideMouseToolStripMenuItem.Click += hideMouseToolStripMenuItem_Click;
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
                try
                {
                    this.Invoke( SetInfo, new object[] { text } );
                }
                catch ( ObjectDisposedException e )
                {
                    Console.WriteLine( e.ObjectName + " is disposed ..." );
                }
            }
            else
            {
                this.statusLabel1.Text = text;
            }
        }


    }
}
