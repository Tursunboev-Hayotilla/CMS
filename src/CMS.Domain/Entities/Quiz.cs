namespace CMS.Domain.Entities
{
    public class Quiz
    {
        public Guid Id { get; set; }
        public string Question { get; set; }
        public  string OptionsA { get; set; }
        public  string OptionsB { get; set; }
        public  string OptionsC { get; set; }
        public string? OptionsD { get; set; }
        public  char CorrectAnswer { get; set; }
        public string? DescriptionPhotoPath { get; set; }
        public Guid? LessonId { get; set; }
        public Guid? SubjectId { get; set; }

        // Virtualarni UseCaseslarda ishlatmatmaymiz
        public virtual Lesson Lesson { get; set; }
        public virtual Subject Subject{ get; set; }
    }
}
