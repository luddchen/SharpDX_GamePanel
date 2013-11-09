using System;
using System.Windows.Forms;

namespace DXTest
{
    public partial class Form1 : Form
    {
        Game1 game;

        public Form1()
        {
            InitializeComponent();

            this.game = new Game1( this.splitContainer1.Panel2 );
            this.game.Run();
            this.exitToolStripMenuItem.Click += exitToolStripMenuItem_Click;
            this.FormClosing += Form1_FormClosing;
        }

        private void Form1_FormClosing( object sender, FormClosingEventArgs e )
        {
            this.game.Exit();
        }

        private void exitToolStripMenuItem_Click( object sender, EventArgs e )
        {
            this.Close();
        }
    }
}
