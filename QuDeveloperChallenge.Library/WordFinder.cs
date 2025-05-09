namespace QuDeveloperChallenge.Library
{
    public class WordFinder : IWordFinder
    {
        private const int MatrixMaxSize = 64;
        private string[] _matrix = [];

        // TODO Test matrix - null and size 
        public WordFinder(IEnumerable<string> matrix)
        {
            Matrix = [.. matrix];
        }

        public string[] Matrix 
        { 
            get => _matrix;
            private set
            {
                if (!string.IsNullOrEmpty(value?.FirstOrDefault()))
                {
                    int firstRowLength = value.First().Length;

                    if (firstRowLength > MatrixMaxSize) 
                    {
                        return;
                    }

                    foreach (var row in value)
                    {
                        if (row.Length != firstRowLength)
                        {
                            return;
                        }
                    }

                    _matrix = value;
                }
            }
        }

        public IEnumerable<string> Find(IEnumerable<string> wordstream)
        {
            HashSet<string> wordSet = [.. wordstream];
            HashSet<string> searchResults = [];

            foreach (string word in wordSet)
            {
                for (int row = 0; row < Matrix.Length; row++)
                {
                    for (int col = 0; col < Matrix[row].Length; col++)
                    {
                        if (Matrix[row][col] != word[0])
                        {
                            continue;
                        }

                        for (int wordCharIndex = 1; wordCharIndex < word.Length; wordCharIndex++)
                        {
                            int colIndexToCompare = col + wordCharIndex;
                            int rowIndexToCompare = row + wordCharIndex;

                            if ((colIndexToCompare >= Matrix[row].Length || Matrix[row][colIndexToCompare] != word[wordCharIndex])
                                && (rowIndexToCompare >= Matrix.Length || Matrix[rowIndexToCompare][col] != word[wordCharIndex])
                                )
                            {
                                break;
                            }

                            if (word.Length == wordCharIndex + 1)
                            {
                                searchResults.Add(word);
                                break;
                            }
                        }
                    }
                }
            }

            return searchResults;
        }
    }
}
