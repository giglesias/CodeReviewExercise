namespace CodeReviewExercise.Repositories
{
    using System.Data.Entity;
    using CodeReviewExercise.Models;

    public class LogsContext : DbContext
    {
        private const string ConnectionString = "LogDbConnectionString";

        public LogsContext()
            : base(ConnectionString)
        {
        }

        public virtual DbSet<LogValue> LogValues { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<LogValue>().ToTable("LogValues");
        }
    }
}
