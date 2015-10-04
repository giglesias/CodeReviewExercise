namespace CodeReviewExercise.Repositories
{
    using System.Data.Entity;
    using CodeReviewExercise.Migrations;

    public class LogsContextInitializer : MigrateDatabaseToLatestVersion<LogsContext, Configuration>
    {
    }
}
