using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monster_Game
{
    public class Player
    {
        Point location;

        public Player()
        {

        }

        public Player(int x, int y)
        {
            location = new Point(x,y);
        }

        public Player(Point f)
        {
            location = f;
        }

        public void Draw(myGraphics handler)
        {
            handler.grp.DrawEllipse(new Pen(Color.DarkViolet), location.X * Engine.dw, location.Y * Engine.dh, Engine.dw, Engine.dh);
            handler.grp.FillEllipse(new SolidBrush(Color.DarkViolet), location.X * Engine.dw, location.Y * Engine.dh, Engine.dw, Engine.dh);
        }

        public void MoveUp()
        {
            if (Engine.CanMove(location.X, location.Y - 1))
                location.Y--;
        }

        public void MoveDown()
        {
            if (Engine.CanMove(location.X, location.Y + 1 ))
                location.Y++;
        }
        public void MoveLeft()
        {
            if (Engine.CanMove(location.X - 1, location.Y ))
                location.X--;
        }

        public void MoveRight()
        {
            if (Engine.CanMove(location.X + 1, location.Y ))
                location.X++;
        }
    }
}
