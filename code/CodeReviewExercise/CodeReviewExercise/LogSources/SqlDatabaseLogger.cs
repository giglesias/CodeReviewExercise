﻿namespace CodeReviewExercise.LogSources
{
    using System;
    using CodeReviewExercise.Models;
    using CodeReviewExercise.Repositories;

    public class SqlDatabaseLogger : JobLogger
    {
        private readonly ILogsRepository logsRepository;

        public SqlDatabaseLogger(LogType logVerbosity)
            : this(logVerbosity, new LogsRepository())
        {
        }

        public SqlDatabaseLogger(LogType logVerbosity, ILogsRepository logsRepository)
        {
            this.LogVerbosity = logVerbosity;
            this.logsRepository = logsRepository;
        }

        public override string LogError(string message)
        {
            return this.LogIfCorresponds(message, LogType.Error, (string msg) => this.SaveMessage(msg, LogType.Error));
        }

        public override string LogWarning(string message)
        {
            return this.LogIfCorresponds(message, LogType.Warning, (string msg) => this.SaveMessage(msg, LogType.Warning));
        }

        public override string LogMessage(string message)
        {
            return this.LogIfCorresponds(message, LogType.Message, (string msg) => this.SaveMessage(msg, LogType.Message));
        }

        private void SaveMessage(string message, LogType type)
        {
            var logValue = new LogValue
            {
                Id = Guid.NewGuid(),
                Message = message,
                Type = type
            };

            this.logsRepository.AddLogValue(logValue);
        }
    }
}
