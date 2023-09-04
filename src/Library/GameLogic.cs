using System;
using System.Security.Cryptography.X509Certificates;
namespace Library
{
    public class GameLogic
    {
        public static bool[,] Game(bool[,] booleanBoard)
        {
            // Cargo la variable gameBoard con los datos obtenidos una vez creada la matriz booleana con Import
            bool[,] gameBoard = booleanBoard;
            // Devuelve la el número de elementos (logitud) de la primer dimensión del tablero -número de columnas-
            int boardWidth = gameBoard.GetLength(0);
            // Devuelve la altura del tablero (cantidad de elementos de la segunda dimensión del tablero) -filas de la matriz-
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

                    // Pregunto si en esta posición hay una célula viva
                    if(gameBoard[x,y])
                    {
                        aliveNeighbors--;
                    }

                    // Pregunto si la célula de la posición esta viva y si tiene menos de dos vecinos
                    if (gameBoard[x,y] && aliveNeighbors < 2)
                    {
                        // Célula muere por baja población
                        cloneBoard[x,y] = false;
                    }
                    // Si no, pregunto si la célula está viva y si además tiene más de 3 vecinos
                    else if (gameBoard[x,y] && aliveNeighbors > 3)
                    {
                        // Célula muere por sobrepoblación
                        cloneBoard[x,y] = false;
                    }

                    // Si no, pregunto si la célula esta muerta pero tiene 3 vecinos
                    else if (!gameBoard[x,y] && aliveNeighbors == 3)
                    {
                        // Célula nace por reproducción
                        cloneBoard[x,y] = true;
                    }
                    else
                    {
                        // Célula mantiene el estado que tenía
                        cloneBoard[x,y] = gameBoard[x,y];
                    }
                }
            }
            gameBoard = cloneBoard;
            return cloneBoard;
        }
    }
}

