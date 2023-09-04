using System;
using System.Security.Cryptography.X509Certificates;
namespace Library
{
    /*
    Esa clase se encarga únicamente hacer un tablero que siga la lógica del juego.
    Luego de proporcionado un tablero con valores booleanos, el método Game dvuelve un nuevo tablero
    basado en el anterior, en el cual hace cumplir la lógica del juego. 
    */
    public class GameLogic
    {
        public static bool[,] Game(bool[,] booleanBoard)
        {
            bool[,] gameBoard = booleanBoard;
            int boardWidth = gameBoard.GetLength(0);
            int boardHeight = gameBoard.GetLength(1);

            bool[,] cloneBoard = new bool[boardWidth, boardHeight];
            
            for (int x = 0; x < boardWidth; x++)
            {
                for (int y = 0; y < boardHeight; y++)
                {
                    int aliveNeighbors = 0;
                    for (int i = x-1; i <= x+1; i++)
                    {
                        for (int j = y-1; j <= y+1; j++)
                        {
                            if (i >= 0 && i<boardWidth && j >= 0 && j < boardHeight && gameBoard[i,j])
                            {
                                aliveNeighbors++;
                            }
                        }
                    }

                    if(gameBoard[x,y])
                    {
                        aliveNeighbors--;
                    }

                    if (gameBoard[x,y] && aliveNeighbors < 2)
                    {
                        cloneBoard[x,y] = false;
                    }
                    else if (gameBoard[x,y] && aliveNeighbors > 3)
                    {
                        cloneBoard[x,y] = false;
                    }
                    else if (!gameBoard[x,y] && aliveNeighbors == 3)
                    {
                        cloneBoard[x,y] = true;
                    }
                    else
                    {
                        cloneBoard[x,y] = gameBoard[x,y];
                    }
                }
            }
            gameBoard = cloneBoard;
            return cloneBoard;
        }
    }
}

