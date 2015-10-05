namespace CodeReviewExercise.LogSources
{
    using System;
    using System.Configuration;
    using System.IO;
    using CodeReviewExercise.Helpers;

    public class TextFileLogger : JobLogger
    {
        private readonly IFileWrapper fileWrapper;

        public TextFileLogger(LogType logVerbosity)
            : this(logVerbosity, new FileWrapper())
        {
        }

        public TextFileLogger(LogType logVerbosity, IFileWrapper fileWrapper)
        {
            this.LogVerbosity = logVerbosity;
            this.fileWrapper = fileWrapper;
        }

        public override string LogError(string message)
        {
            return this.LogIfCorresponds(message, LogType.Error, (string msg) => this.AppendMessage(msg));
        }

        public override string LogWarning(string message)
        {
            return this.LogIfCorresponds(message, LogType.Warning, (string msg) => this.AppendMessage(msg));
        }

        public override string LogMessage(string message)
        {
            return this.LogIfCorresponds(message, LogType.Message, (string msg) => this.AppendMessage(msg));
        }

        private void AppendMessage(string message)
        {
            var filePath = ConfigurationManager.AppSettings["LogFileDirectory"];
            var fileName = Path.ChangeExtension(Path.Combine(filePath, "LogFile" + DateTime.Now.ToShortDateString().Replace("/", "")), "txt");
            this.fileWrapper.AppendAllText(fileName, message);
        }
    }
}
