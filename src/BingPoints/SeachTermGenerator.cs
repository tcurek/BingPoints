namespace src.BingPoints
{
    public static class SearchTermGenerator
    {
        public static IEnumerable<string> Get(int numberOfSeaches)
        {
            var random = new Random();
            var results = new List<string>();
            var lines = System.IO.File.ReadAllLines(@"./Resources/words_alpha.txt");

            for(var i=0; i<numberOfSeaches; i++)
            {
                var prefix = SearchPrefix(random);

                var index = random.Next(minValue: 0, maxValue: lines.Length);
                results.Add($"{prefix} {lines[index]}");
            }

            return results;
        }

        private static string SearchPrefix(Random random)
        {
            var prefixes = new List<string>
            {
                "What is", "Where to find", "Explain a", "Definition of",
                "Meaning of", "Reddit", "Who makes", "etymology of", string.Empty
            };

            return prefixes[random.Next(0, prefixes.Count)];
        }
    }
}