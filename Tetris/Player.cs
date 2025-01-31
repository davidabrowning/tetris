using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Tetris
{
    internal class Player
    {
        // ============================ VARIABLES =============================
        private int x;
        private int y;

        // ============================ PROPERTIES ============================
        internal int X { get; set; }
        internal int Y { get; set; }

        internal void Descend()
        {
            Y = Math.Max(0, Y - 1);
        }
    }
}
