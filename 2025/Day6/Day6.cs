using System;
using System.Collections.Generic;
using System.IO;
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

        public long Run2()
        {
            long totalSum = 0;
            string[] lines = File.ReadAllLines("2025/Day6/data.txt");
            List<char> instructions = lines[lines.Length - 1].Split(" ").Where(s => s != "").Select(e => char.Parse(e)).ToList();
            int matrixheigth = lines.Length - 1; //without instuctions
            int matrixLength = lines[0].Length;
            int verticalIterator = 0; int horizontalIterator = 0;
            int instructionPointer = 0;
            long rowSum = 0;
            while (horizontalIterator < matrixLength) //check left-right
            {
                int number = 0;
                
                while (verticalIterator < matrixheigth) //check top-down
                {
                    char charDigit = lines[verticalIterator][horizontalIterator];
                    bool isDigit = int.TryParse(charDigit.ToString(), out int digit);
                    if (isDigit)
                    {
                        number = number * 10 + digit;
                    }
                    verticalIterator++;
                }
                if (number == 0) //this means that whole row was separator
                {
                    totalSum += rowSum;
                    instructionPointer++;
                    rowSum = 0;
                }

                if (instructions[instructionPointer] == '+')
                {
                    rowSum += number;
                }
                else
                {
                    if (rowSum == 0) rowSum++;
                    rowSum *= number;
                }
                
                horizontalIterator++;
                verticalIterator = 0;
            }

            totalSum += rowSum;
            return totalSum;
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
