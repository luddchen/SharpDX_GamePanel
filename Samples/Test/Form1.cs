using System;
using System.Windows.Forms;


namespace Test
{

    public partial class Form1 : Form
    {

        private delegate void StatusInfo( string text );

        private StatusInfo SetInfo;

        public Form1()
        {
            InitializeComponent();

            this.exitToolStripMenuItem.Click += exitToolStripMenuItem_Click;
            SetInfo = delegate( string text )
            {
                this.statusLabel1.Text = text;
            };
            
            Game1 game = new Game1( this.splitContainer.Panel2 );
            game.form = this;
            game.TargetFps = 120;
            game.Start();
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
