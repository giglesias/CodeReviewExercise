namespace CodeReviewExercise.Tests.Repositories
{
    using System.Data.Entity;
    using CodeReviewExercise.Repositories;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class LogsContextFixture
    {
        [TestMethod]
        public void ConstructorAndOnModelCreatingShouldWork()
        {
            Database.SetInitializer<LogsContext>(null);
            var context = new LogsContext();
            context.Database.Initialize(false);
        }
    }
}
