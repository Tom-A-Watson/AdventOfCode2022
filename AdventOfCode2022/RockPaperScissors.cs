namespace AdventOfCode2022
{
    public static class RockPaperScissors
    {
        public static void GetScoreFromStrategyGuide()
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
}
