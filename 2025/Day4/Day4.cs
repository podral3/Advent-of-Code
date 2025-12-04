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
        public int Run2()
        {
            HashSet<(int, int)> removed = [];
            int movable = 0;
            char[,] data = ReadFile("2025/Day4/test.txt");
            do
            {
                movable = 0;
                HashSet<(int, int)> tempRemoved = [];
                for (int i = 0; i < data.GetLength(0); i++)
                {
                    for (int j = 0; j < data.GetLength(1); j++)
                    {
                        if (data[i, j] == '@')
                        {
                            if (CheckForNeigbours2(data, i, j, removed))
                            {
                                movable++;
                                tempRemoved.Add((i, j));
                            }
                        }
                    }
                }
                if (tempRemoved.Count == 0) break;
                removed.UnionWith(tempRemoved);
            } while (true);
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
            int count = adjecentValues.Count(c => c == '@');
            if (count > 3) return false;
            return true;
        }

        private bool CheckForNeigbours2(char[,] data, int i, int j, HashSet<(int, int)> removed)
        {
            Dictionary<(int, int), char> adjecentValues = GetKernel2(data, i, j);
            List<(int, int)> removedFromDict = adjecentValues.Keys.Where(k => removed.Contains(k)).ToList();
            foreach (var key in removedFromDict)
            {
                adjecentValues.Remove(key);
            }
            int count = adjecentValues.Count(kvp => kvp.Value == '@');
            if (count > 3) return false;
            return true;
        }

        private bool IsInBounds(int length, int heigth, int i, int j)
        {
            if (i > heigth - 1 || i < 0) return false;
            if (j > length - 1 || j < 0) return false;
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
            if (IsInBounds(dataLength, dataHeight, i + 1, j + 1))
            {
                list.Add(data[i + 1, j + 1]);
            }
            return list;
        }

        private Dictionary<(int, int), char> GetKernel2(char[,] data, int i, int j)
        {
            int dataLength = data.GetLength(0);
            int dataHeight = data.GetLength(1);
            Dictionary < (int, int), char> dict = new();
            if (IsInBounds(dataLength, dataHeight, i - 1, j - 1))
            {
                dict.Add((i-1, j-1), data[i - 1, j - 1]);
            }
            if (IsInBounds(dataLength, dataHeight, i - 1, j))
            {
                dict.Add((i - 1, j), data[i - 1, j]);
            }
            if (IsInBounds(dataLength, dataHeight, i - 1, j + 1))
            {
                dict.Add((i - 1, j + 1), data[i - 1, j + 1]);
            }
            if (IsInBounds(dataLength, dataHeight, i, j - 1))
            {
                dict.Add((i, j - 1), data[i, j - 1]);
            }
            if (IsInBounds(dataLength, dataHeight, i, j + 1))
            {
                dict.Add((i, j + 1), data[i, j + 1]);
            }
            if (IsInBounds(dataLength, dataHeight, i + 1, j - 1))
            {
                dict.Add((i + 1, j - 1), data[i + 1, j - 1]);
            }
            if (IsInBounds(dataLength, dataHeight, i + 1, j))
            {
                dict.Add((i + 1, j), data[i + 1, j]);
            }
            if (IsInBounds(dataLength, dataHeight, i + 1, j + 1))
            {
                dict.Add((i + 1, j + 1), data[i + 1, j + 1]);
            }
            return dict;
        }
    }
}
