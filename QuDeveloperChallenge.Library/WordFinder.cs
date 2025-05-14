namespace QuDeveloperChallenge.Library
{
    public class WordFinder : IWordFinder
    {
        private const int MatrixMaxSize = 64;
        private string[] _matrix = [];

        public WordFinder(IEnumerable<string> matrix)
        {
            if (string.IsNullOrEmpty(matrix?.FirstOrDefault()))
            {
                return;
            }

            Matrix = [.. matrix];
        }

        public string[] Matrix 
        { 
            get => _matrix;
            private set
            {
                int firstRowLength = value.First().Length;

                if (firstRowLength > MatrixMaxSize || value.Length > MatrixMaxSize) 
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
                        if (word[0] == Matrix[row][col] && 
                            SearchWordRecursive(word, row, col, 0))
                        {
                            searchResults.Add(word);
                            col = col + word.Length >= Matrix[row].Length ? Matrix[row].Length - 1 : col + word.Length;
                        }
                    }
                }
            }

            return searchResults;
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

        private bool SearchWord(string word, int row, int col)
        {
            for (int wordCharIndex = 1; wordCharIndex < word.Length; wordCharIndex++)
            {
                int colIndexToCompare = col + wordCharIndex;
                int rowIndexToCompare = row + wordCharIndex;

                if ((colIndexToCompare >= Matrix[row].Length || Matrix[row][colIndexToCompare] != word[wordCharIndex]) &&
                    (rowIndexToCompare >= Matrix.Length || Matrix[rowIndexToCompare][col] != word[wordCharIndex]))
                {
                    return false;
                }

                if (word.Length == wordCharIndex + 1)
                {
                    return true;
                }
            }

            return false;
        }

    }
}
