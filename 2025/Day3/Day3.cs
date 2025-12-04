using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace Advent_of_Code_2024._2025.Day3
{
    public class Day3
    {
        public int Run()
        {
            int joltageSum = 0;
            List<int[]> data = ReadData("2025/Day3/data.txt");
            
            foreach (int[] line in data)
            {
                int leftPointer = line[0];
                int rightPointer = 0;
                int tempSecond = 0;
                for (int i = 1; i < line.Length; i++)
                {
                    rightPointer = line[i];
                    if (rightPointer > leftPointer && i != line.Length-1)
                    {
                        leftPointer = rightPointer;
                        rightPointer = line[i+1];
                        tempSecond = 0;
                    }
                    if (rightPointer > tempSecond)
                    {
                        tempSecond = rightPointer;
                    }
                    
                }
                int currentSum = int.Parse($"{leftPointer}{tempSecond}");
                Console.WriteLine(currentSum);
                joltageSum += currentSum;
            }
            return joltageSum;
        }

        private List<int[]> ReadData(string path)
        {
            List<int[]> data = new List<int[]>();
            string[] lines = System.IO.File.ReadAllLines(path);
            foreach (string line in lines)
            {
                int[] intArr = new int[line.Length];
                for (int i = 0; i < line.Length; i++)
                {
                    intArr[i] = int.Parse(line[i].ToString());
                }
                data.Add(intArr);
            }
            return data;
        }
    }
}
