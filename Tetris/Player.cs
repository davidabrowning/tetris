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
        public int X { get; set; }
        public int Y { get; set; }
        
        // =========================== CONSTRUCTORS ===========================
        internal Player()
        {
            X = 4;
            Y = 19;
        }

        internal void Descend()
        {
            Y = Math.Max(0, Y - 1);
        }
        internal void ResetPosition()
        {
            X = 4;
            Y = 19;
        }
    }
}
