using AdventOfCode2022.AoC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AdventOfCode2022.Challenges
{
    public class Day5 : IDay
    {
        public void Part1()
        {
            var lines = File.ReadAllLines("AoC/Input/Day5Part1.txt");

            var beginStack = lines.TakeWhile(i => !string.IsNullOrWhiteSpace(i)).ToList();

            var stackNumbers = beginStack.Last().Split("   ").Select(i => int.Parse(i));
            var stacks = new List<Stack<string>>();
            foreach(var stackNumber in stackNumbers)
            {
                var index = 1 + (4 * (stackNumber - 1));
                var newStack = new Stack<string>();
                for(var i = beginStack.Count() - 2; i >= 0;i--)
                {
                    var item = beginStack[i][index].ToString();
                    if (string.IsNullOrWhiteSpace(item)) continue;

                    newStack.Push(item);
                }

                stacks.Add(newStack);
            }

            var instructions = lines.Where(i => i.StartsWith("move")).ToList();
            var regex = new Regex("move (\\d+) from (\\d+) to (\\d+)");
            foreach(var instruction in instructions)
            {
                var groups = regex.Match(instruction).Groups.Values.Skip(1).Select(i => int.Parse(i.Value.Trim())).ToList();
                for(var j = 0;j < groups[0]; j++)
                {
                    var value = stacks[groups[1] - 1].Pop();
                    stacks[groups[2] - 1].Push(value);
                }
            }

            foreach(var stack in stacks)
            {
                Console.Write(stack.Peek());
            }
            Console.WriteLine();
        }

        public void Part2()
        {
            var lines = File.ReadAllLines("AoC/Input/Day5Part1.txt");

            var beginStack = lines.TakeWhile(i => !string.IsNullOrWhiteSpace(i)).ToList();

            var stackNumbers = beginStack.Last().Split("   ").Select(i => int.Parse(i));
            var stacks = new List<Stack<string>>();
            foreach (var stackNumber in stackNumbers)
            {
                var index = 1 + (4 * (stackNumber - 1));
                var newStack = new Stack<string>();
                for (var i = beginStack.Count() - 2; i >= 0; i--)
                {
                    var item = beginStack[i][index].ToString();
                    if (string.IsNullOrWhiteSpace(item)) continue;

                    newStack.Push(item);
                }

                stacks.Add(newStack);
            }

            var instructions = lines.Where(i => i.StartsWith("move")).ToList();
            var regex = new Regex("move (\\d+) from (\\d+) to (\\d+)");
            foreach (var instruction in instructions)
            {
                var groups = regex.Match(instruction).Groups.Values.Skip(1).Select(i => int.Parse(i.Value.Trim())).ToList();
                var subList = stacks[groups[1] - 1].ToList().GetRange(0, groups[0]).ToList();
                subList.Reverse();

                foreach(var item in subList)
                {
                    stacks[groups[1] - 1].Pop();
                    stacks[groups[2] - 1].Push(item);
                }
            }

            foreach (var stack in stacks)
            {
                Console.Write(stack.Peek());
            }
            Console.WriteLine();
        }
    }
}
