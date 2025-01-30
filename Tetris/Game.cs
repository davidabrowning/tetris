using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris
{
    internal class Game
    {
        private GameBoard gameBoard;
        private Player player;
        int millisecondsElapsed;
        bool playerWantsToQuit;

        internal void Setup()
        {
            player = new Player();
            gameBoard = new GameBoard(player);
            millisecondsElapsed = 0;
            playerWantsToQuit = false;
        }

        internal void Start()
        {
            while (millisecondsElapsed < 300 && !playerWantsToQuit)
            {
                Console.Clear();
                Console.WriteLine(gameBoard);
                if (Console.KeyAvailable)
                {
                    switch (Console.ReadKey().Key.ToString().ToUpper())
                    {
                        case "LEFTARROW":
                            player.X = Math.Max(0, player.X - 1);
                            break;
                        case "RIGHTARROW":
                            player.X = Math.Min(9, player.X + 1);
                            break;
                        case "P":
                            Console.Clear();
                            Console.WriteLine("Paused. Press any key to continue.");
                            Console.ReadKey();
                            break;
                        case "Q":
                            playerWantsToQuit = true;
                            break;
                        default:
                            break;
                    }
                }
                millisecondsElapsed++;
                if (millisecondsElapsed % 10 == 0)
                {
                    player.Descend();
                }
                if (player.Y == 0)
                {
                    gameBoard.PlacePiece(player.X + player.Y * 10);
                    player.ResetPosition();
                }
                Thread.Sleep(5);
            }
        }
    }
}
