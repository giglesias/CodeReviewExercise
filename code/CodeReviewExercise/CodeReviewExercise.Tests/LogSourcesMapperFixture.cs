namespace CodeReviewExercise.Tests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class LogSourcesMapperFixture
    {
        [TestMethod]
        public void ShouldRetrieveConsoleLoggerTypeString()
        {
            // Arrange
            const string expectedType = "CodeReviewExercise.LogSources.ConsoleLogger, CodeReviewExercise";

            // Act
            var type = LogSourcesMapper.SourceMapping[LoggerSources.ConsoleLogger.ToString()];

            // Assert
            Assert.AreEqual(expectedType, type);
        }

        [TestMethod]
        public void ShouldRetrieveSqlDatabaseLoggerTypeString()
        {
            // Arrange
            const string expectedType = "CodeReviewExercise.LogSources.SqlDatabaseLogger, CodeReviewExercise";

            // Act
            var type = LogSourcesMapper.SourceMapping[LoggerSources.SqlDatabaseLogger.ToString()];

            // Assert
            Assert.AreEqual(expectedType, type);
        }

        [TestMethod]
        public void ShouldRetrieveTextFileLoggerTypeString()
        {
            // Arrange
            const string expectedType = "CodeReviewExercise.LogSources.TextFileLogger, CodeReviewExercise";

            // Act
            var type = LogSourcesMapper.SourceMapping[LoggerSources.TextFileLogger.ToString()];

            // Assert
            Assert.AreEqual(expectedType, type);
        }
    }
}
