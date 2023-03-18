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
        static Player player;
        public static void Load(string fileName)
        {
            TextReader load = new StreamReader(fileName);
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
                        monsters.Add(new Monster(i, j, gMatrix[i, j], "../../../Resources/monster.png"));
                    }
                    else
                        if (gMatrix[i, j] == 2) player = new Player(i,j,"../../../Resources/player.png");
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
            player.Tick();
        }

        public static void MovePlayer(KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down) player.direction = 2;
            else
                if (e.KeyCode == Keys.Up)
                player.direction = 1;
            else
                if (e.KeyCode == Keys.Right) player.direction = 3;
            else
                if (e.KeyCode == Keys.Left) player.direction = 4;

        }

        public static void StopPlayer(KeyEventArgs e)
        {
            player.direction = 0;
        }

        public static void Stop()
        {
            monsters.Clear();
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
                            player.DrawImage(handler);
                            break;
                        case 3: // final
                            break;
                        case 9: //diamonds
                            handler.grp.FillEllipse(Brushes.BlueViolet, j * dw, i * dh, dw, dh);
                            handler.grp.DrawEllipse(Pens.Black, j * dw, i * dh, dw, dh);
                            break;

                    }
                }
                foreach(Monster m in monsters)
                {
                    m.DrawImage(handler);
                }
            }
            player.DrawImage(handler);
        }
        
    }

}
    
