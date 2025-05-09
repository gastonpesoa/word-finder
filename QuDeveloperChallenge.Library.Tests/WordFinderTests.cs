namespace QuDeveloperChallenge.Library.Tests
{
    public class WordFinderTests
    {
        [Fact]
        public void Find_ShoulReturnCollectionOfStrings()
        {
            // Arrange
            string[] matrix = [];
            WordFinder wordFinder = new(matrix);
            string[] wordstream = [];

            // Act
            IEnumerable<string> actual = wordFinder.Find(wordstream);
            
            // Assert
            Assert.IsAssignableFrom<IEnumerable<string>>(actual);
        }

        [Fact]
        public void Find_ShoulReturnEmtySetOfStringsIfNoWordsAreFound()
        {
            // Arrange
            string[] matrix = ["djeeomrk"];
            WordFinder wordFinder = new(matrix);
            string[] wordstream = ["cold"];

            // Act
            IEnumerable<string> actual = wordFinder.Find(wordstream);

            // Assert
            Assert.Empty(actual);
        }

        [Fact]
        public void Find_ShoulReturnWordFoundInAMatrixRowContainingIt()
        {
            // Arrange
            string[] matrix = ["abccoldwec"];
            WordFinder wordFinder = new(matrix);
            string[] expected = ["cold"];

            // Act
            IEnumerable<string> actual = wordFinder.Find(expected);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Find_ShoulReturnWordsFoundInARowContainingThem()
        {
            // Arrange
            string[] matrix = ["abccoldwerefvchillpoic"];
            WordFinder wordFinder = new(matrix);
            string[] expected = ["cold", "chill"];

            // Act
            IEnumerable<string> actual = wordFinder.Find(expected);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Find_ShoulReturnWordFoundInAMatrixColumnContainingIt()
        {
            // Arrange
            string[] matrix = ["a", "b", "c", "c", "o", "l", "d", "w", "e", "r"];
            WordFinder wordFinder = new(matrix);
            string[] expected = ["cold"];

            // Act
            IEnumerable<string> actual = wordFinder.Find(expected);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Find_ShoulReturnEmtySetOfStringsIfNoWordsAreFoundInColumn()
        {
            // Arrange
            string[] matrix = ["a", "b", "c", "f", "t", "n", "d", "w", "e", "r"];
            WordFinder wordFinder = new(matrix);
            string[] wordstream = ["cold"];

            // Act
            IEnumerable<string> actual = wordFinder.Find(wordstream);

            // Assert
            Assert.Empty(actual);
        }

        [Fact]
        public void Find_ShoulReturnWordsFoundInAMatrixContainingThem()
        {
            // Arrange
            string[] matrix = ["abcwec", "mwindx", "jcosac", "zoknro", "ilfehn", "edctyj",];
            WordFinder wordFinder = new(matrix);
            string[] expected = ["cold", "wind"];

            // Act
            IEnumerable<string> actual = wordFinder.Find(expected);

            // Assert
            Assert.Equal(expected, actual);
        }
    }
}