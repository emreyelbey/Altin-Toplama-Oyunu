using System;
using System.Drawing;
using System.Windows.Forms;

namespace AltınToplamaOyunu2
{
    public class Kare
    {
        private int x, y, width, heigth;
        public Rectangle rectangle;

        public Kare(int x, int y, int width, int height)
        {
            this.x = x;
            this.y = y;
            this.width = width;
            this.heigth = height;
        }

        public void KareCizdir(PaintEventArgs g, Color color)
        {
            Pen pen = new Pen(color, 4);
            rectangle = new Rectangle(x, y, width, heigth);
            g.Graphics.DrawRectangle(pen, rectangle);
        }

        public void KareBoya(PaintEventArgs g, Color color)
        {
            SolidBrush solidBrush = new SolidBrush(color);
            rectangle = new Rectangle(x, y, width, heigth);
            g.Graphics.FillRectangle(solidBrush, rectangle);
        }

        public void KareYazdir(PaintEventArgs g, Color color, String str)
        {
            Font font = new Font("Microsoft YaHei UI", width/3);
            SolidBrush solidBrush = new SolidBrush(color);
            rectangle = new Rectangle(x, y, width, heigth);
            //g.Graphics.DrawString(str, font, solidBrush, x + width/6, y + heigth/4);
            g.Graphics.DrawString(str, font, solidBrush, x + width/2, y + heigth/2, new StringFormat()
            {
                Alignment = StringAlignment.Center,
                LineAlignment = StringAlignment.Center
            });   
        }
    }
}
