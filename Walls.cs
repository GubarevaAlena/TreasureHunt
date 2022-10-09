using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace treasuremaze
{
    public static class Walls
    {
        public static bool WillHit(Player mc, Point dir)
        {
            for(int i = 0; i < MapController.mazeWalls.Count; i++)
            {
                var currObject = MapController.mazeWalls[i];
                PointF delta = new PointF();
                delta.X = (mc.PosX + mc.size / 2) - (currObject.position.X + currObject.size.Width / 2);
                delta.Y = (mc.PosX + mc.size / 2) - (currObject.position.Y + currObject.size.Height / 2);
                if(Math.Abs(delta.X) <= mc.size / 2 + currObject.size.Width)
                {
                    if (Math.Abs(delta.Y) <= mc.size / 2 + currObject.size.Height)
                    {
                        if (delta.X < 0 && dir.X == 1)
                        {
                            return true;
                        }
                        if (delta.X > 0 && dir.X == -1)
                        {
                            return true;
                        }
                        if (delta.Y < 0 && dir.Y == 1)
                        {
                            return true;
                        }
                        if (delta.Y > 0 && dir.Y == -1)
                        {
                            return true;
                        }
                    }
                }
            }
            return false;
        }
        /*public static void WillHit(Player mc)
        {
            for (int i = mc.PosX/MapController.Cell; i < (mc.PosX+MapController.Cell)/MapController.Cell; i++)
            {
                for (int j = mc.PosY / MapController.Cell; j < (mc.PosY + MapController.Cell) / MapController.Cell; j++)
                {
                    if (MapController.map[i,j] != 1 && MapController.map[i, j] != 13)
                    {
                        if (mc.DirY > 0)
                            mc.PosY -= 3;
                        if (mc.DirY <= 0)
                            mc.PosY += 3;
                        if (mc.DirX > 0)
                            mc.PosX -= 3;
                        if (mc.DirX <= 0)
                            mc.PosX += 3;
                    }
                }
            }

        }*/
    }
}
