namespace CodeReviewExercise.Models
{
    using System;

    public class LogValue
    {
        public Guid Id { get; set; }

        public string Message { get; set; }

        public LogType Type { get; set; }
    }
}
