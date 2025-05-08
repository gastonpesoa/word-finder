namespace QuDeveloperChallenge.Library
{
    public class WordFinder : IWordFinder
    {
        private readonly IEnumerable<string> _matrix;

        public WordFinder(IEnumerable<string> matrix)
        {
            _matrix = matrix;
        }

        public IEnumerable<string> Find(IEnumerable<string> wordStream)
        {
            HashSet<string> searchResults = [];

            foreach (string word in wordStream)
            {
                foreach (string row in _matrix)
                {
                    for (int col = 0; col < row.Length; col++)
                    {
                        if (row[col] == word[0])
                        {
                            for (int charAt = 1; charAt < word.Length; charAt++)
                            {
                                if (row[col + charAt] == word[charAt])
                                {
                                    if (word.Length == charAt + 1)
                                    {
                                        searchResults.Add(word);
                                        break;
                                    }
                                }
                                else
                                {
                                    break;
                                }
                            }
                        }
                    }
                }
            }

            return searchResults;
        }
    }
}
