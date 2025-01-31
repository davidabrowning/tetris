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
                AdvanceTime();
                CheckForKeyPress();
                DrawScene();

                AdvanceTime();
                AdvancePositionData();
                DrawScene();
            }
        }
        private void DrawScene()
        {
            Console.Clear();
            Console.WriteLine(gameBoard);
        }
        private void AdvanceTime()
        {
            millisecondsElapsed++;
            Thread.Sleep(5);
        }
        private void CheckForKeyPress()
        {
            if (Console.KeyAvailable)
            {
                switch (Console.ReadKey().Key.ToString().ToUpper())
                {
                    case "LEFTARROW":
                        gameBoard.MovePlayerLeft();
                        break;
                    case "RIGHTARROW":
                        gameBoard.MovePlayerRight();
                        break;
                    case "P":
                        PauseGame();
                        break;
                    case "Q":
                        playerWantsToQuit = true;
                        break;
                    default:
                        break;
                }
            }
        }
        private void AdvancePositionData()
        {
            if (millisecondsElapsed % 10 == 0)
            {
                player.Descend();
            }
            if (player.Y == 0)
            {
                gameBoard.PlacePiece(player.X + player.Y * 10);
                player.ResetPosition();
            }
        }
        private void PauseGame()
        {
            Console.Clear();
            Console.WriteLine("Paused. Press any key to continue.");
            Console.ReadKey();
        }
    }
}
