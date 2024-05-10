namespace CMS.Domain.Entities
{
    public class Quiz
    {
        public Guid Id { get; set; }
        public required string Question { get; set; }
        public required string Options1 { get; set; }
        public required string Options2 { get; set; }
        public required string Options3 { get; set; }
        public string? Options4 { get; set; }
        public required string CorrectAnswear { get; set; }
        public string? DescriptionPhotoPath { get; set; }
        public virtual Lesson LessonId { get; set; }
        public virtual Subject SubjectId { get; set; }
    }
}
