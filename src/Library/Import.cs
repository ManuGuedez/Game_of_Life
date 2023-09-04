using System.IO;
using System;
namespace Library 
{
    /*
    Esta clase se posee una única responsabilidad de hacer, se encarga de, luego de proporcianda una ruta, 
    leer un archivo y generar en base a los datos provistos, un primer tablero únicamente con valores booleanos, 
    correspondientes a los 1s y 0s del arhivo.
    */
    public class Import
    {
        public static bool[,] ImportFile(string url)
        {
            string content = File.ReadAllText(url);
            
            string[] contentLines = content.Split('\n');

            bool[,] board = new bool[contentLines.Length, contentLines[0].Length];

            for (int  y=0; y<contentLines.Length; y++)
            {
                for (int x=0; x<contentLines[y].Length; x++)
                {
                    if(contentLines[y][x]=='1')
                    {
                        board[x,y]=true;
                    }
                }
            }
            return board;
        }
        
    }
}