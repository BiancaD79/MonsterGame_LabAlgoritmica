using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monster_Game
{
    public enum MonsterType
    {
        Horizontal, Vertical, AllDirection
    }
    internal class Monster
    {
        public int locX, locY;
        public int dX, dY;
        public string imgFile;
        static Random rnd = new Random();
        public MonsterType type;
        public Monster(int locX,int locY,int type,string img)
        {
            this.locX = locX;
            this.locY = locY;
            this.imgFile = img;
            int t;
            switch (type)
            {
                case 5: this.type = MonsterType.Horizontal;
                    t = rnd.Next(2);
                    if (t == 0)
                        dY = -1;
                    else
                        dY = 1;
                    dX = 0; break;
                case 6: this.type= MonsterType.Vertical;
                    t = rnd.Next(2);
                    if (t == 0)
                        dX = -1;
                    else
                        dX = 1;
                    dY = 0; break;
                case 7: this.type= MonsterType.AllDirection;
                    t = rnd.Next(2);
                    int x, y;
                    if (t == 0)
                        x = -1;
                    else
                        x = 1;
                    t = rnd.Next(2);
                    if (t == 0)
                    { dX = x; dY = 0; }
                    else
                    { dY = x; dX = 0;} 
                    break;
            }
            
        }

        public void Tick()
        {
            if (Engine.gMatrix[locX + dX, locY + dY] == 1)
            {
                switch(type)
                {
                    case MonsterType.Vertical:
                        dX *= -1;
                        break;
                    case MonsterType.Horizontal:
                        dY *= -1;
                        break;
                    case MonsterType.AllDirection:
                        int t = rnd.Next(2);
                        int x, y;
                        if (t == 0)
                            x = -1;
                        else
                            x = 1;
                        t = rnd.Next(2);
                        if (t == 0)
                        { dX = x; dY = 0; }
                        else
                        { dY = x; dX = 0; }
                        break;
                }
                
            }
            else
            {
                locY += dY;
                locX += dX;
            }
        }
        public void Draw(myGraphics handler)
        {
            Color fillColor = Color.White;
            Color drawColor = Color.White;
            switch (type)
            { 
                case MonsterType.Horizontal:
                    fillColor = Color.LightBlue;
                    drawColor = Color.DarkBlue;
                    break;
                case MonsterType.Vertical:
                    fillColor = Color.LightPink;
                    drawColor = Color.DeepPink;
                    break;
                case MonsterType.AllDirection:
                    fillColor = Color.LightGreen;
                    drawColor = Color.DarkGreen;
                    break;
            }

            handler.grp.FillEllipse(new SolidBrush(fillColor), locY * Engine.dw, locX * Engine.dh, Engine.dw, Engine.dh);
            handler.grp.DrawEllipse(new Pen(drawColor), locY * Engine.dw, locX * Engine.dh, Engine.dw, Engine.dh);
        }

        public void DrawImage(myGraphics handler)
        {
            Image image = Image.FromFile(imgFile);
            handler.grp.DrawImage(image, locY * Engine.dw, locX * Engine.dh, Engine.dw, Engine.dh);
        }
    }
}
