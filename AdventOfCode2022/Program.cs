using AdventOfCode2022.AoC;
using AdventOfCode2022.Challenges;
using LightInject;

var container = new ServiceContainer();
container.RegisterAssembly(typeof(IDay).Assembly);

var day = container.GetInstance<Day1>();

day.Part1();
day.Part2();