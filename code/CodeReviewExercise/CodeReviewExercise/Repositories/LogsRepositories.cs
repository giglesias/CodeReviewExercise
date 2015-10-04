namespace CodeReviewExercise.Repositories
{
    using CodeReviewExercise.Models;

    public class LogsRepository : ILogsRepository
    {
        private readonly LogsContext context;

        public LogsRepository()
            : this(new LogsContext())
        {
        }

        public LogsRepository(LogsContext context)
        {
            this.context = context;
        }

        public LogValue AddLogValue(LogValue logValue)
        {
            var createdLogValue = this.context.LogValues.Add(logValue);
            this.context.SaveChanges();
            return createdLogValue;
        }
    }
}
