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
            Engine.Load(@"..\..\..\Maps.txt");
            Engine.DoMath(T);
            Engine.Draw(T);
            //for (int i = 0; i < Engine.gMatrix.GetLength(0); i++)
              //  for (int j = 0; j < Engine.gMatrix.GetLength(1); j++)
                //{
                    
                //}
            
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
            button1.Dispose();
        }
    }
}