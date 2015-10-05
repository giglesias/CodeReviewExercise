namespace CodeReviewExercise.Tests.LogSources
{
    using System.Configuration;
    using CodeReviewExercise.Helpers;
    using CodeReviewExercise.LogSources;
    using Moq;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class TextFileLoggerFixture
    {
        private string logFilePath = ConfigurationManager.AppSettings["LogFileDirectory"];

        [TestMethod]
        public void ConstructorWithOnlyVerbosityShouldWork()
        {
            // Act
            new TextFileLogger(LogType.Error);
        }

        [TestMethod]
        public void ShouldWriteWarningIfWarningVerbosity()
        {
            // Arrange
            const LogType verbosity = LogType.Warning;
            const string message = "Test Message";
            var fileWrapperMock = new Mock<IFileWrapper>(MockBehavior.Strict);

            fileWrapperMock.Setup(c => c.AppendAllText(It.Is<string>(path => path.Contains(this.logFilePath)), message)).Verifiable();

            // Act
            var logger = new TextFileLogger(verbosity, fileWrapperMock.Object);
            var loggedMessage = logger.LogWarning(message);

            // Assert
            fileWrapperMock.VerifyAll();
            Assert.AreEqual(message, loggedMessage);
        }

        [TestMethod]
        public void ShouldWriteMessageIfMessageVerbosity()
        {
            // Arrange
            const LogType verbosity = LogType.Message;
            const string message = "Test Message";
            var fileWrapperMock = new Mock<IFileWrapper>(MockBehavior.Strict);

            fileWrapperMock.Setup(c => c.AppendAllText(It.Is<string>(path => path.Contains(this.logFilePath)), message)).Verifiable();

            // Act
            var logger = new TextFileLogger(verbosity, fileWrapperMock.Object);
            var loggedMessage = logger.LogMessage(message);

            // Assert
            fileWrapperMock.VerifyAll();
            Assert.AreEqual(message, loggedMessage);
        }

        [TestMethod]
        public void ShouldWriteErrorIfErrorVerbosity()
        {
            // Arrange
            const LogType verbosity = LogType.Error;
            const string message = "Test Message";
            var fileWrapperMock = new Mock<IFileWrapper>(MockBehavior.Strict);

            fileWrapperMock.Setup(c => c.AppendAllText(It.Is<string>(path => path.Contains(this.logFilePath)), message)).Verifiable();

            // Act
            var logger = new TextFileLogger(verbosity, fileWrapperMock.Object);
            var loggedMessage = logger.LogError(message);

            // Assert
            fileWrapperMock.VerifyAll();
            Assert.AreEqual(message, loggedMessage);
        }

        [TestMethod]
        public void ShouldWriteWarningIfMessageVerbosity()
        {
            // Arrange
            const LogType verbosity = LogType.Message;
            const string message = "Test Message";
            var fileWrapperMock = new Mock<IFileWrapper>(MockBehavior.Strict);

            fileWrapperMock.Setup(c => c.AppendAllText(It.Is<string>(path => path.Contains(this.logFilePath)), message)).Verifiable();

            // Act
            var logger = new TextFileLogger(verbosity, fileWrapperMock.Object);
            var loggedMessage = logger.LogWarning(message);

            // Assert
            fileWrapperMock.VerifyAll();
            Assert.AreEqual(message, loggedMessage);
        }

        [TestMethod]
        public void ShouldWriteErrorIfMessageVerbosity()
        {
            // Arrange
            const LogType verbosity = LogType.Message;
            const string message = "Test Message";
            var fileWrapperMock = new Mock<IFileWrapper>(MockBehavior.Strict);

            fileWrapperMock.Setup(c => c.AppendAllText(It.Is<string>(path => path.Contains(this.logFilePath)), message)).Verifiable();

            // Act
            var logger = new TextFileLogger(verbosity, fileWrapperMock.Object);
            var loggedMessage = logger.LogError(message);

            // Assert
            fileWrapperMock.VerifyAll();
            Assert.AreEqual(message, loggedMessage);
        }

        [TestMethod]
        public void ShouldWriteErrorIfWarningVerbosity()
        {
            // Arrange
            const LogType verbosity = LogType.Warning;
            const string message = "Test Message";
            var fileWrapperMock = new Mock<IFileWrapper>(MockBehavior.Strict);

            fileWrapperMock.Setup(c => c.AppendAllText(It.Is<string>(path => path.Contains(this.logFilePath)), message)).Verifiable();

            // Act
            var logger = new TextFileLogger(verbosity, fileWrapperMock.Object);
            var loggedMessage = logger.LogError(message);

            // Assert
            fileWrapperMock.VerifyAll();
            Assert.AreEqual(message, loggedMessage);
        }

        [TestMethod]
        public void ShouldNotWriteWarningIfErrorVerbosity()
        {
            // Arrange
            const LogType verbosity = LogType.Error;
            const string message = "Test Message";

            // Act
            var logger = new TextFileLogger(verbosity);
            var loggedMessage = logger.LogWarning(message);

            // Assert
            Assert.AreEqual(null, loggedMessage);
        }

        [TestMethod]
        public void ShouldNotWriteMessageIfErrorVerbosity()
        {
            // Arrange
            const LogType verbosity = LogType.Error;
            const string message = "Test Message";

            // Act
            var logger = new TextFileLogger(verbosity);
            var loggedMessage = logger.LogMessage(message);

            // Assert
            Assert.AreEqual(null, loggedMessage);
        }

        [TestMethod]
        public void ShouldNotWriteMessageIfWarningVerbosity()
        {
            // Arrange
            const LogType verbosity = LogType.Warning;
            const string message = "Test Message";

            // Act
            var logger = new TextFileLogger(verbosity);
            var loggedMessage = logger.LogMessage(message);

            // Assert
            Assert.AreEqual(null, loggedMessage);
        }
    }
}
