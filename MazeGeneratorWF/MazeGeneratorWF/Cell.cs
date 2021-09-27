using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MazeGeneratorWF
{
    public class Cell
    {
        public int X { get; set; }
        public int Y { get; set; }

        public bool isVisited = false;

        public bool[] cellWalls = new bool[] { true, true, true, true };

        public Cell()
        {
            this.X = X;
            this.Y = Y;
        }
    }
}
