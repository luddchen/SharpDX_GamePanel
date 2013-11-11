using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace GameTemplate
{
    public partial class Form1 : Form
    {
        private Game1 game;

        public Form1()
        {
            InitializeComponent();
            this.game = new Game1( this, this.panel1 );
            this.game.Run();
        }

        public void SetTitle( string text )
        {
            this.Text = text;
        }
    }
}
