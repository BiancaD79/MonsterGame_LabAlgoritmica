using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monster_Game
{
    internal class Player
    {
        public int locX, locY;
        public int dX, dY;
        public string imgFile;
        public int direction;
        int speed = 1;
        public Player(int locX, int locY, string img)
        {
            this.locX = locX;
            this.locY = locY;
            this.imgFile = img;
        }

        public void DrawImage(myGraphics handler)
        {
            Image image = Image.FromFile(imgFile);
            handler.grp.DrawImage(image, locY * Engine.dw, locX * Engine.dh, Engine.dw, Engine.dh);
        }

        public void Tick()
        {
            switch (direction)
            {
                case 1: // up
                    if (locX - speed > 0 && Engine.gMatrix[locX - speed, locY] != 1)
                        locX -= speed;
                    break;
                case 2: // down
                    if (locX + speed < Engine.gMatrix.GetLength(0) && Engine.gMatrix[locX + speed, locY] != 1)
                        locX += speed;
                    break;
                case 3: // right 
                    if (locY + speed < Engine.gMatrix.GetLength(1) && Engine.gMatrix[locX, locY + speed] != 1)
                        locY += speed;
                    break;
                case 4: //left 
                    if (locY - speed > 0 && Engine.gMatrix[locX, locY - speed] != 1)
                        locY -= speed;
                    break;
            }
        }
    }
}
