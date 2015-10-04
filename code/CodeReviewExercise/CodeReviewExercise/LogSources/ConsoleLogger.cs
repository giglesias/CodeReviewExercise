namespace CodeReviewExercise.LogSources
{
    using System;
    using CodeReviewExercise.Helpers;

    public class ConsoleLogger : Logger
    {
        private readonly IConsoleWrapper consoleWrapper;

        public ConsoleLogger(LogType logVerbosity)
            : this(logVerbosity, new ConsoleWrapper())
        {
        }

        public ConsoleLogger(LogType logVerbosity, IConsoleWrapper consoleWrapper)
        {
            this.LogVerbosity = logVerbosity;
            this.consoleWrapper = consoleWrapper;
        }

        public override void LogError(string message)
        {
            this.LogIfCorresponds(message, LogType.Error, (string msg) =>
            {
                this.consoleWrapper.SetErrorForegroundColor();
                this.consoleWrapper.WriteLine("{0} {1}", DateTime.Now.ToShortDateString(), msg);
            });
        }

        public override void LogWarning(string message)
        {
            this.LogIfCorresponds(message, LogType.Warning, (string msg) =>
            {
                this.consoleWrapper.SetWarningForegroundColor();
                this.consoleWrapper.WriteLine("{0} {1}", DateTime.Now.ToShortDateString(), msg);
            });
        }

        public override void LogMessage(string message)
        {
            this.LogIfCorresponds(message, LogType.Message, (string msg) =>
            {
                this.consoleWrapper.SetMessageForegroundColor();
                this.consoleWrapper.WriteLine("{0} {1}", DateTime.Now.ToShortDateString(), msg);
            });
        }
    }
}
