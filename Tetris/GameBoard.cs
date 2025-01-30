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
        private int[] boardStatus;

        // ============================ PROPERTIES ============================
        private Player? Player { get; set; }

        // =========================== CONSTRUCTORS ===========================
        internal GameBoard(Player player)
        {
            boardStatus = new int[200];
            Player = player;
        }

        internal int ValueAt(int x, int y)
        {
            return boardStatus[x + 10 * y];
        }
        internal void PlacePiece(int location)
        {
            boardStatus[location] = 1;
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
