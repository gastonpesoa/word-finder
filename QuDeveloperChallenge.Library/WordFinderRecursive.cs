namespace QuDeveloperChallenge.Library
{
    public class WordFinderRecursive : WordFinder
    {
        public WordFinderRecursive(IEnumerable<string> matrix)
        {
            if (string.IsNullOrEmpty(matrix?.FirstOrDefault()))
            {
                return;
            }

            Matrix = [.. matrix];
        }

        public override IEnumerable<string> Find(IEnumerable<string> wordstream)
        {
            HashSet<string> wordSet = [.. wordstream];
            Dictionary<string, int> searchResults = new(StringComparer.OrdinalIgnoreCase);

            foreach (string word in wordSet)
            {
                for (int row = 0; row < Matrix.Length; row++)
                {
                    for (int col = 0; col < Matrix[row].Length; col++)
                    {
                        if (word[0] == Matrix[row][col] &&
                            SearchWordRecursive(word, row, col, 0))
                        {
                            if (!searchResults.TryAdd(word, 1))
                            {
                                searchResults[word] = searchResults[word] + 1;
                            }

                            col = col + word.Length >= Matrix[row].Length ? Matrix[row].Length - 1 : col + word.Length;
                        }
                    }
                }
            }

            return searchResults
                .OrderByDescending(word => word.Value)
                .Take(10)
                .Select(word => word.Key);
        }

        private bool SearchWordRecursive(string word, int row, int col, int wordCharIndex)
        {
            if (wordCharIndex == word.Length)
            {
                return true;
            }

            if (row >= Matrix.Length ||
                col >= Matrix[row].Length ||
                Matrix[row][col] != word[wordCharIndex])
            {
                return false;
            }

            if (SearchWordRecursive(word, row, col + 1, wordCharIndex + 1) ||
                SearchWordRecursive(word, row + 1, col, wordCharIndex + 1))
            {
                return true;
            }

            return false;
        }
    }
}
