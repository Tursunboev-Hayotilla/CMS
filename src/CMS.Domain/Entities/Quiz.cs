namespace CMS.Domain.Entities
{
    public class Quiz
    {
        public Guid Id { get; set; }
        public string Question { get; set; }
        public string Options1 { get; set; }
        public string Options2 { get; set; }
        public string Options3 { get; set; }
        public string Options4 { get; set; }
        public string CorrectAnswear { get; set; }
        public string DescriptionPhotoPath { get; set; }
        public object LessonId { get; set; }
        public object SubjectId { get; set; }
    }
}
