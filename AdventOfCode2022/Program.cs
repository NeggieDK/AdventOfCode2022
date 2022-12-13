using AdventOfCode2022.AoC;
using AdventOfCode2022.Challenges;
using LightInject;
using System.Diagnostics;

var container = new ServiceContainer();
container.RegisterAssembly(typeof(IDay).Assembly);

var day = container.GetInstance<Day11>();

var sw1 = Stopwatch.StartNew();
day.Part1();
sw1.Stop();

var sw2 = Stopwatch.StartNew();
day.Part2();
sw2.Stop();

Console.WriteLine();
Console.WriteLine();
Console.WriteLine();
Console.WriteLine($"Execution time: Part1 = {sw1.ElapsedMilliseconds} ----- Part2 = {sw2.ElapsedMilliseconds}");