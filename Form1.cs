using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.IO;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace treasuremaze
{
    public partial class Form1 : Form
    {
        public Image mcSheet;
        public Image chestSheet;
        public Player mc;
        public Chest chest;
        public int[,] map = new int[MapController.MapHeight, MapController.MapWidth];
        public int[,] emptymap = new int[MapController.MapHeight, MapController.MapWidth];
        private readonly Random random = new Random();
        public Form1()
        {
            InitializeComponent();
            timer1.Interval = 20;
            timer1.Tick += new EventHandler(Update);

            KeyDown += new KeyEventHandler(OnPress);
            KeyUp += new KeyEventHandler(OnKeyUp);

            timer1.Start();
            timer2.Start();
            Init();
        }

        public void OnKeyUp(object sender, KeyEventArgs e)
        {
            mc.DirX = 0;
            mc.DirY = 0;
            mc.IsMoving = false;
            mc.SetAnimation(0);
        }

        public void OnPress(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Down:
                    mc.DirY = 3;
                    mc.IsMoving = true;
                    break;
                case Keys.Up:
                    mc.DirY = -3;
                    mc.IsMoving = true;
                    break;
                case Keys.Left:
                    mc.DirX = -3;
                    mc.IsMoving = true;
                    break;
                case Keys.Right:
                    mc.DirX = 3;
                    mc.IsMoving = true;
                    break;
            }

        }

        public void Score()
        {
            Label score = new Label();
            score.Text = "Score ";
            score.Location = new Point(10, (MapController.Cell) * (MapController.MapHeight));
            score.AutoSize = true;
            score.ForeColor = Color.White;
            score.BackColor = Color.Black;
            this.Controls.Add(score);
        }
        public void ScoreCount()
        {
            Label scoreCount = new Label();
            scoreCount.Text = " points";
            scoreCount.Location = new Point(50, (MapController.Cell) * (MapController.MapHeight));
            scoreCount.AutoSize = true;
            scoreCount.ForeColor = Color.White;
            scoreCount.BackColor = Color.Black;
            this.Controls.Add(scoreCount);
        }
        public void Time()
        {
            Label time = new Label();
            time.Text = "Time ";
            time.Location = new Point(100, (MapController.Cell) * (MapController.MapHeight));
            time.AutoSize = true;
            time.ForeColor = Color.White;
            time.BackColor = Color.Black;
            this.Controls.Add(time);
        }

        public void Wall()
        {
            PictureBox wall = new PictureBox();
            wall.Location = new Point(100, 100);
        }


        int timeleft = 10;
        private void timer2_Tick(object sender, EventArgs e)
        {
            Label timer = new Label();
            timer.Location = new Point(140, (MapController.Cell) * (MapController.MapHeight));
            timer.AutoSize = true;
            timer.ForeColor = Color.White;
            timer.BackColor = Color.Black;
            this.Controls.Add(timer);
            if (timeleft > 0)
            {
                timeleft -= 1;
                timer.Text = timeleft + " seconds";
            }
            else
            {
                timer2.Stop();
            }

        }


        public void Init()
        {
            MapController.Init();
            this.Width = (MapController.Cell+1) * MapController.MapWidth;
            this.Height = (MapController.Cell+2) * (MapController.MapHeight+1);
            Score();
            ScoreCount();
            Time();

            mcSheet = new Bitmap(Path.Combine(new DirectoryInfo(Directory.GetCurrentDirectory()).Parent.Parent.FullName.ToString(), "Assets\\mc.png"));
            mc = new Player(23, 1, Hero.IdleFrame, Hero.UpFrame, Hero.DownFrame, Hero.RightFrame, Hero.LeftFrame, mcSheet);
            SpondChest();
        }

        public void SpondChest()
        {
            bool isempty = false;
            int [,] Empty = MapController.GetEmptyMap();
            int chestX = random.Next(1, MapController.MapWidth-1);
            int chestY = random.Next(1, MapController.MapHeight-1);
            do
            {
                isempty = false;
                chestX = random.Next(1, MapController.MapWidth - 1);
                chestY = random.Next(1, MapController.MapHeight - 1);
            } while (Empty[chestX, chestY] != 0);
            isempty = true;

            chestSheet = new Bitmap(Path.Combine(new DirectoryInfo(Directory.GetCurrentDirectory()).Parent.Parent.FullName.ToString(), "Assets\\chest_1.png"));
            if (isempty == true)
                chest = new Chest(chestX * 22 + 3, chestY * 22 + 4, chestSheet);

        }

        public void Update(object sender, EventArgs e)
        {
            if (!Walls.WillHit(mc, new Point(mc.DirX, mc.DirY)))
            {
                if (mc.IsMoving)
                    mc.Move();
            }
            //Walls.WillHit(mc);
            Invalidate();
        }

        private void OnPaint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            MapController.DrawMap(g);
            chest.AddChest(g);
            mc.PlayAnimation(g);
        }

        
    }
}
