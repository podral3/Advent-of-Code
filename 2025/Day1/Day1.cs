using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode._2025.Day1
{
    public class Day1
    {
        public void Run()
        {
            List<(char, int)> instructions = ReadFile("2025/Day1/test.txt");
            int start = 50;
            int length = 100;
            int part1_counter = 0;
            int part2_counter = 0;
            //int timesPassedZero = 0;
            foreach (var instruction in instructions)
            {
                int timesPassedZero = 0;
                int value = instruction.Item2;
                if (instruction.Item1 == 'L') value *= -1;
                if (start + value >= length || start + value <= 0)
                {
                    timesPassedZero = (start + value) / length;
                    part2_counter+=timesPassedZero;
                }
                
                
                start = ((start + value + length) % length);
                if (timesPassedZero > 1 && start == 0)
                {
                    int x = 2;
                }
                //Console.WriteLine(start);
                if (start == 0) part1_counter++;
                if (start == 0) part2_counter++;
            }
            Console.WriteLine(part2_counter);
        }

        public int Run2()
        {
            int sum = 0;
            List<(char, int)> instructions = ReadFile("2025/Day1/data.txt");
            LinkedList<int> list = [];
            for(int i = 0; i < 100; i++)
            {
                list.AddLast(i);
            }
            LinkedListNode<int>? start = list.Find(50);
            foreach (var instruction in instructions)
            {
                if (instruction.Item1 == 'L')
                {
                    for(int i = 0; i < instruction.Item2; i++)
                    {
                        start = start!.Previous ?? list.Last;
                        if (start.Value == 0) sum++;
                    }
                }
                else
                {
                    for (int i = 0; i < instruction.Item2; i++)
                    {
                        start = start!.Next ?? list.First;
                        if (start.Value == 0) sum++;
                    }
                }
            }

            return sum;
        }

        private List<(char, int)> ReadFile(string file)
        {
            List<(char, int)> values = new List<(char, int)>();
            string[] lines = File.ReadAllLines(file);
            foreach (string line in lines)
            {
                char instruction = line[0];
                int number = int.Parse(line.Substring(1));
                values.Add((instruction, number));
            }
            return values;
        }
    }
}
