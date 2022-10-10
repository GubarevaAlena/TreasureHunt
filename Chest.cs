using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace treasuremaze
{
    public class Chest
    {
        public int PosX;
        public int PosY;
        public int size;
        public Image SpriteSheet;

        public Chest(int posX, int posY, Image spriteSheet)
        {
            this.PosX = posX;
            this.PosY = posY;
            size = 17;
            this.SpriteSheet = spriteSheet;
        }
        public void AddChest(Graphics g)
        { 
            g.DrawImage(SpriteSheet, new Rectangle(new Point(PosX, PosY), new Size(size, size)), 1, 1, size, size, GraphicsUnit.Pixel);
        }

    }
}
