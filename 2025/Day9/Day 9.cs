using Advent_of_Code_2024.Day14;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode._2025.Day9
{
    public class Day9
    {
        public long Run()
        {
            string[] lines = File.ReadAllLines("2025/Day9/data.txt");
            List<Point> points = new List<Point>();
            foreach (string line in lines)
            {
                string[] splitted = line.Split(',');
                Point point = new Point() { X = int.Parse(splitted[0]), Y = int.Parse(splitted[1]) };
                points.Add(point);
            }

            long area = 0;
            for (int i = 0; i < points.Count; i++)
            {
                Point current = points[i];
               for (int j = i + 1; j < points.Count; j++)
                {
                    Point comparable = points[j];
                    long tempArea = (long)(Math.Abs(current.X - comparable.X) + 1) * (long)(Math.Abs(current.Y - comparable.Y) + 1);
                    if (tempArea > area)
                    {
                        area = tempArea;
                    }
                    
                } 
            }
            return area;
        }
    }
}
