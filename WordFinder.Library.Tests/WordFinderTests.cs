namespace WordFinder.Library.Tests
{
    public class WordFinderTests
    {
        [Fact]
        public void Find_ShoulReturnCollectionOfStrings()
        {
            // Arrange
            WordFinder wordFinder = new(new HashSet<string>());

            // Act
            IEnumerable<string> actual = wordFinder.Find(new HashSet<string>());
            
            // Assert
            Assert.IsAssignableFrom<IEnumerable<string>>(actual);
        }
    }
}