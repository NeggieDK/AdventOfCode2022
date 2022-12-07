using AdventOfCode2022.AoC;

namespace AdventOfCode2022.Challenges
{
    public class Day7 : IDay
    {
        private DirectoryNode Root;
        private List<DirectoryNode> Directories;

        public void Part1()
        {
            var lines = File.ReadAllLines("AoC/Input/Day7Part1.txt");
            var root = new DirectoryNode("root", null);
            var currentDirectory = root;
            Root = root;
            var directories = new List<DirectoryNode>();
            //directories.Add(root);
            Directories = directories;
            for (int i = 0; i < lines.Length; i++)
            {
                var line = lines[i];
                if (line.StartsWith("$"))
                {
                    var split = line.Split(" ");
                    if (split[1] == "cd")
                    {
                        var to = split[2];
                        if(to == "/")
                        {
                            currentDirectory = root;
                        }
                        else if(to == "..")
                        {
                            currentDirectory = currentDirectory.Parent;
                        }
                        else
                        {
                            currentDirectory = currentDirectory.Children.Single(i => i.Name == to);
                        }
                    }
                    else if (split[1] == "ls")
                    {
                        var offset = 1;
                        var nextLine = new string[1];
                        do
                        {
                            nextLine = lines[i + offset].Split(" ");
                            if (nextLine[0].StartsWith("dir"))
                            {
                                var newDirectory = new DirectoryNode(nextLine[1], currentDirectory);
                                currentDirectory.Children.Add(newDirectory);
                                directories.Add(newDirectory);
                            }
                            else
                            {
                                currentDirectory.Files.Add(new FileNode(nextLine[1], int.Parse(nextLine[0]), currentDirectory));
                            }
                            offset++;
                        }
                        while (i + offset < lines.Length && !lines[i + offset].StartsWith("$"));
                        i += (offset - 1);
                    }
                }
            }

            var sum = 0;
            foreach(var directory in directories)
            {
                if (directory.CalculateSize() > 100_000) continue;

                sum += directory.CalculateSize();
            }
            Console.WriteLine(sum);
        }

        public void Part2()
        {
            var maxSize = 70_000_000;
            var spaceNeeded = 30_000_000;

            var rootSize = Root.CalculateSize();
            var spaceAlreadyFree = maxSize - rootSize;

            var sortedDirectories = Directories.OrderBy(i => i.CalculateSize());
            foreach(var directory in sortedDirectories)
            {
                if(directory.CalculateSize() > spaceNeeded - spaceAlreadyFree)
                {
                    Console.WriteLine(directory.CalculateSize());
                    return;
                }
            }
        }
    }

    public class DirectoryNode
    {
        public string Name { get; set; }
        public DirectoryNode? Parent { get; set; }
        public List<DirectoryNode> Children { get; set; }
        public List<FileNode> Files{ get; set; }
        private int? size = null;

        public DirectoryNode(string name, DirectoryNode parent)
        {
            Parent = parent;
            Children = new List<DirectoryNode>();
            Name = name;
            Files = new List<FileNode>();
        }

        public int CalculateSize()
        {
            if (size != null) return (int)size;

            var totalSize = 0;
            foreach(var child in Children)
            {
                totalSize += child.CalculateSize();
            }

            foreach(var file in Files)
            {
                totalSize += file.Size;
            }
            size = totalSize;
            return totalSize;
        }
    }

    public class FileNode
    {
        public string Name { get; set; }
        public int Size { get; set; }
        public DirectoryNode? Parent { get; set; }

        public FileNode(string name, int size, DirectoryNode parent)
        {
            Name = name;
            Size = size;
            Parent = parent;
        }
    }
}
