namespace WordFinder.Library.Tests
{
    public class WordFinderTests
    {
        [Fact]
        public void Find_ShoulReturn()
        {
            // Arrange
            var matrix = new HashSet<string>
            {
                "ABC", "BCD", "CDE"
            };
            var expected = new HashSet<string>
            {
                "ABC", "BCD", "CDE"
            };
            WordFinder wordFinder = new(matrix);

            // Act
            IEnumerable<string> actual = wordFinder.Find(expected);
            
            // Assert
            Assert.Equal(expected, actual);
        }
    }
}