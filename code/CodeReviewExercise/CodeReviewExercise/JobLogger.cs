namespace CodeReviewExercise
{
    using System;

    public abstract class JobLogger
    {
        public LogType LogVerbosity { get; set; }

        public abstract string LogError(string message);

        public abstract string LogWarning(string message);

        public abstract string LogMessage(string message);

        protected virtual string LogIfCorresponds(string message, LogType type, Action<string> logAction)
        {
            if (string.IsNullOrWhiteSpace(message) || this.LogVerbosity < type)
            {
                return null;
            }

            logAction(message.Trim());
            return message;
        }
    }
}
