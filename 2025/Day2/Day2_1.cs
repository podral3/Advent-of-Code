using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advent_of_Code_2024._2025.Day2
{
    public class Day2_1
    {
        public long Run()
        {
            List<(string, string)> data = ReadDataString("C:\\Users\\Podral3\\source\\repos\\Advent of Code 2024\\2025\\Day2\\data.txt");
            long invalidSum = 0;
            foreach (var item in data)
            {
                long begin = long.Parse(item.Item1);
                long end = long.Parse(item.Item2);

                for (long i = begin; i <= end; i++)
                {
                    string numberParsed = i.ToString();
                    if (numberParsed.Length % 2 == 0)
                    {
                        int half = (numberParsed.Length / 2);
                        string left = numberParsed[..half];
                        string right = numberParsed[half..];
                        if (left == right) invalidSum+=i;
                    }
                }
            }
            return invalidSum;
        }

        public long Run2()
        {
            List<(string, string)> data = ReadDataString("C:\\Users\\Podral3\\source\\repos\\Advent of Code 2024\\2025\\Day2\\data.txt");
            long invalidSum = 0;
            foreach (var item in data)
            {
                long begin = long.Parse(item.Item1);
                long end = long.Parse(item.Item2);

                for (long i =begin; i <= end; i++)
                {
                    if (i == 824824824)
                    {
                        //Console.Write("?");
                    }
                    string numberParsed = i.ToString();
                    int stringLength = numberParsed.Length;
                    List<int> divisors = GetDivisors(stringLength);
                    
                    foreach (long divisor in divisors)
                    {
                        bool allEqual = true;
                        int stringParts = (int)(stringLength / divisor);
                        int partLength = (int) (stringLength / stringParts);
                        for (int j = 0; j < stringLength - partLength; j += partLength)
                        {
                            string substringA = numberParsed.Substring(j, partLength);
                            string substringB = numberParsed.Substring(j + partLength, partLength);
                            if (substringA != substringB)
                            {
                                allEqual = false;
                                break;
                            }
                           
                        }
                        if (allEqual)
                        {
                            long x = i;
                            invalidSum += i;
                            Console.WriteLine(i);
                            break;
                        }
                    }
                    
                }
            }

            return invalidSum;
        }

        private List<(int, int)> ReadData(string path)
        {
            List<(int, int)> data = new ();
            string[] lines = File.ReadAllText(path).Split(',');
            foreach (string line in lines)
            {
                string[] strings = line.Split("-");
                var x = (int.Parse(strings[0]), int.Parse(strings[1]));
                data.Add(x);
            }
            return data;
        }

        private List<(string, string)> ReadDataString(string path)
        {
            List<(string, string)> data = new();
            string[] lines = File.ReadAllText(path).Split(',');
            foreach (string line in lines)
            {
                string[] strings = line.Split("-");
                var x = (strings[0], strings[1]);
                data.Add(x);
            }
            return data;
        }

        private List<int> GetDivisors(int num)
        {
            List<int> divisors = new List<int>();
            for (int i = 1; i <= Math.Sqrt(num); i++)
            {
                if (num % i == 0)
                {
                    if (num / i == i) divisors.Add(i);
                    else
                    {
                        divisors.Add(i);
                        divisors.Add(num / i);
                    }
                }
            }
            divisors.Remove(num);
            return divisors;
        }
    }
}
