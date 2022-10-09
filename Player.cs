using System.Drawing;

namespace treasuremaze
{
    public class Player
    {
        public int PosX;
        public int PosY;

        public int DirX;
        public int DirY;
        public bool IsMoving;

        public int CurrentAnimation;
        public int CurrentFrame;
        public int CurrentLimit;

        public int IdleFrame;
        public int UpFrame;
        public int DownFrame;
        public int RightFrame;
        public int LeftFrame;

        public int size;

        public Image SpriteSheet;

        public Player(int posX, int posY, int idleFrame, int upFrame, int downFrame, int rightFrame, int leftFrame, Image spriteSheet)
        {
            this.PosX = posX;
            this.PosY = posY;
            this.IdleFrame = idleFrame;
            this.UpFrame = upFrame;
            this.DownFrame = downFrame;
            this.RightFrame = rightFrame;
            this.LeftFrame = leftFrame;
            this.SpriteSheet = spriteSheet;
            size = 21;
            CurrentAnimation = 0;
            CurrentFrame = 0;
            CurrentLimit = IdleFrame;
        }

        public void Move()
        {
            PosX += DirX;
            PosY += DirY;
        }

        public void PlayAnimation(Graphics g)
        {
            if (CurrentFrame < CurrentLimit - 1)
                CurrentFrame++;
            else CurrentFrame = 0;
            g.DrawImage(SpriteSheet, new Rectangle(new Point(PosX, PosY), new Size(size, size)), 21 * CurrentFrame, 21 * CurrentFrame, size, size, GraphicsUnit.Pixel);
            
        }

        public void SetAnimation(int currentAnimation)
        {
            this.CurrentAnimation = currentAnimation;
            switch (currentAnimation)
            {
                case 0:
                    CurrentLimit = IdleFrame;
                    break;
                case 1:
                    CurrentLimit = DownFrame;
                    break;
                case 2:
                    CurrentLimit = UpFrame;
                    break;
                case 3:
                    CurrentLimit = LeftFrame;
                    break;
                case 4:
                    CurrentLimit = RightFrame;
                    break;

            }
        }
    }
}
