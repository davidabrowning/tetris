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
            AssertTrue(true, title);

            title = "Two plus two equals four";
            AssertEquals(4, 2 + 2, title);

            title = "GameBoard origin start with value 0";
            gameBoard = new GameBoard(player);
            AssertEquals(0, gameBoard.ValueAt(0, 0), title);

            title = "Player cannot descend below 0";
            AssertTrue(false, title);

            title = "Player cannot descend onto claimed gameboard space";
            AssertTrue(false, title);
        }
        private static void PrintSuccess(string testTitle)
        {
            Console.WriteLine($"Success: {testTitle}");
        }
        private static void PrintFailure(string testTitle, string expected, string actual)
        {
            Console.WriteLine($"FAILURE: {testTitle}. Expected: {expected}, actual: {actual}");
        }
        private static void AssertTrue(bool condition, string testTitle)
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
        private static void AssertFalse(bool condition, string testTitle)
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
        private static void AssertEquals(int expected, int actual, string testTitle)
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
