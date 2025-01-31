using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris
{
    internal class Game
    {
        // Constants
        private static readonly int MillisecondsLimit = 1000;

        // Variables
        private GameBoard gameBoard;
        private Player player;
        private int millisecondsElapsed;
        private bool playerWantsToQuit;

        internal void Setup()
        {
            player = new Player();
            gameBoard = new GameBoard(player);
            millisecondsElapsed = 0;
            playerWantsToQuit = false;

        }

        internal void Start()
        {
            gameBoard.MovePlayerToInitialPosition();
            while (!playerWantsToQuit && !gameBoard.IsGameOver)
            {
                AdvanceTime();
                CheckForKeyPress();
                DrawScene();

                AdvanceTime();
                AdvancePositionData();
                DrawScene();
            }
            if (playerWantsToQuit)
            {
                Console.WriteLine("Quitting game. Thank you for playing!.");
            }
            if (gameBoard.IsGameOver)
            {
                Console.WriteLine("Game over. Thank you for playing!");
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
            if (gameBoard.PlayerIsAtRest())
            {
                gameBoard.PlacePiece(player.X + player.Y * 10);
                gameBoard.MovePlayerToInitialPosition();
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
