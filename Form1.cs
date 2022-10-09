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
        public Player mc;
        public int[,] map = new int[MapController.MapHeight, MapController.MapWidth];
        public Form1()
        {
            InitializeComponent();
            timer1.Interval = 20;
            timer1.Tick += new EventHandler(Update);

            KeyDown += new KeyEventHandler(OnPress);
            KeyUp += new KeyEventHandler(OnKeyUp);

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



        public void Init()
        {
            MapController.Init();
            this.Width = (MapController.Cell+1) * MapController.MapWidth;
            this.Height = (MapController.Cell+2) * (MapController.MapHeight+1);
            Score();
            Time();

            mcSheet = new Bitmap(Path.Combine(new DirectoryInfo(Directory.GetCurrentDirectory()).Parent.Parent.FullName.ToString(), "Assets\\mc.png"));
            mc = new Player(21, 0, Hero.IdleFrame, Hero.UpFrame, Hero.DownFrame, Hero.RightFrame, Hero.LeftFrame, mcSheet);
            timer1.Start();
            timer2.Start();
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
            mc.PlayAnimation(g);
        }

        int timeleft = 5;
        private void timer2_Tick(object sender, EventArgs e)
        {
            if (timeleft > 0)
            {
                timeleft -= 1;
                label1.Text = timeleft + " seconds";
            }
            else
            {
                mc.DirX = 0;
                mc.DirY = 0;
                mc.IsMoving = false;
            }
        }
    }
}
