using AdventOfCode2022.AoC;

namespace AdventOfCode2022.Challenges
{
    public class Day1 : IDay
    {
        public Day1()
        {

        }

        public void Part1()
        {
            var lines = File.ReadAllLines("AoC/Input/Day1Part1.txt");

            var currentAccumulator = 0l;
            var currentMax = 0l;
            foreach(var line in lines)
            {
                if (string.IsNullOrEmpty(line))
                {
                    if (currentAccumulator < currentMax)
                    {
                        currentAccumulator = 0;
                        continue;
                    }
                 
                    currentMax = currentAccumulator;
                    currentAccumulator = 0;
                }
                else
                {
                    var value = long.Parse(line);
                    currentAccumulator += value;
                }
            }

            Console.WriteLine(Math.Max(currentMax, currentAccumulator));
        }

        public void Part2()
        {
            var lines = File.ReadAllLines("AoC/Input/Day1Part1.txt");

            var top1 = 0l;
            var top2 = 0l;
            var top3 = 0l;

            var currentAccumulator = 0l;
            foreach (var line in lines)
            {
                if (string.IsNullOrEmpty(line))
                {
                    if (currentAccumulator < top3)
                    {
                        currentAccumulator = 0;
                    }
                    else if(currentAccumulator < top2)
                    {
                        top3 = currentAccumulator;
                    }
                    else if(currentAccumulator < top1)
                    {
                        top3 = top2;
                        top2 = currentAccumulator;
                    }
                    else 
                    {
                        top3 = top2;
                        top2 = top1;
                        top1 = currentAccumulator;
                    }

                    currentAccumulator = 0;
                }
                else
                {
                    var value = long.Parse(line);
                    currentAccumulator += value;
                }
            }

            Console.WriteLine(Math.Max(top3, currentAccumulator) + top2 + top1);

        }
    }
}
