using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace treasuremaze
{
    public static class MapController
    {
        public const int MapHeight = 17;
        public const int MapWidth = 17;
        public static int Cell = 22;
        public static int[,] map = new int[MapHeight, MapWidth];
        public static Image Maze;
        public static List<Hit> mazeWalls;

        public static void Init()
        {
            map = GetMap();
            Maze = new Bitmap(Path.Combine(new DirectoryInfo(Directory.GetCurrentDirectory()).Parent.Parent.FullName.ToString(), "Assets\\maze.png"));
            mazeWalls = new List<Hit>();
        }
        public static int[,] GetMap()
        {
            return new int[,]
            {
                {1, 0, 4, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 10},
                {1, 0, 0, 0, 13, 0, 0, 0, 1, 0, 0, 0, 0, 0, 13, 0, 8},
                {1, 2, 2, 2, 2, 2, 2, 0, 1, 0, 2, 2, 2, 2, 2, 2, 8},
                {1, 0, 0, 0, 1, 0, 0, 0, 1, 0, 0, 0, 0, 0, 13, 0, 8},
                {1, 0, 1, 0, 1, 0, 2, 2, 2, 2, 2, 0, 5, 2, 2, 0, 8},
                {1, 0, 1, 0, 0, 13, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 8},
                {1, 0, 1, 2, 2, 2, 2, 0, 5, 2, 2, 2, 6, 0, 2, 2, 8},
                {1, 0, 1, 0, 0, 13, 0, 0, 1, 0, 0, 0, 13, 0, 0, 0, 8},
                {1, 13, 1, 2, 2, 2, 2, 2, 6, 0, 2, 2, 2, 2, 2, 0, 8},
                {1, 0, 1, 0, 0, 0, 0, 0, 0, 13, 0, 0, 1, 0, 0, 0, 8},
                {1, 0, 1, 0, 5, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 8},
                {1, 0, 1, 0, 1, 0, 0, 0, 0, 0, 1, 0, 0, 0, 13, 0, 8},
                {1, 0, 1, 0, 11, 3, 3, 3, 3, 0, 1, 0, 5, 2, 2, 0, 8},
                {1, 0, 1, 0, 0, 0, 0, 0, 0, 13, 1, 0, 1, 0, 0, 0, 8},
                {1, 13, 11, 3, 3, 3, 3, 3, 12, 0, 1, 0, 1, 0, 2, 2, 8},
                {1, 0, 0, 0, 0, 0, 13, 0, 1, 0, 0, 0, 1, 13, 0, 0, 8},
                {7, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 9}
            };
        }

        public static void WallMap(Graphics g)
        {
            for (int i = 0; i < MapWidth; i++)
            {
                for (int j = 0; j < MapHeight; j++)
                {
                    
                }
            }
        }
        
        public static void DrawMap(Graphics g)
        {
            //WallMap(g);
            for (int i = 0; i < MapWidth; i++)
            {
                for (int j = 0; j < MapHeight; j++)
                {
                    if (map[i, j] == 0) //клетка
                    {
                        g.DrawImage(Maze, new Rectangle(new Point(j * Cell, i * Cell), new Size(Cell, Cell)), 1, 1, 22, 22, GraphicsUnit.Pixel);
                    }
                    else if (map[i, j] == 1) //вертикальная стена
                    {
                        g.DrawImage(Maze, new Rectangle(new Point(j * Cell, i * Cell), new Size(Cell, Cell)), 76, 2, 22, 22, GraphicsUnit.Pixel);
                        Hit hitbox = new Hit(new Point(j * Cell, i * Cell), new Size(Cell, Cell));
                        mazeWalls.Add(hitbox);
                    }
                    else if (map[i, j] == 2) //горизонтальная стена
                    {
                        g.DrawImage(Maze, new Rectangle(new Point(j * Cell, i * Cell), new Size(Cell, Cell)), 32, 1, 22, 22, GraphicsUnit.Pixel);
                        Hit hitbox = new Hit(new Point(j * Cell, i * Cell), new Size(Cell, Cell));
                        mazeWalls.Add(hitbox);
                    }
                    else if (map[i, j] == 3) //горизонтальная стена снизу
                    {
                        g.DrawImage(Maze, new Rectangle(new Point(j * Cell, i * Cell), new Size(Cell, Cell)), 32, 28, 22, 22, GraphicsUnit.Pixel);
                        Hit hitbox = new Hit(new Point(j * Cell, i * Cell), new Size(Cell, Cell));
                        mazeWalls.Add(hitbox);
                    }
                    else if (map[i, j] == 4) //угол1
                    {
                        g.DrawImage(Maze, new Rectangle(new Point(j * Cell, i * Cell), new Size(Cell, Cell)), 100, 32, 22, 22, GraphicsUnit.Pixel);
                        Hit hitbox = new Hit(new Point(j * Cell, i * Cell), new Size(Cell, Cell));
                        mazeWalls.Add(hitbox);
                    }
                    else if (map[i, j] == 5) //угол2
                    {
                        g.DrawImage(Maze, new Rectangle(new Point(j * Cell, i * Cell), new Size(Cell, Cell)), 139, 5, 22, 22, GraphicsUnit.Pixel);
                        Hit hitbox = new Hit(new Point(j * Cell, i * Cell), new Size(Cell, Cell));
                        mazeWalls.Add(hitbox);
                    }
                    else if (map[i, j] == 6) //угол3
                    {
                        g.DrawImage(Maze, new Rectangle(new Point(j * Cell, i * Cell), new Size(Cell, Cell)), 171, 11, 22, 22, GraphicsUnit.Pixel);
                        Hit hitbox = new Hit(new Point(j * Cell, i * Cell), new Size(Cell, Cell));
                        mazeWalls.Add(hitbox);
                    }
                    else if (map[i, j] == 7) //угол4
                    {
                        g.DrawImage(Maze, new Rectangle(new Point(j * Cell, i * Cell), new Size(Cell, Cell)), 75, 37, 22, 22, GraphicsUnit.Pixel);
                        Hit hitbox = new Hit(new Point(j * Cell, i * Cell), new Size(Cell, Cell));
                        mazeWalls.Add(hitbox);
                    }
                    else if (map[i, j] == 8) //вертиакальная сетна справа
                    {
                        g.DrawImage(Maze, new Rectangle(new Point(j * Cell, i * Cell), new Size(Cell, Cell)), 1, 29, 22, 22, GraphicsUnit.Pixel);
                        Hit hitbox = new Hit(new Point(j * Cell, i * Cell), new Size(Cell, Cell));
                        mazeWalls.Add(hitbox);
                    }
                    else if (map[i, j] == 9) //угол5
                    {
                        g.DrawImage(Maze, new Rectangle(new Point(j * Cell, i * Cell), new Size(Cell, Cell)), 145, 33, 22, 22, GraphicsUnit.Pixel);
                        Hit hitbox = new Hit(new Point(j * Cell, i * Cell), new Size(Cell, Cell));
                        mazeWalls.Add(hitbox);
                    }
                    else if (map[i, j] == 10) //угол6
                    {
                        g.DrawImage(Maze, new Rectangle(new Point(j * Cell, i * Cell), new Size(Cell, Cell)), 171, 30, 22, 22, GraphicsUnit.Pixel);
                        Hit hitbox = new Hit(new Point(j * Cell, i * Cell), new Size(Cell, Cell));
                        mazeWalls.Add(hitbox);
                    }
                    else if (map[i, j] == 11) //угол7
                    {
                        g.DrawImage(Maze, new Rectangle(new Point(j * Cell, i * Cell), new Size(Cell, Cell)), 191, 12, 22, 22, GraphicsUnit.Pixel);
                        Hit hitbox = new Hit(new Point(j * Cell, i * Cell), new Size(Cell, Cell));
                        mazeWalls.Add(hitbox);
                    }
                    else if (map[i, j] == 12)//угол8
                    {
                        g.DrawImage(Maze, new Rectangle(new Point(j * Cell, i * Cell), new Size(Cell, Cell)), 197, 30, 22, 22, GraphicsUnit.Pixel);
                        Hit hitbox = new Hit(new Point(j * Cell, i * Cell), new Size(Cell, Cell));
                        mazeWalls.Add(hitbox);
                    }
                    else //плитка с трещиной
                    {
                        g.DrawImage(Maze, new Rectangle(new Point(j * Cell, i * Cell), new Size(Cell, Cell)), 1, 55, 22, 22, GraphicsUnit.Pixel);
                    }
                }
            }
        }

    }
}
