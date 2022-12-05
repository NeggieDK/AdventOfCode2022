using AdventOfCode2022.AoC;

namespace AdventOfCode2022.Challenges
{
    public class Day2 : IDay
    {
        public void Part1()
        {
            var lines = File.ReadAllLines("AoC/Input/Day2Part1.txt");
            var score = 0;
            foreach (var line in lines)
            {
                var splittedLine = line.Trim().Split(" ");
                var elfStr = splittedLine[0];
                var selfStr = splittedLine[1];

                var elf = RPS.Rock;
                if(elfStr == "A")
                {
                    elf = RPS.Rock;
                }
                else if(elfStr == "B")
                {
                    elf = RPS.Paper;
                }
                else
                {
                    elf = RPS.Scissor;
                }

                var self = RPS.Rock;
                
                if (selfStr == "X")
                {
                     self = RPS.Rock;
                    score += 1;
                }
                else if (selfStr == "Y")
                {
                    self = RPS.Paper;
                    score += 2;
                }
                else
                {
                    self = RPS.Scissor;
                    score += 3;
                }
                score += GameLogic.CalculateGameScore(self, elf);
            }

            Console.WriteLine(score);
        }

        public void Part2()
        {
            var lines = File.ReadAllLines("AoC/Input/Day2Part1.txt");
            var score = 0;
            foreach (var line in lines)
            {
                var splittedLine = line.Trim().Split(" ");
                var elfStr = splittedLine[0];
                var strategyStr = splittedLine[1];

                var elf = RPS.Rock;
                if (elfStr == "A")
                {
                    elf = RPS.Rock;
                }
                else if (elfStr == "B")
                {
                    elf = RPS.Paper;
                }
                else
                {
                    elf = RPS.Scissor;
                }

                if (strategyStr == "X")
                {
                    if(elf == RPS.Rock)
                    {
                        //Scissor
                        score += 3;

                    }
                    else if(elf == RPS.Paper)
                    {
                        //Rock
                        score += 1;
                    }
                    else
                    {
                        //Paper
                        score += 2;
                    }
                }
                else if (strategyStr == "Y")
                {
                    score += 3;
                    if (elf == RPS.Rock)
                    {
                        score += 1;

                    }
                    else if (elf == RPS.Paper)
                    {
                        score += 2;
                    }
                    else
                    {
                        score += 3;
                    }
                }
                else
                {
                    if (elf == RPS.Rock)
                    {
                        //Paper
                        score += 2;

                    }
                    else if (elf == RPS.Paper)
                    {
                        //Scissor
                        score += 3;
                    }
                    else
                    {
                        //Rock
                        score += 1;
                    }
                    score += 6;
                }
            }

            Console.WriteLine(score);
        }
    }

    public enum RPS
    {
        Rock,
        Paper,
        Scissor
    }

    public class GameLogic
    {
        public static int CalculateGameScore(RPS one, RPS two)
        {
            if (one == two) return 3;
            if(one == RPS.Rock)
            {
                if(two == RPS.Paper)
                {
                    return 0;
                }
                else
                {
                    return 6;
                }
            }
            else if(one == RPS.Paper)
            {
                if (two == RPS.Rock)
                {
                    return 6;
                }
                else
                {
                    return 0;
                }
            }
            else if(one == RPS.Scissor)
            {
                if (two == RPS.Paper)
                {
                    return 6;
                }
                else if (two == RPS.Rock)
                {
                    return 0;
                }
            }

            throw new InvalidOperationException();
        }
    }
}
