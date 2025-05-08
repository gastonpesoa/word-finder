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
            string[] wordStream = [];

            // Act
            IEnumerable<string> actual = wordFinder.Find(wordStream);
            
            // Assert
            Assert.IsAssignableFrom<IEnumerable<string>>(actual);
        }

        [Fact]
        public void Find_ShoulReturnEmtySetOfStringsIfNoWordsAreFound()
        {
            // Arrange
            string[] matrix = ["chill"];
            WordFinder wordFinder = new(matrix);
            string[] wordStream = ["cold"];

            // Act
            IEnumerable<string> actual = wordFinder.Find(wordStream);

            // Assert
            Assert.Empty(actual);
        }

        [Fact]
        public void Find_ShoulReturnWordFoundInOneRowMatrix()
        {
            // Arrange
            string[] matrix = ["cold"];
            WordFinder wordFinder = new(matrix);
            string[] expected = ["cold"];

            // Act
            IEnumerable<string> actual = wordFinder.Find(expected);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Find_ShoulReturnWordFoundInOneRowMatrixContainingIt()
        {
            // Arrange
            string[] matrix = ["abccoldwer"];
            WordFinder wordFinder = new(matrix);
            string[] expected = ["cold"];

            // Act
            IEnumerable<string> actual = wordFinder.Find(expected);

            // Assert
            Assert.Equal(expected, actual);
        }
    }
}