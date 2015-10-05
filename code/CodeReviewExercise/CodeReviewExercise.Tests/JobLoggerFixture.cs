namespace CodeReviewExercise.Tests
{
    using CodeReviewExercise.LogSources;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class JobLoggerFixture
    {
        // Using ConsoleLogger as one implementation of JobLogger to test base method LogIfCorresponds
        [TestMethod]
        public void ShouldNotLogIfMessageNull()
        {
            // Act
            var logger = new ConsoleLogger(LogType.Message);
            logger.LogMessage(null);
        }

        [TestMethod]
        public void ShouldNotLogIfMessageEmpty()
        {
            // Act
            var logger = new ConsoleLogger(LogType.Message);
            logger.LogMessage(string.Empty);
        }

        [TestMethod]
        public void ShouldNotLogIfMessageWhitespace()
        {
            // Act
            var logger = new ConsoleLogger(LogType.Message);
            logger.LogMessage("         "); // Spaces and tabs
        }
    }
}
