using Advent_of_Code_2024.Day14;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode._2025.Day7
{
    public class Day7
    {
        public int Run()
        {
            var (board, start) = ReadData("2025/Day7/data.txt");
            HashSet<int> newBeams = [start.Y];
            int sum = 0;

            for (int row = start.X + 1; row < board.GetLength(0); row++)
            {
                HashSet<int> tempBeams = new HashSet<int>();
                foreach (int beam in newBeams)
                {
                    if (board[row, beam] == '^')
                    {
                        tempBeams.Add(beam - 1);
                        tempBeams.Add(beam + 1);
                        tempBeams.Remove(beam);
                        sum++;
                    }
                    else
                    {
                        tempBeams.Add(beam);
                    }
                }
                newBeams= tempBeams;
            }   
            return sum;
        }

        public int Run_temp()
        {
            var (board, start) = ReadData("2025/Day7/test.txt");
            HashSet<Point> newBeams = [start];
            int sum = 0;
            while (newBeams.Count > 0)
            {
                HashSet<Point> tempBeams = new HashSet<Point>();
                foreach (Point beam in newBeams)
                {
                    for (int i = beam.X; i < board.GetLength(0); i++)
                    {
                        char currChar = board[i, beam.Y];
                        if (currChar == '^')
                        {
                            tempBeams.Add(new Point(i + 1, beam.Y + 1));
                            tempBeams.Add(new Point(i + 1, beam.Y - 1));
                            sum++;
                            break;
                        }
                    }
                }
                Console.WriteLine(tempBeams.Count);
                //sum += tempBeams.Count;
                newBeams = tempBeams;
            }
            return sum;
        }

        private (char[,], Point) ReadData(string path)
        {
            string[] data = File.ReadAllLines(path);
            Point start = new Point(1,1);
            char[,] board = new char[data.Length, data[0].Length];
            for (int i = 0; i < data.Length; i++)
            {
                for (int j = 0; j < data[i].Length; j++)
                {
                    if (data[i][j] == 'S') start = new Point(i, j);
                    board[i, j] = data[i][j];
                }
            }
            return (board, start);
        }
    }
}
