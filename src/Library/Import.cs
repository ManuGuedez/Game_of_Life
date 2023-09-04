using System.IO;
using System;
namespace Library 
{
    public class Import
    {

        // string url = "../../assets/board.txt"; --> dirección del archivo con los datos iniciales del tablero

        // Leo el archivo

        public bool[,] Board { get ; set ; }
        public static bool[,] ImportFile(string url)
        {
            // Paso el contenido del texto a un string
            string content = File.ReadAllText(url);
            
            // Creo un lista donde cada elemento va a ser una de las lineas del archivo proporcionado
            string[] contentLines = content.Split('\n');

            /*
            Creo una matriz booleana en la que las dimensiones se corresponden con la cantidad de elementos de
            la lista creada en la sentencia anterior (correspondientes a la cantidad de filas de la matriz)
            y, dentro de cada una de esas filas, se van a almacenar tantos elementos como haya en la primer linea
            del archivo, es decir, correspondientes a la cantidad de columnas.
            */

                                        //filas             //columnas
            bool[,] board = new bool[contentLines.Length, contentLines[0].Length];

            //Recorro cada fila
            for (int  y=0; y<contentLines.Length; y++)
            {
                // Recorro cada elemento de cada fila
                for (int x=0; x<contentLines[y].Length; x++)
                {
                    if(contentLines[y][x]=='1')
                    {
                        board[x,y]=true;
                    }
                }
            }
        // Devuelvo el tablero con las posiciones true or flase proporcionadas por el archivo leido
            return board;
        }
        
    }
}