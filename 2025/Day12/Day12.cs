using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode._2025.Day12
{
    public class Day12
    {
        public int Run()
        {
            int totalSum = 0;
            List<int> shapesCount = [7, 7, 5, 7, 7, 7];
            string[] lines = File.ReadAllLines("2025/Day12/data.txt");
            foreach (var line in lines)
            {
                string[] splitted = line.Split(':');
                string[] nums = splitted[0].Split('x');
                int dim = int.Parse(nums[0]) * int.Parse(nums[1]);

                List<int> shapes = splitted[1].Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(s => int.Parse(s.Trim())).ToList();
                int shapessum = 9 * shapes.Sum();

                if (dim < shapessum) continue;
                totalSum += 1;
                //int sum = 0;
                //for (int i = 0; i < shapes.Count; i++)
                //{
                //    sum += shapes[i] * shapesCount[i];
                //}

                
                
            }
            return totalSum;
        }
    }
}
