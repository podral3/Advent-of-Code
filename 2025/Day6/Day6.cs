using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Intrinsics.Arm;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode._2025.Day6
{
    public class Day6
    {
        public long Run()
        {
            long sum = 0;
            var (matrix, instructions) = ReadData("2025/Day6/data.txt");
            int len0 = matrix.GetLength(0);
            int len1 = matrix.GetLength(1);
            for (int i = 0; i < len1; i++)
            {
                Console.WriteLine($"Counting column {i + 1}");
                long tempSum = 0;
                for (int j = 0; j < len0; j++)
                {
                    if (instructions[i] == '+')
                    {
                        tempSum += matrix[j, i];
                    }
                    else
                    {
                        if (tempSum == 0) tempSum++;
                        int x = matrix[j, i];
                        tempSum *= x;
                    }
                }
                sum += tempSum;
            }
            return sum;
        }

        private (int[,], List<char>) ReadData(string path)
        {
            string [] lines = File.ReadAllLines(path);
            string[] oneLineSplitted = lines[0].Split(" ").Where( s => s != "").ToArray();
            int[,] matrix = new int[lines.Length -1, oneLineSplitted.Length]; //we skip final line for instructions

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                string[] oneLineSplittedd = lines[i].Split(" ").Where(s => s != "").ToArray();
                for (int j = 0; j < oneLineSplittedd.Length; j++)
                {
                    matrix[i, j] = int.Parse(oneLineSplittedd[j]);
                } 
            }

            List<char> instructions = lines[lines.Length - 1].Split(" ").Where(s => s != "").Select(e => char.Parse(e)).ToList();
            return (matrix, instructions);
        }
    }
}
