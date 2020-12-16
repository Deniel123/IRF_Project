using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IRF_Project2.Abstractions
{
    public abstract class Rajz : Label
    {
        public Rajz()
        {
            AutoSize = false;
            Width = 50;
            Height = Width;
            Paint += Rajz_Paint;
        }
        private void Rajz_Paint(object sender, PaintEventArgs e)
        {
            DrawImage(e.Graphics);
        }
        protected abstract void DrawImage(Graphics g)
    }
}
