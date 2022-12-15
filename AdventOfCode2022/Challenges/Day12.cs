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
        private List<string> Lines;
        private List<CurrentPosition> ViablePaths = new List<CurrentPosition>();
        public int EndX { get; set; }
        public int EndY { get; set; }

        private bool CheckLevel(char currentLevel, char nextLevel)
        {
            if (nextLevel <= currentLevel && nextLevel != 'E') return true;
            if(currentLevel + 1 == nextLevel) return true;
            if ((currentLevel == 'z' || currentLevel == 'y') && nextLevel == 'E') return true;

            return false;
        }

        private void CheckNeighbour(CurrentPosition result, int x, int y, PriorityQueue<CurrentPosition, int> positionsToCheck, HashSet<Tuple<int,int>> positionsAlreadyChecked)
        {
            var newResult = result.Clone();
            newResult.CurrentLevel = Lines[result.Y + y][result.X + x];
            newResult.X += x;
            newResult.Y += y;
            newResult.PositionsVisited.Add(new Tuple<int, int>(result.X, result.Y));

            if (Lines[result.Y + y][result.X + x] == 'E')
            {
                ViablePaths.Add(newResult);
                return;
            }

            if (positionsAlreadyChecked.Contains(new Tuple<int, int>(newResult.X, newResult.Y))) return;

            var manhattanDistance = Math.Abs(newResult.X - EndX) + Math.Abs(newResult.Y - EndY);
            positionsToCheck.Enqueue(newResult, manhattanDistance + newResult.PositionsVisited.Count);
            positionsAlreadyChecked.Add(new Tuple<int, int>(result.X, result.Y));
        }

        public void Part1()
        {
            Lines = File.ReadAllLines("AoC/Input/Day12Part1.txt").ToList();
            var startingX = 0;
            var startingY = 0;
            var currentLevel = 'a';

            var maxX = Lines[0].Length - 1;
            var maxY = Lines.Count - 1;

            for (int i = 0; i < Lines.Count; i++)
            {
                string line = Lines[i];
                for (int i1 = 0; i1 < line.Length; i1++)
                {
                    char element = line[i1];
                    if (element == 'S')
                    {
                        startingX = i1;
                        startingY = i;
                    }
                    else if(element == 'E')
                    {
                        EndX = i1;
                        EndY = i;
                    }

                }
            }

            var startPosition = new CurrentPosition
            {
                CurrentLevel = currentLevel,
                X = startingX,
                Y = startingY,
            };
            var positionsToCheck = new PriorityQueue<CurrentPosition, int>();
            positionsToCheck.Enqueue(startPosition, 0);
   
            ViablePaths = new List<CurrentPosition>();
            var positionsAlreadyChecked = new HashSet<Tuple<int, int>>();
            while(positionsToCheck.TryDequeue(out var result, out var _))
            {
                if(result.X != 0)
                {
                    if(!result.PositionsVisited.Contains(new Tuple<int, int>(result.X - 1, result.Y)) && CheckLevel(result.CurrentLevel, Lines[result.Y][result.X - 1]))
                    {
                        CheckNeighbour(result, -1, 0, positionsToCheck, positionsAlreadyChecked);
                    }
                }
                if (result.X != maxX)
                {
                    if (!result.PositionsVisited.Contains(new Tuple<int, int>(result.X + 1, result.Y)) && CheckLevel(result.CurrentLevel, Lines[result.Y][result.X + 1]))
                    {
                        CheckNeighbour(result, 1, 0, positionsToCheck, positionsAlreadyChecked);
                    }
                }

                if (result.Y != 0)
                {
                    if (!result.PositionsVisited.Contains(new Tuple<int, int>(result.X, result.Y - 1)) && CheckLevel(result.CurrentLevel, Lines[result.Y - 1][result.X]))
                    {
                        CheckNeighbour(result, 0, -1, positionsToCheck, positionsAlreadyChecked);
                    }
                }
                if (result.Y != maxY)
                {
                    if (!result.PositionsVisited.Contains(new Tuple<int, int>(result.X, result.Y + 1)) && CheckLevel(result.CurrentLevel, Lines[result.Y + 1][result.X]))
                    {
                        CheckNeighbour(result, 0, 1, positionsToCheck, positionsAlreadyChecked);
                    }
                }
            }

            Console.WriteLine(ViablePaths.Min(i => i.PositionsVisited.Count));
        }

        public void Part2()
        {
            Console.WriteLine();
        }
    }
}
