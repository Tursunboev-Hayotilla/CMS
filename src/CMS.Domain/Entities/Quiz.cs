namespace CMS.Domain.Entities
{
    public class Quiz
    {
        public Guid Id { get; set; }
        public required string Question { get; set; }
        public required string OptionsA { get; set; }
        public required string OptionsB { get; set; }
        public required string OptionsC { get; set; }
        public string? OptionsD { get; set; }
        public required string CorrectAnswer { get; set; }
        public string? DescriptionPhotoPath { get; set; }
        public Guid LessonId { get; set; }
        public Guid SubjectId { get; set; }

        // Virtualarni UseCaseslarda ishlatmatmaymiz
        public virtual Lesson Lesson { get; set; }
        public virtual Subject Subject{ get; set; }
    }
}
