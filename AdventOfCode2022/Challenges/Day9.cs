using AdventOfCode2022.AoC;

namespace AdventOfCode2022.Challenges
{
    public class Point
    {
        public HashSet<string> PointsVisited = new HashSet<string>();

        public Point(int x, int y)
        {
            X = x;
            Y = y;
            PointsVisited.Add($"{X}:{Y}");
        }

        public int X { get; set; }
        public int Y { get; set; }

        public void CalculateTailPosition(Point head)
        {
            PointsVisited.Add($"{X}:{Y}");
            var XDifferenceAbs = Math.Abs(head.X - X);
            var YDifferenceAbs = Math.Abs(head.Y - Y);

            if (XDifferenceAbs == 0 && YDifferenceAbs == 0) return;
            if (XDifferenceAbs == 1 && YDifferenceAbs == 1) return;
            if (XDifferenceAbs == 0 && YDifferenceAbs == 0) return;

            var XDifference = head.X - X;
            var YDifference = head.Y - Y;
            if (XDifferenceAbs == 1 && YDifferenceAbs == 2)
            {
                X = head.X;
                Y += (YDifference / 2);
            }
            else if (XDifferenceAbs == 2 && YDifferenceAbs == 1)
            {
               Y = head.Y;
               X += (XDifference / 2);
            }
            else if (XDifferenceAbs == 2)
            {
                X += (XDifference / 2);
            }
            else if (YDifferenceAbs == 2)
            {
                Y += (YDifference / 2);
            }
            PointsVisited.Add($"{X}:{Y}");
        }

        public void CalculateHeadPosition(string direction)
        {
            PointsVisited.Add($"{X}:{Y}");
            if (direction == "U")
            {
                Y += 1;
            }
            else if (direction == "D")
            {
                Y -= 1;
            }
            else if (direction == "R")
            {
                X += 1;
            }
            else if (direction == "L")
            {
                X -= 1;
            }
            PointsVisited.Add($"{X}:{Y}");
        }
    }
    public class Day9 : IDay
    {
        public void Part1()
        {
            var lines = File.ReadAllLines("AoC/Input/Day9Part1.txt").Select(i => i.Split(" ")).Select(j => new { Direction = j[0], Amount = int.Parse(j[1]) }).ToList();
            var currentHeadPosition = new Point(0, 0);
            var currentTailPosition = new Point(0, 0);
            foreach (var instruction in lines)
            {
                for (var i = 0; i < instruction.Amount; i++)
                {
                    currentHeadPosition.CalculateHeadPosition(instruction.Direction);
                    currentTailPosition.CalculateTailPosition(currentHeadPosition);
                }
            }
            Console.WriteLine(currentTailPosition.PointsVisited.Count);
        }

        public void Part2()
        {
            var lines = File.ReadAllLines("AoC/Input/Day9Part1.txt").Select(i => i.Split(" ")).Select(j => new { Direction = j[0], Amount = int.Parse(j[1]) }).ToList();
            var currentHeadPosition = new Point(0, 0);
            var current1 = new Point(0, 0);
            var current2 = new Point(0, 0);
            var current3 = new Point(0, 0);
            var current4 = new Point(0, 0);
            var current5 = new Point(0, 0);
            var current6 = new Point(0, 0);
            var current7 = new Point(0, 0);
            var current8 = new Point(0, 0);
            var current9 = new Point(0, 0);
            foreach (var instruction in lines)
            {
                for (var i = 0; i < instruction.Amount; i++)
                {
                    currentHeadPosition.CalculateHeadPosition(instruction.Direction);
                    current1.CalculateTailPosition(currentHeadPosition);
                    current2.CalculateTailPosition(current1);
                    current3.CalculateTailPosition(current2);
                    current4.CalculateTailPosition(current3);
                    current5.CalculateTailPosition(current4);
                    current6.CalculateTailPosition(current5);
                    current7.CalculateTailPosition(current6);
                    current8.CalculateTailPosition(current7);
                    current9.CalculateTailPosition(current8);
                }
            }
            Console.WriteLine(current9.PointsVisited.Count);
        }
    }
}
