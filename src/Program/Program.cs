using System;
using Library;

namespace PII_Game_Of_Life
{
    class Program
    {
        static void Main(string[] args)
        {
            bool[,] booleanBoard = Import.ImportFile("../../assets/board.txt");
            bool[,] gameBoard = GameLogic.Game(booleanBoard);

            Printer.PrintBoard(gameBoard);
        }
    }
}
