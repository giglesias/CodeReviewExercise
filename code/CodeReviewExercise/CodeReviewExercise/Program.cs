namespace CodeReviewExercise
{
    using System;
    using System.Configuration;

    public class Program
    {
        public static void Main(string[] args)
        {
            var message = args[0];
            var type = (LogType)Enum.Parse(typeof(LogType), args[1]);

            var logSources = ConfigurationManager.AppSettings["LogSources"].Split(',');
            var logVerbosity = (LogType)Enum.Parse(typeof(LogType), ConfigurationManager.AppSettings["LogVerbosity"]);

            foreach (var logSource in logSources)
            {
                try
                {
                    var logger = Activator.CreateInstance(Type.GetType(LogSourcesMapper.SourceMapping[logSource.Trim()]), logVerbosity) as Logger;

                    switch (type)
                    {
                        case LogType.Error:
                            logger.LogError(message);
                            break;
                        case LogType.Warning:
                            logger.LogWarning(message);
                            break;
                        default:
                            logger.LogMessage(message);
                            break;
                    }
                }
                catch (Exception ex)
                {
                    var errorMessage = string.Format("Invalid configuration. Logger '{0}' is not supported.", logSource);
                    throw new Exception(errorMessage, ex);
                }
            }

            Console.ReadKey();
        }
    }
}
