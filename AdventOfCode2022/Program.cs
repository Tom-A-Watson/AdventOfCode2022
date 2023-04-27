void Main(String[] args) 
{
	Part1();
	Part2();
}

void Part1() 
{
	int currentElf = 1;
	int maxElf = 1;
	int currentCalories = 0;
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

	Console.WriteLine("Elf {0} has the most calories with a total of: {1}", maxElf, maxCalories);
}

void Part2() 
{
	int[] top3Calories = new int[3];
	int currentCalories = 0;

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

	int totalCalories = 0;

	foreach (int num in top3Calories)
	{
		totalCalories += num;
	}

	Console.WriteLine("The 3 elves carrying the most calories in their inventories have a total of: {0}", totalCalories.ToString());
}