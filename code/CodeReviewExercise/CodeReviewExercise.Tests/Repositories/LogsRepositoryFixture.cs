namespace CodeReviewExercise.Tests.Repositories
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using CodeReviewExercise.Models;
    using CodeReviewExercise.Repositories;
    using Moq;
    using System.Linq;

    [TestClass]
    public class LogsRepositoryFixture
    {
        [TestMethod]
        public void ShouldAddLogValueIntoDb()
        {
            // Arrange
            var mockLogValues = SetupMockLogValues();
            var mockLogValue = SetupMockLogValues().First();

            var mockLogValuesSet = SetupMockLogValuesSet(mockLogValues);
            mockLogValuesSet.Setup(m => m.Add(mockLogValue)).Verifiable();
            var contextMock = new Mock<LogsContext>();
            contextMock.Setup(m => m.LogValues).Returns(mockLogValuesSet.Object);
            contextMock.Setup(m => m.SaveChanges()).Returns(1).Verifiable();

            // Act
            var repository = new LogsRepository(contextMock.Object);
            repository.AddLogValue(mockLogValue);

            // Assert
            Assert.AreEqual(2, mockLogValuesSet.Object.Count());
            contextMock.VerifyAll();
        }

        private static IQueryable<LogValue> SetupMockLogValues()
        {
            var mockLogValues =
                new List<LogValue>
                    {
                        new LogValue
                            {
                                Id = Guid.NewGuid(),
                                Message = "Test message",
                                Type = LogType.Error
                            },
                        new LogValue
                            {
                                Id = Guid.NewGuid(),
                                Message = "Test message 2",
                                Type = LogType.Message
                            }
                    }.AsQueryable();
            return mockLogValues;
        }

        private static Mock<DbSet<LogValue>> SetupMockLogValuesSet(IQueryable<LogValue> mockLogValues)
        {
            var mockLogValuesSet = new Mock<DbSet<LogValue>>();
            mockLogValuesSet.As<IQueryable<LogValue>>().Setup(m => m.Provider).Returns(mockLogValues.Provider);
            mockLogValuesSet.As<IQueryable<LogValue>>().Setup(m => m.Expression).Returns(mockLogValues.Expression);
            mockLogValuesSet.As<IQueryable<LogValue>>().Setup(m => m.ElementType).Returns(mockLogValues.ElementType);
            mockLogValuesSet.As<IEnumerable<LogValue>>().Setup(m => m.GetEnumerator()).Returns(mockLogValues.GetEnumerator());
            return mockLogValuesSet;
        }
    }
}
