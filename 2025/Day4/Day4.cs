using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Advent_of_Code_2024._2025.Day4
{
    public class Day4
    {
        public int Run()
        {
            char[,] data = ReadFile("2025/Day4/test.txt");
            int movable = 0;

            for (int i = 0; i < data.GetLength(0); i++)
            {
                for (int j = 0; j < data.GetLength(1); j++)
                {
                    if (data[i, j] == '@')
                    {
                        if(CheckForNeigbours(data, i,j)) movable++;
                    }
                }
            }
            return movable;
        }

        public char[,] ReadFile(string path)
        {
            string[] lines = File.ReadAllLines(path);
            int height = lines[0].Length;
            int width = lines.Length;

            char[,] charArray = new char[height, width];
            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    charArray[i, j] = lines[i][j];
                }
            }
            return charArray;
        }

        private bool CheckForNeigbours(char[,] data, int i, int j)
        {
            List<char> adjecentValues = GetKernel(data, i, j);
            int count = adjecentValues.Select(c => c =='@').Count();
            if (count > 4) return false;
            return true;
        }

        private bool IsInBounds(int length, int heigth, int i, int j)
        {
            if (i > heigth || i < 0) return false;
            if (j > length || j < 0) return false;
            return true;
        }

        private List<char> GetKernel(char[,] data, int i, int j)
        {
            int dataLength = data.GetLength(0);
            int dataHeight = data.GetLength(1);
            List<char> list = new ();
            if (IsInBounds(dataLength, dataHeight, i - 1, j - 1))
            {
                list.Add(data[i - 1, j - 1]);
            }
            if (IsInBounds(dataLength, dataHeight, i - 1, j))
            {
                list.Add(data[i - 1, j]);
            }
            if (IsInBounds(dataLength, dataHeight, i - 1, j + 1))
            {
                list.Add(data[i-1, j+1]);
            }
            if(IsInBounds(dataLength, dataHeight, i, j - 1))
            {
                list.Add(data[i, j - 1]);
            }
            if(IsInBounds(dataLength, dataHeight, i, j + 1))
            {
                list.Add(data[i, j + 1]);
            }
            if (IsInBounds(dataLength, dataHeight, i + 1, j - 1))
            {
                list.Add(data[i + 1, j - 1]);
            }
            if (IsInBounds(dataLength, dataHeight, i + 1, j))
            {
                list.Add(data[i + 1, j]);
            }
            if (IsInBounds(dataLength, dataHeight, i - 1, j + 1))
            {
                list.Add(data[i + 1, j + 1]);
            }
            return list;
        }
    }
}
