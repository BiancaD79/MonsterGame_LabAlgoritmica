namespace Monster_Game
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        myGraphics T = new myGraphics();
        private void Form1_Load(object sender, EventArgs e)
        {
            T.InitGraph(pictureBox1);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            T.ClearGraph();
            Engine.Tick();
            Engine.Draw(T);
            T.RefreshGraph();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            timer1.Start();
            Engine.Load(@"..\..\..\Maps.txt");
            Engine.DoMath(T);
            Engine.Draw(T);
            button2.Hide();
            button1.Hide();
            menubtn.Show();
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            Engine.MovePlayer(e);
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            Engine.StopPlayer(e);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ChooseLevel f = new ChooseLevel();
            f.ShowDialog();
        }

        private void menubtn_Click(object sender, EventArgs e)
        {
            T.ClearGraph();
            menubtn.Hide();
            button1.Show();
            button2.Show();
            Engine.Stop();
            timer1.Stop();
        }
    }
}