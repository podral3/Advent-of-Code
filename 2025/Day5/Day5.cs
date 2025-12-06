
using Advent_of_Code_2024._2025.Day4;
using System.Globalization;
using System.Reflection.Metadata.Ecma335;
using System.Xml.Linq;
using static System.Net.Mime.MediaTypeNames;

namespace AdventOfCode._2025.Day5;

public class Day5
{
    public long Run()
    {
        long result = 0;
        var (ranges, products) = ReadData("2025/Day5/data.txt");
        
        foreach(long product in products)
        {
            foreach (var range in ranges)
            {
                if (product >= range.Item1 && product <= range.Item2)
                {
                    result++;
                    break;
                }
            }

        }
        return result;
    }

    public long Run2()
    {
        var (ranges, products) = ReadData("2025/Day5/test.txt");

        List<long> rangesFlatten = [];
        long total = 0;
        foreach (var range in ranges)
        {
           rangesFlatten.Add(range.Item1);
           rangesFlatten.Add(range.Item2);
        }
        rangesFlatten.Sort();
        for (int i = 0; i < rangesFlatten.Count -1; i++)
        {
            total += rangesFlatten[i + 1] - rangesFlatten[i];
        }
        return total;
    }
    private (List<(long,long)>, List<long>) ReadData(string path)
    {
        List<(long,long)> ranges = new List<(long,long)>();
        List<long> products = new List<long>();
        string[] data = File.ReadAllLines(path);
        int i = 0;
        while (data[i] != "")
        {
            string[] split = data[i].Split('-');
            ranges.Add((long.Parse(split[0]), long.Parse(split[1])));
            i++;
        }
        i++;
        while (i < data.Length)
        {
            products.Add(long.Parse(data[i]));
            i++;
        }

        return (ranges, products);
    }
}
