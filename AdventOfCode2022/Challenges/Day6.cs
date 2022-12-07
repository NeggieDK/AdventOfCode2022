using AdventOfCode2022.AoC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2022.Challenges
{
    public class Day6 : IDay
    {
        private int FindFirstMarker(ReadOnlySpan<char> line, int length)
        {
            for (var i = 0; i < line.Length; i++)
            {
                var slice = line.Slice(i, length);
                var duplicate = false;
                for (var j = 0; j < slice.Length; j++)
                {
                    for (var k = 0; k < slice.Length; k++)
                    {
                        if (j == k) continue;
                        if (slice[j] != slice[k]) continue;

                        duplicate = true;
                    }

                    if (duplicate) continue;
                }

                if (!duplicate)
                {
                    return i + length;
                }
            }

            return 0;
        }

        public void Part1()
        {
            ReadOnlySpan<char> line = File.ReadAllLines("AoC/Input/Day6Part1.txt").First().ToArray();
            Console.WriteLine(FindFirstMarker(line, 4));
        }

        public void Part2()
        {

            ReadOnlySpan<char> line = File.ReadAllLines("AoC/Input/Day6Part1.txt").First().ToArray();
            Console.WriteLine(FindFirstMarker(line, 14));
        }
    }
}
