namespace CodeReviewExercise.Helpers
{
    using System.IO;

    public class FileWrapper : IFileWrapper
    {
        public void AppendAllText(string path, string contents)
        {
            File.AppendAllText(path, contents);
        }
    }
}
