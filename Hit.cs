using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace treasuremaze
{
    public class Hit
    {
        public PointF position;
        public Size size;

        public Hit(PointF pos, Size size)
        {
            this.position = pos;
            this.size = size;
        }
    }
}
