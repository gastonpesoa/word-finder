namespace QuDeveloperChallenge.Library
{
    public abstract class WordFinder : IWordFinder
    {
        private const int MatrixMaxSize = 64;
        private string[] _matrix = [];

        public string[] Matrix 
        { 
            get => _matrix;
            protected set
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

        public abstract IEnumerable<string> Find(IEnumerable<string> wordstream);
    }
}
