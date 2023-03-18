using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Monster_Game
{
    public partial class ChooseLevel : Form
    {
        public ChooseLevel()
        {
            InitializeComponent();
        }

        List<string> map = new List<string>();
        string fileName = "../../../Levels.txt";
        List<string> levels = new List<string>();
        int lvlCount = 1;

        private void ChooseLevel_Load(object sender, EventArgs e)
        {
            GenerateLevels("../../../Levels.txt");
            GenerateButtons();
        }

        void GenerateLevels(string fileName)
        {
            TextReader tr = new StreamReader(fileName);
            string buffer;

            while ((buffer = tr.ReadLine()) != null)
            {
                if (buffer[0] == ' ') lvlCount++;
                levels.Add(buffer);
            }

            tr.Close();
        }

        void GenerateButtons()
        {
            Button[] options = new Button[lvlCount];

            for (int i = 0; i < lvlCount; i++)
            {
                options[i] = new Button();
            }

            for (int i = 0; i < lvlCount; i++)
            {
                options[i].Tag = i + 1;
                options[i].Width = 50;
                options[i].Height = 50;
                options[i].BackColor = Color.AliceBlue;

                options[i].Text = (i+1).ToString();

                options[i].Click += new EventHandler(ClickButton);
                flowLayoutPanel1.Controls.Add(options[i]);
            }
        }
        public void ClickButton(Object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            int idx = btn.Text[0] - '0';
            GetMapFromFile(idx);
            TextWriter sw = new StreamWriter("../../../Maps.txt", false);
            sw.Flush();
            for (int i = 0; i < map.Count; i++)
            {
                sw.WriteLine(map[i]);
            }
            sw.Close();
        }

        private void GetMapFromFile(int index)
        {
            int level = 1;
            map.Clear();

            foreach (var line in levels)
            {
               if(level == index)
                {
                    if (line[0] == ' ') break;
                        map.Add(line);
                }
               else
                {
                    if (line[0] == ' ') level++;
                }
            }

        }
        private void button1_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
