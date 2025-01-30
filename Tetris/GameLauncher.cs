using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris
{
    internal class GameLauncher
    {
        internal void Go()
        {
            Game game = new Game();
            game.Setup();
            game.Start();
        }
    }
}
