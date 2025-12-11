using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode._2025.Day11;

public class Day11
{
    public int Run()
    {
        var dict = ReadInput("2025/Day11/test2.txt");
        List<string> traversals = new List<string>();
        return Traverse("svr", dict, traversals);
    }

    private int Traverse(string machineName, Dictionary<string, string[]> dict, List<string> traversals)
    {
        traversals.Add(machineName);
        List<string> traversalsTemp = traversals.ToList();
        if (machineName == "out")
        {
            if (traversals.Contains("svr") && traversals.Contains("fft")) return 1;
            return 0;
        }
        int count = 0;
        if (dict.TryGetValue(machineName, out string[]? value))
        {
            foreach (string str in value)
            {
                count += Traverse(str, dict, traversals);
                traversals = traversalsTemp;
            }
            
        }
        return count;
    }

    private Dictionary<string, string[]> ReadInput(string path)
    {
        string[] lines = File.ReadAllLines(path);
        Dictionary<string, string[]> dict = [];
        foreach (string line in lines)
        {
            string[] splitted = line.Split(':');
            string[] rightPartSplit = splitted[1].Trim().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            dict.Add(splitted[0], rightPartSplit);
        }
        return dict;
    }
}
