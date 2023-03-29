using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace Monster_Game
{
   
    public static class Engine
    {
        public static int[,] gMatrix;
        static List<Monster> monsters = new List<Monster>();
        public static Player player;
        public static Point final;
        public static string crtLevel;
        public static void Load(string fileName)
        {
            TextReader load = new StreamReader(@"..\..\..\Maps\" + fileName);
            List<string> data = new List<string>();
            string buffer;
            while((buffer = load.ReadLine()) != null)
            {
                data.Add(buffer);
            }
            load.Close();
            gMatrix = new int[data.Count, data[0].Split(' ').Length];
            for (int i = 0; i < data.Count; i++)
            {
                string[] local = data[i].Split(' ');
                for (int j = 0; j < local.Length; j++)
                {
                    gMatrix[i,j] = int.Parse(local[j]);
                    if (gMatrix[i, j] == 5 || gMatrix[i, j] == 6 || gMatrix[i, j] == 7)
                    {
                        monsters.Add(new Monster(i, j, gMatrix[i, j]));
                    }
                    else
                        if (gMatrix[i, j] == 2)
                        player = new Player(i, j);
                    else
                        if (gMatrix[i, j] == 3) final = new Point(i,j);
                }
            }
            
        }

        public static float dw, dh;

        public static void DoMath(myGraphics handler)
        {
            dw = (float)handler.resx / gMatrix.GetLength(1);
            dh = (float)handler.resy / gMatrix.GetLength(0);
        }

        public static void Tick()
        {
            foreach(Monster m in monsters)
                m.Tick();
        }

        public static void Draw(myGraphics handler)
        {
            for (int i = 0; i < gMatrix.GetLength(0); i++)
            {
                for (int j = 0; j < gMatrix.GetLength(1); j++)
                {
                    switch(gMatrix[i,j])
                    {
                        case 1:
                            handler.grp.FillRectangle(Brushes.LightGray, j * dw, i * dh,dw,dh);
                            handler.grp.DrawRectangle(Pens.Black, j * dw, i * dh,dw,dh);
                            break;
                        case 2:
                            player.Draw(handler);
                            break;
                        case 3:
                            handler.grp.FillRectangle(Brushes.Black, j * dw, i * dh, dw, dh);
                            handler.grp.DrawRectangle(Pens.Black, j * dw, i * dh, dw, dh);
                            break;
                        case 9: //diamonds
                            handler.grp.FillEllipse(Brushes.DarkBlue, j * dw, i * dh, dw, dh);
                            handler.grp.DrawEllipse(Pens.Black, j * dw, i * dh, dw, dh);
                            break;
                        case 5: // orizontal
                           
                        case 6: // vertical
                           
                        case 7: // toate dir
                            break;

                    }
                }
                foreach(Monster m in monsters)
                {
                    m.Draw(handler);
                }
                player.Draw(handler);
            }
        }

        public static bool CanMove(int locX, int locY)
        {
            if (gMatrix[locY, locX] != 1)
                return true;
            return false;
        }
        public static bool IsMonster(int locX, int locY)
        {
            foreach(Monster monster in monsters)
            {
                if (monster.locX == locX && monster.locY == locY)
                    return true;
            }
            return false;
        }

    }

}
    
