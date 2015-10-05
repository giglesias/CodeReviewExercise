namespace CodeReviewExercise
{
    using System;
    using System.Configuration;
    using System.Linq;

    public class Program
    {
        public static void Main(string[] args)
        {
            if (!ValidateConsoleParameters(args))
            {
                Console.WriteLine("Invalid parameters...");
                Console.WriteLine();
                Console.WriteLine("Usage: CodeReviewExercise.exe \"{message-to-log}\" \"{message-verbosity-type-number}\"");
                Console.WriteLine();
                Console.WriteLine("Verbosity types: Error (1), Warning (2), Message (3)");
                Console.ReadKey();
                Environment.Exit(0);
            }

            var message = args[0];
            var type = (LogType)Enum.Parse(typeof(LogType), args[1]);

            var logSourcesSetting = ConfigurationManager.AppSettings["LogSources"];
            var logSources = logSourcesSetting.Split(',');
            Console.WriteLine("The following loggers were found in App.config: {0}", logSourcesSetting);
            var logVerbosity = (LogType)Enum.Parse(typeof(LogType), ConfigurationManager.AppSettings["LogVerbosity"]);

            foreach (var logSource in logSources)
            {
                try
                {
                    var logger = Activator.CreateInstance(Type.GetType(LogSourcesMapper.SourceMapping[logSource.Trim()]), logVerbosity) as JobLogger;

                    switch (type)
                    {
                        case LogType.Error:
                            Console.WriteLine("Logging error with message '{0}' and logger '{1}'", message, logSource.Trim());
                            logger.LogError(message);
                            break;
                        case LogType.Warning:
                            Console.WriteLine("Logging warning with message '{0}' and logger '{1}'", message, logSource.Trim());
                            logger.LogWarning(message);
                            break;
                        default:
                            Console.WriteLine("Logging message '{0}' with logger '{1}'", message, logSource.Trim());
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

            Console.WriteLine("Done!");
            Console.ReadKey();
        }

        private static bool ValidateConsoleParameters(string[] args)
        {
            int num;
            return args.Count() == 2 && int.TryParse(args[1], out num);
        }
    }
}
