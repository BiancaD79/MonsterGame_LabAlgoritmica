using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace Monster_Game
{
    public class myGraphics
    {
        PictureBox display;
        Bitmap bmp;
        public Graphics grp;
        public int resx;
        public int resy;
        Color bkColor = Color.DeepSkyBlue;


        public void InitGraph(PictureBox display)
        {
            this.display = display;
            this.bmp = new Bitmap(display.Width, display.Height);
            resx = display.Width;
            resy = display.Height;
            grp = Graphics.FromImage(bmp);
            ClearGraph();
            RefreshGraph();
        }

        public void ClearGraph()
        {
            grp.Clear(bkColor);
        }

        public void RefreshGraph()
        {
            this.display.Image = bmp;
        }

    }
}
