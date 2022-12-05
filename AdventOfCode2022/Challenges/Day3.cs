using AdventOfCode2022.AoC;

namespace AdventOfCode2022.Challenges
{
    public class Day3 : IDay
    {
        public void Part1()
        {
            var lines = File.ReadAllLines("AoC/Input/Day3Part1.txt");

            var score = 0;
            foreach (var line in lines)
            {
                var part1 = line.Substring(0, line.Length / 2).ToCharArray();
                var part2 = line.Substring(line.Length / 2, line.Length / 2).ToHashSet();

                foreach(var letter in part1)
                {
                    if (!part2.Contains(letter)) continue;

                    if(letter < 97)
                    {
                        score += letter - 64 + 26;
                    }
                    else
                    {
                        score += letter - 96;
                    }

                    break;

                }
            }

            Console.WriteLine(score);
        }

        public void Part2()
        {
            var lines = File.ReadAllLines("AoC/Input/Day3Part1.txt");

            var score = 0;
            for (int i = 0; i < lines.Length; i += 3)
            {


                var line1 = lines[i].ToCharArray();
                var line2 = lines[i + 1].ToHashSet();
                var line3 = lines[i + 2].ToHashSet();


                foreach (var letter in line1)
                {
                    if (!line2.Contains(letter) || !line3.Contains(letter)) continue;

                    if (letter < 97)
                    {
                        score += letter - 64 + 26;
                    }
                    else
                    {
                        score += letter - 96;
                    }

                    break;

                }
            }

            Console.WriteLine(score);
        }
    }
}

