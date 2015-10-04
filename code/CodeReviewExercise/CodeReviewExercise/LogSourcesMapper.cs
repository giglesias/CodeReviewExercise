namespace CodeReviewExercise
{
    using System.Collections.Generic;

    public class LogSourcesMapper
    {
        public static readonly Dictionary<string, string> SourceMapping = new Dictionary<string, string>
                                                                 {
                                                                     { LoggerSources.ConsoleLogger.ToString(), "CodeReviewExercise.LogSources.ConsoleLogger, CodeReviewExercise" },
                                                                     { LoggerSources.SqlDatabaseLogger.ToString(), "CodeReviewExercise.LogSources.SqlDatabaseLogger, CodeReviewExercise" },
                                                                     { LoggerSources.TextFileLogger.ToString(), "CodeReviewExercise.LogSources.TextFileLogger, CodeReviewExercise" }
                                                                 };
    }
}
