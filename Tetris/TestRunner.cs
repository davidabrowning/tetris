using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris
{
    internal class TestRunner
    {
        internal void Go()
        {
            // Reused variables
            Player player = new Player();
            GameBoard gameBoard = new GameBoard(player);
            string title = "";

            title = "True is true";
            AssertTrue(title, true);

            title = "Two plus two equals four";
            AssertEquals(title, 4, 2 + 2);

            title = "GameBoard origin start with value 0";
            gameBoard = new GameBoard(player);
            AssertEquals(title, 0, gameBoard.ValueAt(0, 0));

            title = "Player cannot descend below 0";
            player.Y = 0;
            player.Descend();
            AssertEquals(title, 0, player.Y);

            title = "Player is not at rest if there is no piece below Player";
            player.X = 0;
            player.Y = 1;
            AssertFalse(title, gameBoard.PlayerIsAtRest());

            title = "Player is at rest if there is a piece below Player";
            gameBoard.PlacePiece(0);
            player.X = 0;
            player.Y = 1;
            AssertTrue(title, gameBoard.PlayerIsAtRest());

            title = "Player in leftmost column cannot move left";
            player.X = 0;
            player.Y = 5;
            AssertFalse(title, gameBoard.PlayerCanMoveLeft());

            title = "Player in rightmost column cannot move right";
            player.X = gameBoard.XMax;
            player.Y = 8;
            AssertFalse(title, gameBoard.PlayerCanMoveRight());
        }
        private static void PrintSuccess(string testTitle)
        {
            Console.WriteLine($"Success: {testTitle}");
        }
        private static void PrintFailure(string testTitle, string expected, string actual)
        {
            Console.WriteLine($"FAILURE: {testTitle}. Expected: {expected}, actual: {actual}");
        }
        private static void AssertTrue(string testTitle, bool condition)
        {
            if (condition)
            {
                PrintSuccess(testTitle);
            }
            else
            {
                PrintFailure(testTitle, true.ToString(), condition.ToString());
            }
        }
        private static void AssertFalse(string testTitle, bool condition)
        {
            if (condition == false)
            {
                PrintSuccess(testTitle);
            }
            else
            {
                PrintFailure(testTitle, false.ToString(), condition.ToString());
            }
        }
        private static void AssertEquals(string testTitle, int expected, int actual)
        {
            if (expected == actual)
            {
                PrintSuccess(testTitle);
            }
            else
            {
                PrintFailure(testTitle, expected.ToString(), actual.ToString());
            }
        }
    }
}
