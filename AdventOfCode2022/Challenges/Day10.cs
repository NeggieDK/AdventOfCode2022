using AdventOfCode2022.AoC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2022.Challenges
{
    public class Day10 : IDay
    {
        private int Check(int cycle, int x)
        {
            if (cycle == 0) return 0;
            if (cycle > 220) return 0;

            if((cycle - 20) == 0) return 20 * x;
            if((cycle - 20) % 40 == 0) return cycle * x;

            return 0;
        }
        public void Part1()
        {
            var x = 1;
            var cycle = 1;
            var sum = 0;
            var lines = File.ReadAllLines("AoC/Input/Day10Part1.txt").Select(i => i.Split(" "));
            foreach(var instruction in lines)
            {
                if (instruction.Length == 1)
                {
                    cycle++;
                    sum += Check(cycle, x);
                }
                else
                {
                    for(var i = 0;i<2;i++)
                    {
                        cycle++;
                        if(i == 1)
                        {
                            x += int.Parse(instruction[1]);
                        }
                        sum += Check(cycle, x);
                    }
                }
            }
            Console.WriteLine(sum);
        }

        public void Part2()
        {
            var x = 1;
            var cycle = 0;
            var lines = File.ReadAllLines("AoC/Input/Day10Part1.txt").Select(i => i.Split(" "));
            Draw(ref cycle, x);
            foreach (var instruction in lines)
            {
                if (instruction.Length == 1)
                {
                    cycle++;
                    Draw(ref cycle, x);
                }
                else
                {
                    for (var i = 0; i < 2; i++)
                    {
                        cycle++;
                        if (i == 1)
                        {
                            x += int.Parse(instruction[1]);
                        }
                        Draw(ref cycle, x);
                    }
                }

            }
        }

        private void Draw(ref int cycle, int x)
        {
            if (cycle > 0 && cycle % 40 == 0)
            {
                cycle -= 40;
                Console.WriteLine();
            }


            if(cycle == x || cycle == x + 1 || cycle == x - 1)
            {
                Console.Write("#");
            }
            else
            {
                Console.Write(".");
            }
        }
    }
}
