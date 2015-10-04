namespace CodeReviewExercise.Repositories
{
    using CodeReviewExercise.Models;

    public interface ILogsRepository
    {
        LogValue AddLogValue(LogValue logValue);
    }
}
