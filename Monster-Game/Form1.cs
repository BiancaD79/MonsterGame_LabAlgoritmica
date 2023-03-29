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
            Engine.Load(Engine.crtLevel);
            Engine.DoMath(T);
            Engine.Draw(T);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            T.ClearGraph();
            Engine.Tick();
            Engine.Draw(T);
            T.RefreshGraph();
        }

       /* private void button1_Click(object sender, EventArgs e)
        {
            timer1.Start();
            button1.Dispose();
        }*/

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            switch(e.KeyCode)
            {
                case Keys.Down:
                    Engine.player.MoveDown();
                    break;
                case Keys.Up:
                    Engine.player.MoveUp();
                    break;
                case Keys.Left:
                    Engine.player.MoveLeft();
                    break;
                case Keys.Right:
                    Engine.player.MoveRight();
                    break;
                case Keys.Space:
                    timer1.Enabled = !timer1.Enabled;
                    break;
            }
            //T.ClearGraph();
            //Engine.Draw(T);
            //T.RefreshGraph();
        }
    }
}