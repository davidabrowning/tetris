using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Markup;

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
        public int StartingX { get { return numCols / 2; } }
        public int StartingY { get { return numRows - 1;  } }
        public bool HasCompletedRow { get { return LowestCompletedRow != -1;  } }
        public int LowestCompletedRow {  get { return GetLowestCompletedRow(); } }
        public bool IsGameOver {  get { return ValueAt(StartingX, StartingY) == 1; } }

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
        internal void PlacePiece(int x, int y)
        {
            PlacePiece(x + numCols * y);
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
        internal void MovePlayerToInitialPosition()
        {
            Player.X = StartingX;
            Player.Y = StartingY;
        }

        private int GetLowestCompletedRow()
        {
            for (int y = 0; y <= YMax; y++)
            {
                bool completedRow = true;
                for (int x = 0; x <= XMax; x++)
                {
                    if(ValueAt(x, y) == 0)
                    {
                        completedRow = false;
                        break;
                    }
                }
                if (completedRow)
                {
                    return y;
                }
            }
            return -1;
        }

        // ============================== METHOD ==============================
        // ToString. Overrides default ToString and prints current GameBoard.
        // ====================================================================
        public override string ToString()
		{
            string boardAsString = "";
            for (int y = YMax; y >= 0; y--)
            {
                boardAsString += (" * ");
                for (int x = 0; x <= XMax; x++)
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
            for (int x = 0; x <= XMax + 2; x++)
            {
                boardAsString += (" * ");
            }
            return boardAsString;
		}

	}
}
