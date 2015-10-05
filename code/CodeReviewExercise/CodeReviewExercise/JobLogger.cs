namespace CodeReviewExercise
{
    using System;

    public abstract class JobLogger
    {
        public LogType LogVerbosity { get; set; }

        public abstract void LogError(string message);

        public abstract void LogWarning(string message);

        public abstract void LogMessage(string message);

        protected virtual void LogIfCorresponds(string message, LogType type, Action<string> logAction)
        {
            if (!string.IsNullOrWhiteSpace(message.Trim()) && this.LogVerbosity >= type)
            {
                logAction(message);
            }
        }
    }
}
