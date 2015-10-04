namespace CodeReviewExercise.Helpers
{
    using System;

    public class ConsoleWrapper : IConsoleWrapper
    {
        public void WriteLine(string format, params object[] args)
        {
            Console.WriteLine(format, args);
        }

        public void SetErrorForegroundColor()
        {
            Console.ForegroundColor = ConsoleColor.Red;
        }

        public void SetWarningForegroundColor()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
        }

        public void SetMessageForegroundColor()
        {
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}
