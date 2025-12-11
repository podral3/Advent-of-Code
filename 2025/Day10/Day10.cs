using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode._2025.Day10;

public class Day10
{
    public int Run()
    {
        string[] lines = File.ReadAllLines("2025/Day10/data.txt");
        int sum = 0;
        foreach(string line in lines)
        {
            var machine = new Machine(line);
            sum += machine.FindInstructions();
        }
        return sum;
    }
}




public class Machine
{
    private List<bool> Lights = [];
    private List<bool> StartingLights = [];
    private List<bool> DesiredLights = [];

    private List<List<int>> Instructions = [];
    private List<int> Joltage = [];

    public int Sum = int.MaxValue;
    public Machine(string line)
    {
        ReadInstructions(line);
    }

    public int FindInstructions()
    {
        Queue<List<List<int>>> queue = new Queue<List<List<int>>>();

        queue.Enqueue(new List<List<int>>());

        HashSet<string> visitedStates = new HashSet<string>();

        List<bool> startingLights = Lights; 
        string startingStateKey = GetStateKey(startingLights);
        visitedStates.Add(startingStateKey);

        while (queue.Count > 0)
        {
            List<List<int>> currentPath = queue.Dequeue(); 

            List<bool> currentLights = ApplyPath(startingLights, currentPath);

            if (currentLights.SequenceEqual(DesiredLights))
            {
                return currentPath.Count;
            }

            foreach (List<int> nextInstruction in Instructions)
            {
                List<List<int>> newPath = new List<List<int>>(currentPath);
                newPath.Add(nextInstruction);

                List<bool> nextLights = ApplyPath(startingLights, newPath);
                string nextStateKey = GetStateKey(nextLights);

                if (!visitedStates.Contains(nextStateKey))
                {
                    visitedStates.Add(nextStateKey);

                    queue.Enqueue(newPath);
                }
            }
        }

        return -1;
    }

    private int HowManyInPlace(List<bool> lights)
    {
        int sum = 0;
        for(int i = 0; i < lights.Count; i++)
        {
            if (lights[i] == this.DesiredLights[i])
            {
                sum++;
            }
        }
        return sum;
    }

    private string GetStateKey(List<bool> lights)
    {
        return string.Join("", lights.Select(l => l ? '1' : '0'));
    }

    private List<bool> ToggleButtons(List<int> button, List<bool> lights)
    {
        List<bool> newLights = new List<bool>(lights);

        foreach (int i in button)
        {
            newLights[i] = !newLights[i];
        }
        return newLights;
    }

    private List<bool> ApplyPath(List<bool> startingLights, List<List<int>> path)
    {
        List<bool> currentLights = new List<bool>(startingLights);

        foreach (List<int> instruction in path)
        {
            currentLights = ToggleButtons(instruction, currentLights);
        }
        return currentLights;
    }

    private void ReadInstructions(string line)
    {
        int startIdxLights = line.IndexOf('[');
        int endIdxLights = line.IndexOf(']');
        int len = endIdxLights - startIdxLights;
        string desiredLights = line.Substring(startIdxLights+1, len-1);

        foreach(char c in desiredLights)
        {
            if (c == '.') DesiredLights.Add(false);
            else DesiredLights.Add(true);
            Lights.Add(false);
        }
        StartingLights = Lights;
        int startIdxButtons = line.IndexOf("(");
        int endIdxButtons = line.LastIndexOf(")");
        len = endIdxButtons - startIdxButtons;
        string buttons = line.Substring(startIdxButtons, len+1);

        string[] buttonsSplit = buttons.Split(' ');
        foreach(string button in buttonsSplit)
        {
            string newButton = button.Replace('(', ' ').Replace(')', ' ').Trim();
            string[] splitted = newButton.Split(',').Select(s => s.Trim()).ToArray();

            List<int> instructions = new List<int>();
            foreach (string s in splitted)
            {
                instructions.Add(int.Parse(s));
            }
            this.Instructions.Add(instructions);
        }

        int startIdxJoltage = line.IndexOf("{");
        int endIdxJoltage = line.IndexOf("}");
        len = endIdxJoltage - startIdxJoltage;
        string joltageString = line.Substring(startIdxJoltage+1, len-1);
        string[] joltageSplitted = joltageString.Split(',');
        foreach (string  joltage in joltageSplitted)
        {
            Joltage.Add(int.Parse(joltage));
        }
    }
}
