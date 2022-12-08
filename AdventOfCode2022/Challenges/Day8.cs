using AdventOfCode2022.AoC;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2022.Challenges
{
    public class Day8 : IDay
    {
        static HashSet<string> VisibleTrees = new HashSet<string>();
        public void Calculate(List<string> lines)
        {
            for (var i = 0; i < lines.Count; i++)
            {
                for(var j = 0; j < lines[i].Length; j++)
                {
                    if(i == 0 || j == 0 || i == lines.Count -1 || j == lines[i].Length - 1)
                    {
                        VisibleTrees.Add($"{i}:{j}");
                        continue;
                    }


                    var tree = lines[i][j];
                    var upMax = lines.GetRange(0, i).Select(x => x[j]).Max();
                    var downMax = lines.Skip(i + 1).Select(x => x[j]).Max();
                    var leftMax = lines[i].ToList().GetRange(0, j).Max();
                    var rightMax = lines[i].ToList().Skip(j + 1).Max();

                    if (upMax >= tree && downMax >= tree && leftMax >= tree && rightMax >= tree) continue;
                    
                    VisibleTrees.Add($"{i}:{j}");
                }
            }
        }

        public void Part1()
        {
            var lines = File.ReadAllLines("AoC/Input/Day8Part1.txt").ToList();
            Calculate(lines);
            Console.WriteLine(VisibleTrees.Count);
        }

        public void Part2()
        {
            Console.WriteLine();
        }
    }
}
