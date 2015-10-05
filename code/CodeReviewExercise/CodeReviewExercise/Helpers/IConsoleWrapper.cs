namespace CodeReviewExercise.Helpers
{
    public interface IConsoleWrapper
    {
        void WriteLine(string format, params object[] args);

        void SetErrorForegroundColor();

        void SetWarningForegroundColor();

        void SetMessageForegroundColor();

        void ResetColor();
    }
}
