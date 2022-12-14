using AdventOfCode2022.AoC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2022.Challenges
{
    public class CurrentPosition
    {
        public CurrentPosition()
        {
            PositionsVisited = new HashSet<Tuple<int, int>>();
        }

        public int X { get; set; }
        public int Y { get; set; }
        public char CurrentLevel { get; set; }
        public HashSet<Tuple<int, int>> PositionsVisited { get; set; }

        public CurrentPosition Clone()
        {
            return new CurrentPosition
            {
                CurrentLevel = CurrentLevel,
                X = X,
                Y = Y,
                PositionsVisited = new HashSet<Tuple<int, int>>(PositionsVisited)
            };
        }
    }

    public class Day12 : IDay
    {
        private bool CheckLevel(char currentLevel, char nextLevel)
        {
            if (currentLevel == nextLevel) return true;
            if(currentLevel + 1 == nextLevel) return true;
            if ((currentLevel == 'z' || currentLevel == 'y') && nextLevel == 'E') return true;

            return false;
        }

        private void CheckNeighbour(CurrentPosition result, int x, int y, List<string> lines, Queue<CurrentPosition> positionsToCheck, List<CurrentPosition> viablePaths)
        {
            var newResult = result.Clone();
            newResult.CurrentLevel = lines[result.Y + y][result.X + x];
            newResult.X += x;
            newResult.Y += y;
            newResult.PositionsVisited.Add(new Tuple<int, int>(result.X, result.Y));
            

            if (lines[result.Y + y][result.X + x] == 'E')
            {
                viablePaths.Add(newResult);
                return;
            }
            
            positionsToCheck.Enqueue(newResult);
        }

        public void Part1()
        {
            var lines = File.ReadAllLines("AoC/Input/Day12Part1.txt").ToList();
            var startingX = 0;
            var startingY = 0;
            var currentLevel = 'a';

            var maxX = lines[0].Length - 1;
            var maxY = lines.Count - 1;

            for (int i = 0; i < lines.Count; i++)
            {
                string line = lines[i];
                for (int i1 = 0; i1 < line.Length; i1++)
                {
                    char element = line[i1];
                    if (element != 'S') continue;

                    startingX = i1;
                    startingY = i;
                }
            }

            var startPosition = new CurrentPosition
            {
                CurrentLevel = currentLevel,
                X = startingX,
                Y = startingY,
            };
            var positionsToCheck = new Queue<CurrentPosition>();
            positionsToCheck.Enqueue(startPosition);
   
            var viablePaths = new List<CurrentPosition>();
            var positionsAlreadyChecked = new HashSet<Tuple<int, int>>();
            while(positionsToCheck.TryDequeue(out var result))
            {
                if(result.X != 0)
                {
                    if(!result.PositionsVisited.Contains(new Tuple<int, int>(result.X - 1, result.Y)) && CheckLevel(result.CurrentLevel, lines[result.Y][result.X - 1]))
                    {
                        CheckNeighbour(result, -1, 0, lines, positionsToCheck, viablePaths);
                    }
                }
                if (result.X != maxX)
                {
                    if (!result.PositionsVisited.Contains(new Tuple<int, int>(result.X + 1, result.Y)) && CheckLevel(result.CurrentLevel, lines[result.Y][result.X + 1]))
                    {
                        CheckNeighbour(result, 1, 0, lines, positionsToCheck, viablePaths);
                    }
                }

                if (result.Y != 0)
                {
                    if (!result.PositionsVisited.Contains(new Tuple<int, int>(result.X, result.Y - 1)) && CheckLevel(result.CurrentLevel, lines[result.Y - 1][result.X]))
                    {
                        CheckNeighbour(result, 0, -1, lines, positionsToCheck, viablePaths);
                    }
                }
                if (result.Y != maxY)
                {
                    if (!result.PositionsVisited.Contains(new Tuple<int, int>(result.X, result.Y + 1)) && CheckLevel(result.CurrentLevel, lines[result.Y + 1][result.X]))
                    {
                        CheckNeighbour(result, 0, 1, lines, positionsToCheck, viablePaths);
                    }
                }
            }

            Console.WriteLine(viablePaths.Min(i => i.PositionsVisited.Count));
        }

        public void Part2()
        {
            Console.WriteLine();
        }
    }
}
