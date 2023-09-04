using System;
using System.Text;
using System.Threading;

namespace Library
{
    /*
    Esta calse posee una única responsabilidad de hacer, se encarga de imprimir en la 
    consola el tablero a medida que se van cumpliendo las diferentes formas lógicas del juego.
    */
    public class Printer
    {
        public static void PrintBoard(bool[,] board)
        {
            int width = board.GetLength(0);
            int height = board.GetLength(1);

            while (true)
            {
                Console.Clear();
                StringBuilder s = new StringBuilder();

                for (int i = 0; i < height; i++)
                {
                    for (int j = 0; j < width; j++)
                    {
                        if(board[j,i])
                        {
                            s.Append("|X|");
                        }
                        else
                        {
                            s.Append("___");
                        }
                    }
                    s.Append("\n");
                }
                Console.WriteLine(s.ToString());
                board = GameLogic.Game(board);
                Thread.Sleep(300);
            }
        }
    }
}
