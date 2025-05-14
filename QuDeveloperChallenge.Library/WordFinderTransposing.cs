namespace QuDeveloperChallenge.Library
{
    public class WordFinderTransposing : WordFinder
    {
        private readonly string[] _columns = [];

        public WordFinderTransposing(IEnumerable<string> matrix)
        {
            if (string.IsNullOrEmpty(matrix?.FirstOrDefault()))
            {
                return;
            }

            Matrix = [.. matrix];

            int rowCount = Matrix.Length;

            if (rowCount <= 1)
            {
                return;
            }

            int colCount = Matrix[0].Length;
            _columns = new string[colCount];
            FillColumnsTransposingMatrix(rowCount, colCount);
        }

        public override IEnumerable<string> Find(IEnumerable<string> wordstream)
        {
            HashSet<string> words = [.. wordstream];
            Dictionary<string, int> searchResults = new(StringComparer.OrdinalIgnoreCase);

            foreach (var word in words)
            {
                int count = 0;

                for (int row = 0; row < Matrix.Length; row++)
                {
                    count += SearchWordAndReturnCount(Matrix[row], word);
                }

                for (int col = 0; col < _columns.Length; col++)
                {
                    count += SearchWordAndReturnCount(_columns[col], word);
                }

                if (count > 0)
                {
                    searchResults[word] = count;
                }
            }

            return searchResults
                .OrderByDescending(word => word.Value)
                .ThenBy(word => word.Key)
                .Take(10)
                .Select(word => word.Key);
        }

        private static int SearchWordAndReturnCount(string line, string word)
        {
            int count = 0;
            int index = 0;

            while ((index = line.IndexOf(word, index, StringComparison.OrdinalIgnoreCase)) != -1)
            {
                count++;
                index += word.Length;
            }

            return count;
        }

        private void FillColumnsTransposingMatrix(int rowCount, int colCount)
        {
            for (int col = 0; col < colCount; col++)
            {
                char[] columnChars = new char[rowCount];

                for (int row = 0; row < rowCount; row++)
                {
                    columnChars[row] = Matrix[row][col];
                }

                _columns[col] = new string(columnChars);
            }
        }
    }
}
