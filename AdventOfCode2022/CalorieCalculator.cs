namespace AdventOfCode2022
{
    public static class CalorieCalculator
    {
        public static void FindElfWithMostCalories()
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

        public static void FindAndAddTop3Calories()
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
    }
}
