using AdventOfCode2022.AoC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2022.Challenges
{
    public class Day4 : IDay
    {
        public void Part1()
        {
            var lines = File.ReadAllLines("AoC/Input/Day4Part1.txt");
            var found = 0;
            foreach (var line in lines)
            {
                var split = line.Split(",");
                var pair1 = split[0].Split("-").Select(i => int.Parse(i)).ToList();
                var pair2 = split[1].Split("-").Select(i => int.Parse(i)).ToList();

                if (pair1[0] == pair2[0] || pair1[1] == pair2[1]) found++;

                if (pair1[0] > pair2[0])
                {
                    if (pair1[1] < pair2[1])
                    {
                        found++;
                    }
                }
                else if (pair1[0] < pair2[0])
                {
                    if (pair1[1] > pair2[1])
                    {
                        found++;
                    }
                }
            }
            Console.WriteLine(found);
        }

        public void Part2()
        {
            var lines = File.ReadAllLines("AoC/Input/Day4Part1.txt");
            var found = 0;
            foreach (var line in lines)
            {
                var split = line.Split(",");
                var pair1 = split[0].Split("-").Select(i => int.Parse(i)).ToList();
                var pair2 = split[1].Split("-").Select(i => int.Parse(i)).ToList();

                if (pair1[0] == pair2[0] || pair1[1] == pair2[1] || pair1[0] == pair2[1] || pair1[1] == pair2[0])
                {
                    found++;
                    continue;
                }

                if (pair2[0] > pair1[0] && pair2[0] < pair1[1])
                {
                    found++;
                    continue;
                }


                if (pair2[1] > pair1[0] && pair2[1] < pair1[1])
                {
                    found++;
                    continue;
                }

                if (pair1[0] > pair2[0] && pair1[0] < pair2[1])
                {
                    found++;
                    continue;
                }


                if (pair1[1] > pair2[0] && pair1[1] < pair2[1])
                {
                    found++;
                    continue;
                }
            }

            Console.WriteLine(found);
        }
    }
}
