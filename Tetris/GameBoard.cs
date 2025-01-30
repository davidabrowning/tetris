using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris
{
    internal class GameBoard
    {
        // ============================ VARIABLES =============================
        private int[] boardStatus = new int[200];

        // ============================ PROPERTIES ============================
        private Player? Player { get; set; }

        internal void PlacePiece(int location)
        {
            boardStatus[location] = 1;
        }

        // =========================== CONSTRUCTORS ===========================
        internal GameBoard(Player player)
        {
            Player = player;
        }

        // ============================== METHOD ==============================
        // ToString. Overrides default ToString and prints current GameBoard.
        // ====================================================================
        public override string ToString()
		{
            string boardAsString = "";
            for (int y = 19; y >= 0; y--)
            {
                boardAsString += (" * ");
                for (int x = 0; x <= 9; x++)
                {
                    if (boardStatus[x + 10 * y] == 1)
                    {
                        boardAsString += " # ";
                    }
                    else if (Player.X == x && Player.Y == y)
                    {
                        boardAsString += (" # ");
                    }
                    else
                    {
                        boardAsString += ("   ");
                    }
                }
                boardAsString += (" * ");
                boardAsString += ("\n");
            }
            for (int x = 0; x <= 9 + 2; x++)
            {
                boardAsString += (" * ");
            }
            return boardAsString;
		}

	}
}
