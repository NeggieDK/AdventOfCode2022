using AdventOfCode2022.AoC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AdventOfCode2022.Challenges
{
    public class Day11 : IDay
    {
        private Regex WorryLevelRegexInt = new Regex("Operation: new = old (\\S) (\\d+)");
        private Regex WorryLevelRegexSelf = new Regex("Operation: new = old (\\S) (\\w+)");

        public List<Monkey> Parse(List<string> lines)
        {
            var monkeys = new List<Monkey>();
            for(var i = 0;i < lines.Count;i += 7)
            {
                var items = lines[i + 1].Replace("Starting items: ", "").Split(",").Select(i => long.Parse(i.Trim())).ToList();
                var worryLevelInt = WorryLevelRegexInt.Match(lines[i + 2].Trim());
                var worryLevelSelf = WorryLevelRegexSelf.Match(lines[i + 2].Trim());
                var divisibleBy = long.Parse(lines[i + 3].Replace("Test: divisible by ", "").Trim());
                var trueCondition = long.Parse(lines[i + 4].Replace("If true: throw to monkey ", "").Trim());
                var falseCondition = long.Parse(lines[i + 5].Replace("If false: throw to monkey", "").Trim());

                var newMonkey = new Monkey();
                newMonkey.Division = divisibleBy;
                if (worryLevelInt.Success)
                {
                    if (worryLevelInt.Groups[1].Value == "*")
                    {
                        newMonkey.CalculateWorryLevel = x => x * long.Parse(worryLevelInt.Groups[2].Value);
                    }
                    else
                    {
                        newMonkey.CalculateWorryLevel = x => x + long.Parse(worryLevelInt.Groups[2].Value);
                    }
                }
                else
                {
                    if (worryLevelSelf.Groups[1].Value == "*")
                    {
                        newMonkey.CalculateWorryLevel = x => x * x;
                    }
                    else
                    {
                        newMonkey.CalculateWorryLevel = x => x + x;
                    }
                }
               

                newMonkey.CalculateDestination = x => x % divisibleBy == 0 ? trueCondition : falseCondition;
                newMonkey.Items = new Queue<long>(items);
                monkeys.Add(newMonkey);
            }
            return monkeys;
        }

        public void Part1()
        {
            var lines = File.ReadAllLines("AoC/Input/Day11Part1.txt").ToList();
            var monkeys = Parse(lines);

            for (var i = 0; i < 20; i++)
            {
                foreach (var monkey in monkeys)
                {
                    while (monkey.Items.TryPeek(out var _))
                    {
                        var result = monkey.Throw();
                        monkeys[(int)result.Destination].Items.Enqueue(result.WorryLevel);
                    }
                }
            }
            var orderedItems = monkeys.OrderByDescending(i => i.ItemsInspected).ToList();
            Console.WriteLine(orderedItems[0].ItemsInspected * orderedItems[1].ItemsInspected);
        }

        public void Part2()
        {
            var lines = File.ReadAllLines("AoC/Input/Day11Part1.txt").ToList();
            var monkeys = Parse(lines);

            var modifier = 1L;
            foreach(var monkey in monkeys)
            {
                modifier *= monkey.Division;
            }

            for (var i = 0; i < 10000; i++)
            {
                foreach (var monkey in monkeys)
                {
                    while (monkey.Items.TryPeek(out var _))
                    {
                        var result = monkey.ThrowPart2(modifier);
                        monkeys[(int)result.Destination].Items.Enqueue(result.WorryLevel);
                    }
                }
            }
            var orderedItems = monkeys.OrderByDescending(i => i.ItemsInspected).ToList();
            Console.WriteLine(orderedItems[0].ItemsInspected * orderedItems[1].ItemsInspected);
        }
    }

    public class Monkey
    {
        public Queue<long> Items { get; set; }
        public Func<long, long> CalculateWorryLevel;
        public Func<long, long> CalculateDestination;
        public long ItemsInspected { get; set; }
        public long Division { get; set; }

        public Monkey()
        {
            Items = new Queue<long>();
        }

        public Result Throw()
        {
            var item = Items.Dequeue();
            ItemsInspected++;
            var worryLevel = (long)Math.Floor(CalculateWorryLevel.Invoke(item) / 3.0);
            return new Result(worryLevel, CalculateDestination.Invoke(worryLevel));
        }

        public Result ThrowPart2(long modifier)
        {
            var item = Items.Dequeue();
            ItemsInspected++;
            var worryLevel = CalculateWorryLevel.Invoke(item) % modifier;
            return new Result(worryLevel, CalculateDestination.Invoke(worryLevel));
        }
    }

    public record Result(long WorryLevel, long Destination);
}
