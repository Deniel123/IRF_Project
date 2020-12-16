using IRF_Project2.Abstractions;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRF_Project2.Entities
{
    public class Candle : Rajz
    {
        protected override void DrawImage(Graphics g)
        {
            Image imageFile = Image.FromFile("Images/candle.jpg");
            g.DrawImage(imageFile, new Rectangle(0, 0, Width, Height));
        }
    }
}
