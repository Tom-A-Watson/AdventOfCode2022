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