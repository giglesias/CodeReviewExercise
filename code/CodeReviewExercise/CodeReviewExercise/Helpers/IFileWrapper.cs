namespace CodeReviewExercise.Helpers
{
    public interface IFileWrapper
    {
        void AppendAllText(string path, string contents);
    }
}