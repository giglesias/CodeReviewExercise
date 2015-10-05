namespace CodeReviewExercise.Tests.LogSources
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using CodeReviewExercise.LogSources;
    using CodeReviewExercise.Models;
    using CodeReviewExercise.Repositories;
    using Moq;

    [TestClass]
    public class SqlDatabaseLoggerFixture
    {
        [TestMethod]
        public void ConstructorWithOnlyVerbosityShouldWork()
        {
            // Act
            new SqlDatabaseLogger(LogType.Error);
        }

        [TestMethod]
        public void ShouldWriteWarningIfWarningVerbosity()
        {
            // Arrange
            const LogType verbosity = LogType.Warning;
            const string message = "Test Message";
            var logsRepositoryMock = new Mock<ILogsRepository>(MockBehavior.Strict);

            logsRepositoryMock.Setup(c => c.AddLogValue(It.Is<LogValue>(lv => lv.Message.Contains(message) && lv.Type == LogType.Warning))).Returns(It.IsAny<LogValue>).Verifiable();

            // Act
            var logger = new SqlDatabaseLogger(verbosity, logsRepositoryMock.Object);
            logger.LogWarning(message);

            // Assert
            logsRepositoryMock.VerifyAll();
        }

        [TestMethod]
        public void ShouldWriteMessageIfMessageVerbosity()
        {
            // Arrange
            const LogType verbosity = LogType.Message;
            const string message = "Test Message";
            var logsRepositoryMock = new Mock<ILogsRepository>(MockBehavior.Strict);

            logsRepositoryMock.Setup(c => c.AddLogValue(It.Is<LogValue>(lv => lv.Message.Contains(message) && lv.Type == LogType.Message))).Returns(It.IsAny<LogValue>).Verifiable();

            // Act
            var logger = new SqlDatabaseLogger(verbosity, logsRepositoryMock.Object);
            logger.LogMessage(message);

            // Assert
            logsRepositoryMock.VerifyAll();
        }

        [TestMethod]
        public void ShouldWriteErrorIfErrorVerbosity()
        {
            // Arrange
            const LogType verbosity = LogType.Error;
            const string message = "Test Message";
            var logsRepositoryMock = new Mock<ILogsRepository>(MockBehavior.Strict);

            logsRepositoryMock.Setup(c => c.AddLogValue(It.Is<LogValue>(lv => lv.Message.Contains(message) && lv.Type == LogType.Error))).Returns(It.IsAny<LogValue>).Verifiable();

            // Act
            var logger = new SqlDatabaseLogger(verbosity, logsRepositoryMock.Object);
            logger.LogError(message);

            // Assert
            logsRepositoryMock.VerifyAll();
        }

        [TestMethod]
        public void ShouldWriteWarningIfMessageVerbosity()
        {
            // Arrange
            const LogType verbosity = LogType.Message;
            const string message = "Test Message";
            var logsRepositoryMock = new Mock<ILogsRepository>(MockBehavior.Strict);

            logsRepositoryMock.Setup(c => c.AddLogValue(It.Is<LogValue>(lv => lv.Message.Contains(message) && lv.Type == LogType.Warning))).Returns(It.IsAny<LogValue>).Verifiable();

            // Act
            var logger = new SqlDatabaseLogger(verbosity, logsRepositoryMock.Object);
            logger.LogWarning(message);

            // Assert
            logsRepositoryMock.VerifyAll();
        }

        [TestMethod]
        public void ShouldWriteErrorIfMessageVerbosity()
        {
            // Arrange
            const LogType verbosity = LogType.Message;
            const string message = "Test Message";
            var logsRepositoryMock = new Mock<ILogsRepository>(MockBehavior.Strict);

            logsRepositoryMock.Setup(c => c.AddLogValue(It.Is<LogValue>(lv => lv.Message.Contains(message) && lv.Type == LogType.Error))).Returns(It.IsAny<LogValue>).Verifiable();

            // Act
            var logger = new SqlDatabaseLogger(verbosity, logsRepositoryMock.Object);
            logger.LogError(message);

            // Assert
            logsRepositoryMock.VerifyAll();
        }

        [TestMethod]
        public void ShouldWriteErrorIfWarningVerbosity()
        {
            // Arrange
            const LogType verbosity = LogType.Warning;
            const string message = "Test Message";
            var logsRepositoryMock = new Mock<ILogsRepository>(MockBehavior.Strict);

            logsRepositoryMock.Setup(c => c.AddLogValue(It.Is<LogValue>(lv => lv.Message.Contains(message) && lv.Type == LogType.Error))).Returns(It.IsAny<LogValue>).Verifiable();

            // Act
            var logger = new SqlDatabaseLogger(verbosity, logsRepositoryMock.Object);
            logger.LogError(message);

            // Assert
            logsRepositoryMock.VerifyAll();
        }

        [TestMethod]
        public void ShouldNotWriteWarningIfErrorVerbosity()
        {
            // Arrange
            const LogType verbosity = LogType.Error;
            const string message = "Test Message";
            var logsRepositoryMock = new Mock<ILogsRepository>(MockBehavior.Strict);

            // Act
            var logger = new SqlDatabaseLogger(verbosity, logsRepositoryMock.Object);
            logger.LogWarning(message);

            // Assert
            logsRepositoryMock.VerifyAll();
        }

        [TestMethod]
        public void ShouldNotWriteMessageIfErrorVerbosity()
        {
            // Arrange
            const LogType verbosity = LogType.Error;
            const string message = "Test Message";
            var logsRepositoryMock = new Mock<ILogsRepository>(MockBehavior.Strict);

            // Act
            var logger = new SqlDatabaseLogger(verbosity, logsRepositoryMock.Object);
            logger.LogMessage(message);

            // Assert
            logsRepositoryMock.VerifyAll();
        }

        [TestMethod]
        public void ShouldNotWriteMessageIfWarningVerbosity()
        {
            // Arrange
            const LogType verbosity = LogType.Warning;
            const string message = "Test Message";
            var logsRepositoryMock = new Mock<ILogsRepository>(MockBehavior.Strict);

            // Act
            var logger = new SqlDatabaseLogger(verbosity, logsRepositoryMock.Object);
            logger.LogMessage(message);

            // Assert
            logsRepositoryMock.VerifyAll();
        }
    }
}
