public class Program
{
    static void Main(String[] args)
    {
        // Day 1
        Day_One_Part1();
        Day_One_Part2();
        // Day 2
        Day_Two_Part1();
    }

    static void Day_One_Part1()
    {
        int currentElf = 1;
        int maxElf = 1;
        int currentCalories;
        int maxCalories = 0;

        string line;

        using (StreamReader reader = new("day1.txt"))
        {
            while ((line = reader.ReadLine()) != null)
            {
                if (string.IsNullOrWhiteSpace(line))
                {
                    // Start a new elf's inventory
                    currentElf++;
                    currentCalories = 0;
                }
                else
                {
                    // Add the number of calories to the current elf's inventory
                    currentCalories = int.Parse(line);

                    // Updates the elf with the most calories
                    if (currentCalories > maxCalories)
                    {
                        maxElf = currentElf;
                        maxCalories = currentCalories;
                    }
                }
            }
        }

        Console.WriteLine("Day 1: \nElf {0} has the most calories with a total of: {1}", maxElf, maxCalories);
    }

    static void Day_One_Part2()
    {
        int[] top3Calories = new int[3];
        int currentCalories = 0;
        int totalCalories = 0;
        string line;

        using (StreamReader reader = new("day1.txt"))
        {
            while ((line = reader.ReadLine()) != null)
            {
                if (string.IsNullOrWhiteSpace(line))
                {
                    for (int i = 2; i >= 0; i--)
                    {
                        if (currentCalories > top3Calories[i])
                        {
                            if (i != 2)
                            {
                                top3Calories[i + 1] = top3Calories[i];
                            }

                            top3Calories[i] = currentCalories;
                        }
                    }

                    // Start a new elf's inventory
                    currentCalories = 0;
                }
                else
                {
                    // Add the number of calories to the current elf's inventory
                    currentCalories += int.Parse(line);
                }
            }
        }

        foreach (int num in top3Calories)
        {
            totalCalories += num;
        }

        Console.WriteLine("The 3 elves with the most calories in their inventories totals to: {0}", totalCalories.ToString());
    }

    static void Day_Two_Part1()
    {
        var inputFile = File.ReadAllLines("./day2.txt");
        var input = new List<string>(inputFile);

        // A - Rock, B - Paper, C - Scissors
        // X - Rock, Y - Paper, Z - Scissors
        // 1, 2, 3

        var inputScore = new Dictionary<string, int>() 
        {
            {"X", 1},
            {"Y", 2},
            {"Z", 3}
        };

        int score = 0;

        foreach (var line in input) 
        {
            var choices = line.Split(' ');
            var opponent = choices[0];
            var mine = choices[1];

            // Win
            if (opponent == "A" && mine == "Y" ||
                opponent == "B" && mine == "Z" ||
                opponent == "C" && mine == "X")
            {
                score += 6 + inputScore[mine];
            }
            // Draw
            else if (opponent == "A" && mine == "X" ||
                     opponent == "B" && mine == "Y" ||
                     opponent == "C" && mine == "Z")
            {
                score += 3 + inputScore[mine];
            }
            // Loss
            else
            {
                score += inputScore[mine];
            }
        }

        Console.WriteLine("\nDay 2: \nIf everything went exactly according to the strategy guide, my score would be: {0}", score.ToString());
    }
}