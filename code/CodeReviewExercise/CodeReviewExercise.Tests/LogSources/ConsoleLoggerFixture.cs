﻿namespace CodeReviewExercise.Tests.LogSources
{
    using CodeReviewExercise.Helpers;
    using Moq;
    using CodeReviewExercise.LogSources;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class ConsoleLoggerFixture
    {
        [TestMethod]
        public void ConstructorWithOnlyVerbosityShouldWork()
        {
            // Act
            new ConsoleLogger(LogType.Error);
        }

        [TestMethod]
        public void ShouldWriteWarningIfWarningVerbosity()
        {
            // Arrange
            const LogType verbosity = LogType.Warning;
            const string message = "Test Message";
            var consoleWrapperMock = new Mock<IConsoleWrapper>(MockBehavior.Strict);

            consoleWrapperMock.Setup(c => c.SetWarningForegroundColor()).Verifiable();
            consoleWrapperMock.Setup(c => c.WriteLine("{0} {1}", new object[] { It.IsAny<string>(), message })).Verifiable();
            consoleWrapperMock.Setup(c => c.ResetColor()).Verifiable();

            // Act
            var logger = new ConsoleLogger(verbosity, consoleWrapperMock.Object);
            logger.LogWarning(message);

            // Assert
            consoleWrapperMock.VerifyAll();
        }

        [TestMethod]
        public void ShouldWriteMessageIfMessageVerbosity()
        {
            // Arrange
            const LogType verbosity = LogType.Message;
            const string message = "Test Message";
            var consoleWrapperMock = new Mock<IConsoleWrapper>(MockBehavior.Strict);

            consoleWrapperMock.Setup(c => c.SetMessageForegroundColor()).Verifiable();
            consoleWrapperMock.Setup(c => c.WriteLine("{0} {1}", new object[] { It.IsAny<string>(), message })).Verifiable();
            consoleWrapperMock.Setup(c => c.ResetColor()).Verifiable();

            // Act
            var logger = new ConsoleLogger(verbosity, consoleWrapperMock.Object);
            logger.LogMessage(message);

            // Assert
            consoleWrapperMock.VerifyAll();
        }

        [TestMethod]
        public void ShouldWriteErrorIfErrorVerbosity()
        {
            // Arrange
            const LogType verbosity = LogType.Error;
            const string message = "Test Message";
            var consoleWrapperMock = new Mock<IConsoleWrapper>(MockBehavior.Strict);

            consoleWrapperMock.Setup(c => c.SetErrorForegroundColor()).Verifiable();
            consoleWrapperMock.Setup(c => c.WriteLine("{0} {1}", new object[] { It.IsAny<string>(), message })).Verifiable();
            consoleWrapperMock.Setup(c => c.ResetColor()).Verifiable();

            // Act
            var logger = new ConsoleLogger(verbosity, consoleWrapperMock.Object);
            logger.LogError(message);

            // Assert
            consoleWrapperMock.VerifyAll();
        }

        [TestMethod]
        public void ShouldWriteWarningIfMessageVerbosity()
        {
            // Arrange
            const LogType verbosity = LogType.Message;
            const string message = "Test Message";
            var consoleWrapperMock = new Mock<IConsoleWrapper>(MockBehavior.Strict);

            consoleWrapperMock.Setup(c => c.SetWarningForegroundColor()).Verifiable();
            consoleWrapperMock.Setup(c => c.WriteLine("{0} {1}", new object[] { It.IsAny<string>(), message })).Verifiable();
            consoleWrapperMock.Setup(c => c.ResetColor()).Verifiable();

            // Act
            var logger = new ConsoleLogger(verbosity, consoleWrapperMock.Object);
            logger.LogWarning(message);

            // Assert
            consoleWrapperMock.VerifyAll();
        }

        [TestMethod]
        public void ShouldWriteErrorIfMessageVerbosity()
        {
            // Arrange
            const LogType verbosity = LogType.Message;
            const string message = "Test Message";
            var consoleWrapperMock = new Mock<IConsoleWrapper>(MockBehavior.Strict);

            consoleWrapperMock.Setup(c => c.SetErrorForegroundColor()).Verifiable();
            consoleWrapperMock.Setup(c => c.WriteLine("{0} {1}", new object[] { It.IsAny<string>(), message })).Verifiable();
            consoleWrapperMock.Setup(c => c.ResetColor()).Verifiable();

            // Act
            var logger = new ConsoleLogger(verbosity, consoleWrapperMock.Object);
            logger.LogError(message);

            // Assert
            consoleWrapperMock.VerifyAll();
        }

        [TestMethod]
        public void ShouldWriteErrorIfWarningVerbosity()
        {
            // Arrange
            const LogType verbosity = LogType.Warning;
            const string message = "Test Message";
            var consoleWrapperMock = new Mock<IConsoleWrapper>(MockBehavior.Strict);

            consoleWrapperMock.Setup(c => c.SetErrorForegroundColor()).Verifiable();
            consoleWrapperMock.Setup(c => c.WriteLine("{0} {1}", new object[] { It.IsAny<string>(), message })).Verifiable();
            consoleWrapperMock.Setup(c => c.ResetColor()).Verifiable();

            // Act
            var logger = new ConsoleLogger(verbosity, consoleWrapperMock.Object);
            logger.LogError(message);

            // Assert
            consoleWrapperMock.VerifyAll();
        }

        [TestMethod]
        public void ShouldNotWriteWarningIfErrorVerbosity()
        {
            // Arrange
            const LogType verbosity = LogType.Error;
            const string message = "Test Message";

            // Act
            var logger = new ConsoleLogger(verbosity);
            logger.LogWarning(message);
        }

        [TestMethod]
        public void ShouldNotWriteMessageIfErrorVerbosity()
        {
            // Arrange
            const LogType verbosity = LogType.Error;
            const string message = "Test Message";

            // Act
            var logger = new ConsoleLogger(verbosity);
            logger.LogMessage(message);
        }

        [TestMethod]
        public void ShouldNotWriteMessageIfWarningVerbosity()
        {
            // Arrange
            const LogType verbosity = LogType.Warning;
            const string message = "Test Message";

            // Act
            var logger = new ConsoleLogger(verbosity);
            logger.LogMessage(message);
        }
    }
}
