using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Tetris
{
    internal class GameBoard
    {
        // ============================ VARIABLES =============================
        private int numCols;
        private int numRows;
        private int[] boardStatus;

        // ============================ PROPERTIES ============================
        private Player? Player { get; set; }
        public int XMax { get { return numCols - 1; } }
        public int YMax { get { return numRows - 1; } }


        // =========================== CONSTRUCTORS ===========================
        internal GameBoard(Player player)
        {
            numCols = 10;
            numRows = 20;
            boardStatus = new int[numCols * numRows];
            Player = player;
        }

        internal int ValueAt(int x, int y)
        {
            return boardStatus[x + numCols * y];
        }
        internal void PlacePiece(int location)
        {
            boardStatus[location] = 1;
        }

        // ============================== METHOD ==============================
        // PlayerIsAtRest. Returns a bool true if Player is at rest and piece
        // should be placed.
        // ====================================================================
        internal bool PlayerIsAtRest()
        {
            // Check if Player is on bottom row
            // Check if Player is above a placed piece
            // Else return false
            if (Player.Y == 0) { return true; }
            if (ValueAt(Player.X, Player.Y - 1) == 1) { return true; }
            return false;
        }

        internal bool PlayerCanMoveLeft()
        {
            if (Player.X == 0)
            {
                return false;
            }
            if (ValueAt(Player.X - 1, Player.Y) == 1)
            {
                return false;
            }
            return true;
        }

        internal bool PlayerCanMoveRight()
        {
            if (Player.X == XMax)
            {
                return false;
            }
            if (ValueAt(Player.X + 1, Player.Y) == 1)
            {
                return false;
            }
            return true;
        }

        internal void MovePlayerLeft()
        {
            if (PlayerCanMoveLeft())
            {
                Player.X--;
            }
        }

        internal void MovePlayerRight()
        {
            if (PlayerCanMoveRight())
            {
                Player.X++;
            }
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
                    if (boardStatus[x + numCols * y] == 1)
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
