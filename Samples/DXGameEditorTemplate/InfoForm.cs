using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace GameEditorTemplate
{
    public partial class InfoForm : Form
    {
        int xOffset;
        int yOffset;

        public InfoForm()
        {
            InitializeComponent();
        }

        private void okClick( object sender, EventArgs e )
        {
            this.Close();
        }

        private void mouseMove( object sender, MouseEventArgs e )
        {
            if ( e.Button == System.Windows.Forms.MouseButtons.Left )
            {
                System.Drawing.Point pos = this.Location;
                pos.X += e.X - xOffset;
                pos.Y += e.Y - yOffset;
                this.Location = pos;

            }
        }

        private void mouseDown( object sender, MouseEventArgs e )
        {
            xOffset = e.X;
            yOffset = e.Y;
        }
    }
}
